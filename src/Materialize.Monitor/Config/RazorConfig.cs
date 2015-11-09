using Nancy.ViewEngines.Razor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Materialize.Monitor.Config
{
    public class RazorConfig : IRazorConfiguration
    {
        public IEnumerable<string> GetAssemblyNames() {
            yield return "Materialize";
            yield return "Mono.Linq.Expressions";
            yield return "HtmlTags";
            yield return "System.Web, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a";
        }

        public IEnumerable<string> GetDefaultNamespaces() {
            //yield return "HyRes.Models";

            yield break; ;
        }

        public bool AutoIncludeModelNamespace {
            get { return true; }
        }
    }
}