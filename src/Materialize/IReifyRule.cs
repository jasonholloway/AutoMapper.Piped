namespace Materialize
{
    interface IReifyRule
    {
        IReifyStrategy ResolveStrategy(ReifySpec spec);
    }
}
