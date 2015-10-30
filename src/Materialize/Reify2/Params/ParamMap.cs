using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify2.Params
{
    internal class ParamMap
    {
        Dictionary<Expression, Param> _dParams;
        
        public ParamMap(IEnumerable<Param> enParams) {
            _dParams = enParams.ToDictionary(i => i.CanonicalExp);
        }
                       
        
        public IEnumerable<Expression> CanonicalExpressions {
            get { return _dParams.Keys; }
        }
        
        public IEnumerable<Func<Expression, Expression>> Accessors {
            get { return _dParams.Values.Select(i => i.Accessor); }
        }


        public Func<Expression, Expression> TryGetAccessor(Expression ex) {
            Param param = null;

            _dParams.TryGetValue(ex, out param);

            return param?.Accessor;
        }
        
        
        public ArgMap CreateArgMap(Expression exSubject) {
            return ArgMap.Create(this, exSubject);
        }
                

        public class Param
        {
            public Expression CanonicalExp;
            public Func<Expression, Expression> Accessor;
        }
    }

}
