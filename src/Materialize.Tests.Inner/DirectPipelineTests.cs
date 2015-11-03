 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Materialize.Types;
using NUnit.Framework;
using Materialize;
using Materialize.Reify2.Parsing2;
using Materialize.Reify2;
using Materialize.SourceRegimes;

[TestFixture]
class DirectPipelineTests
{

	class Item {
		public int Int;

		public Item(int i) {
			Int = i;
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


	ReifiableFactory _reifiableFac = MaterializeServices.Resolve<ReifiableFactory>();


	[Test]
	public void AggregateTest() 
	{
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Int32> qySource = Enumerable.Range(10, 40).Select(i => (Int32)i).AsQueryable();			
		
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
		IQueryable<Nullable<Int32>> qySource = Enumerable.Range(10, 40).Select(i => (Nullable<Int32>)i).AsQueryable();			
		
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
		IQueryable<Int64> qySource = Enumerable.Range(10, 40).Select(i => (Int64)i).AsQueryable();			
		
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
		IQueryable<Nullable<Int64>> qySource = Enumerable.Range(10, 40).Select(i => (Nullable<Int64>)i).AsQueryable();			
		
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
		IQueryable<Single> qySource = Enumerable.Range(10, 40).Select(i => (Single)i).AsQueryable();			
		
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
		IQueryable<Nullable<Single>> qySource = Enumerable.Range(10, 40).Select(i => (Nullable<Single>)i).AsQueryable();			
		
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
		IQueryable<Double> qySource = Enumerable.Range(10, 40).Select(i => (Double)i).AsQueryable();			
		
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
		IQueryable<Nullable<Double>> qySource = Enumerable.Range(10, 40).Select(i => (Nullable<Double>)i).AsQueryable();			
		
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
		IQueryable<Decimal> qySource = Enumerable.Range(10, 40).Select(i => (Decimal)i).AsQueryable();			
		
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
		IQueryable<Nullable<Decimal>> qySource = Enumerable.Range(10, 40).Select(i => (Nullable<Decimal>)i).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
                                .GroupBy<Item, string>(i => i.Int.ToString());

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.GroupBy<Item, string>(i => i.Int.ToString())));
	}

