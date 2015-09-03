using JH.DynaType;
using System.Collections.Generic;
using System.Linq;

namespace Materialize.Projection
{
    class ProjectedTypeBuilder
    {
        public ProjectedTypeInfo<TMemberSpec> BuildType<TMemberSpec>(IEnumerable<TMemberSpec> specs)
            where TMemberSpec : IProjectedMemberSpec
        {
            //Should ultimately just string along built-in Tuples for this
            //...

            var type = DynaType.Design(x => {
                foreach(var spec in specs) {
                    x.Field(spec.Name, spec.ProjectedType)
                        .MakePublic();
                }
            });

            var memberInfos = specs.Select(spec => new ProjectedMemberInfo<TMemberSpec>(
                                                                                    spec,
                                                                                    type.GetField(spec.Name))
                                                                                ).ToArray();

            return new ProjectedTypeInfo<TMemberSpec>(type, memberInfos);
        }

    }   
    
    
     

}
