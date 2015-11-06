using System.Linq.Expressions;
using System.Collections.Generic;
using System;
using Materialize.Types;
using System.Diagnostics;
using System.Linq;

namespace Materialize.Reify2.Transitions
{
    internal abstract partial class SeqTransition
    {        

        protected class Arg
        {
            TypeArgHub _typeArgHub;
            IReadOnlyList<TypeArg> _ownedTypeArgs = new TypeArg[0];
            Expression _exp;

            public Type TypePattern { get; private set; }


            public Arg(Type typePattern, TypeArgHub typeArgHub) {
                TypePattern = typePattern;
                _typeArgHub = typeArgHub;
            }


            public Expression Expression {
                get {
                    return _exp;
                }
                set {
                    if(value == null) {
                        if(_exp == null) return;

                        foreach(var ownedTypeArg in _ownedTypeArgs) {
                            _typeArgHub.Revoke(ownedTypeArg, this);
                        }

                        _ownedTypeArgs = new TypeArg[0];
                    }
                    else {
                        var match = value.Type.MatchAgainst(TypePattern);

                        Debug.Assert(match.Success,
                                        $"Attempted to set {nameof(Arg)} of type-pattern {TypePattern.GetNiceName()} with {nameof(Expression)} of incorrectly-formed type {value.Type.GetNiceName()}!");

                        foreach(var ownedTypeArg in _ownedTypeArgs) {
                            _typeArgHub.Revoke(ownedTypeArg, this);
                        }

                        _ownedTypeArgs = match.TypeArgs;

                        foreach(var typeArg in _ownedTypeArgs) {
                            _typeArgHub.Register(typeArg, this);
                        }
                    }

                    _exp = value;
                }
            }

        }

    }        
}
