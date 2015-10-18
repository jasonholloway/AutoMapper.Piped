using Materialize.Reify.Parsing.Methods.Filters;
using Materialize.Reify.Parsing.Methods.Partitioners;
using Materialize.Reify.Parsing.Methods.Unaries;
using Materialize.Reify.Parsing.Methods.Quantifiers;
using Materialize.Reify.Parsing.Methods.Aggregators;
using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Materialize.Reify.Parsing.Methods
{
    class MethodRule : ParseRule
    {

        delegate IMethodHandler MethodHandlerFac(ParseContext ctx);

        static IDictionary<MethodInfo, MethodHandlerFac> _dHandlerFacs
            = new Dictionary<MethodInfo, MethodHandlerFac>() {
                { QueryableMethods.Skip, _ => new PartitionerParser() },
                { QueryableMethods.Take, _ => new PartitionerParser() },
                { QueryableMethods.Where, _ => new WhereParser() },
                { QueryableMethods.First, _ => new UnaryParser() },
                { QueryableMethods.Single, _ => new UnaryParser() },
                { QueryableMethods.Last, _ => new UnaryParser() },
                { QueryableMethods.AnyPred, _ => new PredQuantifierParser() },
                { QueryableMethods.All, _ => new PredQuantifierParser() },
                { QueryableMethods.CountPred, _ => new PredCountParser() },
                { QueryableMethods.Count, _ => new CountParser() }
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
