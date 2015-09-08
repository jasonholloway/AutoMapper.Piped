using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Tests.Infrastructure
{
    public static class ExpressionExtensions
    {

        public static bool Contains(this Expression @this, Predicate<Expression> fnTest) {
            var visitor = new ContainsVisitor(fnTest);
            visitor.Visit(@this);
            return visitor.Result;
        }

        public static bool Contains(this Expression @this, Expression exComparand) {
            return @this.Contains(ex => ex == exComparand);
        }



        class ContainsVisitor : ExpressionVisitor
        {
            Predicate<Expression> _fnTest;
            public bool Result = false;
            
            public ContainsVisitor(Predicate<Expression> fnTest) {
                _fnTest = fnTest;
            }

            public override Expression Visit(Expression node) {
                if(_fnTest(node)) {
                    Result = true;
                    return null;
                }

                return base.Visit(node);
            }
        }


    }
}
