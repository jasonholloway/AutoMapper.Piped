using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify.Parsing.CallParsing.Where
{
    class WhereRule : CallParseRule
    {
        static MethodInfo _mWhere = Refl.GetGenericMethodDef(() => Queryable.Where<int>(null, i => true));


        public override CallParserFactory GetParserFactory(CallParseContext ctx) 
        {
            if(ctx.MethodDef == _mWhere)
            {                
                var tElem = ctx.ArgTypes.First();
                
                //Need to get the parsed exp in from somehwere - yet can't key on this, annoyingly.
                //Can only key on the method, and on certain downstream flags.

                //Rules concern what can be keyed upon, and emplace strategies to suit this. These
                //strategies then create modifiers based on what they parse. This really is a different
                //strategy set-up.

                //If each strategy does the parsing... then they will become fixed in brittle hierarchies.

                //For the sake of strategy re-use and simple keying (specialising in this even), the strategies
                //cooperate with a runner: ReifyQueryParser.

                //This does mean though that strategies will do more than now: they will take the top layer
                //of the incoming query expression, and return a suitable modifier.



                return base.BuildParserFactory(
                                typeof(ClientWhereParser<>).MakeGenericType(tElem));
            }

            return null;
        }
    }
}
