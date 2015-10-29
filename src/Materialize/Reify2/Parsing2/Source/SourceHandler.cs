using Materialize.Reify2.Operations;
using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify2.Parsing2.Source
{
    class SourceHandler : ParseHandler
    {
        public override IEnumerable<IOperation> Respond() 
        {
            var regime = Subject.ReifyContext.SourceRegime;

            var elemType = Subject.SubjectExp.Type.GetEnumerableElementType();
            
            yield return (IOperation)Activator.CreateInstance(
                                            typeof(SourceOp<>).MakeGenericType(elemType),
                                            regime);
        }
    }
}
