using Materialize.Reify2.Elements;
using Materialize.Reify2.Mapping;
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
            var outElemType = Subject.MethodTypeArgs.Single();
            var outType = typeof(IQueryable<>).MakeGenericType(outElemType);


            var mapperWriter = GetMapperWriter(inElemType, outElemType);

            var exServerProjection = GetServerProjection(mapperWriter);
            var exClientProjection = GetClientProjection(mapperWriter);
            
            //yield bounded data projector
            yield return (IElement)Activator.CreateInstance(
                                            typeof(BoundaryProjectorElement<,>).MakeGenericType(inElemType, mapperWriter.FetchType),
                                            exServerProjection,
                                            new TolerantRegime());
                        
            //yield transformer                        
            yield return (IElement)Activator.CreateInstance(
                                            typeof(ProjectorElement<,>).MakeGenericType(mapperWriter.FetchType, outElemType),
                                            exClientProjection);
        }



        
        IMapperWriter GetMapperWriter(Type tFrom, Type tTo) {
            var writerSource = Subject.ReifyContext.MapperWriterSource;
            var vector = new TypeVector(tFrom, tTo);

            return writerSource.GetWriter(Subject.ReifyContext, vector);
        }


        LambdaExpression GetServerProjection(IMapperWriter mapperWriter) {
            var exParam = Expression.Parameter(mapperWriter.SourceType, "x");

            return Expression.Lambda(
                            mapperWriter.ServerRewrite(exParam),
                            exParam);

        }


        LambdaExpression GetClientProjection(IMapperWriter mapperWriter) {
            var exParam = Expression.Parameter(mapperWriter.FetchType, "x");

            return Expression.Lambda(
                            mapperWriter.ClientRewrite(exParam),
                            exParam);
        }




    }
}
