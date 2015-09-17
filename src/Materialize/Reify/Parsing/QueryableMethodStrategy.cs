using System;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Parsing
{
    //Quietly does all the upstream-delegation-via-the-parser

    abstract class QueryableMethodStrategy
        : IParseStrategy
    {
        public virtual bool FiltersFetchedSet {
            get { return false; }
        }
        
        public abstract IModifier Parse(Expression exSubject);
        


        //Parser IParser.CreateCallParser(Parser parser) {
        //    return (ex) => {
        //        var exUpstream = ex.Arguments.First();
        //        var upstreamMod = parser.Parse(exUpstream);

        //        return Parse(upstreamMod, ex);
        //    };            
        //}

    }

}
