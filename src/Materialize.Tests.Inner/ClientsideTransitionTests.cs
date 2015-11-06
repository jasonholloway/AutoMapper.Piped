using Materialize.Reify2;
using Materialize.Reify2.Compiling;
using Materialize.Reify2.Parameterize;
using Materialize.Reify2.Transitions;
using Materialize.SourceRegimes;
using NUnit.Framework;
using System;
using System.Linq;
using System.Linq.Expressions;

[TestFixture]
public class ClientsideTransitionTests 
{

	class Item {
		public int Int { get; private set; }

		public Item(int i) {
			Int = i;
		}
	}

	IQueryable<Item> Items { get; } = Enumerable.Range(25, 50).Select(i => new Item(i)).AsQueryable();

	
	public ClientsideTransitionTests() {
		//...
	}

	[Test]
	public void AggregateTest() {
		throw new NotImplementedException();
	}

	[Test]
	public void Aggregate2Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void Aggregate3Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void AllTest() {
		throw new NotImplementedException();
	}


    static ParamMap _emptyParamMap = new ParamMap(Enumerable.Empty<ParamMap.Param>());
    static Expression _exBlank = Expression.Constant(0);

	[Test]
	public void AnyTest() {
        var trans = new Transition[] {
            new SourceTransition(new TolerantRegime(), Items.Expression),
            new FetchTransition(new TolerantRegime()),
            new AnyTransition(),
        };
        
        var scheme = Schematizer.Schematize(trans, _emptyParamMap);
        var reifier = new Reifier(_exBlank, _emptyParamMap, scheme.Compile());

        var result = (bool)reifier.Execute(Items.Provider, _exBlank);

        Assert.That(
            result,
            Is.EqualTo(Items.Any()));
	}

/*

Enumerables need to fit into erstwhile queryable args...
How in God's name could this be?

Realistically, each SeqMethod actually has two lots of args, and depending on fulfilment from outside,
switches between these two sets as in two modes.

Supply a SeqMethod with an IQueryable source, and it is a queryable method. Supply it with an IEnumerable, then it is itself enumerable.

So each arg therefore has two typepatterns, and the use of one means that all others must also follow suit.


SeqMethods have two methods, and therefore two sets of ArgSpecs, which rule a single set of ArgValues.

Each set of ArgSpecs connects to a distinct TypeArgHub, and updates this on each setting of an argument value.

But if this is so, and two type situations are constantly being updated (which is double the work obvs)
then we have to be able to swallow errors, rather than promptly throwing up in the programmer's face.
Which is a completely different model... each typearghub would have a current validity...

What will happen with quoted lambdas? These are acceptible within queryables, but enumerables barf them back.

A very similar issue to the Source argument, which will be too tightly constrained.

A mode manager would be updated by the dual TypeArgHubs, would switch from side to side.

But in the case of quoted lambdas, these only make sense with queryables: the presence of these restricts us to the
queryable sphere, even with mode-switching transitions. We need some general way of translation between the modes.

 In practice, we have been using our Schematizer handler to bodge the queryable into the enumerable if necessary: we manually
 switch between method versions, for instance. Couldn't we do the same bodging with quotes? i.e. all quotes will be removed, as
 even queryables can get by without them, inserting them implicitly.

 Well, yes, this would be a crude solution.

 But it wouldn't fix the problem of the Source arg, as the source arg won't fit into the transition at all, as is. Dual modes
 lead me onwards into the mire...

 ...though, again, this won't solve the problem of quotations (and other possibly different argument types). Ideally, some kind
 of automated bodging would be attempted. A Bodger would be available to capably bash one value into another's place.

*    One solution would be to use the Enumerable method for all transition specs. This makes sense anyway, as Queryables are
*    surely specialisations of Enumerables: the enumerable is the canonical version, is the original, is the superclass.
*
*    Queryable sources can, as standard, be bodged into Enumerable source fields. Only a forced change to the queryable method
*    would make the queryability of a source relevant and detectable. 
*
*    There would still be a problem with quotations, however, as these would not be able to be placed as is into the Enumerable
*    arg field. Would have to manipulate these into shape in parsing! Do-able though ugly.
*

  With the twin-mode idea, how would we know to couple two ArgSpecs in a single ArgValue? obviously we can do this by position,
  though this seems bleak. Types differ, names can't be relied on, what else is there? We have two regimes in play: arg by index,
  and arg by name, each one relating to a separate mode of coupling. Position would always be the thing.

  And so storing args by name makes less sense (unless they're guaranteeably uniform, which they in fact are...)

  The method would be automatically resolved from the available args... and also generically specified, one would hope.
  GetMethod() would start from the method defining the current mode (if any were valid!) and feed it with typeargs.
  
  The original, parsed typeargs would sit in both sides. 


*/

