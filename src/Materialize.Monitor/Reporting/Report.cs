using Materialize.Monitor.DataStructures;
using System;

namespace Materialize.Monitor.Reporting
{
    public abstract class Report
    {
        public Guid SessionGuid { get; private set; }
        public int ReportID { get; private set; }
        public string Name { get; private set; }

        internal Report(Guid sessionGuid, int reportID, string name) 
        {
            SessionGuid = sessionGuid;
            ReportID = reportID;
            Name = name;
        }

        protected Report() { }
        
    }    
}