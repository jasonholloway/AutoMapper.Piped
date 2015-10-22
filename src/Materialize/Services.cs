using Materialize.CollectionFactories;
using Materialize.Dependencies;
using Materialize.Tuples;
using Materialize.Reify2;
using Materialize.Reify2.Mapping;
using Materialize.Reify2.Parsing;
using Materialize.Reify2.Rebasing;
using Materialize.SourceRegimes;
using Materialize.TypeMaps;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Materialize
{ 
    internal static class MaterializeServices 
    {
        static IServiceRegistry _registry;

        static MaterializeServices() {
            Init();
        }


        public static void Init(Action<IServiceRegistry> fnConfig = null) {
            if(_registry != null) {
                _registry.Dispose();
            }

            _registry = new ServiceRegistry();

            DefaultConfig(_registry);

            if(fnConfig != null) {
                fnConfig(_registry);
            }
        }
        

        public static TService Resolve<TService>() {
            return _registry.Resolve<TService>();
        }



        static void DefaultConfig(IServiceRegistry x) 
        {
            x.Register<IServiceRegistry>(_registry);
            x.Register<ITypeMapProvider, CachedTypeMapProvider>();
            x.Register<ISourceRegimeProvider, SourceRegimeProvider>();
            x.Register<IProjectedTypeBuilder, ProjectedTypeBuilder>();
            x.Register<ICollectionFactorySource, CollectionFactorySource>();

            x.Register<IMapRuleRegistry, MapRuleRegistry>();
            x.Register<IMapStrategySource, MapStrategySource>();

            x.Register<ParseStrategySource>();
            x.Register<ParseRuleRegistry>();
            x.Register<ParserFactory>();
            
            x.Register<ReifiableFactory>();

            x.Register(new MaterializeOptions() {
                                AllowClientSideFiltering = false,
                                MappingEngine = AutoMapper.Mapper.Engine
                            });
        }
    }
}
