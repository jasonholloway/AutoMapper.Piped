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

namespace Materialize.Reify2.Compiling
{   

    internal static class Schematizer {

        public static Scheme Schematize(IEnumerable<ITransition> trans) {
            Debug.Assert(trans.Any());

            return trans.Aggregate(
                            (Scheme)new BlankScheme(), 
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

                

        static Scheme Schematize(Scheme scheme, SourceTransition op) 
        {
            return new QuerySideScheme() {
                            QueryExpression = op.CanonicalExpression
                        };
        }





        static MethodInfo _mExecutorInvoke = Refl.GetMethod<ReifyExecutor>(r => r.Invoke(null, null));

        static Scheme Schematize(Scheme prevScheme, FetchTransition op) 
        {            
            var lzUpstreamExecutor = new Lazy<ReifyExecutor>(() => prevScheme.Compile());
            
            var castType = prevScheme.OutType.IsQueryable()
                            ? typeof(IEnumerable<>).MakeGenericType(prevScheme.OutType.GetEnumerableElementType())
                            : prevScheme.OutType;

            var scheme = new ClientSideScheme();

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

    }

       
        
}
