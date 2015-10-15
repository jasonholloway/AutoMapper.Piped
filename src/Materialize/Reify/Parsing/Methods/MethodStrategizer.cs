using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Materialize.Reify.Parsing.Methods
{
    abstract class MethodStrategizer : IMethodStrategizer
    {
        ParseContext _ctx;
        
        public ParseContext Context {
            protected get {
                return _ctx;
            }
            set {
                _ctx = value;
                MethodDef = value.MethodDef;
                ElemType = value.MethodTypeArgs.First();
                CallExp = value.CallExp;
                AllowClientSideFiltering = value.ReifyContext.AllowClientSideFiltering;
            }
        }


        public IParseStrategySource ParseStrategySource { get; set; }
        
        protected IParseStrategy UpstreamStrategy { get; private set; }
        protected MethodInfo MethodDef { get; private set; }
        protected Type ElemType { get; private set; }       
        protected MethodCallExpression CallExp { get; private set; }
        protected bool AllowClientSideFiltering { get; private set; }


        IParseStrategy IMethodStrategizer.Strategize() 
        {
            UpstreamStrategy = GetUpstreamStrategy(Context);
            return Strategize();
        }

        protected abstract IParseStrategy Strategize();






        IParseStrategy GetUpstreamStrategy(ParseContext ctx) {
            var exUpstreamSubject = ctx.CallExp.Arguments.First();
            var upstreamContext = ctx.Spawn(exUpstreamSubject);

            return ParseStrategySource.GetStrategy(upstreamContext);
        }



        protected IParseStrategy CreateStrategy(
            Type type,
            params object[] ctorArgs) 
        {
            return (IParseStrategy)Activator.CreateInstance(type, ctorArgs);
        }




    }
}
