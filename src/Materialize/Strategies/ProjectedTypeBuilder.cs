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
        string ProjectedName { get; }
        Type ProjectedType { get; }
    }



    class ProjectedTypeBuilder
    {
        public ProjectedMemberInfo<TSpec>[] BuildType<TSpec>(IEnumerable<TSpec> specs)
            where TSpec : IProjectedMemberSpec
        {
            var type = DynaType.Design(x => {
                foreach(var spec in specs) {
                    x.Field(spec.ProjectedName, spec.ProjectedType)
                        .MakePublic();
                }
            });

            return specs.Select(spec => new ProjectedMemberInfo<TSpec>(
                                                                    spec,
                                                                    type.GetField(spec.ProjectedName))
                                                                ).ToArray();
        }

    }   
    
    
     

}
