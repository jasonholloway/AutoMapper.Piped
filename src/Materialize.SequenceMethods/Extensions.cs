using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Materialize.SequenceMethods
{
    public static class Extensions
    {
        public static string Describe(this MethodInfo m, bool isExtension = false) {
            var typeArgs = m.GetGenericArguments();
            var rParams = m.GetParameters().Skip(isExtension ? 1 : 0);
            
            var sb = new StringBuilder();

            sb.Append(m.ReturnType.GetNiceName());
            sb.Append(" ");

            if(!isExtension) {
                sb.Append(m.DeclaringType.GetNiceName());
                sb.Append(".");
            }

            sb.Append(m.Name);

            if(typeArgs.Any()) {
                sb.Append("<");
                sb.Append(string.Join(", ", typeArgs.Select(t => t.GetNiceName())));
                sb.Append(">");
            }

            sb.Append("(");
            sb.Append(string.Join(", ", rParams.Select(p => string.Format("{0} {1}", p.ParameterType.GetNiceName(), p.Name))));
            sb.Append(")");

            return sb.ToString();
        }


        public static string GetNiceName(this Type t) {
            if(t.IsGenericType) {
                var genDef = t.GetGenericTypeDefinition();
                var genArgs = t.GetGenericArguments();
                
                if(genDef == typeof(Nullable<>)) {
                    return $"{genArgs[0].GetNiceName()}?";
                }

                var baseName = Regex.Match(t.Name, "(.*)`").Groups[1].Value;

                var sb = new StringBuilder(baseName);
                sb.Append("<");

                bool successor = false;

                foreach(var genArg in genArgs) {
                    if(successor) {
                        sb.Append(", ");
                    }

                    sb.Append(genArg.GetNiceName());

                    successor = true;
                }

                sb.Append(">");

                return sb.ToString();
            }
            else if(t.IsGenericTypeDefinition) {
                throw new NotImplementedException();
            }
            else {
                switch(t.Name) {
                    case "Boolean": return "bool";
                    case "Int32": return "int";
                    case "Int64": return "long";
                    case "Single": return "float";
                    case "Double": return "double";
                    case "Decimal": return "decimal";
                }
                
                return t.Name;
            }
        }






        public static string Capitalize(this string s) {
            return new string(s.ToArray().Select((c, i) => i == 0 ? char.ToUpperInvariant(c) : c).ToArray());
        }




    }
}
