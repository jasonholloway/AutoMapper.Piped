using Materialize.Reify2;
using Materialize.Reify2.Mapping;
using Materialize.SourceRegimes;
using Materialize.Tests.Inner.Fakes;
using Materialize.Types;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Tests.Inner
{
    [TestFixture]
    class ReifiableTests
    {      



        [Test]
        public void ReifiablePassesSourceThrough() 
        {
            var mapperWriterSource = new MapperSource(new MapStrategySourceFake());
                        
            var data = Enumerable.Range(0, 100);

            var qySource = data.AsQueryable();
            
            var reifiable = new Reifiable<int>(qySource, new TolerantRegimeProvider(), mapperWriterSource, new MaterializeOptions());
            
            var result = reifiable.Execute<IEnumerable<int>>(qySource.Expression);

            Assert.That(result, Is.EquivalentTo(data));
        }


        [Test]
        public void ReifiableMapsSimply() {
            throw new NotImplementedException();
        }






    }
}
