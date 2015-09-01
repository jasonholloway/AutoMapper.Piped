using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Strategies.PropertyMapping
{
    struct PropMapStrategySpec : IProjectedMemberSpec
    {
        public readonly PropertyMap PropMap;
        public readonly IReifyStrategy Strategy;

        public PropMapStrategySpec(PropertyMap propMap, IReifyStrategy strategy) {
            PropMap = propMap;
            Strategy = strategy;
        }
        
        string IProjectedMemberSpec.Name {
            get { return PropMap.SourceMember.Name; }
        }

        Type IProjectedMemberSpec.ProjectedType {
            get { return Strategy.ProjectedType; }
        }
    }

}
