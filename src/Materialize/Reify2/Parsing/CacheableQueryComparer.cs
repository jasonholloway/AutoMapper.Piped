using Materialize.Expressions;

namespace Materialize.Reify2.Parsing
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
