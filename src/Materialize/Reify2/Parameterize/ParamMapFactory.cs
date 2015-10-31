using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Materialize.Expressions;

namespace Materialize.Reify2.Parameterize
{
    internal static class ParamMapFactory
    {
        public static ParamMap Build(Expression exSubject) 
        {
            var lParams = new List<ParamMap.Param>();
            
            exSubject.ForEach(
                        (ex, path) => {
                            var exConstant = ex as ConstantExpression;

                            if(exConstant != null) {                                
                                lParams.Add(new ParamMap.Param() {
                                                    CanonicalExp = exConstant,
                                                    Accessor = path.BuildAccessor()
                                                    });
                            }
                        });
            
            return new ParamMap(lParams);
        } 

    }
}
