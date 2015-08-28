using AutoMapper;
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
        public ReifySpec Spec { get; private set; }

        Lazy<TypeMap> _lzTypeMap;

        public TypeMap TypeMap {
            get { return _lzTypeMap.Value; }
        }


        public ReifyContext(ReifierSource source, ReifySpec spec) {
            Source = source;
            Spec = spec;

            _lzTypeMap = new Lazy<TypeMap>(
                                () => Mapper.FindTypeMapFor(Spec.SourceType, Spec.DestType));
        }

    }
}
