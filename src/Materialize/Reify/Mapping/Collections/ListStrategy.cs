using Materialize.Reify.Modifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify.Mapping.Direct
{
    //if we come up against an enumeration in the source, then we should try projecting the same 
    //to an enumeration ALTHOUGH if no translation needed, then no need to project!

    //No need to project? then DirectRule should have already picked it up.


    //But if AutoMapper is expected to intervene via TypeMap even though the resultant type doesn't
    //differ - e.g. it is the same to the same, or to a compatible subclass - then PropertyMapRule etc
    //won't kick in in the event of a list, as these rules are sensitive only to the whole type. 
    //DirectRule, being compatible, will usurp em.

    //After direct TypeMap detecting, we should immediately try the same on the enumeration element, if available.
    //That is, if enumeration, then we should try projecting these. DirectRule would thereafter be the last chance.
    //
    //BEWARE STRINGS - are enumerations, but shouldn't be treated as such.

    





    class ListStrategy<TOrig, TOrigElem, TDest, TDestElem>
        : StrategyBase<TOrig, TDest>
    {
        MapContext _ctx;
        IMapStrategy _elemStrategy;

        Type _tFetched;

        public ListStrategy(MapContext ctx, IMapStrategy elemStrategy) {
            _ctx = ctx;
            _elemStrategy = elemStrategy;

            _tFetched = typeof(IEnumerable<>)
                                .MakeGenericType(_elemStrategy.FetchedType);
        }
        
        public override Type FetchedType {
            get { return _tFetched; }
        }
        
        public override IModifier CreateModifier() {
            return new Mapper(_ctx, _elemStrategy);
        }
                


        class Mapper : MapperModifier<TOrig, TDest>
        {
            MapContext _ctx;
            IMapStrategy _elemStrategy;

            public Mapper(MapContext ctx, IMapStrategy elemStrategy) {
                _ctx = ctx;
                _elemStrategy = elemStrategy;
            }

            protected override Expression RewriteSingle(Expression exOrig) {
                return exOrig;
            }

            protected override TDest TransformSingle(TDest orig) {
                return orig;
            }
        }
    }


}
