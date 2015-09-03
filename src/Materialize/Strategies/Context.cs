﻿using AutoMapper;
using Materialize.Projection;
using Materialize.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Strategies
{
    class Context
    {
        public TypeVector TypeVector { get; private set; }
        public StrategySource StrategySource { get; private set; }
        public InputSpecSource InputSpecs { get; private set; }
        public ProjectedTypeBuilder ProjectedTypeBuilder { get; private set; }

        Lazy<TypeMap> _lzTypeMap;

        public TypeMap TypeMap {
            get { return _lzTypeMap.Value; }
        }
        
        public Context(
            TypeVector typeVector,
            StrategySource source, 
            InputSpecSource inputSpecs, 
            ProjectedTypeBuilder projTypeBuilder) 
        {
            TypeVector = typeVector;
            StrategySource = source;
            InputSpecs = inputSpecs;
            ProjectedTypeBuilder = projTypeBuilder;

            _lzTypeMap = new Lazy<TypeMap>(
                                () => Mapper.FindTypeMapFor(TypeVector.SourceType, TypeVector.DestType));
        }
        
    }
}
