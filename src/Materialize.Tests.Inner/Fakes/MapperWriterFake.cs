using Materialize.Reify2.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Materialize.Tests.Inner.Fakes
{
    class MapperWriterFake : IMapperWriter
    {
        IMapStrategy _strat;


        public MapperWriterFake(IMapStrategy strategy) {
            _strat = strategy;
        }


        public Type DestType {
            get { return _strat.TransformedType; }
        }

        public Type FetchType {
            get { return _strat.FetchType; }
        }

        public Type SourceType {
            get { return _strat.SourceType; }
        }

        public Expression ClientRewrite(Expression ex) {
            return Expression.Default(DestType);
        }

        public Expression ServerRewrite(Expression ex) {
            return Expression.Default(FetchType);
        }
    }
}
