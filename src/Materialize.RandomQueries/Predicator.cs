using Materialize.RandomQueries.Bits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Materialize.RandomQueries
{
    abstract class Predicator<T>
    {
        PropertyInfo _prop = Rand.FromList(typeof(T).GetProperties());

        //...

    }
}