	[Test]
	public void Any2Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void AverageTest() {
		throw new NotImplementedException();
	}

	[Test]
	public void Average10Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void Average11Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void Average12Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void Average13Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void Average14Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void Average15Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void Average16Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void Average17Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void Average18Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void Average19Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void Average2Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void Average20Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void Average3Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void Average4Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void Average5Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void Average6Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void Average7Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void Average8Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void Average9Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void CastTest() {
		throw new NotImplementedException();
	}

	[Test]
	public void ConcatTest() {
		throw new NotImplementedException();
	}

	[Test]
	public void ContainsTest() {
		throw new NotImplementedException();
	}

	[Test]
	public void Contains2Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void CountTest() {
		throw new NotImplementedException();
	}

	[Test]
	public void Count2Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void DefaultIfEmptyTest() {
		throw new NotImplementedException();
	}

	[Test]
	public void DefaultIfEmpty2Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void DistinctTest() {
		throw new NotImplementedException();
	}

	[Test]
	public void Distinct2Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void ElementAtTest() {
		throw new NotImplementedException();
	}

	[Test]
	public void ElementAtOrDefaultTest() {
		throw new NotImplementedException();
	}

	[Test]
	public void ExceptTest() {
		throw new NotImplementedException();
	}

	[Test]
	public void Except2Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void FirstTest() {
		throw new NotImplementedException();
	}

	[Test]
	public void First2Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void FirstOrDefaultTest() {
		throw new NotImplementedException();
	}

	[Test]
	public void FirstOrDefault2Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void GroupByTest() {
		throw new NotImplementedException();
	}

	[Test]
	public void GroupBy2Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void GroupBy3Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void GroupBy4Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void GroupBy5Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void GroupBy6Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void GroupBy7Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void GroupBy8Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void GroupJoinTest() {
		throw new NotImplementedException();
	}

	[Test]
	public void GroupJoin2Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void IntersectTest() {
		throw new NotImplementedException();
	}

	[Test]
	public void Intersect2Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void JoinTest() {
		throw new NotImplementedException();
	}

	[Test]
	public void Join2Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void LastTest() {
		throw new NotImplementedException();
	}

	[Test]
	public void Last2Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void LastOrDefaultTest() {
		throw new NotImplementedException();
	}

	[Test]
	public void LastOrDefault2Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void LongCountTest() {
		throw new NotImplementedException();
	}

	[Test]
	public void LongCount2Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void MaxTest() {
		throw new NotImplementedException();
	}

	[Test]
	public void Max2Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void MinTest() {
		throw new NotImplementedException();
	}

	[Test]
	public void Min2Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void OfTypeTest() {
		throw new NotImplementedException();
	}

	[Test]
	public void OrderByTest() {
		throw new NotImplementedException();
	}

	[Test]
	public void OrderBy2Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void OrderByDescendingTest() {
		throw new NotImplementedException();
	}

	[Test]
	public void OrderByDescending2Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void ReverseTest() {
		throw new NotImplementedException();
	}

	[Test]
	public void SelectTest() {
		throw new NotImplementedException();
	}

	[Test]
	public void Select2Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void SelectManyTest() {
		throw new NotImplementedException();
	}

	[Test]
	public void SelectMany2Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void SelectMany3Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void SelectMany4Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void SequenceEqualTest() {
		throw new NotImplementedException();
	}

	[Test]
	public void SequenceEqual2Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void SingleTest() {
		throw new NotImplementedException();
	}

	[Test]
	public void Single2Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void SingleOrDefaultTest() {
		throw new NotImplementedException();
	}

	[Test]
	public void SingleOrDefault2Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void SkipTest() {
		throw new NotImplementedException();
	}

	[Test]
	public void SkipWhileTest() {
		throw new NotImplementedException();
	}

	[Test]
	public void SkipWhile2Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void SumTest() {
		throw new NotImplementedException();
	}

	[Test]
	public void Sum10Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void Sum11Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void Sum12Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void Sum13Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void Sum14Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void Sum15Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void Sum16Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void Sum17Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void Sum18Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void Sum19Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void Sum2Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void Sum20Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void Sum3Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void Sum4Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void Sum5Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void Sum6Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void Sum7Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void Sum8Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void Sum9Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void TakeTest() {
		throw new NotImplementedException();
	}

	[Test]
	public void TakeWhileTest() {
		throw new NotImplementedException();
	}

	[Test]
	public void TakeWhile2Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void ThenByTest() {
		throw new NotImplementedException();
	}

	[Test]
	public void ThenBy2Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void ThenByDescendingTest() {
		throw new NotImplementedException();
	}

	[Test]
	public void ThenByDescending2Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void UnionTest() {
		throw new NotImplementedException();
	}

	[Test]
	public void Union2Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void WhereTest() {
		throw new NotImplementedException();
	}

	[Test]
	public void Where2Test() {
		throw new NotImplementedException();
	}

	[Test]
	public void ZipTest() {
		throw new NotImplementedException();
	}

}




