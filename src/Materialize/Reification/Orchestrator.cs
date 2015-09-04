using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reification
{
    class Orchestrator<TSource, TDest> : IQueryProvider
    {
        IQueryable<TSource> _sourceQuery;
        IReifyNode _baseNode;

        public Orchestrator(IQueryable<TSource> sourceQuery, IReifyNode baseNode) {
            _sourceQuery = sourceQuery;
            _baseNode = baseNode;
        }




        public IQueryable CreateQuery(Expression expression) {
            throw new NotImplementedException();
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression) {
            return new ReifyQuery<TElement>(this, expression);
        }

        public object Execute(Expression expression) {
            throw new NotImplementedException();
        }

        public TResult Execute<TResult>(Expression expression) {
            //visit expression to stack IReifyNodes

            //visit IReifyNodes to build stack of source-query-expressions and transformations

            

            throw new NotImplementedException();
        }
    }



    class ReifyQuery<TElem> : IQueryable<TElem>
    {
        public IQueryProvider Provider { get; private set; }
        public Expression Expression { get; private set; }

        Lazy<IEnumerable<TElem>> _lzResults;

        public ReifyQuery(IQueryProvider prov, Expression exp) {
            Provider = prov;
            Expression = exp;

            _lzResults = new Lazy<IEnumerable<TElem>>(
                                    () => prov.Execute<IEnumerable<TElem>>(Expression));
        }

        public Type ElementType {
            get { return typeof(TElem); }
        }

        public IEnumerator<TElem> GetEnumerator() {
            return _lzResults.Value.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }




}
