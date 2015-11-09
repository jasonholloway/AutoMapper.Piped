using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Materialize.Monitor.QueryInfo
{
    public class IDSource
    {
        int _nextID = 1;
        object _sync = new object();

        public int GetNextID() {
            lock(_sync) {
                return _nextID++;
            }
        }

    }
}