using Materialize.Reify2.Parsing.Methods.Filters;
using Materialize.Reify2.Parsing.Methods.Partitioners;
using Materialize.Reify2.Parsing.Methods.Unaries;
using Materialize.Reify2.Parsing.Methods.Quantifiers;
using Materialize.Reify2.Parsing.Methods.Aggregators;
using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Materialize.Reify2.Parsing.Methods
{
    class MethodRule : ParseRule
    {

        delegate IMethodHandler MethodHandlerFac(ParseContext ctx);

        static IDictionary<MethodInfo, MethodHandlerFac> _dHandlerFacs
            = new Dictionary<MethodInfo, MethodHandlerFac>() {
                { QueryableMethods.Skip, _ => new PartitionerHandler() },
                { QueryableMethods.Take, _ => new PartitionerHandler() },
                { QueryableMethods.Where, _ => new WhereHandler() },
                { QueryableMethods.First, _ => new UnaryHandler() },
                { QueryableMethods.Single, _ => new UnaryHandler() },
                { QueryableMethods.Last, _ => new UnaryHandler() },
                { QueryableMethods.AnyPred, _ => new PredQuantifierHandler() },
                { QueryableMethods.All, _ => new PredQuantifierHandler() },
                { QueryableMethods.CountPred, _ => new PredCountHandler() },
                { QueryableMethods.Count, _ => new CountHandler() }
            };


        

        ParseStrategySource _parseStrategies;


        public MethodRule(ParseStrategySource parseStrategies) {
            _parseStrategies = parseStrategies;
        }
                

        public override IParseStrategy GetStrategy(ParseContext ctx) 
        {
            MethodHandlerFac fnHandlerFac = null;

            if(_dHandlerFacs.TryGetValue(ctx.MethodDef, out fnHandlerFac)) 
            {
                var handler = fnHandlerFac(ctx);

                handler.Context = ctx;
                handler.ParseStrategySource = _parseStrategies;

                return handler.Strategize();
            }
            
            throw new ParseException(
                            "Can't find IMethodStrategizer factory for {0}", 
                            ctx.MethodDef.GetNiceName());
        }

        
    }
}
