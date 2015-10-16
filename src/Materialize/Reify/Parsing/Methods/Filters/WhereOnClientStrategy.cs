using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Materialize.Reify.Parsing.Methods.Filters
{
    class WhereOnClientStrategy<TElem> 
        : MethodStrategyBase<IEnumerable<TElem>, IEnumerable<TElem>>
    {
        
        public WhereOnClientStrategy(IParseStrategy upstreamStrategy)
            : base(upstreamStrategy) { }
               

        public override bool FiltersFetchedSet {
            get { return true; }
        }


        protected override IModifier Parse(IModifier upstreamMod, MethodCallExpression exSubject) 
        {
            var exPredicate = (Expression<Func<TElem, bool>>)((UnaryExpression)exSubject.Arguments[1]).Operand;


            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //BELOW COMPILATION TO BE DONE BY STRATEGY IN A CACHE-FRIENDLY MANNER!!!
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!


            var fnPredicate = exPredicate.Compile(); //Nasty: no way to cache? Only if entire tree were cached further up...
                                                        //Nah: we could (and should) have a predicate-only auxiliary cache.                                                    
                                                        //specially for little compilations...

                                                        //even better would be a stripping out of non-value-type constants,
                                                        //to be replaced with arguments. This would leave us with the essential
                                                        //shape of the predicate: much easier to cache.

                                                        //Names of parameters should also be stripped for the same reason.

            return new Modifier(upstreamMod, fnPredicate);
        }
                       

        class Modifier : ParseModifier<IEnumerable<TElem>, IEnumerable<TElem>>
        {
            Func<TElem, bool> _fnPredicate;

            public Modifier(IModifier upstreamMod, Func<TElem, bool> fnPredicate)
                : base(upstreamMod) 
            {
                _fnPredicate = fnPredicate;
            }
            

            protected override Expression Rewrite(Expression exQuery) {
                return UpstreamRewrite(exQuery); //no rewrite, as nothing to do on server
            }


            protected override IEnumerable<TElem> Transform(object fetched) 
            {                
                var transformed = UpstreamTransform(fetched);
                return transformed.Where(_fnPredicate);
            }

        }

    }
}
