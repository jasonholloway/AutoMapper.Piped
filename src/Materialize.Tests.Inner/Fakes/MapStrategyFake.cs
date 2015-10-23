using Materialize.Reify2.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Materialize.Reify2.Rebasing;

namespace Materialize.Tests.Inner.Fakes
{
    class MapStrategyFake : IMapStrategy
    {
        MapContext _ctx;

        public MapStrategyFake(MapContext ctx) {
            _ctx = ctx;
        }

        public bool FetchesToTuple {
            get {
                throw new NotImplementedException();
            }
        }

        public Type FetchType {
            get { return typeof(object); }
        }

        public bool RewritesExpression {
            get {
                return true;
            }
        }

        public Type SourceType {
            get { return _ctx.TypeVector.SourceType; }
        }

        public Type TransformedType {
            get { return _ctx.TypeVector.DestType; }
        }

        public IMapperWriter CreateWriter() {
            return new MapperWriterFake(this);
        }

        public IRebaseStrategy GetRootRebaseStrategy(RootVector roots) {
            throw new NotImplementedException();
        }

        //...

    }
}
