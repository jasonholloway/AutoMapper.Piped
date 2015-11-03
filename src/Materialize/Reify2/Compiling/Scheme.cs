using Materialize.Reify2.Parameterize;
using Materialize.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Materialize.Types;

namespace Materialize.Reify2.Compiling
{

    internal delegate object ReifyExecutor(IQueryProvider provider, ArgMap argMap);


    internal abstract class Scheme
    {
        public ParamMap ParamMap { get; set; }

        public abstract Type OutType { get; }

        public abstract ReifyExecutor Compile();
    }



    class QueryScheme : Scheme
    {
        public Expression Query { get; set; }

        public override Type OutType {
            get { return Query.Type; }
        }

        public override ReifyExecutor Compile() {
            return (prov, args) => {             
                var ex = Query.Replace(
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
        public Expression Body { get; set; }

        public ParameterExpression ProviderParam { get; private set; }
        public ParameterExpression ArgMapParam { get; private set; }


        public ClientScheme() {
            ProviderParam = Expression.Parameter(typeof(IQueryProvider));
            ArgMapParam = Expression.Parameter(typeof(ArgMap));
        }


        public override Type OutType {
            get { return Body.Type; }
        }


        public override ReifyExecutor Compile() {
            var exLambda = Expression.Lambda<ReifyExecutor>(
                                        Body.Type.IsValueType 
                                            ? Expression.Convert(Body, typeof(object)) //boxing needed???
                                            : Body,
                                        ProviderParam,
                                        ArgMapParam);

            return exLambda.Compile();
        }
    }



}
