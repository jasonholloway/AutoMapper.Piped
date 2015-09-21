using System.Linq.Expressions;

namespace Materialize.Reify.Rebasing
{
    struct RebaseContext
    {
        public readonly RootedExpression Subject;
        public readonly ParameterExpression NewRoot;
        public readonly RebaseMap Map;

        public RebaseContext(
            RootedExpression subject, 
            ParameterExpression exNewRoot, 
            RebaseMap map) 
        {
            Subject = subject;
            NewRoot = exNewRoot;
            Map = map;
        }

    }
}