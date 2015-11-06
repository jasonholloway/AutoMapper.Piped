 
using Materialize.Reify2;
using Materialize.Reify2.Compiling;
using Materialize.Reify2.Parameterize;
using Materialize.Reify2.Transitions;
using Materialize.SourceRegimes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

[TestFixture]
public class ClientServerEquivalenceTests 
{

	class Item : IEquatable<Item> {
		public int Int { get; private set; }

		public Item(int i) {
			Int = i;
		}

        public bool Equals(Item other) {
            return other != null && Int == other.Int;
        }
    }

	class ItemComparer : IComparer<Item> {
		public int Compare(Item a, Item b) {
			return Comparer<int>.Default.Compare(a.Int, b.Int);
		}
	}

	static IQueryable<Item> Items { get; } = Enumerable.Range(25, 50).Select(i => new Item(i)).AsQueryable();
		
    static ParamMap _emptyParamMap = new ParamMap(Enumerable.Empty<ParamMap.Param>());
    static Expression _exBlank = Expression.Constant(0);
	static ISourceRegime _regime = new TolerantRegime();
			
    static Expression GetQuoted<T, T2>(Expression<Func<T, T2>> exFn) {
        return Expression.Quote(exFn);
    }

    static Expression GetQuoted<T, T2, T3>(Expression<Func<T, T2, T3>> exFn) {
        return Expression.Quote(exFn);
    }

    static Expression GetQuoted<T, T2, T3, T4>(Expression<Func<T, T2, T3, T4>> exFn) {
        return Expression.Quote(exFn);
    }


	

    static object ReifyOnClient(Transition t) 
    {
        var trans = new Transition[] {
            new SourceTransition(_regime, Items.Expression),
            new FetchTransition(_regime),
            t
        };

        var scheme = Schematizer.Schematize(trans, _emptyParamMap);
        var reifier = new Reifier(_exBlank, _emptyParamMap, scheme.Compile());

        return reifier.Execute(Items.Provider, _exBlank);
    }

    static object ReifyOnServer(Transition t) 
    {
        var trans = new Transition[] {
            new SourceTransition(_regime, Items.Expression),
            t
        };

        var scheme = Schematizer.Schematize(trans, _emptyParamMap);
        var reifier = new Reifier(_exBlank, _emptyParamMap, scheme.Compile());

        return reifier.Execute(Items.Provider, _exBlank);
    }





