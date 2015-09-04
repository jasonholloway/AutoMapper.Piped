using AutoMapper;
using Materialize.Projection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify.Mapping.PropertyMaps
{
    struct PropMapSpec : IProjectedMemberSpec
    {
        public readonly PropertyMap PropMap;
        public readonly IStrategy Strategy;

        public PropMapSpec(PropertyMap propMap, IStrategy strategy) {
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
