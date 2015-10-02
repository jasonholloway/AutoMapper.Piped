using System;
using System.Collections.Generic;
using System.Linq;

namespace Materialize
{
    public class MaterializationException : Exception
    {
        public MaterializationException(string message)
            : base(message) { }

        public MaterializationException(string message, Exception innerException) 
            : base(message, innerException) { }
        
    }


    public class UnableToRebaseException : MaterializationException
    {
        public UnableToRebaseException(string message)
            : base(message) { }
    }


}
