using Materialize.Reify2.Transitions;
using Materialize.Reify2.Mapping;
using Materialize.SourceRegimes;
using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify2.Parsing2.Methods.Handlers
{
    class MapAsHandler : SequenceMethodHandler
    {
        
        protected override IEnumerable<ITransition> InnerRespond() 
        {
            var tInElem = Call.Arguments[0].Type.GetEnumerableElementType();
            var tOutElem = Subject.MethodTypeArgs.Single();
            
            var mapper = GetMapper(tInElem, tOutElem);
                        
            yield return new ProjectionTransition(GetServerProjection(mapper));
            
            yield return new FetchTransition(new TolerantRegime());
            
            yield return new ProjectionTransition(GetClientProjection(mapper));            
        }



        
        IMapper GetMapper(Type tFrom, Type tTo) 
        {
            var writerSource = Subject.ReifyContext.MapperWriterSource;
            var vector = new TypeVector(tFrom, tTo);

            return writerSource.GetWriter(Subject.ReifyContext, vector);
        }


        LambdaExpression GetServerProjection(IMapper mapper) 
        {
            var exParam = Expression.Parameter(mapper.SourceType, "x");

            return Expression.Lambda(
                            mapper.ServerRewrite(exParam),
                            exParam);

        }


        LambdaExpression GetClientProjection(IMapper mapper) 
        {
            var exParam = Expression.Parameter(mapper.FetchType, "x");

            return Expression.Lambda(
                            mapper.ClientRewrite(exParam),
                            exParam);
        }




    }
}
