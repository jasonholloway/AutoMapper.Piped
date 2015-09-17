using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Materialize.Reify.Parsing.Unaries
{
    class BaseRule : ParseRule
    {   
        public override IParseStrategy GetStrategy(ParseContext ctx) 
        {
            if(ctx.SubjectExp == ctx.BaseExp) { //not sure 




            }



            if(ctx.MethodDef != null && ctx.TypeArgs.Length == 1) 
            {
                Type tStrategy = null;

                if(_dStrategies.TryGetValue(ctx.MethodDef, out tStrategy)) {
                    var tElem = ctx.TypeArgs.First();

                    return base.CreateStrategy(
                                    tStrategy.MakeGenericType(tElem));
                }
            }

            return null;
        }
    }
}
