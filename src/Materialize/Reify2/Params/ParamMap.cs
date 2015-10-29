using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify2.Params
{
    internal class ParamMap
    {
        Dictionary<ParameterExpression, Item> _dItems //Doesn't need to be threadsafe... will only *access* concurrently, not write
            = new Dictionary<ParameterExpression, Item>();

        public void Add(ParameterExpression exParam) {
            _dItems[exParam] = new Item() { Param = exParam };
        }

        public void TryModify(ParameterExpression param, Action<Item> fnModify) {
            Item item = null;

            if(_dItems.TryGetValue(param, out item)) {
                fnModify(item);
            }
        }

        public IEnumerable<ParameterExpression> Parameters {
            get { return _dItems.Keys; }
        }
        
        public IEnumerable<Func<Expression, Expression>> Accessors {
            get { return _dItems.Values.Select(i => i.Accessor); }
        }


        public Func<Expression, Expression> TryGetAccessor(ParameterExpression param) {
            Item item = null;
            _dItems.TryGetValue(param, out item);

            return item?.Accessor;
        }
        
        
                

        public class Item
        {
            public ParameterExpression Param;
            public Func<Expression, Expression> Accessor;
        }
    }

}
