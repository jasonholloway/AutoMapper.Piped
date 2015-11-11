using Materialize.Reify2.Rebase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify2.Transitions
{
    //FIRST THINGS FIRST!
    //Move Where clauses onto server.
    //Just this, nowt else for now.
    
    //And to do this, I just need a special optimizer to do such
    //ignoring predicated aggregators, etc.
    




    internal interface ITakesSource
    {
        Expression Source { get; set; }
    }


    internal interface ITypeRebasable
    {
        IEnumerable<LambdaExpression> Rebasables { get; }
    }



    internal interface IPowerOblivious { }

    internal interface ITypeOblivious { }

    internal interface IOrderOblivious { }
    



    partial class SelectTransition : IPowerOblivious, IOrderOblivious
    { }
    
    partial class CastTransition : IPowerOblivious, IOrderOblivious
    { }




    //FILTERS -------------------------------------------------------
    partial class WhereTransition : ITypeRebasable, IOrderOblivious
    {
        IEnumerable<LambdaExpression> ITypeRebasable.Rebasables {
            get { yield return (LambdaExpression)Predicate; }
        }
    }


    partial class OfTypeTransition : IPowerOblivious, IOrderOblivious
    { }

    


    //PARTITIONERS --------------------------------------------------
    partial class SkipTransition : ITypeOblivious
    { }

    partial class TakeTransition : ITypeOblivious
    { }


    partial class SkipWhileTransition
    { }

    partial class SkipWhile2Transition
    { }


    partial class TakeWhileTransition
    { }

    partial class TakeWhile2Transition
    { }







    partial class ReverseTransition : ITypeOblivious, IPowerOblivious
    { }
    

    partial class ExceptTransition : IOrderOblivious
    { }

    partial class Except2Transition : IOrderOblivious
    { }


    partial class IntersectTransition : IOrderOblivious
    { }

    partial class Intersect2Transition : IOrderOblivious
    { }










    //AGGREGATORS ------------------------------------------------------------------------
    //in sorting, these should take precedence over others in being shunted forwards...
    //and they KILL anything they overtake

    //Should certainly be rearranged by a distinct stage

    partial class CountTransition : ITypeOblivious, IPowerOblivious
    { }

    partial class Count2Transition : ITypeOblivious, IPowerOblivious
    { }

    partial class AnyTransition : ITypeOblivious, IOrderOblivious
    { }

    partial class Any2Transition : IOrderOblivious
    { }

    partial class AllTransition : IOrderOblivious
    { }

    partial class MaxTransition : IOrderOblivious
    { }

    partial class Max2Transition : IOrderOblivious
    { }

    partial class MinTransition : IOrderOblivious
    { }

    partial class Min2Transition : IOrderOblivious
    { }




    //ELEMENT OPS -----------------------------------------------------------------
    //overtaken stages must be changed to operate on single element
    //and, if pushed to server, should be immediately followed by fetch
    //predicated ops are more or less immovable, as they are type-reliant
    //THOUGH they can moved via rebasing as with Where clauses....

    partial class FirstTransition : ITypeOblivious
    { }

    partial class LastTransition : ITypeOblivious
    { }

    partial class SingleTransition : ITypeOblivious, IOrderOblivious
    { }

    partial class ElementAtTransition : ITypeOblivious
    { }

    
    partial class FirstOrDefaultTransition : ITypeOblivious //Not actually quite type-oblivious, as default is type-dependent
    { }

    partial class LastOrDefaultTransition : ITypeOblivious
    { }

    partial class SingleOrDefaultTransition : ITypeOblivious, IOrderOblivious
    { }
    
    partial class ElementAtOrDefault : ITypeOblivious
    { }



        

}
