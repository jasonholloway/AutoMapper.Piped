using Materialize.Expressions;

namespace Materialize.Reify.Parsing
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
