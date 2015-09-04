using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify.Mapping
{
    [Obsolete]
    struct TypeSpec
    {
        public readonly Type Type;
        public readonly IMemberSpec[] Members;
        
        public TypeSpec(Type type, IEnumerable<IMemberSpec> members) {
            Type = type;            
            Members = members.ToArray();
        }
    }





    [Obsolete]
    interface IMemberSpec
    {
        MemberInfo MemberInfo { get; }
        object Read(object tuple);
    }
    
    [Obsolete]
    interface IMemberSpec<TType, TValue>
        : IMemberSpec
    {
        TValue Read(TType tuple);
    }

    [Obsolete]
    struct MemberSpec<TType, TValue>
        : IMemberSpec<TType, TValue>
    {
        readonly MemberInfo _memberInfo;
        readonly Func<TType, TValue> _fnRead;

        public MemberSpec(MemberInfo memberInfo, Func<TType, TValue> fnRead) {
            _memberInfo = memberInfo;
            _fnRead = fnRead;
        }
        
        public MemberInfo MemberInfo {
            get { return _memberInfo; }
        }

        public object Read(object obj) {
            return _fnRead((TType)obj);
        }

        public TValue Read(TType obj) {
            return _fnRead(obj);
        }
    }

}
