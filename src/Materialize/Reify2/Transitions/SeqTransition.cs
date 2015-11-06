using Materialize.SequenceMethods;
using System.Linq.Expressions;
using System.Collections.Generic;
using Materialize.Types;
using System.Reflection;
using System;
using System.Linq;

namespace Materialize.Reify2.Transitions
{
    internal abstract partial class SeqTransition : Transition
    {
        protected TypeArgHub _typeArgHub;


        public abstract SeqMethod SeqMethod { get; }

        public abstract IEnumerable<Expression> Args { get; }
        

        public IEnumerable<TypeArg> GetTypeArgs() {
            return _typeArgHub.GetTypeArgs();
        }


        protected Mode[] _modes;
        
        Mode GetCurrentMode() {
            return _modes.FirstOrDefault(m => m.Args.All(a => a.Status == ArgStatus.Matched));
        }

        

        protected class Mode
        {
            public MethodInfo MethodDef { get; private set; }
            public TypeArgHub TypeArgHub { get; private set; }
            public ArgSpec[] Args { get; private set; }

            public Mode(MethodInfo methodDef, Type[] typeParams, ArgSpec[] args) {
                MethodDef = methodDef;
                TypeArgHub = new TypeArgHub(typeParams);    //typeParams passed separately to allow static cacheing
                Args = args;
            }
        }






        protected enum ArgStatus
        {
            Empty,
            Matched,
            Errored
        }


        protected class ArgSpec
        {
            static TypeArg[] _emptyTypeArgs = new TypeArg[0];

            Type _argType;
            TypeArgHub _typeArgHub;
            IReadOnlyList<TypeArg> _ownedTypeArgs = _emptyTypeArgs;
            
            public Type TypePattern { get; private set; }
            public ArgStatus Status { get; private set; } = ArgStatus.Empty;
            
            public ArgSpec(TypeArgHub typeArgHub, Type pattern) {
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
            public ArgSpec[] ArgSpecs { get; private set; }

            Expression _exp;

            public Expression Expression {
                get {
                    return _exp;
                }
                set {
                    if(value != _exp) {
                        _exp = value;

                        foreach(var argSpec in ArgSpecs) {
                            argSpec.ArgType = _exp?.Type;
                        }
                    }
                }
            }


            public ArgValue(ArgSpec[] argSpecs) {
                ArgSpecs = argSpecs;
            }
        }


        
    }        
       

}
