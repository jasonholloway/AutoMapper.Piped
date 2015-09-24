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

        //Mapping strategies need to register themselves...

        //or maybe each MapStrategy could be asked to rebase the passed subject

        //as is, RebaseStrategizer does half of this itself.

        //in rebasing however, maybe we could burrow back down the stack, with each layer responsible
        //for *some* rebasing. This is an established idea of course.

        







        public MappedMemberRebaseStrategizer() {

        }
        

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
