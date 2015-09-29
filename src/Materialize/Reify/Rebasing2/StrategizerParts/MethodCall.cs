using Materialize.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify.Rebasing2
{
    partial class RebaseStrategizer 
    {
        //Question of whether rooting should flow through method calls
        //Yes - as long as they are Queryable methods
        
        protected override IRebaseStrategy VisitMethodCall(MethodCallExpression exCall) 
        {
            if(exCall.Method.IsGenericMethod
                && exCall.Method.DeclaringType == typeof(Queryable))
            {
                var methodDef = exCall.Method.GetGenericMethodDefinition();

                if(methodDef == QueryableMethods.WhereDef) 
                {
                    var strInst = Visit(exCall.Arguments[0]);

                    if(strInst is IRootedRebaseStrategy) {
                        var strExpanded = ((IRootedRebaseStrategy)strInst).Expand(exCall);

                        if(strExpanded != null) {
                            return strExpanded;
                        }
                    }

                    if(strInst is PassiveRebaseStrategy) {
                        return PassiveStrategy(exCall.Type);
                    }
                    

                    var tRebasedElem = strInst.TypeVector.DestType
                                                            .GetEnumerableElementType();

                    var exQuotedPred = (UnaryExpression)exCall.Arguments[1];

                    var exPred = (LambdaExpression)exQuotedPred.Operand;

                    //the question here is, how do we switch to the correct rebase strategy, given that
                    //we're stepping from a multiple to an element? At the beginning of rebasing, we will
                    //treat a multiple, and properly, in correlation with the outermost mapping layer, which
                    //itself concerns a multiple.

                    //And so the outermost mapping layer, in rebasing, executes the RebaseStrategizer with its
                    //own root RebaseStrategy. But then we get here.

                    //We must ask the underlying mapping layer for the RebaseStrategy matching the
                    //desired TypeVector of the root of the predicate

                    //The mapping layers all publish strategies upwards, suitable for particular typevectors.
                    //Certain of these strategies will then allow expansion. Though this is up to them.

                    //But shouldn't publish blindly upwards... otherwise we'd have vicious loops in no time.
                    //Each clause in the chain should make an appropriate range of transformations available.



                    var predStrategizer = SpawnChildStrategizer(
                                                (tv, r) => {
                                                    return null;
                                                },
                                                new RootVector(
                                                        exPred.Parameters.Single(), 
                                                        Expression.Parameter(tRebasedElem))
                                                );

                    

                    var strPred = predStrategizer.Strategize(exQuotedPred);


                    var mRebasedWhere = QueryableMethods.WhereDef
                                                        .MakeGenericMethod(tRebasedElem);

                    Func<MethodCallExpression, MethodCallExpression> fnRebaser;
                        
                    fnRebaser = (x) => {
                        var exRebasedInst = strInst.Rebase(x.Arguments[0]);
                        var exRebasedPred = strPred.Rebase(x.Arguments[1]);

                        return Expression.Call(
                                            mRebasedWhere,
                                            exRebasedInst,
                                            exRebasedPred);
                    };

                    return Strategy(strInst.TypeVector, fnRebaser);                    
                }

                throw new NotImplementedException("Only Where methods handled for now...");
            }
            

            return null;
        }
    }
}
