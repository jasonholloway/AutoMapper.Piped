using Materialize.SequenceMethods;
using System.Linq.Expressions;
using System.Collections.Generic;
using Materialize.Types;
using System.Reflection;
using System;
using System.Linq;
using System.Diagnostics;

namespace Materialize.Reify2.Transitions
{
    internal abstract partial class SeqTransition : Transition
    {
        protected Mode[] _modes;

        public abstract SeqMethod SeqMethod { get; }
        public abstract IEnumerable<Expression> Args { get; }
        
        public MethodInfo GetMethod() {
            var method = _modes.Select(m => m.GetMethod())
                                .FirstOrDefault(m => m != null);

            if(method == null) {
                throw new InvalidOperationException("No valid method could be summoned given the current arguments and type-arguments!");
            }

            return method;
        }
                       


        protected class Mode
        {
            public MethodInfo Method { get; private set; }
            public TypeArgHub TypeArgHub { get; private set; }
            public Arg[] Args { get; private set; }

            public Mode(MethodInfo method, Type[] typeParams, Type[] paramTypes) {
                Method = method;
                TypeArgHub = new TypeArgHub(typeParams);
                Args = paramTypes.Select(t => new Arg(TypeArgHub, t)).ToArray();
            }

            public MethodInfo GetMethod() {
                var typeArgs = TypeArgHub.GetTypeArgs();

                bool allArgsMatched = Args.All(a => a.Status == ArgStatus.Matched);
                bool allTypeArgsGiven = typeArgs.Select(a => a.ParamType).SequenceEqual(TypeArgHub.TypeParams);

                if(allArgsMatched && allTypeArgsGiven) {
                    return Method.IsGenericMethodDefinition
                            ? Method.MakeGenericMethod(TypeArgHub.GetTypeArgs().Select(a => a.ArgType).ToArray())
                            : Method;
                }

                return null;
            }
        }






        protected enum ArgStatus
        {
            Empty,
            Matched,
            Errored
        }


        protected class Arg
        {
            static TypeArg[] _emptyTypeArgs = new TypeArg[0];

            Type _argType;
            TypeArgHub _typeArgHub;
            IReadOnlyList<TypeArg> _ownedTypeArgs = _emptyTypeArgs;
            
            public Type TypePattern { get; private set; }
            public ArgStatus Status { get; private set; } = ArgStatus.Empty;
            
            public Arg(TypeArgHub typeArgHub, Type pattern) {
                _typeArgHub = typeArgHub;
                TypePattern = pattern;
            }

            public Type ArgType {
                get { return _argType; }
                set {
                    foreach(var typeArg in _ownedTypeArgs) {
                        _typeArgHub.Revoke(typeArg, this);
                    }

                    _argType = value;

                    if(_argType == null) {
                        Status = ArgStatus.Empty;
                        _ownedTypeArgs = _emptyTypeArgs;
                    }
                    else {
                        var match = _argType.MatchAgainst(TypePattern);

                        Status = match.Success 
                                    ? ArgStatus.Matched 
                                    : ArgStatus.Errored;

                        foreach(var typeArg in match.TypeArgs) {
                            _typeArgHub.Register(typeArg, this);
                        }

                        _ownedTypeArgs = match.TypeArgs;
                    }
                }

            }
                        
        }



        protected class ArgValue
        {
            Arg[] _argSpecs;
            Expression _exp;

            public ArgValue(Arg[] argSpecs) {
                _argSpecs = argSpecs;
            }
            
            public Expression Expression {
                get { return _exp; }
                set {
                    if(value != _exp) {
                        _exp = value;

                        foreach(var argSpec in _argSpecs) {
                            argSpec.ArgType = _exp?.Type;
                        }
                    }
                }
            }            
        }
        
        
    }        
       

}
