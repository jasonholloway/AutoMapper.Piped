using System;
using System.Collections.Generic;
using System.Linq;

namespace Materialize
{
    public class MaterializationException : Exception
    {
        public MaterializationException(string message)
            : base(message) { }

        public MaterializationException(string format, params object[] args)
            : base(string.Format(format, args)) { }


        public MaterializationException(string message, Exception innerException) 
            : base(message, innerException) { }
        
    }

    public class ParseException : MaterializationException
    {
        public ParseException(string message)
            : base(message) { }

        public ParseException(string format, params object[] args)
            : base(string.Format(format, args)) { }


        public ParseException(string message, Exception innerException)
            : base(message, innerException) { }

    }



    public class RebaseException : MaterializationException
    {
        public RebaseException(string message)
            : base(message) { }

        public RebaseException(string message, Exception innerException)
            : base(message, innerException) { }

    }

    public class RebaseRootException : RebaseException
    {
        public RebaseRootException(string message)
            : base(message) { }

        public RebaseRootException(string pattern, params object[] args)
            : this(string.Format(pattern, args)) { }
    }

}
