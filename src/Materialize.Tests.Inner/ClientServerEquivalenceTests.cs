 
using Materialize.Reify2;
using Materialize.Reify2.Compiling;
using Materialize.Reify2.Parameterize;
using Materialize.Reify2.Transitions;
using Materialize.SourceRegimes;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

[TestFixture]
public class ClientServerEquivalenceTests 
{

	class Item : IEquatable<Item>, IComparable<Item> {
		public int Int { get; private set; }

		public Item(int i) {
			Int = i;
		}

        public bool Equals(Item other) {
            return other != null && Int == other.Int;
        }

		public int CompareTo(Item other) {
			return ItemComparer.Default.Compare(this, other);
		}
    }

	class ItemComparer : IComparer<Item> {
		public static ItemComparer Default = new ItemComparer();

		public int Compare(Item a, Item b) {
			return Comparer<int>.Default.Compare(a.Int, b.Int);
		}
	}

	
	class ItemEqualityComparer : IEqualityComparer<Item> {		
        public bool Equals(Item x, Item y) {
            return x.Int == y.Int;
        }

        public int GetHashCode(Item obj) {
            return obj.Int.GetHashCode();
        }
    }



	static IQueryable<Item> Items { get; } = 
		new[] { 13, 20, 2, 22, 27, 6, 25, 7, 14, 1, 5, 26, 4, 3, 18, 21, 7, 21, 14, 8, 5, 3, 17, 14, 18, 8, 8, 12, 9, 24, 11, 16, 29, 11, 1, 7, 2, 23, 9, 28, 3, 2, 18, 2, 11, 2, 23, 5, 20, 10 }
			.Select(i => new Item(i)).AsQueryable();
		
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


	

    static object ReifyOnClient(IQueryable qySource, params Transition[] newTrans) 
    {
        var trans = new Transition[] {
            new SourceTransition(_regime, qySource.Expression),
            new FetchTransition(_regime)
        };

        var scheme = Schematizer.Schematize(trans.Concat(newTrans), _emptyParamMap);
        var reifier = new Reifier(_exBlank, _emptyParamMap, scheme.Compile());

        return reifier.Execute(qySource.Provider, _exBlank);
    }

    static object ReifyOnServer(IQueryable qySource, params Transition[] newTrans) 
    {
        var trans = new Transition[] {
            new SourceTransition(_regime, qySource.Expression)
        };

        var scheme = Schematizer.Schematize(trans.Concat(newTrans), _emptyParamMap);
        var reifier = new Reifier(_exBlank, _emptyParamMap, scheme.Compile());

        return reifier.Execute(qySource.Provider, _exBlank);
    }





