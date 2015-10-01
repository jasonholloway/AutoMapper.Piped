using System.Collections.Generic;

namespace Materialize.Tuples
{
    internal interface IProjectedTypeBuilder
    {
        ProjectedTypeInfo<TMemberSpec> BuildType<TMemberSpec>(IEnumerable<TMemberSpec> specs)
            where TMemberSpec : IProjectedMemberSpec;
    }
}
