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
            return @this.Replace(fnTest, _ => exNew);
        }

        public static Expression Replace(
            this Expression @this, 
            Expression exOld, 
            Expression exNew) 
        {
            return @this.Replace(ex => ex == exOld, exNew);
        }
        
        public static Expression Replace(
            this Expression @this,
            Predicate<Expression> fnTest,
            Func<Expression, Expression> fnReplace) 
        {
            var visitor = new ReplacerVisitor(fnTest, fnReplace);
            return visitor.Visit(@this);
        }



        public static void ForEach(
            this Expression @this,
            Action<Expression> fn) 
        {
            new EnumeratorVisitor(fn).Visit(@this);
        }




        public static Expression Simplify(this Expression @this) {
            return new SimplifyVisitor().Visit(@this);
        }


        public static bool IsFormallyEquivalentTo(this Expression @this, Expression comparand) {
            return new FormalComparer().Equals(@this, comparand);
        }

        public static int GetFormalHashCode(this Expression @this) {
            return new FormalComparer().GetHashCode(@this);
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
            Func<Expression, Expression> _fnReplace;

            public ReplacerVisitor(Predicate<Expression> fnTest, Func<Expression, Expression> fnReplace) {
                _fnTest = fnTest;
                _fnReplace = fnReplace;
            }

            public override Expression Visit(Expression node) {
                if(_fnTest(node)) {
                    return _fnReplace(node);
                }

                return base.Visit(node);
            }            
        }


        class EnumeratorVisitor : ExpressionVisitor
        {
            Action<Expression> _fn;

            public EnumeratorVisitor(Action<Expression> fn) {
                _fn = fn;
            }

            public override Expression Visit(Expression node) {
                _fn(node);
                return base.Visit(node);
            }
        }


        




        class FormalComparer : ExpressionComparer
        {
            public FormalComparer() {
                CompareConstants = ConstantComparison.ByTypeOnly;
                CompareLambdaNames = NameComparison.None;
                CompareParameterNames = NameComparison.None;
            }
        }

    }


}
