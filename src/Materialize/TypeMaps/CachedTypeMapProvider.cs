using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Materialize.Types;

namespace Materialize.TypeMaps
{
    //THIS IS A BIT NASTY...
    //unless one unique service were created per map request.
    //but as services are injected into quasi-static rules this isn't the case...
    

    class CachedTypeMapProvider
        : ITypeMapProvider
    {
        static TypeVectorEqualityComparer _typeVectorComparer = TypeVectorEqualityComparer.Default;

        object _sync = new object();
        TypeVector _lastTypeVector;
        TypeMap _lastResult = null;
        
        public TypeMap FindTypeMap(TypeVector types) {
            lock(_sync) {
                if(_typeVectorComparer.Equals(types, _lastTypeVector)) {
                    return _lastResult;
                }
                else {
                    _lastTypeVector = types;
                    _lastResult = Mapper.FindTypeMapFor(types.SourceType, types.DestType);
                    return _lastResult;
                }
            }
        }
    }
}
