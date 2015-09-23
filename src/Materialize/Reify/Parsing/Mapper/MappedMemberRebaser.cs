using Materialize.Reify.Rebasing2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Linq.Expressions;

namespace Materialize.Reify.Parsing.Mapper
{
    class MappedMemberRebaser : IMemberRebaser
    {
        public Expression Rebase(Rebased instance, MemberInfo member) {
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //Scratched together as prototype
            

            return Expression.MakeMemberAccess(
                                        instance.Expression,
                                        instance.TypeVector.DestType.GetMember(member.Name).Single());

            //return Rebased.Active(exRebased, 
            //                        ((PropertyInfo)member).PropertyType,
            //                        exRebased.Type);
                        
            //throw new NotImplementedException();
        }        
    }
}
