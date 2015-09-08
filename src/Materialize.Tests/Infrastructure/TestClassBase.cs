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
        protected void Initialize(
            Action<IConfiguration> fnAutoMapperConfig,
            Action<IServiceRegistry> fnServicesConfig = null) 
        {
            Services.Init(fnServicesConfig);
            Mapper.Initialize(fnAutoMapperConfig);
        }

    }
}