	[Test]
	public void AggregateTest() 
	{
		var t0 = new AggregateTransition() {
				Func = GetQuoted((Item i, Item j) => new Item(i.Int + j.Int - 20)),
		};		
		
		var serverResult = ReifyOnServer(Items, t0);
		var clientResult = ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Aggregate2Test() 
	{
		var t0 = new Aggregate2Transition() {
				Seed = Expression.Constant(Items.ElementAt(6)),
				Func = GetQuoted((Item i, Item j) => new Item(i.Int + j.Int - 3)),
		};		
		
		var serverResult = ReifyOnServer(Items, t0);
		var clientResult = ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Aggregate3Test() 
	{
		var t0 = new Aggregate3Transition() {
				Seed = Expression.Constant(Items.ElementAt(10)),
				Func = GetQuoted((Item i, Item j) => new Item(i.Int + j.Int - 16)),
				ResultSelector = GetQuoted((Item i) => new Item(i.Int + 8)),
		};		
		
		var serverResult = ReifyOnServer(Items, t0);
		var clientResult = ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void AllTest() 
	{
		var t0 = new AllTransition() {
				Predicate = GetQuoted((Item i) => i.Int % 2 == 1),
		};		
		
		var serverResult = ReifyOnServer(Items, t0);
		var clientResult = ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void AnyTest() 
	{
		var t0 = new AnyTransition() {
		};		
		
		var serverResult = ReifyOnServer(Items, t0);
		var clientResult = ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Any2Test() 
	{
		var t0 = new Any2Transition() {
				Predicate = GetQuoted((Item i) => i.Int % 2 == 1),
		};		
		
		var serverResult = ReifyOnServer(Items, t0);
		var clientResult = ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void AverageTest() 
	{
		var t0 = new AverageTransition() {
		};		
		
		var serverResult = ReifyOnServer(Items.Select(i => (int)i.Int).AsQueryable(), t0);
		var clientResult = ReifyOnClient(Items.Select(i => (int)i.Int).AsQueryable(), t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Average10Test() 
	{
		var t0 = new Average10Transition() {
		};		
		
		var serverResult = ReifyOnServer(Items.Select(i => (decimal?)i.Int).AsQueryable(), t0);
		var clientResult = ReifyOnClient(Items.Select(i => (decimal?)i.Int).AsQueryable(), t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Average11Test() 
	{
		var t0 = new Average11Transition() {
				Selector = GetQuoted((Item i) => (int)(i.Int * 4)),
		};		
		
		var serverResult = ReifyOnServer(Items, t0);
		var clientResult = ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Average12Test() 
	{
		var t0 = new Average12Transition() {
				Selector = GetQuoted((Item i) => (int?)(i.Int * 14)),
		};		
		
		var serverResult = ReifyOnServer(Items, t0);
		var clientResult = ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Average13Test() 
	{
		var t0 = new Average13Transition() {
				Selector = GetQuoted((Item i) => (float)(i.Int * 20)),
		};		
		
		var serverResult = ReifyOnServer(Items, t0);
		var clientResult = ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Average14Test() 
	{
		var t0 = new Average14Transition() {
				Selector = GetQuoted((Item i) => (float?)(i.Int * 10)),
		};		
		
		var serverResult = ReifyOnServer(Items, t0);
		var clientResult = ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Average15Test() 
	{
		var t0 = new Average15Transition() {
				Selector = GetQuoted((Item i) => (long)(i.Int * 19)),
		};		
		
		var serverResult = ReifyOnServer(Items, t0);
		var clientResult = ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Average16Test() 
	{
		var t0 = new Average16Transition() {
				Selector = GetQuoted((Item i) => (long?)(i.Int * 13)),
		};		
		
		var serverResult = ReifyOnServer(Items, t0);
		var clientResult = ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Average17Test() 
	{
		var t0 = new Average17Transition() {
				Selector = GetQuoted((Item i) => (double)(i.Int * 14)),
		};		
		
		var serverResult = ReifyOnServer(Items, t0);
		var clientResult = ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Average18Test() 
	{
		var t0 = new Average18Transition() {
				Selector = GetQuoted((Item i) => (double?)(i.Int * 13)),
		};		
		
		var serverResult = ReifyOnServer(Items, t0);
		var clientResult = ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Average19Test() 
	{
		var t0 = new Average19Transition() {
				Selector = GetQuoted((Item i) => (decimal)(i.Int * 18)),
		};		
		
		var serverResult = ReifyOnServer(Items, t0);
		var clientResult = ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Average2Test() 
	{
		var t0 = new Average2Transition() {
		};		
		
		var serverResult = ReifyOnServer(Items.Select(i => (int?)i.Int).AsQueryable(), t0);
		var clientResult = ReifyOnClient(Items.Select(i => (int?)i.Int).AsQueryable(), t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Average20Test() 
	{
		var t0 = new Average20Transition() {
				Selector = GetQuoted((Item i) => (decimal?)(i.Int * 16)),
		};		
		
		var serverResult = ReifyOnServer(Items, t0);
		var clientResult = ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Average3Test() 
	{
		var t0 = new Average3Transition() {
		};		
		
		var serverResult = ReifyOnServer(Items.Select(i => (long)i.Int).AsQueryable(), t0);
		var clientResult = ReifyOnClient(Items.Select(i => (long)i.Int).AsQueryable(), t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Average4Test() 
	{
		var t0 = new Average4Transition() {
		};		
		
		var serverResult = ReifyOnServer(Items.Select(i => (long?)i.Int).AsQueryable(), t0);
		var clientResult = ReifyOnClient(Items.Select(i => (long?)i.Int).AsQueryable(), t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Average5Test() 
	{
		var t0 = new Average5Transition() {
		};		
		
		var serverResult = ReifyOnServer(Items.Select(i => (float)i.Int).AsQueryable(), t0);
		var clientResult = ReifyOnClient(Items.Select(i => (float)i.Int).AsQueryable(), t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Average6Test() 
	{
		var t0 = new Average6Transition() {
		};		
		
		var serverResult = ReifyOnServer(Items.Select(i => (float?)i.Int).AsQueryable(), t0);
		var clientResult = ReifyOnClient(Items.Select(i => (float?)i.Int).AsQueryable(), t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Average7Test() 
	{
		var t0 = new Average7Transition() {
		};		
		
		var serverResult = ReifyOnServer(Items.Select(i => (double)i.Int).AsQueryable(), t0);
		var clientResult = ReifyOnClient(Items.Select(i => (double)i.Int).AsQueryable(), t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Average8Test() 
	{
		var t0 = new Average8Transition() {
		};		
		
		var serverResult = ReifyOnServer(Items.Select(i => (double?)i.Int).AsQueryable(), t0);
		var clientResult = ReifyOnClient(Items.Select(i => (double?)i.Int).AsQueryable(), t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Average9Test() 
	{
		var t0 = new Average9Transition() {
		};		
		
		var serverResult = ReifyOnServer(Items.Select(i => (decimal)i.Int).AsQueryable(), t0);
		var clientResult = ReifyOnClient(Items.Select(i => (decimal)i.Int).AsQueryable(), t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void CastTest() 
	{
		var t0 = new CastTransition() {
		};		
		
		t0.SetTypeArg(0, typeof(Object));
		var serverResult = (IEnumerable)ReifyOnServer(Items, t0);
		var clientResult = (IEnumerable)ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult));
	}


	[Test]
	public void ConcatTest() 
	{
		var t0 = new ConcatTransition() {
				Second = Expression.Constant(Items.Reverse()),
		};		
		
		var serverResult = (IEnumerable)ReifyOnServer(Items, t0);
		var clientResult = (IEnumerable)ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult));
	}


	[Test]
	public void ContainsTest() 
	{
		var t0 = new ContainsTransition() {
				Value = Expression.Constant(Items.ElementAt(8)),
		};		
		
		var serverResult = ReifyOnServer(Items, t0);
		var clientResult = ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Contains2Test() 
	{
		var t0 = new Contains2Transition() {
				Value = Expression.Constant(Items.ElementAt(14)),
				Comparer = Expression.Constant(new ItemEqualityComparer()),
		};		
		
		var serverResult = ReifyOnServer(Items, t0);
		var clientResult = ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void CountTest() 
	{
		var t0 = new CountTransition() {
		};		
		
		var serverResult = ReifyOnServer(Items, t0);
		var clientResult = ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Count2Test() 
	{
		var t0 = new Count2Transition() {
				Predicate = GetQuoted((Item i) => i.Int % 2 == 1),
		};		
		
		var serverResult = ReifyOnServer(Items, t0);
		var clientResult = ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void DefaultIfEmptyTest() 
	{
		var t0 = new DefaultIfEmptyTransition() {
		};		
		
		var serverResult = (IEnumerable)ReifyOnServer(Items, t0);
		var clientResult = (IEnumerable)ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult));
	}


	[Test]
	public void DefaultIfEmpty2Test() 
	{
		var t0 = new DefaultIfEmpty2Transition() {
				DefaultValue = Expression.Constant(Items.ElementAt(11)),
		};		
		
		var serverResult = (IEnumerable)ReifyOnServer(Items, t0);
		var clientResult = (IEnumerable)ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult));
	}


	[Test]
	public void DistinctTest() 
	{
		var t0 = new DistinctTransition() {
		};		
		
		var serverResult = (IEnumerable)ReifyOnServer(Items, t0);
		var clientResult = (IEnumerable)ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult));
	}


	[Test]
	public void Distinct2Test() 
	{
		var t0 = new Distinct2Transition() {
				Comparer = Expression.Constant(new ItemEqualityComparer()),
		};		
		
		var serverResult = (IEnumerable)ReifyOnServer(Items, t0);
		var clientResult = (IEnumerable)ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult));
	}


	[Test]
	public void ElementAtTest() 
	{
		var t0 = new ElementAtTransition() {
				Index = Expression.Constant(2),
		};		
		
		var serverResult = ReifyOnServer(Items, t0);
		var clientResult = ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void ElementAtOrDefaultTest() 
	{
		var t0 = new ElementAtOrDefaultTransition() {
				Index = Expression.Constant(10),
		};		
		
		var serverResult = ReifyOnServer(Items, t0);
		var clientResult = ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void ExceptTest() 
	{
		var t0 = new ExceptTransition() {
				Second = Expression.Constant(Items.Reverse()),
		};		
		
		var serverResult = (IEnumerable)ReifyOnServer(Items, t0);
		var clientResult = (IEnumerable)ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult));
	}


	[Test]
	public void Except2Test() 
	{
		var t0 = new Except2Transition() {
				Second = Expression.Constant(Items.Reverse()),
				Comparer = Expression.Constant(new ItemEqualityComparer()),
		};		
		
		var serverResult = (IEnumerable)ReifyOnServer(Items, t0);
		var clientResult = (IEnumerable)ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult));
	}


	[Test]
	public void FirstTest() 
	{
		var t0 = new FirstTransition() {
		};		
		
		var serverResult = ReifyOnServer(Items, t0);
		var clientResult = ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void First2Test() 
	{
		var t0 = new First2Transition() {
				Predicate = GetQuoted((Item i) => i.Int % 2 == 1),
		};		
		
		var serverResult = ReifyOnServer(Items, t0);
		var clientResult = ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void FirstOrDefaultTest() 
	{
		var t0 = new FirstOrDefaultTransition() {
		};		
		
		var serverResult = ReifyOnServer(Items, t0);
		var clientResult = ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void FirstOrDefault2Test() 
	{
		var t0 = new FirstOrDefault2Transition() {
				Predicate = GetQuoted((Item i) => i.Int % 2 == 1),
		};		
		
		var serverResult = ReifyOnServer(Items, t0);
		var clientResult = ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void GroupByTest() 
	{
		var t0 = new GroupByTransition() {
				KeySelector = GetQuoted((Item i) => i.Int.ToString()),
		};		
		
		var serverResult = (IEnumerable)ReifyOnServer(Items, t0);
		var clientResult = (IEnumerable)ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult));
	}


	[Test]
	public void GroupBy2Test() 
	{
		var t0 = new GroupBy2Transition() {
				KeySelector = GetQuoted((Item i) => i.Int.ToString()),
				ElementSelector = GetQuoted((Item i) => new Item(i.Int - 1)),
		};		
		
		var serverResult = (IEnumerable)ReifyOnServer(Items, t0);
		var clientResult = (IEnumerable)ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult));
	}


	[Test]
	public void GroupBy3Test() 
	{
		var t0 = new GroupBy3Transition() {
				KeySelector = GetQuoted((Item i) => i.Int.ToString()),
				Comparer = Expression.Constant(EqualityComparer<string>.Default),
		};		
		
		var serverResult = (IEnumerable)ReifyOnServer(Items, t0);
		var clientResult = (IEnumerable)ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult));
	}


	[Test]
	public void GroupBy4Test() 
	{
		var t0 = new GroupBy4Transition() {
				KeySelector = GetQuoted((Item i) => i.Int.ToString()),
				ElementSelector = GetQuoted((Item i) => new Item(i.Int - 1)),
				Comparer = Expression.Constant(EqualityComparer<string>.Default),
		};		
		
		var serverResult = (IEnumerable)ReifyOnServer(Items, t0);
		var clientResult = (IEnumerable)ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult));
	}


	[Test]
	public void GroupBy5Test() 
	{
		var t0 = new GroupBy5Transition() {
				KeySelector = GetQuoted((Item i) => i.Int.ToString()),
				ElementSelector = GetQuoted((Item i) => new Item(i.Int - 1)),
				ResultSelector = GetQuoted((string k, IEnumerable<Item> r) => r.Last()),
		};		
		
		var serverResult = (IEnumerable)ReifyOnServer(Items, t0);
		var clientResult = (IEnumerable)ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult));
	}


	[Test]
	public void GroupBy6Test() 
	{
		var t0 = new GroupBy6Transition() {
				KeySelector = GetQuoted((Item i) => i.Int.ToString()),
				ResultSelector = GetQuoted((string k, IEnumerable<Item> r) => r.Last()),
		};		
		
		var serverResult = (IEnumerable)ReifyOnServer(Items, t0);
		var clientResult = (IEnumerable)ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult));
	}


	[Test]
	public void GroupBy7Test() 
	{
		var t0 = new GroupBy7Transition() {
				KeySelector = GetQuoted((Item i) => i.Int.ToString()),
				ResultSelector = GetQuoted((string k, IEnumerable<Item> r) => r.Last()),
				Comparer = Expression.Constant(EqualityComparer<string>.Default),
		};		
		
		var serverResult = (IEnumerable)ReifyOnServer(Items, t0);
		var clientResult = (IEnumerable)ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult));
	}


	[Test]
	public void GroupBy8Test() 
	{
		var t0 = new GroupBy8Transition() {
				KeySelector = GetQuoted((Item i) => i.Int.ToString()),
				ElementSelector = GetQuoted((Item i) => new Item(i.Int - 1)),
				ResultSelector = GetQuoted((string k, IEnumerable<Item> r) => r.Last()),
				Comparer = Expression.Constant(EqualityComparer<string>.Default),
		};		
		
		var serverResult = (IEnumerable)ReifyOnServer(Items, t0);
		var clientResult = (IEnumerable)ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult));
	}


	[Test]
	public void GroupJoinTest() 
	{
		var t0 = new GroupJoinTransition() {
				Inner = Expression.Constant(Items.Reverse()),
				OuterKeySelector = GetQuoted((Item i) => i.Int.ToString()),
				InnerKeySelector = GetQuoted((Item i) => i.Int.ToString()),
				ResultSelector = GetQuoted((Item o, IEnumerable<Item> r) => new Item(r.Last().Int + o.Int)),
		};		
		
		var serverResult = (IEnumerable)ReifyOnServer(Items, t0);
		var clientResult = (IEnumerable)ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult));
	}


	[Test]
	public void GroupJoin2Test() 
	{
		var t0 = new GroupJoin2Transition() {
				Inner = Expression.Constant(Items.Reverse()),
				OuterKeySelector = GetQuoted((Item i) => i.Int.ToString()),
				InnerKeySelector = GetQuoted((Item i) => i.Int.ToString()),
				ResultSelector = GetQuoted((Item o, IEnumerable<Item> r) => new Item(r.Last().Int + o.Int)),
				Comparer = Expression.Constant(EqualityComparer<string>.Default),
		};		
		
		var serverResult = (IEnumerable)ReifyOnServer(Items, t0);
		var clientResult = (IEnumerable)ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult));
	}


	[Test]
	public void IntersectTest() 
	{
		var t0 = new IntersectTransition() {
				Second = Expression.Constant(Items.Reverse()),
		};		
		
		var serverResult = (IEnumerable)ReifyOnServer(Items, t0);
		var clientResult = (IEnumerable)ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult));
	}


	[Test]
	public void Intersect2Test() 
	{
		var t0 = new Intersect2Transition() {
				Second = Expression.Constant(Items.Reverse()),
				Comparer = Expression.Constant(new ItemEqualityComparer()),
		};		
		
		var serverResult = (IEnumerable)ReifyOnServer(Items, t0);
		var clientResult = (IEnumerable)ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult));
	}


	[Test]
	public void JoinTest() 
	{
		var t0 = new JoinTransition() {
				Inner = Expression.Constant(Items.Reverse()),
				OuterKeySelector = GetQuoted((Item i) => i.Int.ToString()),
				InnerKeySelector = GetQuoted((Item i) => i.Int.ToString()),
				ResultSelector = GetQuoted((Item o, Item i) => new Item(o.Int - i.Int * 20)),
		};		
		
		var serverResult = (IEnumerable)ReifyOnServer(Items, t0);
		var clientResult = (IEnumerable)ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult));
	}


	[Test]
	public void Join2Test() 
	{
		var t0 = new Join2Transition() {
				Inner = Expression.Constant(Items.Reverse()),
				OuterKeySelector = GetQuoted((Item i) => i.Int.ToString()),
				InnerKeySelector = GetQuoted((Item i) => i.Int.ToString()),
				ResultSelector = GetQuoted((Item o, Item i) => new Item(o.Int - i.Int * 9)),
				Comparer = Expression.Constant(EqualityComparer<string>.Default),
		};		
		
		var serverResult = (IEnumerable)ReifyOnServer(Items, t0);
		var clientResult = (IEnumerable)ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult));
	}


	[Test]
	public void LastTest() 
	{
		var t0 = new LastTransition() {
		};		
		
		var serverResult = ReifyOnServer(Items, t0);
		var clientResult = ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Last2Test() 
	{
		var t0 = new Last2Transition() {
				Predicate = GetQuoted((Item i) => i.Int % 2 == 1),
		};		
		
		var serverResult = ReifyOnServer(Items, t0);
		var clientResult = ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void LastOrDefaultTest() 
	{
		var t0 = new LastOrDefaultTransition() {
		};		
		
		var serverResult = ReifyOnServer(Items, t0);
		var clientResult = ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void LastOrDefault2Test() 
	{
		var t0 = new LastOrDefault2Transition() {
				Predicate = GetQuoted((Item i) => i.Int % 2 == 1),
		};		
		
		var serverResult = ReifyOnServer(Items, t0);
		var clientResult = ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void LongCountTest() 
	{
		var t0 = new LongCountTransition() {
		};		
		
		var serverResult = ReifyOnServer(Items, t0);
		var clientResult = ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void LongCount2Test() 
	{
		var t0 = new LongCount2Transition() {
				Predicate = GetQuoted((Item i) => i.Int % 2 == 1),
		};		
		
		var serverResult = ReifyOnServer(Items, t0);
		var clientResult = ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void MaxTest() 
	{
		var t0 = new MaxTransition() {
		};		
		
		var serverResult = ReifyOnServer(Items, t0);
		var clientResult = ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Max2Test() 
	{
		var t0 = new Max2Transition() {
				Selector = GetQuoted((Item i) => new Item(i.Int - 1)),
		};		
		
		var serverResult = ReifyOnServer(Items, t0);
		var clientResult = ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void MinTest() 
	{
		var t0 = new MinTransition() {
		};		
		
		var serverResult = ReifyOnServer(Items, t0);
		var clientResult = ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Min2Test() 
	{
		var t0 = new Min2Transition() {
				Selector = GetQuoted((Item i) => new Item(i.Int - 1)),
		};		
		
		var serverResult = ReifyOnServer(Items, t0);
		var clientResult = ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void OfTypeTest() 
	{
		var t0 = new OfTypeTransition() {
		};		
		
		t0.SetTypeArg(0, typeof(Object));
		var serverResult = (IEnumerable)ReifyOnServer(Items, t0);
		var clientResult = (IEnumerable)ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult));
	}


	[Test]
	public void OrderByTest() 
	{
		var t0 = new OrderByTransition() {
				KeySelector = GetQuoted((Item i) => i.Int.ToString()),
		};		
		
		var serverResult = (IEnumerable)ReifyOnServer(Items, t0);
		var clientResult = (IEnumerable)ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult));
	}


	[Test]
	public void OrderBy2Test() 
	{
		var t0 = new OrderBy2Transition() {
				KeySelector = GetQuoted((Item i) => i.Int.ToString()),
				Comparer = Expression.Constant(StringComparer.Ordinal),
		};		
		
		var serverResult = (IEnumerable)ReifyOnServer(Items, t0);
		var clientResult = (IEnumerable)ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult));
	}


	[Test]
	public void OrderByDescendingTest() 
	{
		var t0 = new OrderByDescendingTransition() {
				KeySelector = GetQuoted((Item i) => i.Int.ToString()),
		};		
		
		var serverResult = (IEnumerable)ReifyOnServer(Items, t0);
		var clientResult = (IEnumerable)ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult));
	}


	[Test]
	public void OrderByDescending2Test() 
	{
		var t0 = new OrderByDescending2Transition() {
				KeySelector = GetQuoted((Item i) => i.Int.ToString()),
				Comparer = Expression.Constant(StringComparer.Ordinal),
		};		
		
		var serverResult = (IEnumerable)ReifyOnServer(Items, t0);
		var clientResult = (IEnumerable)ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult));
	}


	[Test]
	public void ReverseTest() 
	{
		var t0 = new ReverseTransition() {
		};		
		
		var serverResult = (IEnumerable)ReifyOnServer(Items, t0);
		var clientResult = (IEnumerable)ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult));
	}


