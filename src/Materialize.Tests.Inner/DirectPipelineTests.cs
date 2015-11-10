using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Materialize.Types;
using NUnit.Framework;
using Materialize;
using Materialize.Reify2.Parse;
using Materialize.Reify2;
using Materialize.SourceRegimes;

[TestFixture]
class DirectPipelineTests
{

	class Item : IComparable {
		public int Int;

		public Item(int i) {
			Int = i;
		}
		
        public int CompareTo(object obj) {
            return Comparer<int>.Default.Compare(Int, ((Item)obj).Int);
        }
	}
	
	class ItemComparer : IEqualityComparer<Item> {
		public static readonly ItemComparer Default = new ItemComparer();

		public bool Equals(Item a, Item b) {
			return a.Int == b.Int;
		}

		public int GetHashCode(Item i) {
			return i.Int;
		}
	}

	
    class GroupingComparer : IComparer<IGrouping<string, Item>>
    {
        public int Compare(IGrouping<string, Item> x, IGrouping<string, Item> y) {
            return Comparer<string>.Default.Compare(x.Key, y.Key);
        }
    }


	ReifiableFactory _reifiableFac = MaterializeServices.Resolve<ReifiableFactory>();


	[Test]
	public void AggregateTest() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.Aggregate<Item>((i, j) => new Item(i.Int + j.Int)).Int;

