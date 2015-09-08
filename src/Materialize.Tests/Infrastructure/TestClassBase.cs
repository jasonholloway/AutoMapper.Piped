using AutoMapper;
using Materialize.Dependencies;
using Materialize.Reify.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Tests.Infrastructure
{
    abstract class TestClassBase
    {
        protected void InitMapper(Action<IConfiguration> fnConfig = null) {
            Mapper.Initialize(fnConfig ?? (_ => { }));
        }

        protected void InitServices(Action<IServiceRegistry> fnConfig = null) {
            Services.Init(fnConfig ?? (_ => { }));
        }
    }
}
