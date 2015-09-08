using Materialize.Dependencies.LightInject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Materialize.Dependencies
{
    class ServiceRegistry : IServiceRegistry
    {
        IServiceContainer _cont = new ServiceContainer();

        public void Register(Type tService) {
            _cont.Register(tService, new PerContainerLifetime());
        }

        public void Register<TService>() {
            this.Register(typeof(TService));
        }

        public void Register(Type tService, Type tImpl) {
            _cont.Register(tService, tImpl, new PerContainerLifetime());
        }

        public void Register<TService, TImpl>() where TImpl : TService {
            this.Register(typeof(TService), typeof(TImpl));
        }

        public void Register(Type tService, object instance) {
            throw new NotImplementedException(); //LightInject makes this a bit nasty - ignore for time being
        }

        public void Register<TService>(TService instance) {
            _cont.Register<TService>(_ => instance, new PerContainerLifetime());
        }
        
        public object Resolve(Type tService) {
            return _cont.GetInstance(tService);
        }

        public TService Resolve<TService>() {
            return _cont.GetInstance<TService>();
        }

        public void Dispose() {
            if(_cont != null) _cont.Dispose();
        }
    }

}
