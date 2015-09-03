using System.Reflection;

namespace Materialize.Projection
{
    struct ProjectedMemberInfo<TMemberSpec>
        where TMemberSpec : IProjectedMemberSpec
    {
        public readonly TMemberSpec Spec;
        public readonly FieldInfo ProjectedField;

        public ProjectedMemberInfo(TMemberSpec spec, FieldInfo projField) {
            Spec = spec;
            ProjectedField = projField;
        }
    }

}