	[Test]
	public void GroupBy2Test() 
	{
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
                                .GroupBy<Item, string, Item>(i => i.Int.ToString(), i => new Item(i.Int - 1));

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.GroupBy<Item, string, Item>(i => i.Int.ToString(), i => new Item(i.Int - 1))));
	}

	[Test]
	public void GroupBy3Test() 
	{
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
                                .GroupBy<Item, string>(i => i.Int.ToString(), EqualityComparer<string>.Default);

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.GroupBy<Item, string>(i => i.Int.ToString(), EqualityComparer<string>.Default)));
	}

	[Test]
	public void GroupBy4Test() 
	{
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
                                .GroupBy<Item, string, Item>(i => i.Int.ToString(), i => new Item(i.Int - 1), EqualityComparer<string>.Default);

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.GroupBy<Item, string, Item>(i => i.Int.ToString(), i => new Item(i.Int - 1), EqualityComparer<string>.Default)));
	}

	[Test]
	public void GroupBy5Test() 
	{
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
                                .GroupBy<Item, string, Item, Item>(i => i.Int.ToString(), i => new Item(i.Int - 1), (k, r) => r.Last()).Select(i => i.Int);

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.GroupBy<Item, string, Item, Item>(i => i.Int.ToString(), i => new Item(i.Int - 1), (k, r) => r.Last()).Select(i => i.Int)));
	}

	[Test]
	public void GroupBy6Test() 
	{
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
                                .GroupBy<Item, string, Item>(i => i.Int.ToString(), (k, r) => r.Last()).Select(i => i.Int);

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.GroupBy<Item, string, Item>(i => i.Int.ToString(), (k, r) => r.Last()).Select(i => i.Int)));
	}

	[Test]
	public void GroupBy7Test() 
	{
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
                                .GroupBy<Item, string, Item>(i => i.Int.ToString(), (k, r) => r.Last(), EqualityComparer<string>.Default).Select(i => i.Int);

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.GroupBy<Item, string, Item>(i => i.Int.ToString(), (k, r) => r.Last(), EqualityComparer<string>.Default).Select(i => i.Int)));
	}

	[Test]
	public void GroupBy8Test() 
	{
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
                                .GroupBy<Item, string, Item, Item>(i => i.Int.ToString(), i => new Item(i.Int - 1), (k, r) => r.Last(), EqualityComparer<string>.Default).Select(i => i.Int);

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.GroupBy<Item, string, Item, Item>(i => i.Int.ToString(), i => new Item(i.Int - 1), (k, r) => r.Last(), EqualityComparer<string>.Default).Select(i => i.Int)));
	}

	[Test]
	public void GroupJoinTest() 
	{
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
                                .GroupJoin<Item, Item, string, Item>(qySource.Reverse(), i => i.Int.ToString(), i => i.Int.ToString(), (o, r) => new Item(r.Last().Int + o.Int)).Select(i => i.Int);

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.GroupJoin<Item, Item, string, Item>(qySource.Reverse(), i => i.Int.ToString(), i => i.Int.ToString(), (o, r) => new Item(r.Last().Int + o.Int)).Select(i => i.Int)));
	}

	[Test]
	public void GroupJoin2Test() 
	{
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
                                .GroupJoin<Item, Item, string, Item>(qySource.Reverse(), i => i.Int.ToString(), i => i.Int.ToString(), (o, r) => new Item(r.Last().Int + o.Int), EqualityComparer<string>.Default).Select(i => i.Int);

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.GroupJoin<Item, Item, string, Item>(qySource.Reverse(), i => i.Int.ToString(), i => i.Int.ToString(), (o, r) => new Item(r.Last().Int + o.Int), EqualityComparer<string>.Default).Select(i => i.Int)));
	}

	[Test]
	public void IntersectTest() 
	{
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Int32> qySource = Enumerable.Range(10, 40).Select(i => (Int32)i).AsQueryable();			
		
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
		IQueryable<Nullable<Int32>> qySource = Enumerable.Range(10, 40).Select(i => (Nullable<Int32>)i).AsQueryable();			
		
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
		IQueryable<Int64> qySource = Enumerable.Range(10, 40).Select(i => (Int64)i).AsQueryable();			
		
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
		IQueryable<Nullable<Int64>> qySource = Enumerable.Range(10, 40).Select(i => (Nullable<Int64>)i).AsQueryable();			
		
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
		IQueryable<Single> qySource = Enumerable.Range(10, 40).Select(i => (Single)i).AsQueryable();			
		
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
		IQueryable<Nullable<Single>> qySource = Enumerable.Range(10, 40).Select(i => (Nullable<Single>)i).AsQueryable();			
		
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
		IQueryable<Double> qySource = Enumerable.Range(10, 40).Select(i => (Double)i).AsQueryable();			
		
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
		IQueryable<Nullable<Double>> qySource = Enumerable.Range(10, 40).Select(i => (Nullable<Double>)i).AsQueryable();			
		
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
		IQueryable<Decimal> qySource = Enumerable.Range(10, 40).Select(i => (Decimal)i).AsQueryable();			
		
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
		IQueryable<Nullable<Decimal>> qySource = Enumerable.Range(10, 40).Select(i => (Nullable<Decimal>)i).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
                                .TakeWhile<Item>((s, i) => s.Int + i < 10).Select(i => i.Int);

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.TakeWhile<Item>((s, i) => s.Int + i < 10).Select(i => i.Int)));
	}

	//[Test]
	//public void ThenByTest() 
	//{
	//	IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
 //       var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

 //       var result = reifiable.CreateQuery<Item>(qySource.Expression)
 //                               .ThenBy<Item, string>(i => i.Int.ToString()).Select(i => i.Int);

 //       Assert.That(
	//			result, 
	//			Is.EquivalentTo(qySource.ThenBy<Item, string>(i => i.Int.ToString()).Select(i => i.Int)));
	//}

	//[Test]
	//public void ThenBy2Test() 
	//{
	//	IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
 //       var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

 //       var result = reifiable.CreateQuery<Item>(qySource.Expression)
 //                               .ThenBy<Item, string>(i => i.Int.ToString(), StringComparer.Ordinal).Select(i => i.Int);

 //       Assert.That(
	//			result, 
	//			Is.EquivalentTo(qySource.ThenBy<Item, string>(i => i.Int.ToString(), StringComparer.Ordinal).Select(i => i.Int)));
	//}

	//[Test]
	//public void ThenByDescendingTest() 
	//{
	//	IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
 //       var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

 //       var result = reifiable.CreateQuery<Item>(qySource.Expression)
 //                               .ThenByDescending<Item, string>(i => i.Int.ToString()).Select(i => i.Int);

 //       Assert.That(
	//			result, 
	//			Is.EquivalentTo(qySource.ThenByDescending<Item, string>(i => i.Int.ToString()).Select(i => i.Int)));
	//}

	//[Test]
	//public void ThenByDescending2Test() 
	//{
	//	IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
 //       var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

 //       var result = reifiable.CreateQuery<Item>(qySource.Expression)
 //                               .ThenByDescending<Item, string>(i => i.Int.ToString(), StringComparer.Ordinal).Select(i => i.Int);

 //       Assert.That(
	//			result, 
	//			Is.EquivalentTo(qySource.ThenByDescending<Item, string>(i => i.Int.ToString(), StringComparer.Ordinal).Select(i => i.Int)));
	//}

	[Test]
	public void UnionTest() 
	{
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
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
		IQueryable<Item> qySource = Enumerable.Range(10, 40).Select(i => new Item(i)).AsQueryable();			
		
        var reifiable = _reifiableFac.CreateReifiable(qySource, new MaterializeOptions());

        var result = reifiable.CreateQuery<Item>(qySource.Expression)
                                .Zip<Item, Item, Item>(qySource.Reverse(), (a, b) => new Item(a.Int * b.Int)).Select(i => i.Int);

        Assert.That(
				result, 
				Is.EquivalentTo(qySource.Zip<Item, Item, Item>(qySource.Reverse(), (a, b) => new Item(a.Int * b.Int)).Select(i => i.Int)));
	}

	
}

