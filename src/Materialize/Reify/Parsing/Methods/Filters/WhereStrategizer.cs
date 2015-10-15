using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Parsing.Methods.Filters
{
    class WhereStrategizer : FilterStrategizerBase
    {    
        protected override IParseStrategy Strategize() 
        {            
            var predRebaseResult = RebaseQuotedPredicate((UnaryExpression)CallExp.Arguments[1]);
            
            if(predRebaseResult.Successful) {
                return CreateStrategy(  //we can prepend to source query!                        
                            typeof(WhereOnServerStrategy<>).MakeGenericType(ElemType),
                            UpstreamStrategy,
                            predRebaseResult.RebaseStrategy);
            }

            if(AllowClientSideFiltering) {
                return CreateStrategy(
                            typeof(WhereOnClientStrategy<>).MakeGenericType(ElemType),
                            UpstreamStrategy);
            }

            if(predRebaseResult.Errored) {
                throw new RebaseException(
                            "Can't rebase predicate to push to server, and client-side filtering forbidden!",
                            predRebaseResult.Exception);
            }

            if(predRebaseResult.RejectedByServer) {
                throw new RebaseException(
                            "Server won't accept predicate, and client-side filtering forbidden!");
            }

            throw new InvalidOperationException();
        }
    }
}
