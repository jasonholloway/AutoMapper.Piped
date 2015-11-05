using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Materialize.Types
{
    internal struct TypeArg
    {
        public readonly Type ParamType;
        public readonly Type ArgType;

        public TypeArg(Type paramType, Type argType) {
            Debug.Assert(paramType.IsGenericParameter,
                    $"Can't construct {nameof(TypeArg)} with non-parameter {nameof(paramType)}!");

            //Debug.Assert(argType.MatchAgainst(paramType).Success,
            //        $"Can't construct {nameof(TypeArg)} with {nameof(argType)} that doesn't match supplied {nameof(paramType)}!");

            ParamType = paramType;
            ArgType = argType;
        }
    }

}
