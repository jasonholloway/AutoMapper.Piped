using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify2.Compiling
{
    abstract class StageCompiler
    {
        public abstract StageCompilation Compile(ITransition op);
    }


    internal class StageCompilation
    {
        public Func<object> Func { get; private set; }
        public ITransition NextOp { get; private set; }

        public StageCompilation(Func<object> fn, ITransition nextOp) {
            Func = fn;
            NextOp = nextOp;
        }
    }






    internal class QueryStageCompiler : StageCompiler
    {
        public override StageCompilation Compile(ITransition op) {
            throw new NotImplementedException();
        }
    }


    internal class TransformStageCompiler : StageCompiler
    {
        public override StageCompilation Compile(ITransition op) {
            throw new NotImplementedException();
        }
    }



}
