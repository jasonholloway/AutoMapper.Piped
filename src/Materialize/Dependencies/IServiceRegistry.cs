using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Dependencies
{
    internal interface IServiceRegistry : IDisposable
    {
        void Register(Type tService);
        void Register<TService>();

        void Register<TService, TImpl>() where TImpl : TService;
        void Register(Type tService, Type tImpl);

        void Register(Type tService, object instance);
        void Register<TService>(TService instance);

        object Resolve(Type tService);
        TService Resolve<TService>();
    }
}
