using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify.Parsing.CallParsing
{
    //Unlike MapStrategies, which form quasi-static hierarchies,
    //ParseStrategies are more loosely assembled

    //Each incoming query is read clause by clause


    delegate IModifier CallParser(MethodCallExpression exCall);


    interface ICallParseStrategy
    {
        CallParser CreateCallParser(Parser parser);
    }
}
