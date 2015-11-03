using Materialize.Reify2.Parameterize;
using Materialize.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Materialize.Types;
using System.Reflection;

namespace Materialize.Reify2.Compiling
{

    internal delegate object ReifyExecutor(IQueryProvider provider, ArgMap argMap);


    internal abstract class Scheme
    {
        public ParamMap ParamMap { get; set; }
        public Expression Exp { get; set; }
        
        public abstract ReifyExecutor Compile();

        public Type OutType {
            get { return Exp?.Type; }
        }

        public bool IsQueryable {
            get { return OutType.IsQueryable(); }
        }
    }



    class QueryScheme : Scheme
    {
        public override ReifyExecutor Compile() {
            return (prov, args) => {             
                var ex = Exp.Replace(
                            x => x is ConstantExpression,
                            x => args.GetIncidentalFor(x));

                return ex.Type.IsQueryable() 
                            ? prov.CreateQuery(ex) 
                            : prov.Execute(ex);                
            };            
        }
    }
    

    class ClientScheme : Scheme
    {
        public ParameterExpression ProviderParam { get; private set; }
        public ParameterExpression ArgMapParam { get; private set; }


        public ClientScheme() {
            ProviderParam = Expression.Parameter(typeof(IQueryProvider));
            ArgMapParam = Expression.Parameter(typeof(ArgMap));
        }

        public override ReifyExecutor Compile() 
        {
            var exBody = InjectIncidentalFetchers(Exp);

            var exLambda = Expression.Lambda<ReifyExecutor>(
                                        exBody.Type.IsValueType 
                                            ? Expression.Convert(exBody, typeof(object))
                                            : exBody,
                                        ProviderParam,
                                        ArgMapParam);

            return exLambda.Compile();
        }

        


        static MethodInfo _mGetValueWith = Refl.GetMethod<ArgMap>(m => m.GetValueWith(_ => null));


        Expression InjectIncidentalFetchers(Expression exSubject) {
            return exSubject.Replace(
                        x => x is ConstantExpression,
                        x => {
                            var accessor = ParamMap.TryGetAccessor(x);

                            if(accessor == null) {
                                return x; //not all constants are parameterized - some are produced by the mapping layer, and should be left in place
                            }

                            return Expression.Convert(
                                        Expression.Call(
                                            ArgMapParam,
                                            _mGetValueWith,
                                            Expression.Constant(accessor)),
                                        x.Type
                                        );
                        });
        }



    }



}
