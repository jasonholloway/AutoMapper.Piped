using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify2.Transitions
{

    internal interface ITakesSource
    {
        Expression Source { get; set; }
    }



    internal interface IPowerOblivious { }

    internal interface ITypeOblivious { }

    internal interface IOrderOblivious { }



    internal interface ITypeFlexible
    { 
        
    } 



    

    /*    
    Where am I? We have transitions nicely laid-out in a buffer, easy to rearrange.

    My main goal is to get where clauses pushed serverside. And similar behaviour with aggregators, etc.

    SO: need to sort and rebase transitions. That's the beef.

    And first, I need to decide what to do about sorting past the fetch transition.

    And secondly, I need to put in place simple sorting manouevres (ie no rebasing quite yet).

    Finally, rebasing. Transitions need to be given opportunity to reform themselves to desired type regime.

    For this, they should be fed a relative type-regime definition, to suit themselves to.

    ------------------------------------------------------------

    Sorting and regime acknowledgement

    The problem with testing against the new regime immediately is that the produced expression may only
    be acceptible after further transformations. We should maybe prepare a smorgasbord of options, for a final
    confirmation stage to select from. But this would most definitely suit immutable, copyable transitions, which
    we don't have to hand.

    Mutable transitions do not suit this scheme one bit. The mutable transition requires changes to be accepted.
    But we could actually do this with the predicates appended to these transitions. The predicates are those that
    will be rebased, after all. The predicates determine the dynamic possibilities. This would get more complicated
    with multiple predicates, of course, though as I think there are no transitions actually like this...
    though this veers us away from the general solution, and also requires us to *extract* expression values out of
    each encapsulated transition.

    With the transition machinery in place, we would have to plod up the buffer step by step, testing as we go and responding
    to the encapsulated rebaser's immediate rejection or acceptance of our demand. Our hands would be tied from being
    more mobile than this.

    We don't have to go step by step, actually. We can hop ahead. All we have to do is accumulate type-regime changes on
    the outside of our subject transition, present them to it as a hoop to leap through, and request it to jump. It will
    either manage it or it won't. We can hereby traverse the buffer more widely. Though we spoil the possibility of being
    able to progress by small incremental steps. A more involved rebasing mechanism will be needed, with an articulated
    registry of type mappings.

    In fact, why would we recreate this each time? If we lay down as a fact that we won't reposition type-changers themselves,
    we can use them as limit points, to create a type-regime map of the buffer. Each projection will be analysed to create
    a TypeRegimeTransition, linked others at each side. This will then be used in rebasing predicated subjects.
    
    Maybe, maybe, this will serve as a lead in to a more developed optimisation stage. OR NOT, FUCKFACE!!!!


    




    */

        



    partial class SelectTransition : IPowerOblivious, IOrderOblivious
    { }
    
    partial class CastTransition : IPowerOblivious, IOrderOblivious
    { }




    //FILTERS -------------------------------------------------------
    partial class WhereTransition : ITypeFlexible, IOrderOblivious
    { }


    partial class OfTypeTransition : IPowerOblivious, IOrderOblivious
    { }

    


    //PARTITIONERS --------------------------------------------------
    partial class SkipTransition : ITypeOblivious
    { }

    partial class TakeTransition : ITypeOblivious
    { }


    partial class SkipWhileTransition : ITypeFlexible
    { }

    partial class SkipWhile2Transition : ITypeFlexible
    { }


    partial class TakeWhileTransition : ITypeFlexible
    { }

    partial class TakeWhile2Transition : ITypeFlexible
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

    partial class Any2Transition : ITypeFlexible, IOrderOblivious
    { }

    partial class AllTransition : ITypeFlexible, IOrderOblivious
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
