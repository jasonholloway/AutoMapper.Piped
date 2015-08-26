namespace Materialize
{
    interface IReifierFactory
    {
        IReifier CreateReifier(ReifyContext ctx);
    }

    interface IReifierFactory<TOrig, TDest>
        : IReifierFactory
    {
        new IReifier<TOrig, TDest> CreateReifier(ReifyContext ctx);
    }


    abstract class ReifierFactory<TOrig, TDest>
        : IReifierFactory<TOrig, TDest>
    {
        public abstract IReifier<TOrig, TDest> CreateReifier(ReifyContext ctx);

        IReifier IReifierFactory.CreateReifier(ReifyContext ctx) {
            return CreateReifier(ctx);
        }
    }
    
}
