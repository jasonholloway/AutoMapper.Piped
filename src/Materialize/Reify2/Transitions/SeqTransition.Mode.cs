using System.Collections.Generic;
using System;
using Materialize.Types;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Linq.Expressions;

namespace Materialize.Reify2.Transitions
{
    internal abstract partial class SeqTransition
    {




        protected enum ModeStatus
        {
            Incomplete,
            Matched,
            Forced,
            Errored
        }

        protected class Mode
        {
            public MethodInfo Method { get; private set; }
            public TypeArgHub TypeArgHub { get; private set; }
            public Arg[] Args { get; private set; }

            public Mode(MethodInfo method, Type[] typeParams, Type[] paramTypes) {
                Method = method;
                TypeArgHub = new TypeArgHub(this, typeParams);
                Args = paramTypes.Select(t => new Arg(this, TypeArgHub, t)).ToArray();
            }



            public MethodCallExpression GetCallExpression() {
                return Expression.Call(
                                GetMethod(),
                                Args.Select(a => a.Value).ToArray());
            }

            public MethodInfo GetMethod() {
                return Method.IsGenericMethodDefinition
                        ? Method.MakeGenericMethod(TypeArgHub.GetTypeArgs().Select(a => a.ArgType).ToArray())
                        : Method;
            }


            ModeStatus? _currentStatus = null;

            public ModeStatus GetStatus() {
                if(_currentStatus == null) {
                    var s = ModeStatus.Matched;

                    foreach(var a in Args) {
                        switch(a.Status) {
                            case ArgStatus.Errored:
                                return ModeStatus.Errored;

                            case ArgStatus.Empty:
                                s = ModeStatus.Incomplete;
                                break;

                            case ArgStatus.Forced:
                                if(s == ModeStatus.Matched) {
                                    s = ModeStatus.Forced;
                                }
                                break;
                        }
                    }

                    if(s == ModeStatus.Matched) {
                        s = TypeArgHub.GetTypeArgs().Select(a => a.ParamType).SequenceEqual(TypeArgHub.TypeParams)
                                ? ModeStatus.Matched
                                : ModeStatus.Incomplete;
                    }

                    _currentStatus = s;
                }

                return (ModeStatus)_currentStatus;
            }


            public void InvalidateStatus() {
                _currentStatus = null;
            }

        }



    }
}
