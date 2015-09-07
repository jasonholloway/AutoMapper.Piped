using AutoMapper;
using Materialize.SourceRegimes;
using Materialize.ProjectionTypes;
using Materialize.Reify.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify.Mapping
{
    class Context
    {
        public ISourceRegime QueryRegime { get; private set; }
        public TypeVector TypeVector { get; private set; }
        public MapStrategyProvider StrategySource { get; private set; }
        public InputSpecSource InputSpecs { get; private set; }
        public ProjectedTypeBuilder ProjectedTypeBuilder { get; private set; }
        
        Lazy<TypeMap> _lzTypeMap;

        public TypeMap TypeMap {
            get { return _lzTypeMap.Value; }
        }

        public Context(
            ISourceRegime queryRegime,
            TypeVector typeVector,
            MapStrategyProvider source, 
            InputSpecSource inputSpecs, 
            ProjectedTypeBuilder projTypeBuilder) 
        {
            QueryRegime = queryRegime;
            TypeVector = typeVector;
            StrategySource = source;
            InputSpecs = inputSpecs;
            ProjectedTypeBuilder = projTypeBuilder;

            _lzTypeMap = new Lazy<TypeMap>(
                                () => Mapper.FindTypeMapFor(TypeVector.SourceType, TypeVector.DestType));
        }
        
    }
}
