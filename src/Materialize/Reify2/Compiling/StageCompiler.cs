using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify2.Compiling
{
    abstract class StageCompiler
    {
        public abstract StageCompilation Compile(IOperation op);
    }


    internal class StageCompilation
    {
        public Func<object> Func { get; private set; }
        public IOperation NextOp { get; private set; }

        public StageCompilation(Func<object> fn, IOperation nextOp) {
            Func = fn;
            NextOp = nextOp;
        }
    }






    internal class QueryStageCompiler : StageCompiler
    {
        public override StageCompilation Compile(IOperation op) {
            throw new NotImplementedException();
        }
    }


    internal class TransformStageCompiler : StageCompiler
    {
        public override StageCompilation Compile(IOperation op) {
            throw new NotImplementedException();
        }
    }



}