	[Test]
	public void AggregateTest() 
	{
		var t = new AggregateTransition() {
							Func = GetQuoted((Item i, Item j) => new Item(i.Int + j.Int)),
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Aggregate2Test() 
	{
		var t = new Aggregate2Transition() {
							Seed = Expression.Constant(Items.ElementAt(13)),
							Func = GetQuoted((Item i, Item j) => new Item(i.Int + j.Int)),
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Aggregate3Test() 
	{
		var t = new Aggregate3Transition() {
							Seed = Expression.Constant(Items.ElementAt(13)),
							Func = GetQuoted((Item i, Item j) => new Item(i.Int + j.Int)),
							ResultSelector = GetQuoted((Item i) => i),
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void AllTest() 
	{
		var t = new AllTransition() {
							Predicate = GetQuoted((Item i) => i.Int % 2 == 1),
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void AnyTest() 
	{
		var t = new AnyTransition() {
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Any2Test() 
	{
		var t = new Any2Transition() {
							Predicate = GetQuoted((Item i) => i.Int % 2 == 1),
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void AverageTest() 
	{
		var t = new AverageTransition() {
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Average10Test() 
	{
		var t = new Average10Transition() {
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Average11Test() 
	{
		var t = new Average11Transition() {
							Selector = GetQuoted((Item i) => i.Int * 3),
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Average12Test() 
	{
		var t = new Average12Transition() {
							Selector = GetQuoted((Item i) => i.Int * 3),
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Average13Test() 
	{
		var t = new Average13Transition() {
							Selector = GetQuoted((Item i) => i.Int * 3.5F),
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Average14Test() 
	{
		var t = new Average14Transition() {
							Selector = GetQuoted((Item i) => i.Int * 3.5F),
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Average15Test() 
	{
		var t = new Average15Transition() {
							Selector = GetQuoted((Item i) => i.Int * 13),
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Average16Test() 
	{
		var t = new Average16Transition() {
							Selector = GetQuoted((Item i) => i.Int * 13),
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Average17Test() 
	{
		var t = new Average17Transition() {
							Selector = GetQuoted((Item i) => i.Int * 0.73),
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Average18Test() 
	{
		var t = new Average18Transition() {
							Selector = GetQuoted((Item i) => i.Int * 0.73),
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Average19Test() 
	{
		var t = new Average19Transition() {
							Selector = GetQuoted((Item i) => i.Int * 3.67),
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Average2Test() 
	{
		var t = new Average2Transition() {
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Average20Test() 
	{
		var t = new Average20Transition() {
							Selector = GetQuoted((Item i) => i.Int * 3.67),
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Average3Test() 
	{
		var t = new Average3Transition() {
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Average4Test() 
	{
		var t = new Average4Transition() {
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Average5Test() 
	{
		var t = new Average5Transition() {
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Average6Test() 
	{
		var t = new Average6Transition() {
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Average7Test() 
	{
		var t = new Average7Transition() {
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Average8Test() 
	{
		var t = new Average8Transition() {
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Average9Test() 
	{
		var t = new Average9Transition() {
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void CastTest() 
	{
		var t = new CastTransition() {
					};

		var serverResult = (IEnumerable<Item>)ReifyOnServer(t);
		var clientResult = (IEnumerable<Item>)ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult).Using(new ItemComparer()));
	}


	[Test]
	public void ConcatTest() 
	{
		var t = new ConcatTransition() {
							Second = Expression.Constant(Items.Reverse()),
					};

		var serverResult = (IEnumerable<Item>)ReifyOnServer(t);
		var clientResult = (IEnumerable<Item>)ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult).Using(new ItemComparer()));
	}


	[Test]
	public void ContainsTest() 
	{
		var t = new ContainsTransition() {
							Value = Expression.Constant(Items.ElementAt(13)),
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Contains2Test() 
	{
		var t = new Contains2Transition() {
							Value = Expression.Constant(Items.ElementAt(13)),
							Comparer = Expression.Constant(new ItemComparer()),
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void CountTest() 
	{
		var t = new CountTransition() {
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Count2Test() 
	{
		var t = new Count2Transition() {
							Predicate = GetQuoted((Item i) => i.Int % 2 == 1),
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void DefaultIfEmptyTest() 
	{
		var t = new DefaultIfEmptyTransition() {
					};

		var serverResult = (IEnumerable<Item>)ReifyOnServer(t);
		var clientResult = (IEnumerable<Item>)ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult).Using(new ItemComparer()));
	}


	[Test]
	public void DefaultIfEmpty2Test() 
	{
		var t = new DefaultIfEmpty2Transition() {
							DefaultValue = Expression.Constant(Items.ElementAt(13)),
					};

		var serverResult = (IEnumerable<Item>)ReifyOnServer(t);
		var clientResult = (IEnumerable<Item>)ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult).Using(new ItemComparer()));
	}


	[Test]
	public void DistinctTest() 
	{
		var t = new DistinctTransition() {
					};

		var serverResult = (IEnumerable<Item>)ReifyOnServer(t);
		var clientResult = (IEnumerable<Item>)ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult).Using(new ItemComparer()));
	}


	[Test]
	public void Distinct2Test() 
	{
		var t = new Distinct2Transition() {
							Comparer = Expression.Constant(new ItemComparer()),
					};

		var serverResult = (IEnumerable<Item>)ReifyOnServer(t);
		var clientResult = (IEnumerable<Item>)ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult).Using(new ItemComparer()));
	}


	[Test]
	public void ElementAtTest() 
	{
		var t = new ElementAtTransition() {
							Index = Expression.Constant(17),
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void ElementAtOrDefaultTest() 
	{
		var t = new ElementAtOrDefaultTransition() {
							Index = Expression.Constant(17),
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void ExceptTest() 
	{
		var t = new ExceptTransition() {
							Second = Expression.Constant(Items.Reverse()),
					};

		var serverResult = (IEnumerable<Item>)ReifyOnServer(t);
		var clientResult = (IEnumerable<Item>)ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult).Using(new ItemComparer()));
	}


	[Test]
	public void Except2Test() 
	{
		var t = new Except2Transition() {
							Second = Expression.Constant(Items.Reverse()),
							Comparer = Expression.Constant(new ItemComparer()),
					};

		var serverResult = (IEnumerable<Item>)ReifyOnServer(t);
		var clientResult = (IEnumerable<Item>)ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult).Using(new ItemComparer()));
	}


	[Test]
	public void FirstTest() 
	{
		var t = new FirstTransition() {
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void First2Test() 
	{
		var t = new First2Transition() {
							Predicate = GetQuoted((Item i) => i.Int % 2 == 1),
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void FirstOrDefaultTest() 
	{
		var t = new FirstOrDefaultTransition() {
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void FirstOrDefault2Test() 
	{
		var t = new FirstOrDefault2Transition() {
							Predicate = GetQuoted((Item i) => i.Int % 2 == 1),
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void GroupByTest() 
	{
		var t = new GroupByTransition() {
							KeySelector = GetQuoted((Item i) => i.Int.ToString()),
					};

		var serverResult = (IEnumerable<Item>)ReifyOnServer(t);
		var clientResult = (IEnumerable<Item>)ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult).Using(new ItemComparer()));
	}


	[Test]
	public void GroupBy2Test() 
	{
		var t = new GroupBy2Transition() {
							KeySelector = GetQuoted((Item i) => i.Int.ToString()),
							ElementSelector = GetQuoted((Item i) => new Item(i.Int - 1)),
					};

		var serverResult = (IEnumerable<Item>)ReifyOnServer(t);
		var clientResult = (IEnumerable<Item>)ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult).Using(new ItemComparer()));
	}


	[Test]
	public void GroupBy3Test() 
	{
		var t = new GroupBy3Transition() {
							KeySelector = GetQuoted((Item i) => i.Int.ToString()),
							Comparer = Expression.Constant(EqualityComparer<string>.Default),
					};

		var serverResult = (IEnumerable<Item>)ReifyOnServer(t);
		var clientResult = (IEnumerable<Item>)ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult).Using(new ItemComparer()));
	}


	[Test]
	public void GroupBy4Test() 
	{
		var t = new GroupBy4Transition() {
							KeySelector = GetQuoted((Item i) => i.Int.ToString()),
							ElementSelector = GetQuoted((Item i) => new Item(i.Int - 1)),
							Comparer = Expression.Constant(EqualityComparer<string>.Default),
					};

		var serverResult = (IEnumerable<Item>)ReifyOnServer(t);
		var clientResult = (IEnumerable<Item>)ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult).Using(new ItemComparer()));
	}


	[Test]
	public void GroupBy5Test() 
	{
		var t = new GroupBy5Transition() {
							KeySelector = GetQuoted((Item i) => i.Int.ToString()),
							ElementSelector = GetQuoted((Item i) => new Item(i.Int - 1)),
							ResultSelector = GetQuoted((string k, IEnumerable<Item> r) => r.Last()),
					};

		var serverResult = (IEnumerable<Item>)ReifyOnServer(t);
		var clientResult = (IEnumerable<Item>)ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult).Using(new ItemComparer()));
	}


	[Test]
	public void GroupBy6Test() 
	{
		var t = new GroupBy6Transition() {
							KeySelector = GetQuoted((Item i) => i.Int.ToString()),
							ResultSelector = GetQuoted((string k, IEnumerable<Item> r) => r.Last()),
					};

		var serverResult = (IEnumerable<Item>)ReifyOnServer(t);
		var clientResult = (IEnumerable<Item>)ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult).Using(new ItemComparer()));
	}


	[Test]
	public void GroupBy7Test() 
	{
		var t = new GroupBy7Transition() {
							KeySelector = GetQuoted((Item i) => i.Int.ToString()),
							ResultSelector = GetQuoted((string k, IEnumerable<Item> r) => r.Last()),
							Comparer = Expression.Constant(EqualityComparer<string>.Default),
					};

		var serverResult = (IEnumerable<Item>)ReifyOnServer(t);
		var clientResult = (IEnumerable<Item>)ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult).Using(new ItemComparer()));
	}


	[Test]
	public void GroupBy8Test() 
	{
		var t = new GroupBy8Transition() {
							KeySelector = GetQuoted((Item i) => i.Int.ToString()),
							ElementSelector = GetQuoted((Item i) => new Item(i.Int - 1)),
							ResultSelector = GetQuoted((string k, IEnumerable<Item> r) => r.Last()),
							Comparer = Expression.Constant(EqualityComparer<string>.Default),
					};

		var serverResult = (IEnumerable<Item>)ReifyOnServer(t);
		var clientResult = (IEnumerable<Item>)ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult).Using(new ItemComparer()));
	}


	[Test]
	public void GroupJoinTest() 
	{
		var t = new GroupJoinTransition() {
							Inner = Expression.Constant(Items.Reverse()),
							OuterKeySelector = GetQuoted((Item i) => i.Int.ToString()),
							InnerKeySelector = GetQuoted((Item i) => i.Int.ToString()),
							ResultSelector = GetQuoted((Item o, IEnumerable<Item> r) => new Item(r.Last().Int + o.Int)),
					};

		var serverResult = (IEnumerable<Item>)ReifyOnServer(t);
		var clientResult = (IEnumerable<Item>)ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult).Using(new ItemComparer()));
	}


	[Test]
	public void GroupJoin2Test() 
	{
		var t = new GroupJoin2Transition() {
							Inner = Expression.Constant(Items.Reverse()),
							OuterKeySelector = GetQuoted((Item i) => i.Int.ToString()),
							InnerKeySelector = GetQuoted((Item i) => i.Int.ToString()),
							ResultSelector = GetQuoted((Item o, IEnumerable<Item> r) => new Item(r.Last().Int + o.Int)),
							Comparer = Expression.Constant(EqualityComparer<string>.Default),
					};

		var serverResult = (IEnumerable<Item>)ReifyOnServer(t);
		var clientResult = (IEnumerable<Item>)ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult).Using(new ItemComparer()));
	}


	[Test]
	public void IntersectTest() 
	{
		var t = new IntersectTransition() {
							Second = Expression.Constant(Items.Reverse()),
					};

		var serverResult = (IEnumerable<Item>)ReifyOnServer(t);
		var clientResult = (IEnumerable<Item>)ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult).Using(new ItemComparer()));
	}


	[Test]
	public void Intersect2Test() 
	{
		var t = new Intersect2Transition() {
							Second = Expression.Constant(Items.Reverse()),
							Comparer = Expression.Constant(new ItemComparer()),
					};

		var serverResult = (IEnumerable<Item>)ReifyOnServer(t);
		var clientResult = (IEnumerable<Item>)ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult).Using(new ItemComparer()));
	}


	[Test]
	public void JoinTest() 
	{
		var t = new JoinTransition() {
							Inner = Expression.Constant(Items.Reverse()),
							OuterKeySelector = GetQuoted((Item i) => i.Int.ToString()),
							InnerKeySelector = GetQuoted((Item i) => i.Int.ToString()),
							ResultSelector = GetQuoted((Item o, Item i) => new Item(o.Int - i.Int * 3)),
					};

		var serverResult = (IEnumerable<Item>)ReifyOnServer(t);
		var clientResult = (IEnumerable<Item>)ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult).Using(new ItemComparer()));
	}


	[Test]
	public void Join2Test() 
	{
		var t = new Join2Transition() {
							Inner = Expression.Constant(Items.Reverse()),
							OuterKeySelector = GetQuoted((Item i) => i.Int.ToString()),
							InnerKeySelector = GetQuoted((Item i) => i.Int.ToString()),
							ResultSelector = GetQuoted((Item o, Item i) => new Item(o.Int - i.Int * 3)),
							Comparer = Expression.Constant(EqualityComparer<string>.Default),
					};

		var serverResult = (IEnumerable<Item>)ReifyOnServer(t);
		var clientResult = (IEnumerable<Item>)ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult).Using(new ItemComparer()));
	}


	[Test]
	public void LastTest() 
	{
		var t = new LastTransition() {
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Last2Test() 
	{
		var t = new Last2Transition() {
							Predicate = GetQuoted((Item i) => i.Int % 2 == 1),
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void LastOrDefaultTest() 
	{
		var t = new LastOrDefaultTransition() {
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void LastOrDefault2Test() 
	{
		var t = new LastOrDefault2Transition() {
							Predicate = GetQuoted((Item i) => i.Int % 2 == 1),
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void LongCountTest() 
	{
		var t = new LongCountTransition() {
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void LongCount2Test() 
	{
		var t = new LongCount2Transition() {
							Predicate = GetQuoted((Item i) => i.Int % 2 == 1),
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void MaxTest() 
	{
		var t = new MaxTransition() {
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Max2Test() 
	{
		var t = new Max2Transition() {
							Selector = GetQuoted((Item i) => new Item(i.Int - 1)),
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void MinTest() 
	{
		var t = new MinTransition() {
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Min2Test() 
	{
		var t = new Min2Transition() {
							Selector = GetQuoted((Item i) => new Item(i.Int - 1)),
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void OfTypeTest() 
	{
		var t = new OfTypeTransition() {
					};

		var serverResult = (IEnumerable<Item>)ReifyOnServer(t);
		var clientResult = (IEnumerable<Item>)ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult).Using(new ItemComparer()));
	}


	[Test]
	public void OrderByTest() 
	{
		var t = new OrderByTransition() {
							KeySelector = GetQuoted((Item i) => i.Int.ToString()),
					};

		var serverResult = (IEnumerable<Item>)ReifyOnServer(t);
		var clientResult = (IEnumerable<Item>)ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult).Using(new ItemComparer()));
	}


	[Test]
	public void OrderBy2Test() 
	{
		var t = new OrderBy2Transition() {
							KeySelector = GetQuoted((Item i) => i.Int.ToString()),
							Comparer = Expression.Constant(StringComparer.Ordinal),
					};

		var serverResult = (IEnumerable<Item>)ReifyOnServer(t);
		var clientResult = (IEnumerable<Item>)ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult).Using(new ItemComparer()));
	}


	[Test]
	public void OrderByDescendingTest() 
	{
		var t = new OrderByDescendingTransition() {
							KeySelector = GetQuoted((Item i) => i.Int.ToString()),
					};

		var serverResult = (IEnumerable<Item>)ReifyOnServer(t);
		var clientResult = (IEnumerable<Item>)ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult).Using(new ItemComparer()));
	}


	[Test]
	public void OrderByDescending2Test() 
	{
		var t = new OrderByDescending2Transition() {
							KeySelector = GetQuoted((Item i) => i.Int.ToString()),
							Comparer = Expression.Constant(StringComparer.Ordinal),
					};

		var serverResult = (IEnumerable<Item>)ReifyOnServer(t);
		var clientResult = (IEnumerable<Item>)ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult).Using(new ItemComparer()));
	}


	[Test]
	public void ReverseTest() 
	{
		var t = new ReverseTransition() {
					};

		var serverResult = (IEnumerable<Item>)ReifyOnServer(t);
		var clientResult = (IEnumerable<Item>)ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult).Using(new ItemComparer()));
	}


	[Test]
	public void SelectTest() 
	{
		var t = new SelectTransition() {
							Selector = GetQuoted((Item i) => new Item(i.Int - 1)),
					};

		var serverResult = (IEnumerable<Item>)ReifyOnServer(t);
		var clientResult = (IEnumerable<Item>)ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult).Using(new ItemComparer()));
	}


	[Test]
	public void Select2Test() 
	{
		var t = new Select2Transition() {
							Selector = GetQuoted((Item s, int i) => new Item(s.Int * i)),
					};

		var serverResult = (IEnumerable<Item>)ReifyOnServer(t);
		var clientResult = (IEnumerable<Item>)ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult).Using(new ItemComparer()));
	}


	[Test]
	public void SelectManyTest() 
	{
		var t = new SelectManyTransition() {
							Selector = GetQuoted((Item i) => Enumerable.Repeat(i, i.Int + 30)),
					};

		var serverResult = (IEnumerable<Item>)ReifyOnServer(t);
		var clientResult = (IEnumerable<Item>)ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult).Using(new ItemComparer()));
	}


	[Test]
	public void SelectMany2Test() 
	{
		var t = new SelectMany2Transition() {
							Selector = GetQuoted((Item s, int i) => Enumerable.Repeat(s, i * 2)),
					};

		var serverResult = (IEnumerable<Item>)ReifyOnServer(t);
		var clientResult = (IEnumerable<Item>)ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult).Using(new ItemComparer()));
	}


	[Test]
	public void SelectMany3Test() 
	{
		var t = new SelectMany3Transition() {
							CollectionSelector = GetQuoted((Item s) => new[] { new List<Item>() }),
							ResultSelector = GetQuoted((Item s, List<Item> c) => s),
					};

		var serverResult = (IEnumerable<Item>)ReifyOnServer(t);
		var clientResult = (IEnumerable<Item>)ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult).Using(new ItemComparer()));
	}


	[Test]
	public void SelectMany4Test() 
	{
		var t = new SelectMany4Transition() {
							CollectionSelector = GetQuoted((Item s) => new[] { new List<Item>() }),
							ResultSelector = GetQuoted((Item s, List<Item> c) => s),
					};

		var serverResult = (IEnumerable<Item>)ReifyOnServer(t);
		var clientResult = (IEnumerable<Item>)ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult).Using(new ItemComparer()));
	}


	[Test]
	public void SequenceEqualTest() 
	{
		var t = new SequenceEqualTransition() {
							Second = Expression.Constant(Items.Reverse()),
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void SequenceEqual2Test() 
	{
		var t = new SequenceEqual2Transition() {
							Second = Expression.Constant(Items.Reverse()),
							Comparer = Expression.Constant(new ItemComparer()),
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void SingleTest() 
	{
		var t = new SingleTransition() {
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Single2Test() 
	{
		var t = new Single2Transition() {
							Predicate = GetQuoted((Item i) => i.Int % 2 == 1),
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void SingleOrDefaultTest() 
	{
		var t = new SingleOrDefaultTransition() {
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void SingleOrDefault2Test() 
	{
		var t = new SingleOrDefault2Transition() {
							Predicate = GetQuoted((Item i) => i.Int % 2 == 1),
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void SkipTest() 
	{
		var t = new SkipTransition() {
							Count = Expression.Constant(17),
					};

		var serverResult = (IEnumerable<Item>)ReifyOnServer(t);
		var clientResult = (IEnumerable<Item>)ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult).Using(new ItemComparer()));
	}


	[Test]
	public void SkipWhileTest() 
	{
		var t = new SkipWhileTransition() {
							Predicate = GetQuoted((Item i) => i.Int % 2 == 1),
					};

		var serverResult = (IEnumerable<Item>)ReifyOnServer(t);
		var clientResult = (IEnumerable<Item>)ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult).Using(new ItemComparer()));
	}


	[Test]
	public void SkipWhile2Test() 
	{
		var t = new SkipWhile2Transition() {
							Predicate = GetQuoted((Item s, int i) => s.Int + i < 10),
					};

		var serverResult = (IEnumerable<Item>)ReifyOnServer(t);
		var clientResult = (IEnumerable<Item>)ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult).Using(new ItemComparer()));
	}


	[Test]
	public void SumTest() 
	{
		var t = new SumTransition() {
							Selector = GetQuoted((Item i) => i.Int * 3.67),
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Sum10Test() 
	{
		var t = new Sum10Transition() {
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Sum11Test() 
	{
		var t = new Sum11Transition() {
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Sum12Test() 
	{
		var t = new Sum12Transition() {
							Selector = GetQuoted((Item i) => i.Int * 3),
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Sum13Test() 
	{
		var t = new Sum13Transition() {
							Selector = GetQuoted((Item i) => i.Int * 3),
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Sum14Test() 
	{
		var t = new Sum14Transition() {
							Selector = GetQuoted((Item i) => i.Int * 13),
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Sum15Test() 
	{
		var t = new Sum15Transition() {
							Selector = GetQuoted((Item i) => i.Int * 13),
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Sum16Test() 
	{
		var t = new Sum16Transition() {
							Selector = GetQuoted((Item i) => i.Int * 3.5F),
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Sum17Test() 
	{
		var t = new Sum17Transition() {
							Selector = GetQuoted((Item i) => i.Int * 3.5F),
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Sum18Test() 
	{
		var t = new Sum18Transition() {
							Selector = GetQuoted((Item i) => i.Int * 0.73),
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Sum19Test() 
	{
		var t = new Sum19Transition() {
							Selector = GetQuoted((Item i) => i.Int * 0.73),
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Sum2Test() 
	{
		var t = new Sum2Transition() {
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Sum20Test() 
	{
		var t = new Sum20Transition() {
							Selector = GetQuoted((Item i) => i.Int * 3.67),
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Sum3Test() 
	{
		var t = new Sum3Transition() {
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Sum4Test() 
	{
		var t = new Sum4Transition() {
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Sum5Test() 
	{
		var t = new Sum5Transition() {
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Sum6Test() 
	{
		var t = new Sum6Transition() {
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Sum7Test() 
	{
		var t = new Sum7Transition() {
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Sum8Test() 
	{
		var t = new Sum8Transition() {
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Sum9Test() 
	{
		var t = new Sum9Transition() {
					};

		var serverResult = ReifyOnServer(t);
		var clientResult = ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void TakeTest() 
	{
		var t = new TakeTransition() {
							Count = Expression.Constant(17),
					};

		var serverResult = (IEnumerable<Item>)ReifyOnServer(t);
		var clientResult = (IEnumerable<Item>)ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult).Using(new ItemComparer()));
	}


	[Test]
	public void TakeWhileTest() 
	{
		var t = new TakeWhileTransition() {
							Predicate = GetQuoted((Item i) => i.Int % 2 == 1),
					};

		var serverResult = (IEnumerable<Item>)ReifyOnServer(t);
		var clientResult = (IEnumerable<Item>)ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult).Using(new ItemComparer()));
	}


	[Test]
	public void TakeWhile2Test() 
	{
		var t = new TakeWhile2Transition() {
							Predicate = GetQuoted((Item s, int i) => s.Int + i < 10),
					};

		var serverResult = (IEnumerable<Item>)ReifyOnServer(t);
		var clientResult = (IEnumerable<Item>)ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult).Using(new ItemComparer()));
	}


	[Test]
	public void ThenByTest() 
	{
		var t = new ThenByTransition() {
							KeySelector = GetQuoted((Item i) => i.Int.ToString()),
					};

		var serverResult = (IEnumerable<Item>)ReifyOnServer(t);
		var clientResult = (IEnumerable<Item>)ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult).Using(new ItemComparer()));
	}


	[Test]
	public void ThenBy2Test() 
	{
		var t = new ThenBy2Transition() {
							KeySelector = GetQuoted((Item i) => i.Int.ToString()),
							Comparer = Expression.Constant(StringComparer.Ordinal),
					};

		var serverResult = (IEnumerable<Item>)ReifyOnServer(t);
		var clientResult = (IEnumerable<Item>)ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult).Using(new ItemComparer()));
	}


	[Test]
	public void ThenByDescendingTest() 
	{
		var t = new ThenByDescendingTransition() {
							KeySelector = GetQuoted((Item i) => i.Int.ToString()),
					};

		var serverResult = (IEnumerable<Item>)ReifyOnServer(t);
		var clientResult = (IEnumerable<Item>)ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult).Using(new ItemComparer()));
	}


	[Test]
	public void ThenByDescending2Test() 
	{
		var t = new ThenByDescending2Transition() {
							KeySelector = GetQuoted((Item i) => i.Int.ToString()),
							Comparer = Expression.Constant(StringComparer.Ordinal),
					};

		var serverResult = (IEnumerable<Item>)ReifyOnServer(t);
		var clientResult = (IEnumerable<Item>)ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult).Using(new ItemComparer()));
	}


	[Test]
	public void UnionTest() 
	{
		var t = new UnionTransition() {
							Second = Expression.Constant(Items.Reverse()),
					};

		var serverResult = (IEnumerable<Item>)ReifyOnServer(t);
		var clientResult = (IEnumerable<Item>)ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult).Using(new ItemComparer()));
	}


	[Test]
	public void Union2Test() 
	{
		var t = new Union2Transition() {
							Second = Expression.Constant(Items.Reverse()),
							Comparer = Expression.Constant(new ItemComparer()),
					};

		var serverResult = (IEnumerable<Item>)ReifyOnServer(t);
		var clientResult = (IEnumerable<Item>)ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult).Using(new ItemComparer()));
	}


	[Test]
	public void WhereTest() 
	{
		var t = new WhereTransition() {
							Predicate = GetQuoted((Item i) => i.Int % 2 == 1),
					};

		var serverResult = (IEnumerable<Item>)ReifyOnServer(t);
		var clientResult = (IEnumerable<Item>)ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult).Using(new ItemComparer()));
	}


	[Test]
	public void Where2Test() 
	{
		var t = new Where2Transition() {
							Predicate = GetQuoted((Item s, int i) => s.Int + i < 10),
					};

		var serverResult = (IEnumerable<Item>)ReifyOnServer(t);
		var clientResult = (IEnumerable<Item>)ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult).Using(new ItemComparer()));
	}


	[Test]
	public void ZipTest() 
	{
		var t = new ZipTransition() {
							Second = Expression.Constant(Items.Reverse()),
							ResultSelector = GetQuoted((Item a, Item b) => new Item(a.Int * b.Int)),
					};

		var serverResult = (IEnumerable<Item>)ReifyOnServer(t);
		var clientResult = (IEnumerable<Item>)ReifyOnClient(t);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult).Using(new ItemComparer()));
	}


}




