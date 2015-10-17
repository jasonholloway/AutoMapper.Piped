using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Materialize.Reify.Parsing.Methods
{
    abstract class MethodParserBase : IMethodParser
    {
        ParseContext _ctx;
        
        public ParseContext Context {
            protected get {
                return _ctx;
            }
            set {
                _ctx = value;
                MethodDef = value.MethodDef;
                SourceType = value.SourceType;
                ElemType = value.MethodTypeArgs.First(); //could also get this from element of dest type
                CallExp = value.CallExp;
                AllowClientSideFiltering = value.ReifyContext.AllowClientSideFiltering;
            }
        }


        public ParseStrategySource ParseStrategySource { get; set; }
        
        protected IParseStrategy UpstreamStrategy { get; private set; }

        protected MethodInfo MethodDef { get; private set; }
        protected Type SourceType { get; private set; }
        protected Type ElemType { get; private set; }       
        protected MethodCallExpression CallExp { get; private set; }
        protected bool AllowClientSideFiltering { get; private set; }


        IParseStrategy IMethodParser.Parse() 
        {
            UpstreamStrategy = GetUpstreamStrategy(Context);
            return Parse();
        }

        protected abstract IParseStrategy Parse();






        IParseStrategy GetUpstreamStrategy(ParseContext ctx) {
            var exUpstreamSubject = ctx.CallExp.Arguments.First();
            var upstreamContext = ctx.Spawn(exUpstreamSubject, SourceType); //SourceType passed upwards may change here, eg in projections(?)
                                                                            //depends on rewriting...
                                                                            //First() could do this, but to do so would need to know fair bit about
                                                                            //upstream behaviour first... a vicious circle.
                                                                            //So in practice this will never change between layers (I suspect)

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
