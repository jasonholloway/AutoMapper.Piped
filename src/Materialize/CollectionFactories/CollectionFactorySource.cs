using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.CollectionFactories
{
    class CollectionFactorySource : ICollectionFactorySource
    {   
        public CollectionFactory GetFactory(Type collType) 
        {
            if(collType.IsArray && collType.GetArrayRank() == 1) {
                return (en) => en.to 
            }



            throw new NotImplementedException();
        }
    }
}
