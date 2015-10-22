using Materialize.Reify2.Elements;
using Materialize.SourceRegimes;
using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify2.Parsing2.Methods.Handlers
{
    class MapAsHandler : SequenceMethodHandler
    {
        protected override IEnumerable<IElement> InnerRespond() 
        {
            var elPrev = UpstreamElements.Last();

            var regime = elPrev.OutRegime;

            var inElemType = elPrev.OutType.GetEnumerableElementType();            
            var mappedElemType = Subject.MethodTypeArgs.Single();
            var mappedType = typeof(IQueryable<>).MakeGenericType(mappedElemType);


            //run the mapping engine
            //generate mapping projection
            //...


            var inType = elPrev.OutType;
            var medType = typeof(IQueryable<object>);
            var medElemType = typeof(object);


            //yield bounded data projector
            yield return (IElement)Activator.CreateInstance(
                                            typeof(BoundaryProjectorElement<,>).MakeGenericType(inElemType, medElemType),
                                            Expression.Lambda(
                                                        typeof(Func<,>).MakeGenericType(inElemType, medElemType),
                                                        Expression.Default(medElemType),
                                                        Expression.Parameter(inElemType)),
                                            new TolerantRegime());
                        
            //yield transformer            
            
            yield return (IElement)Activator.CreateInstance(
                                            typeof(ProjectorElement<,>).MakeGenericType(medElemType, mappedElemType),
                                            Expression.Lambda(
                                                        typeof(Func<,>).MakeGenericType(medElemType, mappedElemType),
                                                        Expression.Default(mappedElemType),
                                                        Expression.Parameter(medElemType)
                                                        ));

        }
    }
}
