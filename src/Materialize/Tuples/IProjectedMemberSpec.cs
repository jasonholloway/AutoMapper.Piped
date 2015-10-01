using System;

namespace Materialize.Tuples
{
    internal interface IProjectedMemberSpec
    {
        string Name { get; }
        Type ProjectedType { get; }
    }
}
