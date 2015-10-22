using Materialize.Expressions;

namespace Materialize.Reify2.Parsing2
{
    class CacheableQueryComparer : ExpressionComparer
    {
        public CacheableQueryComparer() {
            CompareConstants = ConstantComparison.ByTypeOnly;
            CompareLambdaNames = NameComparison.None;
            CompareParameterNames = NameComparison.None;
        }
    }
}
