using System;
using System.Collections.Generic;
using System.Linq;
using Materialize.SourceRegimes;
using Materialize.Reify2.Mapping;

namespace Materialize.Reify2
{
    internal class ReifiableFactory
    {
        ISourceRegimeProvider _regimeSource;
        MapperWriterSource _mapperWriterSource;
        MaterializeOptions _baseOptions;

        public ReifiableFactory(
            ISourceRegimeProvider regimeSource,
            MapperWriterSource mapperWriterSource,
            MaterializeOptions baseOptions) 
        {
            _regimeSource = regimeSource;
            _mapperWriterSource = mapperWriterSource;
            _baseOptions = baseOptions;
        }


        public IReifiable CreateReifiable(IQueryable qySource, MaterializeOptions options) 
        {
            return (IReifiable)Activator.CreateInstance(
                                            typeof(Reifiable<>).MakeGenericType(qySource.ElementType),
                                            qySource,
                                            _regimeSource,
                                            _mapperWriterSource,
                                            options.MergeWith(_baseOptions));
        }

    }
}
