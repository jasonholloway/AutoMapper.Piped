using Materialize.Reify2.Transitions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Materialize.Reify2.Params;
using System.Reflection;
using Materialize.Types;
using Materialize.Expressions;

namespace Materialize.Reify2.Compiling
{   

    internal static class Schematizer {

        public static Scheme Schematize(IEnumerable<ITransition> trans, ParamMap paramMap) {
            Debug.Assert(trans.Any());

            return trans.Aggregate(
                            (Scheme)new BlankScheme() { ParamMap = paramMap }, 
                            (scheme, transition) => Schematize((dynamic)scheme, (dynamic)transition));
        }



        class BlankScheme : Scheme
        {
            public override Type OutType {
                get { return typeof(void); }
            }

            public override ReifyExecutor Compile() {
                return (_, __) => null;
            }
        }

                

        static Scheme Schematize(Scheme prevScheme, SourceTransition trans) 
        {
            return new QuerySideScheme() {
                            QueryExpression = trans.CanonicalExpression,
                            ParamMap = prevScheme.ParamMap
                        };
        }





        static MethodInfo _mExecutorInvoke = Refl.GetMethod<ReifyExecutor>(r => r.Invoke(null, null));


        static Scheme Schematize(Scheme prevScheme, FetchTransition fetch) 
        {         
            var lzUpstreamExecutor = new Lazy<ReifyExecutor>(() => prevScheme.Compile());
            
            var castType = prevScheme.OutType.IsQueryable()
                            ? typeof(IEnumerable<>).MakeGenericType(prevScheme.OutType.GetEnumerableElementType())
                            : prevScheme.OutType;

            var scheme = new ClientSideScheme();

            scheme.ParamMap = prevScheme.ParamMap;

            scheme.Body = Expression.Convert(
                                Expression.Call(
                                        Expression.MakeMemberAccess(
                                                Expression.Constant(lzUpstreamExecutor), 
                                                typeof(Lazy<ReifyExecutor>).GetProperty("Value")),
                                        _mExecutorInvoke,
                                        scheme.ProviderParam,
                                        scheme.ArgMapParam),
                                castType);
            
            return scheme;
        }





        static Scheme Schematize(QuerySideScheme scheme, ProjectionTransition trans) 
        {
            scheme.QueryExpression = Expression.Call(
                                            QueryableMethods.Select.MakeGenericMethod(trans.InElemType, trans.OutElemType),
                                            scheme.QueryExpression,
                                            trans.Projection
                                            );
            
            return scheme;
        }






        static MethodInfo _mGetValueWith = Refl.GetMethod<ArgMap>(m => m.GetValueWith(_ => null));


        static Scheme Schematize(ClientSideScheme scheme, ProjectionTransition trans) 
        {
            scheme.Body = Expression.Call(
                                EnumerableMethods.Select.MakeGenericMethod(trans.InElemType, trans.OutElemType),
                                scheme.Body,
                                EmplaceIncidentals(scheme, trans.Projection)
                                );
            
            return scheme;
        }



        



        static Scheme Schematize(QuerySideScheme scheme, FilterTransition trans) 
        {
            scheme.QueryExpression = Expression.Call(
                                            QueryableMethods.Where.MakeGenericMethod(trans.ElemType),
                                            scheme.QueryExpression,
                                            trans.Predicate);

            return scheme;
        }





        static Scheme Schematize(ClientSideScheme scheme, FilterTransition trans) 
        {
            scheme.Body = Expression.Call(
                                EnumerableMethods.Where.MakeGenericMethod(trans.ElemType),
                                scheme.Body,
                                EmplaceIncidentals(scheme, trans.Predicate)
                                );

            return scheme;
        }








        static Expression EmplaceIncidentals(ClientSideScheme scheme, Expression exSubject) {
            //replace all constant-parameters with fetching code, to acquire incidental values from the passed ArgMap
            return exSubject.Replace(
                        x => x is ConstantExpression,
                        x => {
                            var accessor = scheme.ParamMap.TryGetAccessor(x);
                            Debug.Assert(accessor != null);

                            return Expression.Convert(
                                        Expression.Call(
                                                scheme.ArgMapParam,
                                                _mGetValueWith,
                                                Expression.Constant(accessor)),
                                        x.Type
                                        );
                        });
        }






    }



}
