using Materialize.Reify2.Transitions;
using Materialize.Reify2.Mapping;
using Materialize.SourceRegimes;
using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify2.Parsing2.SeqMethods
{
    static class MapAsParser
    {        
        public static IEnumerable<ITransition> Parse(ParseSubject s) 
        {
            var tInElem = s.CallExp.Arguments[0].Type.GetEnumerableElementType();
            var tOutElem = s.MethodTypeArgs.Single();

            var mapper = s.ReifyContext.MapperSource.GetMapper(
                                                        s.ReifyContext, 
                                                        new TypeVector(tInElem, tOutElem));

            throw new NotImplementedException();

            //would have to insert two Select transitions...


            //yield return new ProjectionTransition(GetServerProjection(mapper));
            
            yield return new FetchTransition(new TolerantRegime());
            
            //yield return new ProjectionTransition(GetClientProjection(mapper));            
        }
        
        

        static LambdaExpression GetServerProjection(IMapper mapper) 
        {
            var exParam = Expression.Parameter(mapper.SourceType, "x");

            return Expression.Lambda(
                            mapper.ServerRewrite(exParam),
                            exParam);

        }


        static LambdaExpression GetClientProjection(IMapper mapper) 
        {
            var exParam = Expression.Parameter(mapper.FetchType, "x");

            return Expression.Lambda(
                            mapper.ClientRewrite(exParam),
                            exParam);
        }

    }
}
