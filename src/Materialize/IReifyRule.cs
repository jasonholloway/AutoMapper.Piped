namespace Materialize
{
    interface IReifyRule
    {
        IReifyStrategy DeduceStrategy(ReifySpec spec);
    }
}
