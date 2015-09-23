using Materialize.Reify.Rebasing2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Linq.Expressions;

namespace Materialize.Reify.Parsing.Mapper
{
    class MappedMemberRebaseStrategizer : IMemberRebaseStrategizer
    {
        public IRebaseStrategy GetStrategy(IRebaseStrategy strInst, MemberInfo member) {

            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //Scratched-together mock-up
            
            var rebasedMember = strInst.TypeVector.DestType.GetMember(member.Name).Single();

            return new RebaseStrategy<MemberExpression>(
                                new TypeVector(
                                        Refl.GetMemberType(member),
                                        Refl.GetMemberType(rebasedMember)),
                                strInst.Roots,
                                (x) => Expression.MakeMemberAccess(
                                                        strInst.Rebase(x.Expression),
                                                        rebasedMember
                                                        ));
        }
                
    }
}
