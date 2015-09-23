using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Reify.Rebasing2
{
    struct Rebased
    {
        public readonly Expression Expression;
        public readonly TypeVector TypeVector;
        public readonly bool IsRebased;



        //type vector would be good here,
        //but this should also be deducible from the returned expression, which will always be a certain type,
        //and, as the original expression's type is always going to be available 

        //so, received upstream expressions are always going to express a TypeVector, with or without a result wrapper
        //But then that puts the onus on the receiver to reconstitute this. Or rather, it puts the onus on the receiver
        //to *cope* with this: and this is always going to be necessary anyway. This is even the essential role of each handler.

        //So, let em do it. Ones may fall over, but so what: these cases form the limits of the implementation.

        //A further consideration is with ExpressionVisitor's default behaviour. But if the default behaviour again throws
        //errors, then again - so what? There will always 
        
        //Can't trust a typevector on its own, as we may have mapped back to the same type, yet have changed its properties.
        //For instance, the formatting of a string. So, again, the need to return contextual information.
        
        //r.Owner.Name => rm.Owner.Name
        //
        // Name, first-encountered, is MemberAccessExpression.
        // As a memberinfo, it will be available via RebaseMap.
        //   (each member record in the map will be accompanied by a TypeVector for which it is valid)
        // 
        // So, on its encounter, VisitCall will visit upstream first, n tell us what's on.
        // 
        // Only a member-access deriving directly from a root, or from another such member in a chain, 
        // is elgibile for rebase. 
        //
        // How about rm.Owner.Name.Length - no mapping would be in place for this, so would be left.
        //
        // How about rm.Owners.FirstOrDefault().Name?
        // would rebase to r.Owners.FirstOrDefault().Name.
        // Each LINQ function would have to remap its element type, which is fair enough
        // And each predicate in linq functions should be rebased appropriately
        //
        // rm.Owners.FirstOrDefault(o => o.Name != "").Name
        //  - Name member would delegate upstream first
        //  - FirstOrDefault method would find that it's in a rebase chain from its upstream counterparts; would
        //      handle its lambda happily.
        //
        //  - Each interested handler needs to know if its upstream is a rebased one. If so, it will have a particular
        //      TypeVector and a telltale flag. Not all will be straight maps to a corresponding rebased member. Some will
        //      require further processing, but all will need remapped base, surely, at least as input into new rebased hotchpotch. 



        





        private Rebased(Expression exp, TypeVector typeVector, bool isRebased) {
            Expression = exp;
            TypeVector = typeVector;
            IsRebased = isRebased;
        }



        public static Rebased Active(Expression exp, Type oldType, Type newType) {
            return Active(exp, new TypeVector(oldType, newType));
        }

        public static Rebased Active(Expression exp, TypeVector typeVector) {
            return new Rebased(
                            exp,
                            typeVector,
                            true);
        }

        public static Rebased Passive(Expression exp) {
            return new Rebased(
                            exp, 
                            new TypeVector(exp.Type, exp.Type), 
                            false);
        }

    }
}
