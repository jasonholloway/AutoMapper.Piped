using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Materialize.Reify.Parsing.Unaries
{
    class UnaryRule : ParseRule
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
        
                       

        //need to get upstream strategy before working out current strategy

        //so rules find rules via their knowledge of instance arg
        //but then strategy itself must know the same



        
        public override IParseStrategy GetStrategy(ParseContext ctx) 
        {
            if(ctx.MethodDef != null && ctx.TypeArgs.Length == 1) 
            {
                Type tStrategy = null;

                if(_dStrategies.TryGetValue(ctx.MethodDef, out tStrategy)) {
                    var tElem = ctx.TypeArgs.First();

                    //get upstream strategy


                    return base.CreateStrategy(
                                    tStrategy.MakeGenericType(tElem));
                }
            }

            return null;
        }
    }
}
