using AutoMapper;
using Materialize.Tuples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify2.Mapping.PropertyMaps
{
    struct PropMapSpec : IProjectedMemberSpec
    {
        public readonly PropertyMap PropMap;
        public readonly IMapStrategy Strategy;

        public PropMapSpec(PropertyMap propMap, IMapStrategy strategy) {
            PropMap = propMap;
            Strategy = strategy;
        }
        
        string IProjectedMemberSpec.Name {
            get { return PropMap.SourceMember.Name; }
        }

        Type IProjectedMemberSpec.ProjectedType {
            get { return Strategy.FetchType; }
        }
    }

}