        Assert.That(
				result, 
				Is.EqualTo(qySource.Aggregate<Item>((i, j) => new Item(i.Int + j.Int)).Int));
	}

	[Test]
	public void Aggregate2Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.Aggregate<Item, Item>(qySource.ElementAt(13), (i, j) => new Item(i.Int + j.Int)).Int;

        Assert.That(
				result, 
				Is.EqualTo(qySource.Aggregate<Item, Item>(qySource.ElementAt(13), (i, j) => new Item(i.Int + j.Int)).Int));
	}

	[Test]
	public void Aggregate3Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.Aggregate<Item, Item, Item>(qySource.ElementAt(13), (i, j) => new Item(i.Int + j.Int), i => i).Int;

        Assert.That(
				result, 
				Is.EqualTo(qySource.Aggregate<Item, Item, Item>(qySource.ElementAt(13), (i, j) => new Item(i.Int + j.Int), i => i).Int));
	}

	[Test]
	public void AllTest() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.All<Item>(i => i.Int % 2 == 1);

        Assert.That(
				result, 
				Is.EqualTo(qySource.All<Item>(i => i.Int % 2 == 1)));
	}

	[Test]
	public void AnyTest() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.Any<Item>();

        Assert.That(
				result, 
				Is.EqualTo(qySource.Any<Item>()));
	}

	[Test]
	public void Any2Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.Any<Item>(i => i.Int % 2 == 1);

        Assert.That(
				result, 
				Is.EqualTo(qySource.Any<Item>(i => i.Int % 2 == 1)));
	}

	[Test]
	public void AverageTest() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => (Int32)i)
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Int32>(qySource.Expression)
								.Average();

        Assert.That(
				result, 
				Is.EqualTo(qySource.Average()));
	}

	[Test]
	public void Average2Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => (Nullable<Int32>)i)
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Nullable<Int32>>(qySource.Expression)
								.Average();

        Assert.That(
				result, 
				Is.EqualTo(qySource.Average()));
	}

	[Test]
	public void Average3Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => (Int64)i)
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Int64>(qySource.Expression)
								.Average();

        Assert.That(
				result, 
				Is.EqualTo(qySource.Average()));
	}

	[Test]
	public void Average4Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => (Nullable<Int64>)i)
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Nullable<Int64>>(qySource.Expression)
								.Average();

        Assert.That(
				result, 
				Is.EqualTo(qySource.Average()));
	}

	[Test]
	public void Average5Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => (Single)i)
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Single>(qySource.Expression)
								.Average();

        Assert.That(
				result, 
				Is.EqualTo(qySource.Average()));
	}

	[Test]
	public void Average6Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => (Nullable<Single>)i)
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Nullable<Single>>(qySource.Expression)
								.Average();

        Assert.That(
				result, 
				Is.EqualTo(qySource.Average()));
	}

	[Test]
	public void Average7Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => (Double)i)
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Double>(qySource.Expression)
								.Average();

        Assert.That(
				result, 
				Is.EqualTo(qySource.Average()));
	}

	[Test]
	public void Average8Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => (Nullable<Double>)i)
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Nullable<Double>>(qySource.Expression)
								.Average();

        Assert.That(
				result, 
				Is.EqualTo(qySource.Average()));
	}

	[Test]
	public void Average9Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => (Decimal)i)
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Decimal>(qySource.Expression)
								.Average();

        Assert.That(
				result, 
				Is.EqualTo(qySource.Average()));
	}

	[Test]
	public void Average10Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => (Nullable<Decimal>)i)
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Nullable<Decimal>>(qySource.Expression)
								.Average();

        Assert.That(
				result, 
				Is.EqualTo(qySource.Average()));
	}

	[Test]
	public void Average11Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.Average<Item>(i => i.Int * 3);

        Assert.That(
				result, 
				Is.EqualTo(qySource.Average<Item>(i => i.Int * 3)));
	}

	[Test]
	public void Average12Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.Average<Item>(i => i.Int * 3);

        Assert.That(
				result, 
				Is.EqualTo(qySource.Average<Item>(i => i.Int * 3)));
	}

	[Test]
	public void Average13Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.Average<Item>(i => i.Int * 3.5F);

        Assert.That(
				result, 
				Is.EqualTo(qySource.Average<Item>(i => i.Int * 3.5F)));
	}

	[Test]
	public void Average14Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.Average<Item>(i => i.Int * 3.5F);

        Assert.That(
				result, 
				Is.EqualTo(qySource.Average<Item>(i => i.Int * 3.5F)));
	}

	[Test]
	public void Average15Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.Average<Item>(i => i.Int * 13);

        Assert.That(
				result, 
				Is.EqualTo(qySource.Average<Item>(i => i.Int * 13)));
	}

	[Test]
	public void Average16Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.Average<Item>(i => i.Int * 13);

        Assert.That(
				result, 
				Is.EqualTo(qySource.Average<Item>(i => i.Int * 13)));
	}

	[Test]
	public void Average17Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.Average<Item>(i => i.Int * 0.73);

        Assert.That(
				result, 
				Is.EqualTo(qySource.Average<Item>(i => i.Int * 0.73)));
	}

	[Test]
	public void Average18Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.Average<Item>(i => i.Int * 0.73);

        Assert.That(
				result, 
				Is.EqualTo(qySource.Average<Item>(i => i.Int * 0.73)));
	}

	[Test]
	public void Average19Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.Average<Item>(i => i.Int * 3.67);

        Assert.That(
				result, 
				Is.EqualTo(qySource.Average<Item>(i => i.Int * 3.67)));
	}

	[Test]
	public void Average20Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.Average<Item>(i => i.Int * 3.67);

        Assert.That(
				result, 
				Is.EqualTo(qySource.Average<Item>(i => i.Int * 3.67)));
	}

	[Test]
	public void CastTest() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.Cast<Item>().Select(i => i.Int);

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.Cast<Item>().Select(i => i.Int)));
	}

	[Test]
	public void ConcatTest() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.Concat<Item>(qySource.Reverse()).Select(i => i.Int);

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.Concat<Item>(qySource.Reverse()).Select(i => i.Int)));
	}

	[Test]
	public void ContainsTest() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.Contains<Item>(qySource.ElementAt(13));

        Assert.That(
				result, 
				Is.EqualTo(qySource.Contains<Item>(qySource.ElementAt(13))));
	}

	[Test]
	public void Contains2Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.Contains<Item>(qySource.ElementAt(13), ItemComparer.Default);

        Assert.That(
				result, 
				Is.EqualTo(qySource.Contains<Item>(qySource.ElementAt(13), ItemComparer.Default)));
	}

	[Test]
	public void CountTest() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.Count<Item>();

        Assert.That(
				result, 
				Is.EqualTo(qySource.Count<Item>()));
	}

	[Test]
	public void Count2Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.Count<Item>(i => i.Int % 2 == 1);

        Assert.That(
				result, 
				Is.EqualTo(qySource.Count<Item>(i => i.Int % 2 == 1)));
	}

	[Test]
	public void DefaultIfEmptyTest() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.DefaultIfEmpty<Item>().Select(i => i.Int);

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.DefaultIfEmpty<Item>().Select(i => i.Int)));
	}

	[Test]
	public void DefaultIfEmpty2Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.DefaultIfEmpty<Item>(qySource.ElementAt(13)).Select(i => i.Int);

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.DefaultIfEmpty<Item>(qySource.ElementAt(13)).Select(i => i.Int)));
	}

	[Test]
	public void DistinctTest() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.Distinct<Item>().Select(i => i.Int);

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.Distinct<Item>().Select(i => i.Int)));
	}

	[Test]
	public void Distinct2Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.Distinct<Item>(ItemComparer.Default).Select(i => i.Int);

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.Distinct<Item>(ItemComparer.Default).Select(i => i.Int)));
	}

	[Test]
	public void ElementAtTest() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.ElementAt<Item>(17).Int;

        Assert.That(
				result, 
				Is.EqualTo(qySource.ElementAt<Item>(17).Int));
	}

	[Test]
	public void ElementAtOrDefaultTest() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.ElementAtOrDefault<Item>(17).Int;

        Assert.That(
				result, 
				Is.EqualTo(qySource.ElementAtOrDefault<Item>(17).Int));
	}

	[Test]
	public void ExceptTest() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.Except<Item>(qySource.Reverse()).Select(i => i.Int);

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.Except<Item>(qySource.Reverse()).Select(i => i.Int)));
	}

	[Test]
	public void Except2Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.Except<Item>(qySource.Reverse(), ItemComparer.Default).Select(i => i.Int);

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.Except<Item>(qySource.Reverse(), ItemComparer.Default).Select(i => i.Int)));
	}

	[Test]
	public void FirstTest() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.First<Item>().Int;

        Assert.That(
				result, 
				Is.EqualTo(qySource.First<Item>().Int));
	}

	[Test]
	public void First2Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.First<Item>(i => i.Int % 2 == 1).Int;

        Assert.That(
				result, 
				Is.EqualTo(qySource.First<Item>(i => i.Int % 2 == 1).Int));
	}

	[Test]
	public void FirstOrDefaultTest() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.FirstOrDefault<Item>().Int;

        Assert.That(
				result, 
				Is.EqualTo(qySource.FirstOrDefault<Item>().Int));
	}

	[Test]
	public void FirstOrDefault2Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.FirstOrDefault<Item>(i => i.Int % 2 == 1).Int;

        Assert.That(
				result, 
				Is.EqualTo(qySource.FirstOrDefault<Item>(i => i.Int % 2 == 1).Int));
	}

	[Test]
	public void GroupByTest() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.GroupBy<Item, string>(i => i.Int.ToString());

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.GroupBy<Item, string>(i => i.Int.ToString()))
					.Using(new GroupingComparer()));
	}

	[Test]
	public void GroupBy2Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.GroupBy<Item, string, Item>(i => i.Int.ToString(), i => new Item(i.Int - 1));

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.GroupBy<Item, string, Item>(i => i.Int.ToString(), i => new Item(i.Int - 1)))
					.Using(new GroupingComparer()));
	}

	[Test]
	public void GroupBy3Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.GroupBy<Item, string>(i => i.Int.ToString(), EqualityComparer<string>.Default);

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.GroupBy<Item, string>(i => i.Int.ToString(), EqualityComparer<string>.Default))
					.Using(new GroupingComparer()));
	}

	[Test]
	public void GroupBy4Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.GroupBy<Item, string, Item>(i => i.Int.ToString(), i => new Item(i.Int - 1), EqualityComparer<string>.Default);

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.GroupBy<Item, string, Item>(i => i.Int.ToString(), i => new Item(i.Int - 1), EqualityComparer<string>.Default))
					.Using(new GroupingComparer()));
	}

	[Test]
	public void GroupBy5Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.GroupBy<Item, string, Item, Item>(i => i.Int.ToString(), i => new Item(i.Int - 1), (k, r) => r.Last()).Select(i => i.Int);

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.GroupBy<Item, string, Item, Item>(i => i.Int.ToString(), i => new Item(i.Int - 1), (k, r) => r.Last()).Select(i => i.Int))
					.Using(new GroupingComparer()));
	}

	[Test]
	public void GroupBy6Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.GroupBy<Item, string, Item>(i => i.Int.ToString(), (k, r) => r.Last()).Select(i => i.Int);

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.GroupBy<Item, string, Item>(i => i.Int.ToString(), (k, r) => r.Last()).Select(i => i.Int))
					.Using(new GroupingComparer()));
	}

	[Test]
	public void GroupBy7Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.GroupBy<Item, string, Item>(i => i.Int.ToString(), (k, r) => r.Last(), EqualityComparer<string>.Default).Select(i => i.Int);

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.GroupBy<Item, string, Item>(i => i.Int.ToString(), (k, r) => r.Last(), EqualityComparer<string>.Default).Select(i => i.Int))
					.Using(new GroupingComparer()));
	}

	[Test]
	public void GroupBy8Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.GroupBy<Item, string, Item, Item>(i => i.Int.ToString(), i => new Item(i.Int - 1), (k, r) => r.Last(), EqualityComparer<string>.Default).Select(i => i.Int);

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.GroupBy<Item, string, Item, Item>(i => i.Int.ToString(), i => new Item(i.Int - 1), (k, r) => r.Last(), EqualityComparer<string>.Default).Select(i => i.Int))
					.Using(new GroupingComparer()));
	}

	[Test]
	public void GroupJoinTest() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.GroupJoin<Item, Item, string, Item>(qySource.Reverse(), i => i.Int.ToString(), i => i.Int.ToString(), (o, r) => new Item(r.Last().Int + o.Int)).Select(i => i.Int);

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.GroupJoin<Item, Item, string, Item>(qySource.Reverse(), i => i.Int.ToString(), i => i.Int.ToString(), (o, r) => new Item(r.Last().Int + o.Int)).Select(i => i.Int))
					.Using(new GroupingComparer()));
	}

	[Test]
	public void GroupJoin2Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.GroupJoin<Item, Item, string, Item>(qySource.Reverse(), i => i.Int.ToString(), i => i.Int.ToString(), (o, r) => new Item(r.Last().Int + o.Int), EqualityComparer<string>.Default).Select(i => i.Int);

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.GroupJoin<Item, Item, string, Item>(qySource.Reverse(), i => i.Int.ToString(), i => i.Int.ToString(), (o, r) => new Item(r.Last().Int + o.Int), EqualityComparer<string>.Default).Select(i => i.Int))
					.Using(new GroupingComparer()));
	}

	[Test]
	public void IntersectTest() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.Intersect<Item>(qySource.Reverse()).Select(i => i.Int);

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.Intersect<Item>(qySource.Reverse()).Select(i => i.Int)));
	}

	[Test]
	public void Intersect2Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.Intersect<Item>(qySource.Reverse(), ItemComparer.Default).Select(i => i.Int);

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.Intersect<Item>(qySource.Reverse(), ItemComparer.Default).Select(i => i.Int)));
	}

	[Test]
	public void JoinTest() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.Join<Item, Item, string, Item>(qySource.Reverse(), i => i.Int.ToString(), i => i.Int.ToString(), (o, i) => new Item(o.Int - i.Int * 3)).Select(i => i.Int);

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.Join<Item, Item, string, Item>(qySource.Reverse(), i => i.Int.ToString(), i => i.Int.ToString(), (o, i) => new Item(o.Int - i.Int * 3)).Select(i => i.Int)));
	}

	[Test]
	public void Join2Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.Join<Item, Item, string, Item>(qySource.Reverse(), i => i.Int.ToString(), i => i.Int.ToString(), (o, i) => new Item(o.Int - i.Int * 3), EqualityComparer<string>.Default).Select(i => i.Int);

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.Join<Item, Item, string, Item>(qySource.Reverse(), i => i.Int.ToString(), i => i.Int.ToString(), (o, i) => new Item(o.Int - i.Int * 3), EqualityComparer<string>.Default).Select(i => i.Int)));
	}

	[Test]
	public void LastTest() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.Last<Item>().Int;

        Assert.That(
				result, 
				Is.EqualTo(qySource.Last<Item>().Int));
	}

	[Test]
	public void Last2Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.Last<Item>(i => i.Int % 2 == 1).Int;

        Assert.That(
				result, 
				Is.EqualTo(qySource.Last<Item>(i => i.Int % 2 == 1).Int));
	}

	[Test]
	public void LastOrDefaultTest() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.LastOrDefault<Item>().Int;

        Assert.That(
				result, 
				Is.EqualTo(qySource.LastOrDefault<Item>().Int));
	}

	[Test]
	public void LastOrDefault2Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.LastOrDefault<Item>(i => i.Int % 2 == 1).Int;

        Assert.That(
				result, 
				Is.EqualTo(qySource.LastOrDefault<Item>(i => i.Int % 2 == 1).Int));
	}

	[Test]
	public void LongCountTest() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.LongCount<Item>();

        Assert.That(
				result, 
				Is.EqualTo(qySource.LongCount<Item>()));
	}

	[Test]
	public void LongCount2Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.LongCount<Item>(i => i.Int % 2 == 1);

        Assert.That(
				result, 
				Is.EqualTo(qySource.LongCount<Item>(i => i.Int % 2 == 1)));
	}

	[Test]
	public void MaxTest() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.Max<Item>().Int;

        Assert.That(
				result, 
				Is.EqualTo(qySource.Max<Item>().Int));
	}

	[Test]
	public void Max2Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.Max<Item, Item>(i => new Item(i.Int - 1)).Int;

        Assert.That(
				result, 
				Is.EqualTo(qySource.Max<Item, Item>(i => new Item(i.Int - 1)).Int));
	}

	[Test]
	public void MinTest() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.Min<Item>().Int;

        Assert.That(
				result, 
				Is.EqualTo(qySource.Min<Item>().Int));
	}

	[Test]
	public void Min2Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.Min<Item, Item>(i => new Item(i.Int - 1)).Int;

        Assert.That(
				result, 
				Is.EqualTo(qySource.Min<Item, Item>(i => new Item(i.Int - 1)).Int));
	}

	[Test]
	public void OfTypeTest() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.OfType<Item>().Select(i => i.Int);

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.OfType<Item>().Select(i => i.Int)));
	}

	[Test]
	public void OrderByTest() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.OrderBy<Item, string>(i => i.Int.ToString()).Select(i => i.Int);

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.OrderBy<Item, string>(i => i.Int.ToString()).Select(i => i.Int)));
	}

	[Test]
	public void OrderBy2Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.OrderBy<Item, string>(i => i.Int.ToString(), StringComparer.Ordinal).Select(i => i.Int);

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.OrderBy<Item, string>(i => i.Int.ToString(), StringComparer.Ordinal).Select(i => i.Int)));
	}

	[Test]
	public void OrderByDescendingTest() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.OrderByDescending<Item, string>(i => i.Int.ToString()).Select(i => i.Int);

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.OrderByDescending<Item, string>(i => i.Int.ToString()).Select(i => i.Int)));
	}

	[Test]
	public void OrderByDescending2Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.OrderByDescending<Item, string>(i => i.Int.ToString(), StringComparer.Ordinal).Select(i => i.Int);

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.OrderByDescending<Item, string>(i => i.Int.ToString(), StringComparer.Ordinal).Select(i => i.Int)));
	}

	[Test]
	public void ReverseTest() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.Reverse<Item>().Select(i => i.Int);

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.Reverse<Item>().Select(i => i.Int)));
	}

	[Test]
	public void SelectTest() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.Select<Item, Item>(i => new Item(i.Int - 1)).Select(i => i.Int);

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.Select<Item, Item>(i => new Item(i.Int - 1)).Select(i => i.Int)));
	}

	[Test]
	public void Select2Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.Select<Item, Item>((s, i) => new Item(s.Int * i)).Select(i => i.Int);

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.Select<Item, Item>((s, i) => new Item(s.Int * i)).Select(i => i.Int)));
	}

	[Test]
	public void SelectManyTest() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.SelectMany<Item, Item>(i => Enumerable.Repeat(i, i.Int + 30)).Select(i => i.Int);

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.SelectMany<Item, Item>(i => Enumerable.Repeat(i, i.Int + 30)).Select(i => i.Int)));
	}

	[Test]
	public void SelectMany2Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.SelectMany<Item, Item>((s, i) => Enumerable.Repeat(s, i * 2)).Select(i => i.Int);

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.SelectMany<Item, Item>((s, i) => Enumerable.Repeat(s, i * 2)).Select(i => i.Int)));
	}

	[Test]
	public void SelectMany3Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.SelectMany<Item, List<Item>, Item>(s => new[] { new List<Item>() }, (s, c) => s).Select(i => i.Int);

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.SelectMany<Item, List<Item>, Item>(s => new[] { new List<Item>() }, (s, c) => s).Select(i => i.Int)));
	}

	[Test]
	public void SelectMany4Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.SelectMany<Item, List<Item>, Item>(s => new[] { new List<Item>() }, (s, c) => s).Select(i => i.Int);

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.SelectMany<Item, List<Item>, Item>(s => new[] { new List<Item>() }, (s, c) => s).Select(i => i.Int)));
	}

	[Test]
	public void SequenceEqualTest() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.SequenceEqual<Item>(qySource.Reverse());

        Assert.That(
				result, 
				Is.EqualTo(qySource.SequenceEqual<Item>(qySource.Reverse())));
	}

	[Test]
	public void SequenceEqual2Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.SequenceEqual<Item>(qySource.Reverse(), ItemComparer.Default);

        Assert.That(
				result, 
				Is.EqualTo(qySource.SequenceEqual<Item>(qySource.Reverse(), ItemComparer.Default)));
	}

	[Test]
	public void SingleTest() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.Skip(33).Take(1)
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.Single<Item>().Int;

        Assert.That(
				result, 
				Is.EqualTo(qySource.Single<Item>().Int));
	}

	[Test]
	public void Single2Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.Skip(33).Take(1)
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.Single<Item>(i => i.Int % 2 == 1).Int;

        Assert.That(
				result, 
				Is.EqualTo(qySource.Single<Item>(i => i.Int % 2 == 1).Int));
	}

	[Test]
	public void SingleOrDefaultTest() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.Skip(33).Take(1)
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.SingleOrDefault<Item>().Int;

        Assert.That(
				result, 
				Is.EqualTo(qySource.SingleOrDefault<Item>().Int));
	}

	[Test]
	public void SingleOrDefault2Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.Skip(33).Take(1)
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.SingleOrDefault<Item>(i => i.Int % 2 == 1).Int;

        Assert.That(
				result, 
				Is.EqualTo(qySource.SingleOrDefault<Item>(i => i.Int % 2 == 1).Int));
	}

	[Test]
	public void SkipTest() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.Skip<Item>(17).Select(i => i.Int);

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.Skip<Item>(17).Select(i => i.Int)));
	}

	[Test]
	public void SkipWhileTest() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.SkipWhile<Item>(i => i.Int % 2 == 1).Select(i => i.Int);

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.SkipWhile<Item>(i => i.Int % 2 == 1).Select(i => i.Int)));
	}

	[Test]
	public void SkipWhile2Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.SkipWhile<Item>((s, i) => s.Int + i < 10).Select(i => i.Int);

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.SkipWhile<Item>((s, i) => s.Int + i < 10).Select(i => i.Int)));
	}

	[Test]
	public void SumTest() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.Sum<Item>(i => i.Int * 3.67);

        Assert.That(
				result, 
				Is.EqualTo(qySource.Sum<Item>(i => i.Int * 3.67)));
	}

	[Test]
	public void Sum2Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => (Int32)i)
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Int32>(qySource.Expression)
								.Sum();

        Assert.That(
				result, 
				Is.EqualTo(qySource.Sum()));
	}

	[Test]
	public void Sum3Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => (Nullable<Int32>)i)
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Nullable<Int32>>(qySource.Expression)
								.Sum();

        Assert.That(
				result, 
				Is.EqualTo(qySource.Sum()));
	}

	[Test]
	public void Sum4Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => (Int64)i)
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Int64>(qySource.Expression)
								.Sum();

        Assert.That(
				result, 
				Is.EqualTo(qySource.Sum()));
	}

	[Test]
	public void Sum5Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => (Nullable<Int64>)i)
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Nullable<Int64>>(qySource.Expression)
								.Sum();

        Assert.That(
				result, 
				Is.EqualTo(qySource.Sum()));
	}

	[Test]
	public void Sum6Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => (Single)i)
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Single>(qySource.Expression)
								.Sum();

        Assert.That(
				result, 
				Is.EqualTo(qySource.Sum()));
	}

	[Test]
	public void Sum7Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => (Nullable<Single>)i)
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Nullable<Single>>(qySource.Expression)
								.Sum();

        Assert.That(
				result, 
				Is.EqualTo(qySource.Sum()));
	}

	[Test]
	public void Sum8Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => (Double)i)
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Double>(qySource.Expression)
								.Sum();

        Assert.That(
				result, 
				Is.EqualTo(qySource.Sum()));
	}

	[Test]
	public void Sum9Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => (Nullable<Double>)i)
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Nullable<Double>>(qySource.Expression)
								.Sum();

        Assert.That(
				result, 
				Is.EqualTo(qySource.Sum()));
	}

	[Test]
	public void Sum10Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => (Decimal)i)
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Decimal>(qySource.Expression)
								.Sum();

        Assert.That(
				result, 
				Is.EqualTo(qySource.Sum()));
	}

	[Test]
	public void Sum11Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => (Nullable<Decimal>)i)
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Nullable<Decimal>>(qySource.Expression)
								.Sum();

        Assert.That(
				result, 
				Is.EqualTo(qySource.Sum()));
	}

	[Test]
	public void Sum12Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.Sum<Item>(i => i.Int * 3);

        Assert.That(
				result, 
				Is.EqualTo(qySource.Sum<Item>(i => i.Int * 3)));
	}

	[Test]
	public void Sum13Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.Sum<Item>(i => i.Int * 3);

        Assert.That(
				result, 
				Is.EqualTo(qySource.Sum<Item>(i => i.Int * 3)));
	}

	[Test]
	public void Sum14Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.Sum<Item>(i => i.Int * 13);

        Assert.That(
				result, 
				Is.EqualTo(qySource.Sum<Item>(i => i.Int * 13)));
	}

	[Test]
	public void Sum15Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.Sum<Item>(i => i.Int * 13);

        Assert.That(
				result, 
				Is.EqualTo(qySource.Sum<Item>(i => i.Int * 13)));
	}

	[Test]
	public void Sum16Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.Sum<Item>(i => i.Int * 3.5F);

        Assert.That(
				result, 
				Is.EqualTo(qySource.Sum<Item>(i => i.Int * 3.5F)));
	}

	[Test]
	public void Sum17Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.Sum<Item>(i => i.Int * 3.5F);

        Assert.That(
				result, 
				Is.EqualTo(qySource.Sum<Item>(i => i.Int * 3.5F)));
	}

	[Test]
	public void Sum18Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.Sum<Item>(i => i.Int * 0.73);

        Assert.That(
				result, 
				Is.EqualTo(qySource.Sum<Item>(i => i.Int * 0.73)));
	}

	[Test]
	public void Sum19Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.Sum<Item>(i => i.Int * 0.73);

        Assert.That(
				result, 
				Is.EqualTo(qySource.Sum<Item>(i => i.Int * 0.73)));
	}

	[Test]
	public void Sum20Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.Sum<Item>(i => i.Int * 3.67);

        Assert.That(
				result, 
				Is.EqualTo(qySource.Sum<Item>(i => i.Int * 3.67)));
	}

	[Test]
	public void TakeTest() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.Take<Item>(17).Select(i => i.Int);

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.Take<Item>(17).Select(i => i.Int)));
	}

	[Test]
	public void TakeWhileTest() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.TakeWhile<Item>(i => i.Int % 2 == 1).Select(i => i.Int);

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.TakeWhile<Item>(i => i.Int % 2 == 1).Select(i => i.Int)));
	}

	[Test]
	public void TakeWhile2Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.TakeWhile<Item>((s, i) => s.Int + i < 10).Select(i => i.Int);

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.TakeWhile<Item>((s, i) => s.Int + i < 10).Select(i => i.Int)));
	}

	[Test]
	public void ThenByTest() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.OrderByDescending(i => i.Int)
								.ThenBy<Item, string>(i => i.Int.ToString()).Select(i => i.Int);

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.OrderByDescending(i => i.Int).ThenBy<Item, string>(i => i.Int.ToString()).Select(i => i.Int)));
	}

	[Test]
	public void ThenBy2Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.OrderByDescending(i => i.Int)
								.ThenBy<Item, string>(i => i.Int.ToString(), StringComparer.Ordinal).Select(i => i.Int);

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.OrderByDescending(i => i.Int).ThenBy<Item, string>(i => i.Int.ToString(), StringComparer.Ordinal).Select(i => i.Int)));
	}

	[Test]
	public void ThenByDescendingTest() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.OrderByDescending(i => i.Int)
								.ThenByDescending<Item, string>(i => i.Int.ToString()).Select(i => i.Int);

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.OrderByDescending(i => i.Int).ThenByDescending<Item, string>(i => i.Int.ToString()).Select(i => i.Int)));
	}

	[Test]
	public void ThenByDescending2Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.OrderByDescending(i => i.Int)
								.ThenByDescending<Item, string>(i => i.Int.ToString(), StringComparer.Ordinal).Select(i => i.Int);

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.OrderByDescending(i => i.Int).ThenByDescending<Item, string>(i => i.Int.ToString(), StringComparer.Ordinal).Select(i => i.Int)));
	}

	[Test]
	public void UnionTest() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.Union<Item>(qySource.Reverse()).Select(i => i.Int);

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.Union<Item>(qySource.Reverse()).Select(i => i.Int)));
	}

	[Test]
	public void Union2Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.Union<Item>(qySource.Reverse(), ItemComparer.Default).Select(i => i.Int);

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.Union<Item>(qySource.Reverse(), ItemComparer.Default).Select(i => i.Int)));
	}

	[Test]
	public void WhereTest() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.Where<Item>(i => i.Int % 2 == 1).Select(i => i.Int);

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.Where<Item>(i => i.Int % 2 == 1).Select(i => i.Int)));
	}

	[Test]
	public void Where2Test() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.Where<Item>((s, i) => s.Int + i < 10).Select(i => i.Int);

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.Where<Item>((s, i) => s.Int + i < 10).Select(i => i.Int)));
	}

	[Test]
	public void ZipTest() 
	{
		var qySource 
			= Enumerable.Range(10, 40)
				.Select(i => new Item(i))
				.AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
								.Zip<Item, Item, Item>(qySource.Reverse(), (a, b) => new Item(a.Int * b.Int)).Select(i => i.Int);

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.Zip<Item, Item, Item>(qySource.Reverse(), (a, b) => new Item(a.Int * b.Int)).Select(i => i.Int)));
	}

	
}

