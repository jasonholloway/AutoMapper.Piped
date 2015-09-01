using JH.DynaType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Strategies
{

    interface IProjectedMemberSpec
    {
        string Name { get; }
        Type ProjectedType { get; }
    }



    struct ProjectedTypeInfo<TMemberSpec>
        where TMemberSpec : IProjectedMemberSpec
    {
        public readonly Type Type;
        public readonly ProjectedMemberInfo<TMemberSpec>[] Members;

        public ProjectedTypeInfo(Type type, ProjectedMemberInfo<TMemberSpec>[] members) {
            Type = type;
            Members = members;
        }
    }



    class ProjectedTypeBuilder
    {
        public ProjectedTypeInfo<TSpec> BuildType<TSpec>(IEnumerable<TSpec> specs)
            where TSpec : IProjectedMemberSpec
        {
            var type = DynaType.Design(x => {
                foreach(var spec in specs) {
                    x.Field(spec.Name, spec.ProjectedType)
                        .MakePublic();
                }
            });

            var memberInfos = specs.Select(spec => new ProjectedMemberInfo<TSpec>(
                                                                    spec,
                                                                    type.GetField(spec.Name))
                                                                ).ToArray();

            return new ProjectedTypeInfo<TSpec>(type, memberInfos);
        }

    }   
    
    
     

}
