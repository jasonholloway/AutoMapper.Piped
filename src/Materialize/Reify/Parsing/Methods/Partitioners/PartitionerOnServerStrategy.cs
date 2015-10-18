using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Materialize.Types;


namespace Materialize.Reify.Parsing.Methods.Partitioners
{   
    class PartitionerOnServerStrategy<TSource, TElem> 
        : MethodStrategyBase<TSource, IQueryable<TElem>>
    {
        MethodInfo _mPartitioner;

        public PartitionerOnServerStrategy(IParseStrategy upstreamStrategy, MethodInfo mPartitionerDef)
            : base(upstreamStrategy) 
        {
            _mPartitioner = mPartitionerDef.MakeGenericMethod(typeof(TElem));
        }
        

        protected override IModifier Parse(IModifier upstreamMod, MethodCallExpression ex) 
        {
            var count = (int)((ConstantExpression)ex.Arguments[1]).Value;

            return new Modifier(upstreamMod, _mPartitioner, count);
        }
        

        class Modifier : ParseModifier<IQueryable<TElem>, IQueryable<TElem>>
        {
            MethodInfo _mPartitioner;
            int _count;

            public Modifier(IModifier upstreamMod, MethodInfo mPartitioner, int count)
                : base(upstreamMod) 
            {
                _mPartitioner = mPartitioner;
                _count = count;
            }
            

            protected override Expression Rewrite(Expression exSourceQuery) 
            {
                var exUpstream = UpstreamRewrite(exSourceQuery);
                
                return Expression.Call(
                                    _mPartitioner, 
                                    exUpstream, 
                                    Expression.Constant(_count));
            }


            protected override IQueryable<TElem> Transform(object fetched) {
                return UpstreamTransform(fetched);
            }
        }

    }
}
