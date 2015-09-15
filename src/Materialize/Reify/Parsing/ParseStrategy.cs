using System;

namespace Materialize.Reify.Parsing
{
    abstract class ParseStrategy<TElem>
        : IParseStrategy
    {
        public abstract IModifier CreateModifier(IModifier upstreamMod);
    }

}
