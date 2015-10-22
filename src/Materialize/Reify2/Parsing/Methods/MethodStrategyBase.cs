﻿using Materialize.Reify2.Rebasing;
using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify2.Parsing.Methods
{
    //Quietly does all the upstream-delegation-via-the-parser

    abstract class MethodStrategyBase<TSource, TDest>
        : ReifyStrategy, IParseStrategy
    {
        public MethodStrategyBase(IParseStrategy upstreamStrategy) 
        {
            SourceType = typeof(TSource);
            FetchType = upstreamStrategy.FetchType;
            DestType = typeof(TDest);
            UpstreamStrategy = upstreamStrategy;
        }

        public Type SourceType { get; private set; }        
        public Type FetchType { get; protected set; }
        public Type DestType { get; private set; }

        protected IParseStrategy UpstreamStrategy { get; private set; }
        
        public virtual bool FiltersFetchedSet {
            get { return UpstreamStrategy.FiltersFetchedSet; }
        }
        
                
        //as is, the expression is passed just so we can access variables - not for its form,
        //which should be felt out by the rule
        protected abstract IModifier Parse(IModifier upstreamMod, MethodCallExpression exSubject);
        
        IModifier IParseStrategy.Parse(Expression exSubject) {
            var exCall = (MethodCallExpression)exSubject;

            var upstreamMod = UpstreamStrategy.Parse(exCall.Arguments.First());

            return Parse(upstreamMod, exCall);
        }
        

        //by default, behaves as though nothing to rebase here - but this will often be right        
        public virtual IRebaseStrategy RebaseToSource(RebaseSubject subject) 
        {
            Debug.Assert(
                subject.RootVectors.Single().OrigRoot.Type == DestType.GetEnumerableElementType(), 
                "Bad rebase attempted in parse layer!");

            return UpstreamStrategy.RebaseToSource(subject);
        }

        


        public override IEnumerable<IReifyStrategy> UpstreamStrategies {
            get { return new[] { UpstreamStrategy }; }
        }

    }

}
