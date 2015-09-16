using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify.Parsing.CallParsing.Unaries
{
    class UnaryRule : CallParseRule
    {
        static IDictionary<MethodInfo, Type> _dStrategies
            = new Dictionary<MethodInfo, Type>() {
                {
                    Refl.GetGenericMethodDef(() => Queryable.First<int>(null)),
                    typeof(FirstParser<>)
                },
                {
                    Refl.GetGenericMethodDef(() => Queryable.FirstOrDefault<int>(null)),
                    typeof(FirstOrDefaultParser<>)
                },
            };
        
                       
        
        public override CallParserFactory GetParserFactory(CallParseContext ctx) 
        {
            if(ctx.MethodDef != null && ctx.ArgTypes.Length == 1) 
            {
                Type tStrategy = null;

                if(_dStrategies.TryGetValue(ctx.MethodDef, out tStrategy)) {
                    var tElem = ctx.ArgTypes.First();

                    return base.BuildParserFactory(
                                        tStrategy.MakeGenericType(tElem));
                }
            }

            return null;
        }
    }
}
