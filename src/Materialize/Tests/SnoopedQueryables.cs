using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Tests
{

    public static class SnoopedQueryableExtensions
    {
        public static IQueryable<TElem> Snoop<TElem>(this IQueryable<TElem> qyInner, Action<Expression> fnOnExecute) {
            var prov = new SnoopingQueryProvider(qyInner.Provider, fnOnExecute);
            return prov.CreateQuery<TElem>(qyInner.Expression);
        }
    }
    


    class SnoopedQuery<TElem> : IQueryable<TElem>
    {
        IQueryable<TElem> _qyInner;
        SnoopingQueryProvider _provider;

        public Type ElementType {
            get { return _qyInner.ElementType; }
        }

        public Expression Expression {
            get { return _qyInner.Expression; }
        }

        public IQueryProvider Provider {
            get { return _provider; }
        }


        public SnoopedQuery(IQueryable<TElem> qyInner, SnoopingQueryProvider newProvider) {
            _qyInner = qyInner;
            _provider = newProvider;
        }

        public IEnumerator<TElem> GetEnumerator() {
            var enumerator = _qyInner.GetEnumerator();
            _provider.Snoop(Expression); //should really only snoop if enumerator build without calling provider (as with Linq2Objects) 
            return enumerator;
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
       


    class SnoopingQueryProvider : IQueryProvider
    {
        IQueryProvider _innerProv;
        Action<Expression> _fnOnExecute;
        bool _alreadySnooped = false;

        public SnoopingQueryProvider(IQueryProvider innerProv, Action<Expression> fnOnExecute) {
            _innerProv = innerProv;
            _fnOnExecute = fnOnExecute;
        }
        
        public IQueryable CreateQuery(Expression expression) {
            var elemType = GetElementType(expression);
            
            return (IQueryable)Activator.CreateInstance(
                                            typeof(SnoopedQuery<>).MakeGenericType(elemType),
                                            _innerProv.CreateQuery(expression),
                                            this);
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression) {
            return new SnoopedQuery<TElement>(
                            _innerProv.CreateQuery<TElement>(expression),
                            this);
        }

        public object Execute(Expression expression) {
            Snoop(expression);
            return _innerProv.Execute(expression);
        }

        public TResult Execute<TResult>(Expression expression) {
            Snoop(expression);
            return _innerProv.Execute<TResult>(expression);
        }


        public void Snoop(Expression expression) {
            if(!_alreadySnooped) {
                _fnOnExecute(expression);
                _alreadySnooped = true;
            }
        }

        static Type GetElementType(Expression exp) {
            var tQuery = exp.Type
                            .GetInterfaces()
                            .Concat(new[] { exp.Type })
                            .First(t => t.IsInterface 
                                        && t.IsGenericType 
                                        && t.GetGenericTypeDefinition() == typeof(IQueryable<>));

            return tQuery.GenericTypeArguments.First();
        }

    }
}
