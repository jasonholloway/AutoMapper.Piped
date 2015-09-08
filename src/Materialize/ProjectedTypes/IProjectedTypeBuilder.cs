using System.Collections.Generic;

namespace Materialize.ProjectedTypes
{
    internal interface IProjectedTypeBuilder
    {
        ProjectedTypeInfo<TMemberSpec> BuildType<TMemberSpec>(IEnumerable<TMemberSpec> specs)
            where TMemberSpec : IProjectedMemberSpec;
    }
}
