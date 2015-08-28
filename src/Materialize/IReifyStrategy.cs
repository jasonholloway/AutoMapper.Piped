using System;

namespace Materialize
{
    interface IReifyStrategy
    {
        //Type SourceType { get; }
        //Type ProjectType { get; }
        //Type ReformType { get; }

        bool UsesIntermediateType { get; }
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
        //public Type SourceType {
        //    get { return typeof(TOrig); }
        //}

        //public virtual Type ProjectType {
        //    get { return typeof(TDest); }
        //}

        //public Type ReformType {
        //    get { return typeof(TDest); }
        //}
        
        public abstract bool UsesIntermediateType { get; }

        public abstract IReifier<TOrig, TDest> CreateReifier(ReifyContext ctx);

        IReifier IReifyStrategy.CreateReifier(ReifyContext ctx) {
            return CreateReifier(ctx);
        }
    }
    
}
