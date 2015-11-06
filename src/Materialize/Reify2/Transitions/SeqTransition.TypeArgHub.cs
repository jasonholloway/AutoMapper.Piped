using System.Collections.Generic;
using System;
using Materialize.Types;
using System.Diagnostics;
using System.Linq;

namespace Materialize.Reify2.Transitions
{
    internal abstract partial class SeqTransition
    {

        protected class TypeArgHub
        {
            Mode _mode;
            ISet<Type> _typeParamHash;
            List<Entry> _reg;

            public IEnumerable<Type> TypeParams { get; private set; }


            public TypeArgHub(Mode mode, IEnumerable<Type> typeParams) 
            {
                _mode = mode;
                TypeParams = typeParams.ToArray();
                _typeParamHash = new HashSet<Type>(typeParams);
                _reg = new List<Entry>();
            }

           
            public void Register(TypeArg typeArg, object owner) {
                Debug.Assert(
                        _typeParamHash.Contains(typeArg.ParamType),
                        $"Passed {nameof(typeArg.ParamType)} isn't expected by {nameof(TypeArgHub)}!");

                _reg.Add(new Entry(owner, typeArg));

                Debug.Assert(
                        _reg.Where(e => e.Owner != null).Select(e => e.TypeArg).GroupBy(a => a.ParamType).All(g => g.Distinct().Count() == 1),
                        $"A {nameof(TypeArg)} conflict has arisen in {nameof(TypeArgHub)}!");

                _mode.InvalidateStatus();
            }


            public void Revoke(TypeArg typeArg, object owner) {
                var entry = new Entry(owner, typeArg);
                _reg.RemoveAll(e => e.Equals(entry));

                _mode.InvalidateStatus();
            }


            public IEnumerable<TypeArg> GetTypeArgs() {
                var d = _reg.Select(e => e.TypeArg)
                                .GroupBy(a => a.ParamType)
                                .ToDictionary(g => g.Key, g => g.Last());

                foreach(var typeParam in TypeParams) {
                    TypeArg typeArg;

                    if(d.TryGetValue(typeParam, out typeArg)) {
                        yield return typeArg;
                    }
                }
            }


            struct Entry
            {
                public readonly object Owner;
                public readonly TypeArg TypeArg;

                public Entry(object owner, TypeArg typeArg) {
                    Owner = owner;
                    TypeArg = typeArg;
                }
            }

        }
        
                
    }        
}
