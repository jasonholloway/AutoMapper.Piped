using System;

namespace Materialize.ProjectedTypes
{
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

}
