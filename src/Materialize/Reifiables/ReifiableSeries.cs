using Materialize.Strategies;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reifiables
{
    abstract class ReifiableSeries : Reifiable
    {
        public static ReifiableSeries Create(IQueryable qyOrig, Type tDest) 
        {            
            var tOrig = qyOrig.ElementType;

            //Regime -> TypeVector -> Context -> Strategy
            //...

            var rootStrategy = StrategySource.Default.GetStrategy(tOrig, tDest);

            var tProj = rootStrategy.ProjectedType;

            return (ReifiableSeries)Activator.CreateInstance(
                                                typeof(ReifiableSeries<,,>)
                                                            .MakeGenericType(tOrig, tProj, tDest),
                                                qyOrig,
                                                rootStrategy);
        }
    }


    abstract class ReifiableSeries<TDest> 
        : ReifiableSeries, IMaterializable<TDest>, IQueryProvider
    {
        public IQueryable<TDest> AsQueryable() {
            return CreateQuery<TDest>(Expression.Call(
                                                    Expression.Constant(this), 
                                                    "AsQueryable", 
                                                    null)); //should be compiled and cached...
        }

        #region IQueryProvider

        public abstract IQueryable CreateQuery(Expression expression);
        public abstract IQueryable<TElement> CreateQuery<TElement>(Expression expression);
        public abstract object Execute(Expression expression);
        public abstract TResult Execute<TResult>(Expression expression);

        #endregion

        #region IEnumerable

        public IEnumerator<TDest> GetEnumerator() {
            return ((IEnumerable<TDest>)Result).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        #endregion
    }



    class ReifiableSeries<TOrig, TProj, TDest>
        : ReifiableSeries<TDest>
    {
        readonly IQueryable<TOrig> _qyOrig;
        readonly IStrategy<TOrig, TDest> _rootStrategy;
        readonly Lazy<IEnumerable<TDest>> _lzReified;

        public ReifiableSeries(
                IQueryable<TOrig> qyOrig,
                IStrategy<TOrig, TDest> rootStrategy) 
        {
            _qyOrig = qyOrig;
            _rootStrategy = rootStrategy;
            _lzReified = new Lazy<IEnumerable<TDest>>(Reify);
        }


        public override bool IsCompleted {
            get { return _lzReified.IsValueCreated; }
        }

        public override object Result {
            get { return _lzReified.Value; }
        }
        
        public override Type OrigType {
            get { return typeof(TOrig); }
        }

        public override Type ProjType {
            get { return typeof(TProj); }
        }

        public override Type DestType {
            get { return typeof(TDest); }
        }

             
        
        ///////////////////////////////////////////////////////////////////////////////
        //BELOW IS MESS!!!!!!!!!!!!!!!
          
        //nasty interface below: should be more elegant way of doing this
        //than arbitrarily exposing function as public.
       
        //how about if ReifiableSeries had internal-only IQueryable interface?
        //users would still get IMaterializable, but this would delegate to IQueryable in a controlled manner
        
        //...


        IEnumerable<TDest> Reify() {
            return (IEnumerable<TDest>)Reify(null);
        }


        public object Reify(Func<Expression, Expression> fnModifyExp) {
            var reifier = _rootStrategy.CreateReifier();

            var projExp = reifier.Project(_qyOrig.Expression);

            if(fnModifyExp != null) {
                projExp = fnModifyExp(projExp);
            }

            if(typeof(IQueryable<TProj>).IsAssignableFrom(projExp.Type)) {
                var enProjected = (IEnumerable<TProj>)_qyOrig.Provider.CreateQuery(projExp);
                OnFetched(enProjected);

                var enTransformed = (IEnumerable<TDest>)reifier.Transform(enProjected);
                OnTransformed(enTransformed);

                return enTransformed;
            }
            else {
                var fetched = _qyOrig.Provider.Execute<TProj>(projExp);
                OnFetched(new[] { fetched });

                var transformed = (TDest)reifier.Transform(fetched);
                OnTransformed(new[] { transformed });

                return transformed;
            }
        }

        #region IQueryProvider

        public override IQueryable CreateQuery(Expression expression) {
            //call generically-typed sibling via reflection
            //...

            throw new NotImplementedException();
        }

        public override IQueryable<TElement> CreateQuery<TElement>(Expression expression) {
            var query = new ReifyQuery<TElement>(this, expression);
            return query;
        }

        public override object Execute(Expression expression) {
            //call generically-typed sibling via reflection
            //...

            throw new NotImplementedException();
        }

        public override TResult Execute<TResult>(Expression expression) 
        {
            //have to parse tree here...

            //for each expression layer, we need a handler. A visitor is required!
            //the operation order is to be inverted, however.
            //and what will each handler do? append to source query, or add operations to transformation

            //a Queryable.First call will append a first expression onto the source query, and nothing to the transformation
            //the same with all the clauses I plan on handling

            //but there should be infrastructure in place to append to either side.

            //a where statement, for instance, with a fully transitive condition, should again only affect the source query.

            //but a where statement that is fully intransitive, should modify the tranformed enumeration offered by previous layers

            //all operations affect these two stacks. And the visitor that crawls the tree is to append to both as fits its intention.
            
            
            
                        
            throw new NotImplementedException();
        }

        #endregion
    }




    

    class QueryVisitor : ExpressionVisitor
    {
        //need to reform tree into linear shape: from parameter at centre outwards
        //and then clause-by-clause, we append to Reifiable


        //visitor starts outside first; it creates a reifiable and pushes it to a stack
        //then a ReifyExecutor enumerates through each ReifyNode, from the inside out,
        //building its query and transformation stack.

        //but what about result caches? This would live in the Reifiable outer, which would
        //summon and run the executor internally, to traverse the ReifyNodes it itself had put in place.


        //So, every served query would have its own cache. It only needs to be executed once...
        //Nah, IQueryable shouldn't cache itself. Though they usually do...

        //But what of unary operations? Where's their cache? They don't need one, as they simply return
        //an in-memory instance, that won't whither by itself.

        //So queries should cache whatever they enumerate. Executions don't need it however.

        //The central, monolithic Reifiable that straddles the border between client and server, 
        //and itself serves queries, dreams up internally its map of ReifyNodes, which it then executes
        //to fulfil its queries. All results are served by this mechanism. 

        //Privately, it does its own projection, which consequent query-modifications only add to.
        //If the transformation stack were itself expressed in expressions, then some rationalisation
        //of the complementary stacks could perhaps be done. Client-side transformations could sometimes
        //be shunted onto the server to minimise throughput.

        //Reifiable then exposes IQueryable. No need to cater for IMaterializable at moment, which is really
        //just an afterthought, a wrapper to expose only certain functions to the eventual user.

        


        public IReifiable Reifiable { get; private set; }

        public QueryVisitor(IReifiable reifiable) {
            Reifiable = reifiable;
        }
        
        protected override Expression VisitParameter(ParameterExpression node) {
            //...
            return base.VisitParameter(node);
        }

        protected override Expression VisitMethodCall(MethodCallExpression node) 
        {
            //If Queryable.First, then set Reifiable prop to new ReifiableMod
            //with appropriate modifications to expression and transformation stages

            //this would obvs be better testing by method handle!

            string methodName = node.Method.DeclaringType.FullName + "." + node.Method.Name;
            
            switch(methodName) {        
                case "System.Linq.Queryable.First":

                    Reifiable = new ReifiableMod(
                                        Reifiable,
                                        ex => ex,
                                        null
                                        );

                    break;
            }


            return node;
        }

    }




    class ReifyQuery<TElem> : IQueryable<TElem>
    {
        public IQueryProvider Provider { get; private set; }
        public Expression Expression { get; private set; }
        
        public ReifyQuery(IQueryProvider prov, Expression exp) {
            Provider = prov;
            Expression = exp;
        }
        
        public Type ElementType {
            get { return typeof(TElem); }
        }

        public IEnumerator<TElem> GetEnumerator() {
            return Provider.Execute<IEnumerable<TElem>>(Expression).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }


}
