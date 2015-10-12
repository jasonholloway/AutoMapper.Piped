using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Materialize.Demo2.Reporting
{
    public class StrategyReport
    {
        public readonly string Name;
        public readonly string Description;

        public StrategyReport(string name, string description) {
            Name = name;
            Description = description;
        }
    }

}