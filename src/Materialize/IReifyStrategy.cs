namespace Materialize
{
    interface IReifyStrategy
    {
        IReifier CreateReifier(ReifyContext ctx);
    }

    interface IReifierStrategy<TOrig, TDest>
        : IReifyStrategy
    {
        new IReifier<TOrig, TDest> CreateReifier(ReifyContext ctx);
    }


    abstract class ReifierStrategy<TOrig, TDest>
        : IReifierStrategy<TOrig, TDest>
    {
        public abstract IReifier<TOrig, TDest> CreateReifier(ReifyContext ctx);

        IReifier IReifyStrategy.CreateReifier(ReifyContext ctx) {
            return CreateReifier(ctx);
        }
    }
    
}
