using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify2.Transitions
{

    internal interface IPowerOblivious { }
    internal interface ITypeOblivious { }


    partial class SelectTransition : IPowerOblivious
    { }

    partial class WhereTransition : IPowerOblivious
    { }

    partial class TakeTransition : ITypeOblivious
    { }

    partial class SkipTransition : ITypeOblivious
    { }
        
}