	[Test]
	public void SelectTest() 
	{
		var t0 = new SelectTransition() {
				Selector = GetQuoted((Item i) => new Item(i.Int - 1)),
		};		
		
		var serverResult = (IEnumerable)ReifyOnServer(Items, t0);
		var clientResult = (IEnumerable)ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult));
	}


	[Test]
	public void Select2Test() 
	{
		var t0 = new Select2Transition() {
				Selector = GetQuoted((Item s, int i) => new Item(s.Int * i)),
		};		
		
		var serverResult = (IEnumerable)ReifyOnServer(Items, t0);
		var clientResult = (IEnumerable)ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult));
	}


	[Test]
	public void SelectManyTest() 
	{
		var t0 = new SelectManyTransition() {
				Selector = GetQuoted((Item i) => Enumerable.Repeat(i, i.Int + 1)),
		};		
		
		var serverResult = (IEnumerable)ReifyOnServer(Items, t0);
		var clientResult = (IEnumerable)ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult));
	}


	[Test]
	public void SelectMany2Test() 
	{
		var t0 = new SelectMany2Transition() {
				Selector = GetQuoted((Item s, int i) => Enumerable.Repeat(s, i + 8)),
		};		
		
		var serverResult = (IEnumerable)ReifyOnServer(Items, t0);
		var clientResult = (IEnumerable)ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult));
	}


	[Test]
	public void SelectMany3Test() 
	{
		var t0 = new SelectMany3Transition() {
				CollectionSelector = GetQuoted((Item s, int i) => Enumerable.Repeat(s, i + 7)),
				ResultSelector = GetQuoted((Item s, Item c) => new Item(s.Int - c.Int)),
		};		
		
		var serverResult = (IEnumerable)ReifyOnServer(Items, t0);
		var clientResult = (IEnumerable)ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult));
	}


	[Test]
	public void SelectMany4Test() 
	{
		var t0 = new SelectMany4Transition() {
				CollectionSelector = GetQuoted((Item i) => Enumerable.Repeat(i, i.Int + 5)),
				ResultSelector = GetQuoted((Item s, Item c) => new Item(s.Int - c.Int)),
		};		
		
		var serverResult = (IEnumerable)ReifyOnServer(Items, t0);
		var clientResult = (IEnumerable)ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult));
	}


	[Test]
	public void SequenceEqualTest() 
	{
		var t0 = new SequenceEqualTransition() {
				Second = Expression.Constant(Items.Reverse()),
		};		
		
		var serverResult = ReifyOnServer(Items, t0);
		var clientResult = ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void SequenceEqual2Test() 
	{
		var t0 = new SequenceEqual2Transition() {
				Second = Expression.Constant(Items.Reverse()),
				Comparer = Expression.Constant(new ItemEqualityComparer()),
		};		
		
		var serverResult = ReifyOnServer(Items, t0);
		var clientResult = ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void SingleTest() 
	{
		var t0 = new SingleTransition() {
		};		
		
		var serverResult = ReifyOnServer(Items.Where(i => i.Int % 2 == 1).Take(1), t0);
		var clientResult = ReifyOnClient(Items.Where(i => i.Int % 2 == 1).Take(1), t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Single2Test() 
	{
		var t0 = new Single2Transition() {
				Predicate = GetQuoted((Item i) => i.Int % 2 == 1),
		};		
		
		var serverResult = ReifyOnServer(Items.Where(i => i.Int % 2 == 1).Take(1), t0);
		var clientResult = ReifyOnClient(Items.Where(i => i.Int % 2 == 1).Take(1), t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void SingleOrDefaultTest() 
	{
		var t0 = new SingleOrDefaultTransition() {
		};		
		
		var serverResult = ReifyOnServer(Items.Where(i => i.Int % 2 == 1).Take(1), t0);
		var clientResult = ReifyOnClient(Items.Where(i => i.Int % 2 == 1).Take(1), t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void SingleOrDefault2Test() 
	{
		var t0 = new SingleOrDefault2Transition() {
				Predicate = GetQuoted((Item i) => i.Int % 2 == 1),
		};		
		
		var serverResult = ReifyOnServer(Items.Where(i => i.Int % 2 == 1).Take(1), t0);
		var clientResult = ReifyOnClient(Items.Where(i => i.Int % 2 == 1).Take(1), t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void SkipTest() 
	{
		var t0 = new SkipTransition() {
				Count = Expression.Constant(1),
		};		
		
		var serverResult = (IEnumerable)ReifyOnServer(Items, t0);
		var clientResult = (IEnumerable)ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult));
	}


	[Test]
	public void SkipWhileTest() 
	{
		var t0 = new SkipWhileTransition() {
				Predicate = GetQuoted((Item i) => i.Int % 2 == 1),
		};		
		
		var serverResult = (IEnumerable)ReifyOnServer(Items, t0);
		var clientResult = (IEnumerable)ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult));
	}


	[Test]
	public void SkipWhile2Test() 
	{
		var t0 = new SkipWhile2Transition() {
				Predicate = GetQuoted((Item s, int i) => s.Int + i < 3),
		};		
		
		var serverResult = (IEnumerable)ReifyOnServer(Items, t0);
		var clientResult = (IEnumerable)ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult));
	}


	[Test]
	public void SumTest() 
	{
		var t0 = new SumTransition() {
				Selector = GetQuoted((Item i) => (decimal?)(i.Int * 17)),
		};		
		
		var serverResult = ReifyOnServer(Items, t0);
		var clientResult = ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Sum10Test() 
	{
		var t0 = new Sum10Transition() {
		};		
		
		var serverResult = ReifyOnServer(Items.Select(i => (decimal)i.Int).AsQueryable(), t0);
		var clientResult = ReifyOnClient(Items.Select(i => (decimal)i.Int).AsQueryable(), t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Sum11Test() 
	{
		var t0 = new Sum11Transition() {
		};		
		
		var serverResult = ReifyOnServer(Items.Select(i => (decimal?)i.Int).AsQueryable(), t0);
		var clientResult = ReifyOnClient(Items.Select(i => (decimal?)i.Int).AsQueryable(), t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Sum12Test() 
	{
		var t0 = new Sum12Transition() {
				Selector = GetQuoted((Item i) => (int)(i.Int * 4)),
		};		
		
		var serverResult = ReifyOnServer(Items, t0);
		var clientResult = ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Sum13Test() 
	{
		var t0 = new Sum13Transition() {
				Selector = GetQuoted((Item i) => (int?)(i.Int * 3)),
		};		
		
		var serverResult = ReifyOnServer(Items, t0);
		var clientResult = ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Sum14Test() 
	{
		var t0 = new Sum14Transition() {
				Selector = GetQuoted((Item i) => (long)(i.Int * 16)),
		};		
		
		var serverResult = ReifyOnServer(Items, t0);
		var clientResult = ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Sum15Test() 
	{
		var t0 = new Sum15Transition() {
				Selector = GetQuoted((Item i) => (long?)(i.Int * 11)),
		};		
		
		var serverResult = ReifyOnServer(Items, t0);
		var clientResult = ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Sum16Test() 
	{
		var t0 = new Sum16Transition() {
				Selector = GetQuoted((Item i) => (float)(i.Int * 16)),
		};		
		
		var serverResult = ReifyOnServer(Items, t0);
		var clientResult = ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Sum17Test() 
	{
		var t0 = new Sum17Transition() {
				Selector = GetQuoted((Item i) => (float?)(i.Int * 18)),
		};		
		
		var serverResult = ReifyOnServer(Items, t0);
		var clientResult = ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Sum18Test() 
	{
		var t0 = new Sum18Transition() {
				Selector = GetQuoted((Item i) => (double)(i.Int * 14)),
		};		
		
		var serverResult = ReifyOnServer(Items, t0);
		var clientResult = ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Sum19Test() 
	{
		var t0 = new Sum19Transition() {
				Selector = GetQuoted((Item i) => (double?)(i.Int * 1)),
		};		
		
		var serverResult = ReifyOnServer(Items, t0);
		var clientResult = ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Sum2Test() 
	{
		var t0 = new Sum2Transition() {
		};		
		
		var serverResult = ReifyOnServer(Items.Select(i => (int)i.Int).AsQueryable(), t0);
		var clientResult = ReifyOnClient(Items.Select(i => (int)i.Int).AsQueryable(), t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Sum20Test() 
	{
		var t0 = new Sum20Transition() {
				Selector = GetQuoted((Item i) => (decimal)(i.Int * 9)),
		};		
		
		var serverResult = ReifyOnServer(Items, t0);
		var clientResult = ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Sum3Test() 
	{
		var t0 = new Sum3Transition() {
		};		
		
		var serverResult = ReifyOnServer(Items.Select(i => (int?)i.Int).AsQueryable(), t0);
		var clientResult = ReifyOnClient(Items.Select(i => (int?)i.Int).AsQueryable(), t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Sum4Test() 
	{
		var t0 = new Sum4Transition() {
		};		
		
		var serverResult = ReifyOnServer(Items.Select(i => (long)i.Int).AsQueryable(), t0);
		var clientResult = ReifyOnClient(Items.Select(i => (long)i.Int).AsQueryable(), t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Sum5Test() 
	{
		var t0 = new Sum5Transition() {
		};		
		
		var serverResult = ReifyOnServer(Items.Select(i => (long?)i.Int).AsQueryable(), t0);
		var clientResult = ReifyOnClient(Items.Select(i => (long?)i.Int).AsQueryable(), t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Sum6Test() 
	{
		var t0 = new Sum6Transition() {
		};		
		
		var serverResult = ReifyOnServer(Items.Select(i => (float)i.Int).AsQueryable(), t0);
		var clientResult = ReifyOnClient(Items.Select(i => (float)i.Int).AsQueryable(), t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Sum7Test() 
	{
		var t0 = new Sum7Transition() {
		};		
		
		var serverResult = ReifyOnServer(Items.Select(i => (float?)i.Int).AsQueryable(), t0);
		var clientResult = ReifyOnClient(Items.Select(i => (float?)i.Int).AsQueryable(), t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Sum8Test() 
	{
		var t0 = new Sum8Transition() {
		};		
		
		var serverResult = ReifyOnServer(Items.Select(i => (double)i.Int).AsQueryable(), t0);
		var clientResult = ReifyOnClient(Items.Select(i => (double)i.Int).AsQueryable(), t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void Sum9Test() 
	{
		var t0 = new Sum9Transition() {
		};		
		
		var serverResult = ReifyOnServer(Items.Select(i => (double?)i.Int).AsQueryable(), t0);
		var clientResult = ReifyOnClient(Items.Select(i => (double?)i.Int).AsQueryable(), t0);

		Assert.That(
				clientResult,
				Is.EqualTo(serverResult));
	}


	[Test]
	public void TakeTest() 
	{
		var t0 = new TakeTransition() {
				Count = Expression.Constant(15),
		};		
		
		var serverResult = (IEnumerable)ReifyOnServer(Items, t0);
		var clientResult = (IEnumerable)ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult));
	}


	[Test]
	public void TakeWhileTest() 
	{
		var t0 = new TakeWhileTransition() {
				Predicate = GetQuoted((Item i) => i.Int % 2 == 1),
		};		
		
		var serverResult = (IEnumerable)ReifyOnServer(Items, t0);
		var clientResult = (IEnumerable)ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult));
	}


	[Test]
	public void TakeWhile2Test() 
	{
		var t0 = new TakeWhile2Transition() {
				Predicate = GetQuoted((Item s, int i) => s.Int + i < 2),
		};		
		
		var serverResult = (IEnumerable)ReifyOnServer(Items, t0);
		var clientResult = (IEnumerable)ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult));
	}


	[Test]
	public void ThenByTest() 
	{
		var t0 = new OrderByTransition() {
				KeySelector = GetQuoted((Item i) => i.Int.ToString()),
		};		
		
		var t1 = new ThenByTransition() {
				KeySelector = GetQuoted((Item i) => i.Int.ToString()),
		};		
		
		var serverResult = (IEnumerable)ReifyOnServer(Items, t0, t1);
		var clientResult = (IEnumerable)ReifyOnClient(Items, t0, t1);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult));
	}


	[Test]
	public void ThenBy2Test() 
	{
		var t0 = new OrderByTransition() {
				KeySelector = GetQuoted((Item i) => i.Int.ToString()),
		};		
		
		var t1 = new ThenBy2Transition() {
				KeySelector = GetQuoted((Item i) => i.Int.ToString()),
				Comparer = Expression.Constant(StringComparer.Ordinal),
		};		
		
		var serverResult = (IEnumerable)ReifyOnServer(Items, t0, t1);
		var clientResult = (IEnumerable)ReifyOnClient(Items, t0, t1);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult));
	}


	[Test]
	public void ThenByDescendingTest() 
	{
		var t0 = new OrderByTransition() {
				KeySelector = GetQuoted((Item i) => i.Int.ToString()),
		};		
		
		var t1 = new ThenByDescendingTransition() {
				KeySelector = GetQuoted((Item i) => i.Int.ToString()),
		};		
		
		var serverResult = (IEnumerable)ReifyOnServer(Items, t0, t1);
		var clientResult = (IEnumerable)ReifyOnClient(Items, t0, t1);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult));
	}


	[Test]
	public void ThenByDescending2Test() 
	{
		var t0 = new OrderByTransition() {
				KeySelector = GetQuoted((Item i) => i.Int.ToString()),
		};		
		
		var t1 = new ThenByDescending2Transition() {
				KeySelector = GetQuoted((Item i) => i.Int.ToString()),
				Comparer = Expression.Constant(StringComparer.Ordinal),
		};		
		
		var serverResult = (IEnumerable)ReifyOnServer(Items, t0, t1);
		var clientResult = (IEnumerable)ReifyOnClient(Items, t0, t1);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult));
	}


	[Test]
	public void UnionTest() 
	{
		var t0 = new UnionTransition() {
				Second = Expression.Constant(Items.Reverse()),
		};		
		
		var serverResult = (IEnumerable)ReifyOnServer(Items, t0);
		var clientResult = (IEnumerable)ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult));
	}


	[Test]
	public void Union2Test() 
	{
		var t0 = new Union2Transition() {
				Second = Expression.Constant(Items.Reverse()),
				Comparer = Expression.Constant(new ItemEqualityComparer()),
		};		
		
		var serverResult = (IEnumerable)ReifyOnServer(Items, t0);
		var clientResult = (IEnumerable)ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult));
	}


	[Test]
	public void WhereTest() 
	{
		var t0 = new WhereTransition() {
				Predicate = GetQuoted((Item i) => i.Int % 2 == 1),
		};		
		
		var serverResult = (IEnumerable)ReifyOnServer(Items, t0);
		var clientResult = (IEnumerable)ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult));
	}


	[Test]
	public void Where2Test() 
	{
		var t0 = new Where2Transition() {
				Predicate = GetQuoted((Item s, int i) => s.Int + i < 6),
		};		
		
		var serverResult = (IEnumerable)ReifyOnServer(Items, t0);
		var clientResult = (IEnumerable)ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult));
	}


	[Test]
	public void ZipTest() 
	{
		var t0 = new ZipTransition() {
				Second = Expression.Constant(Items.Reverse()),
				ResultSelector = GetQuoted((Item a, Item b) => new Item(a.Int * b.Int + 15)),
		};		
		
		var serverResult = (IEnumerable)ReifyOnServer(Items, t0);
		var clientResult = (IEnumerable)ReifyOnClient(Items, t0);

		Assert.That(
				clientResult,
				Is.EquivalentTo(serverResult));
	}


}




