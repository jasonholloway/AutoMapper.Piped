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
            public override ReifyExecutor Compile() {
                throw new InvalidOperationException();
            }
        }

                

        static Scheme Schematize(Scheme prevScheme, SourceTransition trans) 
        {
            return new QueryScheme() {
                            Exp = trans.CanonicalExpression,
                            ParamMap = prevScheme.ParamMap
                        };
        }





        static MethodInfo _mExecutorInvoke = Refl.GetMethod<ReifyExecutor>(r => r.Invoke(null, null));


        static Scheme Schematize(Scheme prevScheme, FetchTransition fetch) 
        {         
            var lzUpstreamExecutor = new Lazy<ReifyExecutor>(() => prevScheme.Compile());
            
            var castType = prevScheme.IsQueryable
                                ? typeof(IEnumerable<>).MakeGenericType(prevScheme.OutType.GetEnumerableElementType())
                                : prevScheme.OutType;

            var scheme = new ClientScheme();

            scheme.ParamMap = prevScheme.ParamMap;

            scheme.Exp = Expression.Convert(
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









        static Scheme Schematize(Scheme scheme, ProjectionTransition trans) 
        {
            var method = scheme.IsQueryable 
                            ? QyMethods.Select 
                            : EnMethods.Select;

            scheme.Exp = Expression.Call(
                                method.MakeGenericMethod(trans.InElemType, trans.OutElemType),
                                scheme.Exp,
                                trans.Projection
                                );
            
            return scheme;
        }

                


        



        static Scheme Schematize(Scheme scheme, FilterTransition trans) 
        {
            var method = scheme.IsQueryable 
                            ? QyMethods.Where 
                            : EnMethods.Where;

            scheme.Exp = Expression.Call(
                                method.MakeGenericMethod(trans.ElemType),
                                scheme.Exp,
                                trans.Predicate);

            return scheme;
        }
        




        static Scheme Schematize(Scheme scheme, PartitionTransition trans) 
        {
            MethodInfo mPartition = null;

            switch(trans.PartitionType) {
                case PartitionType.Skip:
                    mPartition = scheme.IsQueryable ? QyMethods.Skip : EnMethods.Skip;
                    break;
                case PartitionType.Take:
                    mPartition = scheme.IsQueryable ? QyMethods.Take : EnMethods.Take;
                    break;
            }
            
            scheme.Exp = Expression.Call(
                                    mPartition.MakeGenericMethod(scheme.OutType.GetEnumerableElementType()),
                                    scheme.Exp,
                                    trans.CountExpression);

            return scheme;
        }
        



        static Scheme Schematize(Scheme scheme, ElementTransition trans) 
        {
            MethodInfo method = null;

            switch(trans.ElementTransitionType) {
                case ElementTransitionType.ElementAt:
                    method = scheme.IsQueryable
                                ? (trans.ReturnsDefault ? QyMethods.ElementAtOrDefault : QyMethods.ElementAt)
                                : (trans.ReturnsDefault ? EnMethods.ElementAtOrDefault : EnMethods.ElementAt);

                    method = method.MakeGenericMethod(scheme.OutType.GetEnumerableElementType());

                    scheme.Exp = Expression.Call(
                                            method,
                                            scheme.Exp,
                                            trans.IndexExpression);
                    return scheme;

                case ElementTransitionType.First:
                    method = scheme.IsQueryable
                                ? (trans.ReturnsDefault ? QyMethods.FirstOrDefault : QyMethods.First)
                                : (trans.ReturnsDefault ? EnMethods.FirstOrDefault : EnMethods.First);
                    break;

                case ElementTransitionType.Last:
                    method = scheme.IsQueryable
                                ? (trans.ReturnsDefault ? QyMethods.LastOrDefault : QyMethods.Last)
                                : (trans.ReturnsDefault ? EnMethods.LastOrDefault : EnMethods.Last);
                    break;

                case ElementTransitionType.Single:
                    method = scheme.IsQueryable
                                ? (trans.ReturnsDefault ? QyMethods.SingleOrDefault : QyMethods.Single)
                                : (trans.ReturnsDefault ? EnMethods.SingleOrDefault : EnMethods.Single);
                    break;
            }

            method = method.MakeGenericMethod(scheme.OutType.GetEnumerableElementType());

            scheme.Exp = Expression.Call(
                                    method,
                                    scheme.Exp);

            return scheme;
        }

        

    }



}
