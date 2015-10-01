using AutoMapper;
using Materialize.Types;

namespace Materialize.TypeMaps
{
    internal interface ITypeMapProvider
    {
        TypeMap FindTypeMap(TypeVector types);
    }
}
