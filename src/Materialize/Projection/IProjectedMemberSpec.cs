using System;

namespace Materialize.Projection
{
    interface IProjectedMemberSpec
    {
        string Name { get; }
        Type ProjectedType { get; }
    }
}
