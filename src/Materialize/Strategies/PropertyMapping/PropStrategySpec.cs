using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Strategies.PropertyMapping
{
    struct PropStrategySpec
    {
        public readonly PropertyMap PropMap;
        public readonly IReifyStrategy Strategy;

        public PropStrategySpec(PropertyMap propMap, IReifyStrategy strategy) {
            PropMap = propMap;
            Strategy = strategy;
        }
    }

}
