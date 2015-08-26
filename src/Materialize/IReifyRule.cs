namespace Materialize
{
    interface IReifyRule
    {
        IReifierFactory BuildFactoryIfApplicable(ReifySpec spec);
    }
}
