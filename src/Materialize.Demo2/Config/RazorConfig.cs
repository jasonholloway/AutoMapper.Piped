using Nancy.ViewEngines.Razor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Materialize.Demo2.Config
{
    public class RazorConfig : IRazorConfiguration
    {
        public IEnumerable<string> GetAssemblyNames() {
            //yield return "HyRes.Models";

            yield break;
        }

        public IEnumerable<string> GetDefaultNamespaces() {
            //yield return "HyRes.Models";

            yield break;
        }

        public bool AutoIncludeModelNamespace {
            get { return true; }
        }
    }
}