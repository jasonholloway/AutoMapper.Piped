using System;

namespace Materialize.ProjectionTypes
{
    interface IProjectedMemberSpec
    {
        string Name { get; }
        Type ProjectedType { get; }
    }
}
