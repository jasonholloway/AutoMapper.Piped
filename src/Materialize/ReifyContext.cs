using AutoMapper;
using Materialize.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize
{
    class ReifyContext
    {
        public ReifierSource Source { get; private set; }
        public InputSpecSource InputSpecs { get; private set; }
        public ProjectedTypeBuilder ProjectedTypeBuilder { get; private set; }
        public ReifySpec Spec { get; private set; }

        Lazy<TypeMap> _lzTypeMap;

        public TypeMap TypeMap {
            get { return _lzTypeMap.Value; }
        }



        public ReifyContext(
                    ReifierSource source, 
                    InputSpecSource inputSpecs, 
                    ProjectedTypeBuilder projTypeBuilder, 
                    ReifySpec spec) 
                {
                    Source = source;
                    InputSpecs = inputSpecs;
                    ProjectedTypeBuilder = projTypeBuilder;
                    Spec = spec;

                    _lzTypeMap = new Lazy<TypeMap>(
                                        () => Mapper.FindTypeMapFor(Spec.SourceType, Spec.DestType));
                }

    }
}
