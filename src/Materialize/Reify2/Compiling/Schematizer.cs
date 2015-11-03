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
using Materialize.SequenceMethods;

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
            var m = SeqMethods.Select;
            
            scheme.Exp = Expression.Call(
                                (scheme.IsQueryable ? m.Qy : m.En).MakeGenericMethod(trans.InElemType, trans.OutElemType),
                                scheme.Exp,
                                trans.Projection
                                );
            
            return scheme;
        }

                


        



        static Scheme Schematize(Scheme scheme, FilterTransition trans) 
        {
            var m = SeqMethods.Where;
            
            scheme.Exp = Expression.Call(
                                (scheme.IsQueryable ? m.Qy : m.En).MakeGenericMethod(trans.ElemType),
                                scheme.Exp,
                                trans.Predicate);

            return scheme;
        }
        




        static Scheme Schematize(Scheme scheme, PartitionTransition trans) 
        {
            SeqMethod m = null;

            switch(trans.PartitionType) {
                case PartitionType.Skip:
                    m = SeqMethods.Skip;
                    break;

                case PartitionType.Take:
                    m = SeqMethods.Take;
                    break;
            }
            
            scheme.Exp = Expression.Call(
                            (scheme.IsQueryable ? m.Qy : m.En).MakeGenericMethod(scheme.OutType.GetEnumerableElementType()),
                            scheme.Exp,
                            trans.CountExpression);

            return scheme;
        }
        



        static Scheme Schematize(Scheme scheme, ElementTransition trans) 
        {
            SeqMethod m = null;

            var args = new List<Expression>(2);
            args.Add(scheme.Exp);

            switch(trans.ElementTransitionType) {
                case ElementTransitionType.ElementAt:
                    m = trans.ReturnsDefault ? SeqMethods.ElementAtOrDefault : SeqMethods.ElementAt;
                    args.Add(trans.IndexExpression);
                    break;

                case ElementTransitionType.First:
                    m = trans.ReturnsDefault ? SeqMethods.FirstOrDefault : SeqMethods.First;
                    break;

                case ElementTransitionType.Last:
                    m = trans.ReturnsDefault ? SeqMethods.LastOrDefault : SeqMethods.Last;
                    break;

                case ElementTransitionType.Single:
                    m = trans.ReturnsDefault ? SeqMethods.SingleOrDefault : SeqMethods.Single;
                    break;
            }
            
            scheme.Exp = Expression.Call(
                            (scheme.IsQueryable ? m.Qy : m.En).MakeGenericMethod(scheme.OutType.GetEnumerableElementType()),                                    
                            args.ToArray());

            return scheme;
        }

        
        static Scheme Schematize(Scheme scheme, QuantifierTransition trans) 
        {
            SeqMethod m = null;
            var args = new List<Expression>(2);
            args.Add(scheme.Exp);

            switch(trans.QuantifierTransitionType) {
                case QuantifierTransitionType.Any:
                    m = SeqMethods.Any;
                    break;

                case QuantifierTransitionType.All:
                    m = SeqMethods.All;
                    args.Add(trans.Predicate);
                    break;

                default:
                    throw new NotImplementedException();
            }

            scheme.Exp = Expression.Call(
                                (scheme.IsQueryable ? m.Qy : m.En).MakeGenericMethod(scheme.OutType.GetEnumerableElementType()),
                                args);

            return scheme;
        }

    }



}
