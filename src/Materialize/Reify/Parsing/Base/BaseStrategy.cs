using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;


namespace Materialize.Reify.Parsing.Unaries
{
    class BaseStrategy<TElem>
        : IParseStrategy
    {
        public bool FiltersFetchedSet {
            get { return false; }
        }

        public Parser CreateParser() {

            //delegate to mapping here


            throw new NotImplementedException();
        }
    }
}
