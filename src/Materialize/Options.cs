using Materialize.SourceRegimes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Materialize
{
    public class Options
    {
        /// <summary>
        /// Emplaces a user-defined source regime, overriding the usual detection process
        /// </summary>
        public ISourceRegime SourceRegime { get; set; }

        public IMappingEngine MappingEngine { get; set; }

        public ISnooper Snooper { get; set; }

        public bool? AllowClientSideFiltering { get; set; }


        internal Options MergeWith(Options baseOptions) {
            return new Options() {
                SourceRegime = SourceRegime ?? baseOptions.SourceRegime,
                MappingEngine = MappingEngine ?? baseOptions.MappingEngine,
                Snooper = Snooper ?? baseOptions.Snooper,
                AllowClientSideFiltering = AllowClientSideFiltering ?? baseOptions.AllowClientSideFiltering
            };
        }

    }
}
