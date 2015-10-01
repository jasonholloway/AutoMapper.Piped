using System;
using System.Collections.Generic;
using System.Linq;

namespace Materialize
{
    class MaterializeException : Exception
    {
        public MaterializeException(string message)
            : base(message) { }

        public MaterializeException(string message, Exception innerException) 
            : base(message, innerException) { }
        
    }
}
