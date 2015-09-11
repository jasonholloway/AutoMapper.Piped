using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.CollectionFactories
{
    public interface ICollectionFactorySource
    {
        CollectionFactory GetFactory(Type collType);
    }
}
