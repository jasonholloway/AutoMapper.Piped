using AutoMapper;

namespace Materialize.TypeMaps
{
    internal interface ITypeMapProvider
    {
        TypeMap FindTypeMap(TypeVector types);
    }
}
