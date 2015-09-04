using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reifiables
{

    interface IReifiable
    {
        Expression QueryExpression { get; }
        IQueryProvider QueryProvider { get; }

        object Fetch();
        object Transform(object inp);
    }




    abstract class ReifiableMod : IReifiable
    {
        public abstract Expression QueryExpression { get; }
        public abstract IQueryProvider QueryProvider { get; }

        public abstract object Fetch();
        public abstract object Transform(object inp);
    }


    class ReifiableMod<TDest> : ReifiableMod
    {
        IReifiable _base;
        Func<object, object> _fnTransform;
        Lazy<Expression> _lzQueryExp;

        public ReifiableMod(
                IReifiable baseReifiable, 
                Func<Expression, Expression> fnExpMod, 
                Func<object, object> fnTransform) 
        {
            _base = baseReifiable;
            _fnTransform = fnTransform;
            
            _lzQueryExp = new Lazy<Expression>(() => fnExpMod(baseReifiable.QueryExpression));
        }


        public override IQueryProvider QueryProvider {
            get { return _base.QueryProvider; }
        }

        public override Expression QueryExpression {
            get { return _lzQueryExp.Value; }
        }


        public override object Transform(object inp) {            
            object obj = _base.Transform(inp);              
            return _fnTransform(obj);                       
        }                                                                                                               
                 
                                                   
        public override object Fetch() {
            //need much more subtle fetching mechanism...

            //if enumerable, then get query and enumerate
            //...

            return QueryProvider.Execute(QueryExpression);
        }




        public object Reify() {
            throw new NotImplementedException();
        }



        //in reifying, have to get 




    }
}
