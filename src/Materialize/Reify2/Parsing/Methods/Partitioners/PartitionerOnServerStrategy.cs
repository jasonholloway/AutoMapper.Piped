using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Materialize.Types;


namespace Materialize.Reify2.Parsing.Methods.Partitioners
{   
    class PartitionerOnServerStrategy<TSource, TSourceElem, TElem> 
        : MethodStrategyBase<TSource, IEnumerable<TElem>>
    {
        MethodInfo _mPartitioner;

        public PartitionerOnServerStrategy(IParseStrategy upstreamStrategy, MethodInfo mPartitionerDef)
            : base(upstreamStrategy) 
        {
            _mPartitioner = mPartitionerDef.MakeGenericMethod(typeof(TSourceElem));
        }
        

        protected override IModifier Parse(IModifier upstreamMod, MethodCallExpression ex) 
        {
            var count = (int)((ConstantExpression)ex.Arguments[1]).Value;

            return new Modifier(upstreamMod, _mPartitioner, count);
        }
        

        class Modifier : ParseModifier<IEnumerable<TElem>, IEnumerable<TElem>>
        {
            MethodInfo _mPartitioner;
            int _count;

            public Modifier(IModifier upstreamMod, MethodInfo mPartitioner, int count)
                : base(upstreamMod) 
            {
                _mPartitioner = mPartitioner;
                _count = count;
            }


            protected override Expression ServerFilter(Expression exQuery) {                
                return Expression.Call(         //this could also be hooked on projection, but would have to safely treat incoming leg...
                                    _mPartitioner,
                                    UpstreamServerFilter(exQuery),
                                    Expression.Constant(_count));
            }
            
        }

    }
}
