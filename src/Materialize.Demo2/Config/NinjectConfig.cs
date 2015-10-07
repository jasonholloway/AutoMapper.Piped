using Materialize.Demo2.QueryInfo;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Materialize.Demo2.Config
{
    public static class NinjectConfig
    {
        public static IKernel CreateRootKernel() {
            var kernel = new StandardKernel();

            kernel.Bind<QueryInfoSource>().ToSelf().InSingletonScope();
            
            return kernel;
        }        
    }    
}