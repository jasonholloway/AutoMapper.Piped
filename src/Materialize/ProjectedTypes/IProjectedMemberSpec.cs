using System;

namespace Materialize.ProjectedTypes
{
    internal interface IProjectedMemberSpec
    {
        string Name { get; }
        Type ProjectedType { get; }
    }
}
