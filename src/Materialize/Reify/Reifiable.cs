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


        public event EventHandler<IEnumerable> Fetched;
        public event EventHandler<IEnumerable> Transformed;

        protected void OnFetched(IEnumerable elems) {
            if(Fetched != null) {
                Fetched(this, elems);
            }
        }

        protected void OnTransformed(IEnumerable elems) {
            if(Transformed != null) {
                Transformed(this, elems);
            }
        }



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
        Lazy<IStrategy> _lzMapStrategy;


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

            _lzMapStrategy = new Lazy<IStrategy>(
                                    () => StrategyProvider.Default.GetStrategy(typeof(TSource), typeof(TDest)));
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

        public override TResult Execute<TResult>(Expression exReifyQuery) 
        {            
            var parser = new ReifyQueryParser(
                                            this,
                                            () => _lzMapStrategy.Value.CreateModifier());

            var modifier = parser.Parse(exReifyQuery);
                                                            
            var exQuery = modifier.RewriteQuery(exReifyQuery);
            
                                    
            if(typeof(IQueryable).IsAssignableFrom(exQuery.Type)) {
                var enFetched = (IEnumerable)_qySource.Provider.CreateQuery(exQuery);
                OnFetched(enFetched);

                var enTransformed = (IEnumerable)modifier.TransformFetched(enFetched);
                OnTransformed(enTransformed);

                return (TResult)enTransformed;
            }
            else {
                var fetched = _qySource.Provider.Execute(exQuery);
                OnFetched(new[] { fetched });

                var transformed = (TResult)modifier.TransformFetched(fetched);
                OnTransformed(new[] { transformed });

                return transformed;
            }
        }





        IEnumerator<TDest> IEnumerable<TDest>.GetEnumerator() {
            //SHOULD CACHE RESULT!!!
            return Execute<IEnumerable<TDest>>(_expression).GetEnumerator();
        }

        public override IEnumerator GetEnumerator() {
            return ((IEnumerable<TDest>)this).GetEnumerator();
        }
        
    }






}
