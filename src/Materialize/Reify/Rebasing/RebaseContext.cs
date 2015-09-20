using System.Linq.Expressions;

namespace Materialize.Reify.Rebasing
{
    struct RebaseContext
    {
        public readonly RootedExpression Subject;
        public readonly RebaseMap Map;

        public RebaseContext(RootedExpression subject, RebaseMap map) {
            Subject = subject;
            Map = map;
        }

    }
}