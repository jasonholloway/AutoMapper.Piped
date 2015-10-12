using Materialize.Demo2.DataStructures;

namespace Materialize.Demo2.Reporting
{
    public class QueryReport
    {
        public readonly int? ReportID;
        public readonly string QueryFromClient;
        public readonly string QueryToServer;
        public readonly Tree<StrategyReport> StrategyTree;

        public QueryReport(
            int? reportID,
            string queryFromClient,
            string queryToServer,
            Tree<StrategyReport> strategyTree) 
        {
            ReportID = reportID;
            QueryFromClient = queryFromClient;
            QueryToServer = queryToServer;
            StrategyTree = strategyTree;
        }
        
    }    
}