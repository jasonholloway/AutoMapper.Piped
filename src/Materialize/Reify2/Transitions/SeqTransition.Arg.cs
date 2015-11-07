using System.Collections.Generic;
using System;
using Materialize.Types;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify2.Transitions
{
    internal abstract partial class SeqTransition
    {


        protected enum ArgStatus
        {
            Empty,
            Matched,
            Forced,
            Errored
        }


        protected class Arg
        {
            static TypeArg[] _emptyTypeArgs = new TypeArg[0];

            Mode _mode;
            TypeArgHub _typeArgHub;
            IReadOnlyList<TypeArg> _ownedTypeArgs = _emptyTypeArgs;

            public Type TypePattern { get; private set; }
            public ArgStatus Status { get; private set; } = ArgStatus.Empty;


            public Arg(Mode mode, TypeArgHub typeArgHub, Type pattern) {
                _mode = mode;
                _typeArgHub = typeArgHub;
                TypePattern = pattern;
            }


            public Expression Value { get; private set; }


            public ArgStatus SetValue(Expression ex) {
                RevokeTypeArgs();

                Value = ex;

                if(Value == null) {
                    Status = ArgStatus.Empty;
                }
                else {
                    var match = Value.Type.MatchAgainst(TypePattern);

                    if(match.Success) {
                        Status = ArgStatus.Matched;
                    }
                    else {                        
                        if(Value.NodeType == ExpressionType.Quote) {
                            var forced = ((UnaryExpression)Value).Operand;
                            var forcedMatch = forced.Type.MatchAgainst(TypePattern);

                            if(forcedMatch.Success) {
                                Value = forced;
                                match = forcedMatch;
                                Status = ArgStatus.Forced;
                            }
                            else {
                                Status = ArgStatus.Errored;
                            }
                        }
                        else {
                            Status = ArgStatus.Errored;
                        }
                    }

                    if(Status == ArgStatus.Matched || Status == ArgStatus.Forced) {
                        RegisterTypeArgs(match.TypeArgs);
                        //Type args are asserted on each change
                    }
                }

                _mode.InvalidateStatus();

                return Status;
            }





            void RevokeTypeArgs() {
                foreach(var typeArg in _ownedTypeArgs) {
                    _typeArgHub.Revoke(typeArg, this);
                }

                _ownedTypeArgs = _emptyTypeArgs;
            }


            void RegisterTypeArgs(IEnumerable<TypeArg> typeArgs) {
                foreach(var typeArg in typeArgs) {
                    _typeArgHub.Register(typeArg, this);
                }

                _ownedTypeArgs = typeArgs.ToArray();

                //SHOULD RETURN TYPEARG CONFLICT STATUS...
                //...or maybe each registration should return a status
            }

        }



        protected class ArgValue
        {
            string _name;
            Arg[] _argSpecs;
            Expression _exp;

            public ArgValue(string name, Arg[] argSpecs) {
                _name = name;
                _argSpecs = argSpecs;
            }

            public Expression Expression {
                get { return _exp; }
                set {
                    if(value != _exp) {
                        _exp = value;

                        var statuses = _argSpecs.Select(a => a.SetValue(_exp))
                                                .ToArray(); //forces enumeration

                        if(statuses.All(s => s == ArgStatus.Errored)) {
                            throw new InvalidOperationException($"Arg {_name} set to invalid value!");
                        }
                    }
                }
            }
        }




    }
}
