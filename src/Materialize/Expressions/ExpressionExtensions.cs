using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Materialize.Expressions
{
    public static class ExpressionExtensions
    {
        public static bool Contains(
            this Expression @this, 
            Predicate<Expression> fnTest) 
        {
            var visitor = new ContainsVisitor(fnTest);
            visitor.Visit(@this);
            return visitor.Result;
        }


        public static bool Contains(
            this Expression @this, 
            Expression exComparand) 
        {
            return @this.Contains(ex => ex == exComparand);
        }
        

        public static Expression Replace(
            this Expression @this, 
            Predicate<Expression> fnTest, 
            Expression exNew) 
        {
            var visitor = new ReplacerVisitor(fnTest, exNew);
            return visitor.Visit(@this);
        }

        public static Expression Replace(
            this Expression @this, 
            Expression exOld, 
            Expression exNew) 
        {
            return @this.Replace(ex => ex == exOld, exNew);
        }
        


        public static Expression Simplify(this Expression @this) {
            return new SimplifyVisitor().Visit(@this);
        }


        class SimplifyVisitor : ExpressionVisitor
        {
            protected override Expression VisitMember(MemberExpression node) {
                var exNewUpstream = base.Visit(node.Expression);
                
                var exConstant = exNewUpstream as ConstantExpression;

                if(exConstant != null) {
                    object value = null;

                    switch(node.Member.MemberType) {
                        case MemberTypes.Field:
                            value = ((FieldInfo)node.Member).GetValue(exConstant.Value);
                            break;

                        case MemberTypes.Property:
                            value = ((PropertyInfo)node.Member).GetValue(exConstant.Value);
                            break;

                        default:
                            throw new NotImplementedException();
                    }

                    return Expression.Constant(value);
                }

                return Expression.MakeMemberAccess(exNewUpstream, node.Member);
            }
        }





        class ContainsVisitor : ExpressionVisitor {
            Predicate<Expression> _fnTest;
            public bool Result = false;

            public ContainsVisitor(Predicate<Expression> fnTest) {
                _fnTest = fnTest;
            }

            public override Expression Visit(Expression node) {
                if(_fnTest(node)) {
                    Result = true;
                    return node;
                }

                return base.Visit(node);
            }
        }
        

        class ReplacerVisitor : ExpressionVisitor
        {
            Predicate<Expression> _fnTest;
            Expression _exNew;

            public ReplacerVisitor(Predicate<Expression> fnTest, Expression exNew) {
                _fnTest = fnTest;
                _exNew = exNew;
            }

            public override Expression Visit(Expression node) {
                if(_fnTest(node)) {
                    return _exNew;
                }

                return base.Visit(node);
            }
            
        }

    }


}
