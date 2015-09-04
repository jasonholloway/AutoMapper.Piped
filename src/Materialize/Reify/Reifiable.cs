using Materialize.Reify.Mapping;
using Materialize.Reify.Mods;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify
{

    abstract class Reifiable : IQueryProvider, IQueryable
    {
        public abstract IQueryable CreateQuery(Expression expression);
        public abstract IQueryable<TElement> CreateQuery<TElement>(Expression expression);
        public abstract object Execute(Expression expression);
        public abstract TResult Execute<TResult>(Expression expression);

        public abstract Expression Expression { get; }
        public abstract Type ElementType { get; }
        public abstract IQueryProvider Provider { get; }
        
        public abstract IEnumerator GetEnumerator();

        //------------------------------------------------------

        public static Reifiable Create(IQueryable qySource, Type tDest) 
        {
            var tOrig = qySource.ElementType;
            
            return (Reifiable)Activator.CreateInstance(
                                                typeof(Reifiable<,>)
                                                            .MakeGenericType(tOrig, tDest),
                                                qySource);
        }
    }



    class Reifiable<TSource, TDest> 
        : Reifiable, IQueryable<TDest>
    {
        IQueryable<TSource> _qySource;
        StrategyProvider _strategyProv;

        Expression _expression;

        public override Expression Expression {
            get { return _expression; }
        }

        public override Type ElementType {
            get { return typeof(TDest); }
        }

        public override IQueryProvider Provider {
            get { return this; }
        }

        public Reifiable(IQueryable<TSource> sourceQuery) 
        {
            _qySource = sourceQuery;
            _expression = Expression.Constant(this);
        }




        public override IQueryable CreateQuery(Expression expression) {
            throw new NotImplementedException();
        }

        public override IQueryable<TElement> CreateQuery<TElement>(Expression expression) {
            return new ReifyQuery<TElement>(this, expression);
        }

        public override object Execute(Expression expression) {
            throw new NotImplementedException();
        }

        public override TResult Execute<TResult>(Expression expression) 
        {   
            var mapStrategy = _strategyProv
                                    .GetStrategy(typeof(TSource), typeof(TDest));

            var mapper = mapStrategy.CreateModifier();
                        
            var stMods = new Stack<IModifier>(new[] { mapper });
            
            var modEmitter = new ModEmittingQueryVisitor(null, mod => stMods.Push(mod));
            modEmitter.Visit(expression);

            //with yer stack of mods, now construct ReifyExecutor
            //...            

            //var executor = new ReifyExecutor(stMods);

            //return (TResult)executor.Execute(_qySource);



            //couldn't modifiers themselves be built as nested stack?
            //visitor would create mod for each node encountered, forming layers,
            //each with some control over type


            //instead of visiting entire expression in one pass, should interpret layer by layer,
            //till we reach baserock of queryable
            
            //each layer produces a modifier

            //say, if First with a predicate is found at the top of the tree:
            //then we produce the appropriate modifier, and go to the instance (down the tree, that is)
            //to produce the modifier feeding the First() modifier.
            //Good good good: but what will each layer (modifier) return? Nothing:
            //it is only a modifier. At the end of the process, we'll have an amassed stack
            //to which we can feed our source query, which will be rewritten and transformed
            //layer by layer. So modifier still.

            //What will this analysing thing be called? A proper quandary. It's a parser, really.
            //A ReifyQueryParser, which will recreate itself for each dependent layer encountered.

            //The parser will at the end delegate to the mapping strategies to build up the core mapper modifier.

            //Then the modification stack will be run as part of execution.





            throw new NotImplementedException();
        }





        IEnumerator<TDest> IEnumerable<TDest>.GetEnumerator() {
            //not needed as is
            throw new NotImplementedException();
        }

        public override IEnumerator GetEnumerator() {
            return ((IEnumerable<TDest>)this).GetEnumerator();
        }
        
    }






}
