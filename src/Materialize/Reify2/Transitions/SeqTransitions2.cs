using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify2.Transitions
{

    internal interface IHasSource
    {
        Expression Source { get; set; }
    }



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
