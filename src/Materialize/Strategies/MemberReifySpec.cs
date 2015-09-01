using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Strategies
{

    

    class AClass<T>
    {
        public T Thing { get; set; }
    }


    struct MemberReifySpec
    {

        //Members needing separate, self-centred reification only arise from PropertyMapping, right?
        //And as such, they always have targets. They are effectively propertymaps with strategies.

        //But limited CustomMappings require only certain source members to be projected too, without
        //a corresponding destinationtype. Commonality is in having a sourcemember. Such population
        //of projections does not however require separate strategies!

        //We need PropMapSpecs with strategies, sourcemembers and destmembers.
        //and SourceMemberSpecs(?) specialised for custom mapping via intermediate type.

        //Each kind of member spec is unique to its strategy-realm. Yet each should expose same interface for
        //building ProjectionType

        //PropMapSpecs will proffer their strategy's ProjectionType.
        //SourceMemberSpecs will give their SourceType.
        //each also needs a unique, meaningful name.

        //BuildProjectionType requires, for each field: a type, a field. It should return a ProjectionTypeInfo object,
        //with a bank of ProjectionTypeFieldInfos, with FieldInfos and lazily-compiled accessors.
        //These then need integrating with the original set of member specs.








        readonly MemberInfo _sourceMember;
        //readonly MemberInfo _targetMember;
        readonly IReifyStrategy _strategy;

        public MemberReifySpec(MemberInfo sourceMember, IReifyStrategy strategy) {
            _sourceMember = sourceMember;
            _strategy = strategy;
        }


        public MemberInfo SourceMember {
            get { return _sourceMember; }
        }

        public IReifyStrategy Strategy {
            get { return _strategy; }
        }
                
    }
}
