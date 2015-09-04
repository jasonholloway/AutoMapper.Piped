using AutoMapper;
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

        protected void Initialize(Action<IConfiguration> fnConfig) {
            StrategySource.Default.Reset();
            Mapper.Initialize(fnConfig);
        }


    }
}
