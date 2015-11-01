using Materialize.Reify2.Transitions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using Materialize.Reify2.Parameterize;
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
            return new QueryScheme() {
                            Query = trans.CanonicalExpression,
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

            var scheme = new ClientScheme();

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





        static Scheme Schematize(QueryScheme scheme, ProjectionTransition trans) 
        {
            scheme.Query = Expression.Call(
                                QyMethods.Select.MakeGenericMethod(trans.InElemType, trans.OutElemType),
                                scheme.Query,
                                trans.Projection
                                );
            
            return scheme;
        }






        
        static Scheme Schematize(ClientScheme scheme, ProjectionTransition trans) 
        {
            scheme.Body = Expression.Call(
                                EnMethods.Select.MakeGenericMethod(trans.InElemType, trans.OutElemType),
                                scheme.Body,
                                InjectIncidentalFetchers(scheme, trans.Projection)
                                );
            
            return scheme;
        }



        



        static Scheme Schematize(QueryScheme scheme, FilterTransition trans) 
        {
            scheme.Query = Expression.Call(
                                QyMethods.Where.MakeGenericMethod(trans.ElemType),
                                scheme.Query,
                                trans.Predicate);

            return scheme;
        }





        static Scheme Schematize(ClientScheme scheme, FilterTransition trans) 
        {
            scheme.Body = Expression.Call(
                                EnMethods.Where.MakeGenericMethod(trans.ElemType),
                                scheme.Body,
                                InjectIncidentalFetchers(scheme, trans.Predicate)
                                );

            return scheme;
        }






        static Scheme Schematize(QueryScheme scheme, PartitionTransition trans) 
        {
            MethodInfo mPartition = null;

            switch(trans.PartitionType) {
                case PartitionType.Skip:
                    mPartition = QyMethods.Skip;
                    break;
                case PartitionType.Take:
                    mPartition = QyMethods.Take;
                    break;
            }
            
            scheme.Query = Expression.Call(
                                    mPartition.MakeGenericMethod(scheme.OutType.GetEnumerableElementType()),
                                    scheme.Query,
                                    trans.CountExpression);

            return scheme;
        }




        static Scheme Schematize(ClientScheme scheme, PartitionTransition trans) 
        {
            MethodInfo mPartition = null;

            switch(trans.PartitionType) {
                case PartitionType.Skip:
                    mPartition = EnMethods.Skip;
                    break;
                case PartitionType.Take:
                    mPartition = EnMethods.Take;
                    break;
            }

            scheme.Body = Expression.Call(
                                    mPartition.MakeGenericMethod(scheme.OutType.GetEnumerableElementType()),
                                    scheme.Body,
                                    InjectIncidentalFetchers(scheme, trans.CountExpression));

            return scheme;
        }






        static MethodInfo _mGetValueWith = Refl.GetMethod<ArgMap>(m => m.GetValueWith(_ => null));


        static Expression InjectIncidentalFetchers(ClientScheme scheme, Expression exSubject) 
        {
            //replace all constant-parameters with fetching code, to acquire incidental values from the passed ArgMap
            return exSubject.Replace(
                        x => x is ConstantExpression,
                        x => {
                            var accessor = scheme.ParamMap.TryGetAccessor(x);
                            
                            if(accessor == null) {
                                return x; //not all constants are paramterized - some are produced by the mapping layer, and should be left in place
                            }

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
