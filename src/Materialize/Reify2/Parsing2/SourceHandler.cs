using Materialize.Reify2.Elements;
using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify2.Parsing2
{
    class SourceHandler : ParseHandler
    {
        public override IEnumerable<IElement> Respond() 
        {
            var regime = Subject.ReifyContext.SourceRegime;

            var elemType = Subject.SubjectExp.Type.GetEnumerableElementType();
            
            yield return (IElement)Activator.CreateInstance(
                                            typeof(SourceElement<>).MakeGenericType(elemType),
                                            regime);
        }
    }
}
