using Materialize.Demo2.DataStructures;

namespace Materialize.Demo2.Reporting
{
    public class QueryReport
    {
        public readonly int? ReportID;
        public readonly string QueryFromClient;
        public readonly string FetchExpression;
        public readonly string TransformExpression;
        public readonly Tree<StrategyReport> StrategyTree;

        public QueryReport(
            int? reportID,
            string queryFromClient,
            string fetchExpression,
            string transformExpression,
            Tree<StrategyReport> strategyTree) 
        {
            ReportID = reportID;
            QueryFromClient = queryFromClient;
            FetchExpression = fetchExpression;
            TransformExpression = transformExpression;
            StrategyTree = strategyTree;
        }
        
    }    
}