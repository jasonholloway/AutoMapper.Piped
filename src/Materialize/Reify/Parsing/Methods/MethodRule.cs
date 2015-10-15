using Materialize.Reify.Parsing.Methods.Filters;
using Materialize.Reify.Parsing.Methods.Partitioners;
using Materialize.Reify.Parsing.Methods.Unaries;
using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Materialize.Reify.Parsing.Methods
{
    class MethodRule : ParseRule
    {

        delegate IMethodStrategizer MethodStrategizerFac(ParseContext ctx);

        static IDictionary<MethodInfo, MethodStrategizerFac> _dStrategizerFacs
            = new Dictionary<MethodInfo, MethodStrategizerFac>() {
                { QueryableMethods.Skip, _ => new SimplePartitionerStrategizer() },
                { QueryableMethods.Take, _ => new SimplePartitionerStrategizer() },
                { QueryableMethods.Where, _ => new WhereStrategizer() },
                { QueryableMethods.First, _ => new SimpleUnaryStrategizer() },
                { QueryableMethods.Single, _ => new SimpleUnaryStrategizer() },
                { QueryableMethods.Last, _ => new SimpleUnaryStrategizer() }
            };


        

        ParseStrategySource _parseStrategies;


        public MethodRule(ParseStrategySource parseStrategies) {
            _parseStrategies = parseStrategies;
        }
                

        public override IParseStrategy GetStrategy(ParseContext ctx) 
        {
            MethodStrategizerFac fnMethodStrategizer = null;

            if(_dStrategizerFacs.TryGetValue(ctx.MethodDef, out fnMethodStrategizer)) 
            {
                var strategizer = fnMethodStrategizer(ctx);

                strategizer.Context = ctx;
                strategizer.ParseStrategySource = _parseStrategies;

                return strategizer.Strategize();
            }
            
            throw new ParseException(
                            "Can't find IMethodStrategizer factory for {0}", 
                            ctx.MethodDef.GetNiceName());
        }





    }
}
