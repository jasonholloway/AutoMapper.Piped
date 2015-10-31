using System;
using System.Linq;
using System.Reflection;

internal static class QyMethods 
{
	///<summary>
	///TSource qy.Aggregate&lt;TSource&gt;(Expression&lt;Func&lt;TSource, TSource, TSource&gt;&gt; func)
	///</summary>
	public static readonly MethodInfo Aggregate;

	///<summary>
	///TAccumulate qy.Aggregate&lt;TSource, TAccumulate&gt;(TAccumulate seed, Expression&lt;Func&lt;TAccumulate, TSource, TAccumulate&gt;&gt; func)
	///</summary>
	public static readonly MethodInfo Aggregate2;

	///<summary>
	///TResult qy.Aggregate&lt;TSource, TAccumulate, TResult&gt;(TAccumulate seed, Expression&lt;Func&lt;TAccumulate, TSource, TAccumulate&gt;&gt; func, Expression&lt;Func&lt;TAccumulate, TResult&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Aggregate3;

	///<summary>
	///Boolean qy.All&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Boolean&gt;&gt; predicate)
	///</summary>
	public static readonly MethodInfo All;

	///<summary>
	///Boolean qy.Any&lt;TSource&gt;()
	///</summary>
	public static readonly MethodInfo Any;

	///<summary>
	///Boolean qy.Any&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Boolean&gt;&gt; predicate)
	///</summary>
	public static readonly MethodInfo Any2;

	///<summary>
	///IQueryable&lt;TElement&gt; qy.AsQueryable&lt;TElement&gt;()
	///</summary>
	public static readonly MethodInfo AsQueryable;

	///<summary>
	///IQueryable qy.AsQueryable&lt;&gt;()
	///</summary>
	public static readonly MethodInfo AsQueryable2;

	///<summary>
	///Double qy.Average&lt;&gt;()
	///</summary>
	public static readonly MethodInfo Average;

	///<summary>
	///Nullable&lt;Double&gt; qy.Average&lt;&gt;()
	///</summary>
	public static readonly MethodInfo Average2;

	///<summary>
	///Double qy.Average&lt;&gt;()
	///</summary>
	public static readonly MethodInfo Average3;

	///<summary>
	///Nullable&lt;Double&gt; qy.Average&lt;&gt;()
	///</summary>
	public static readonly MethodInfo Average4;

	///<summary>
	///Single qy.Average&lt;&gt;()
	///</summary>
	public static readonly MethodInfo Average5;

	///<summary>
	///Nullable&lt;Single&gt; qy.Average&lt;&gt;()
	///</summary>
	public static readonly MethodInfo Average6;

	///<summary>
	///Double qy.Average&lt;&gt;()
	///</summary>
	public static readonly MethodInfo Average7;

	///<summary>
	///Nullable&lt;Double&gt; qy.Average&lt;&gt;()
	///</summary>
	public static readonly MethodInfo Average8;

	///<summary>
	///Decimal qy.Average&lt;&gt;()
	///</summary>
	public static readonly MethodInfo Average9;

	///<summary>
	///Nullable&lt;Decimal&gt; qy.Average&lt;&gt;()
	///</summary>
	public static readonly MethodInfo Average10;

	///<summary>
	///Double qy.Average&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Int32&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Average11;

	///<summary>
	///Nullable&lt;Double&gt; qy.Average&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Nullable&lt;Int32&gt;&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Average12;

	///<summary>
	///Single qy.Average&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Single&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Average13;

	///<summary>
	///Nullable&lt;Single&gt; qy.Average&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Nullable&lt;Single&gt;&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Average14;

	///<summary>
	///Double qy.Average&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Int64&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Average15;

	///<summary>
	///Nullable&lt;Double&gt; qy.Average&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Nullable&lt;Int64&gt;&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Average16;

	///<summary>
	///Double qy.Average&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Double&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Average17;

	///<summary>
	///Nullable&lt;Double&gt; qy.Average&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Nullable&lt;Double&gt;&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Average18;

	///<summary>
	///Decimal qy.Average&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Decimal&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Average19;

	///<summary>
	///Nullable&lt;Decimal&gt; qy.Average&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Nullable&lt;Decimal&gt;&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Average20;

	///<summary>
	///IQueryable&lt;TResult&gt; qy.Cast&lt;TResult&gt;()
	///</summary>
	public static readonly MethodInfo Cast;

	///<summary>
	///IQueryable&lt;TSource&gt; qy.Concat&lt;TSource&gt;(IEnumerable&lt;TSource&gt; source2)
	///</summary>
	public static readonly MethodInfo Concat;

	///<summary>
	///Boolean qy.Contains&lt;TSource&gt;(TSource item)
	///</summary>
	public static readonly MethodInfo Contains;

	///<summary>
	///Boolean qy.Contains&lt;TSource&gt;(TSource item, IEqualityComparer&lt;TSource&gt; comparer)
	///</summary>
	public static readonly MethodInfo Contains2;

	///<summary>
	///Int32 qy.Count&lt;TSource&gt;()
	///</summary>
	public static readonly MethodInfo Count;

	///<summary>
	///Int32 qy.Count&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Boolean&gt;&gt; predicate)
	///</summary>
	public static readonly MethodInfo Count2;

	///<summary>
	///IQueryable&lt;TSource&gt; qy.DefaultIfEmpty&lt;TSource&gt;()
	///</summary>
	public static readonly MethodInfo DefaultIfEmpty;

	///<summary>
	///IQueryable&lt;TSource&gt; qy.DefaultIfEmpty&lt;TSource&gt;(TSource defaultValue)
	///</summary>
	public static readonly MethodInfo DefaultIfEmpty2;

	///<summary>
	///IQueryable&lt;TSource&gt; qy.Distinct&lt;TSource&gt;()
	///</summary>
	public static readonly MethodInfo Distinct;

	///<summary>
	///IQueryable&lt;TSource&gt; qy.Distinct&lt;TSource&gt;(IEqualityComparer&lt;TSource&gt; comparer)
	///</summary>
	public static readonly MethodInfo Distinct2;

	///<summary>
	///TSource qy.ElementAt&lt;TSource&gt;(Int32 index)
	///</summary>
	public static readonly MethodInfo ElementAt;

	///<summary>
	///TSource qy.ElementAtOrDefault&lt;TSource&gt;(Int32 index)
	///</summary>
	public static readonly MethodInfo ElementAtOrDefault;

	///<summary>
	///IQueryable&lt;TSource&gt; qy.Except&lt;TSource&gt;(IEnumerable&lt;TSource&gt; source2)
	///</summary>
	public static readonly MethodInfo Except;

	///<summary>
	///IQueryable&lt;TSource&gt; qy.Except&lt;TSource&gt;(IEnumerable&lt;TSource&gt; source2, IEqualityComparer&lt;TSource&gt; comparer)
	///</summary>
	public static readonly MethodInfo Except2;

	///<summary>
	///TSource qy.First&lt;TSource&gt;()
	///</summary>
	public static readonly MethodInfo First;

	///<summary>
	///TSource qy.First&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Boolean&gt;&gt; predicate)
	///</summary>
	public static readonly MethodInfo First2;

	///<summary>
	///TSource qy.FirstOrDefault&lt;TSource&gt;()
	///</summary>
	public static readonly MethodInfo FirstOrDefault;

	///<summary>
	///TSource qy.FirstOrDefault&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Boolean&gt;&gt; predicate)
	///</summary>
	public static readonly MethodInfo FirstOrDefault2;

	///<summary>
	///IQueryable&lt;IGrouping&lt;TKey, TSource&gt;&gt; qy.GroupBy&lt;TSource, TKey&gt;(Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector)
	///</summary>
	public static readonly MethodInfo GroupBy;

	///<summary>
	///IQueryable&lt;IGrouping&lt;TKey, TElement&gt;&gt; qy.GroupBy&lt;TSource, TKey, TElement&gt;(Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector, Expression&lt;Func&lt;TSource, TElement&gt;&gt; elementSelector)
	///</summary>
	public static readonly MethodInfo GroupBy2;

	///<summary>
	///IQueryable&lt;IGrouping&lt;TKey, TSource&gt;&gt; qy.GroupBy&lt;TSource, TKey&gt;(Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector, IEqualityComparer&lt;TKey&gt; comparer)
	///</summary>
	public static readonly MethodInfo GroupBy3;

	///<summary>
	///IQueryable&lt;IGrouping&lt;TKey, TElement&gt;&gt; qy.GroupBy&lt;TSource, TKey, TElement&gt;(Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector, Expression&lt;Func&lt;TSource, TElement&gt;&gt; elementSelector, IEqualityComparer&lt;TKey&gt; comparer)
	///</summary>
	public static readonly MethodInfo GroupBy4;

	///<summary>
	///IQueryable&lt;TResult&gt; qy.GroupBy&lt;TSource, TKey, TElement, TResult&gt;(Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector, Expression&lt;Func&lt;TSource, TElement&gt;&gt; elementSelector, Expression&lt;Func&lt;TKey, IEnumerable&lt;TElement&gt;, TResult&gt;&gt; resultSelector)
	///</summary>
	public static readonly MethodInfo GroupBy5;

	///<summary>
	///IQueryable&lt;TResult&gt; qy.GroupBy&lt;TSource, TKey, TResult&gt;(Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector, Expression&lt;Func&lt;TKey, IEnumerable&lt;TSource&gt;, TResult&gt;&gt; resultSelector)
	///</summary>
	public static readonly MethodInfo GroupBy6;

	///<summary>
	///IQueryable&lt;TResult&gt; qy.GroupBy&lt;TSource, TKey, TResult&gt;(Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector, Expression&lt;Func&lt;TKey, IEnumerable&lt;TSource&gt;, TResult&gt;&gt; resultSelector, IEqualityComparer&lt;TKey&gt; comparer)
	///</summary>
	public static readonly MethodInfo GroupBy7;

	///<summary>
	///IQueryable&lt;TResult&gt; qy.GroupBy&lt;TSource, TKey, TElement, TResult&gt;(Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector, Expression&lt;Func&lt;TSource, TElement&gt;&gt; elementSelector, Expression&lt;Func&lt;TKey, IEnumerable&lt;TElement&gt;, TResult&gt;&gt; resultSelector, IEqualityComparer&lt;TKey&gt; comparer)
	///</summary>
	public static readonly MethodInfo GroupBy8;

	///<summary>
	///IQueryable&lt;TResult&gt; qy.GroupJoin&lt;TOuter, TInner, TKey, TResult&gt;(IEnumerable&lt;TInner&gt; inner, Expression&lt;Func&lt;TOuter, TKey&gt;&gt; outerKeySelector, Expression&lt;Func&lt;TInner, TKey&gt;&gt; innerKeySelector, Expression&lt;Func&lt;TOuter, IEnumerable&lt;TInner&gt;, TResult&gt;&gt; resultSelector)
	///</summary>
	public static readonly MethodInfo GroupJoin;

	///<summary>
	///IQueryable&lt;TResult&gt; qy.GroupJoin&lt;TOuter, TInner, TKey, TResult&gt;(IEnumerable&lt;TInner&gt; inner, Expression&lt;Func&lt;TOuter, TKey&gt;&gt; outerKeySelector, Expression&lt;Func&lt;TInner, TKey&gt;&gt; innerKeySelector, Expression&lt;Func&lt;TOuter, IEnumerable&lt;TInner&gt;, TResult&gt;&gt; resultSelector, IEqualityComparer&lt;TKey&gt; comparer)
	///</summary>
	public static readonly MethodInfo GroupJoin2;

	///<summary>
	///IQueryable&lt;TSource&gt; qy.Intersect&lt;TSource&gt;(IEnumerable&lt;TSource&gt; source2)
	///</summary>
	public static readonly MethodInfo Intersect;

	///<summary>
	///IQueryable&lt;TSource&gt; qy.Intersect&lt;TSource&gt;(IEnumerable&lt;TSource&gt; source2, IEqualityComparer&lt;TSource&gt; comparer)
	///</summary>
	public static readonly MethodInfo Intersect2;

	///<summary>
	///IQueryable&lt;TResult&gt; qy.Join&lt;TOuter, TInner, TKey, TResult&gt;(IEnumerable&lt;TInner&gt; inner, Expression&lt;Func&lt;TOuter, TKey&gt;&gt; outerKeySelector, Expression&lt;Func&lt;TInner, TKey&gt;&gt; innerKeySelector, Expression&lt;Func&lt;TOuter, TInner, TResult&gt;&gt; resultSelector)
	///</summary>
	public static readonly MethodInfo Join;

	///<summary>
	///IQueryable&lt;TResult&gt; qy.Join&lt;TOuter, TInner, TKey, TResult&gt;(IEnumerable&lt;TInner&gt; inner, Expression&lt;Func&lt;TOuter, TKey&gt;&gt; outerKeySelector, Expression&lt;Func&lt;TInner, TKey&gt;&gt; innerKeySelector, Expression&lt;Func&lt;TOuter, TInner, TResult&gt;&gt; resultSelector, IEqualityComparer&lt;TKey&gt; comparer)
	///</summary>
	public static readonly MethodInfo Join2;

	///<summary>
	///TSource qy.Last&lt;TSource&gt;()
	///</summary>
	public static readonly MethodInfo Last;

	///<summary>
	///TSource qy.Last&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Boolean&gt;&gt; predicate)
	///</summary>
	public static readonly MethodInfo Last2;

	///<summary>
	///TSource qy.LastOrDefault&lt;TSource&gt;()
	///</summary>
	public static readonly MethodInfo LastOrDefault;

	///<summary>
	///TSource qy.LastOrDefault&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Boolean&gt;&gt; predicate)
	///</summary>
	public static readonly MethodInfo LastOrDefault2;

	///<summary>
	///Int64 qy.LongCount&lt;TSource&gt;()
	///</summary>
	public static readonly MethodInfo LongCount;

	///<summary>
	///Int64 qy.LongCount&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Boolean&gt;&gt; predicate)
	///</summary>
	public static readonly MethodInfo LongCount2;

	///<summary>
	///TSource qy.Max&lt;TSource&gt;()
	///</summary>
	public static readonly MethodInfo Max;

	///<summary>
	///TResult qy.Max&lt;TSource, TResult&gt;(Expression&lt;Func&lt;TSource, TResult&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Max2;

	///<summary>
	///TSource qy.Min&lt;TSource&gt;()
	///</summary>
	public static readonly MethodInfo Min;

	///<summary>
	///TResult qy.Min&lt;TSource, TResult&gt;(Expression&lt;Func&lt;TSource, TResult&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Min2;

	///<summary>
	///IQueryable&lt;TResult&gt; qy.OfType&lt;TResult&gt;()
	///</summary>
	public static readonly MethodInfo OfType;

	///<summary>
	///IOrderedQueryable&lt;TSource&gt; qy.OrderBy&lt;TSource, TKey&gt;(Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector)
	///</summary>
	public static readonly MethodInfo OrderBy;

	///<summary>
	///IOrderedQueryable&lt;TSource&gt; qy.OrderBy&lt;TSource, TKey&gt;(Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector, IComparer&lt;TKey&gt; comparer)
	///</summary>
	public static readonly MethodInfo OrderBy2;

	///<summary>
	///IOrderedQueryable&lt;TSource&gt; qy.OrderByDescending&lt;TSource, TKey&gt;(Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector)
	///</summary>
	public static readonly MethodInfo OrderByDescending;

	///<summary>
	///IOrderedQueryable&lt;TSource&gt; qy.OrderByDescending&lt;TSource, TKey&gt;(Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector, IComparer&lt;TKey&gt; comparer)
	///</summary>
	public static readonly MethodInfo OrderByDescending2;

	///<summary>
	///IQueryable&lt;TSource&gt; qy.Reverse&lt;TSource&gt;()
	///</summary>
	public static readonly MethodInfo Reverse;

	///<summary>
	///IQueryable&lt;TResult&gt; qy.Select&lt;TSource, TResult&gt;(Expression&lt;Func&lt;TSource, TResult&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Select;

	///<summary>
	///IQueryable&lt;TResult&gt; qy.Select&lt;TSource, TResult&gt;(Expression&lt;Func&lt;TSource, Int32, TResult&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Select2;

	///<summary>
	///IQueryable&lt;TResult&gt; qy.SelectMany&lt;TSource, TResult&gt;(Expression&lt;Func&lt;TSource, IEnumerable&lt;TResult&gt;&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo SelectMany;

	///<summary>
	///IQueryable&lt;TResult&gt; qy.SelectMany&lt;TSource, TResult&gt;(Expression&lt;Func&lt;TSource, Int32, IEnumerable&lt;TResult&gt;&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo SelectMany2;

	///<summary>
	///IQueryable&lt;TResult&gt; qy.SelectMany&lt;TSource, TCollection, TResult&gt;(Expression&lt;Func&lt;TSource, Int32, IEnumerable&lt;TCollection&gt;&gt;&gt; collectionSelector, Expression&lt;Func&lt;TSource, TCollection, TResult&gt;&gt; resultSelector)
	///</summary>
	public static readonly MethodInfo SelectMany3;

	///<summary>
	///IQueryable&lt;TResult&gt; qy.SelectMany&lt;TSource, TCollection, TResult&gt;(Expression&lt;Func&lt;TSource, IEnumerable&lt;TCollection&gt;&gt;&gt; collectionSelector, Expression&lt;Func&lt;TSource, TCollection, TResult&gt;&gt; resultSelector)
	///</summary>
	public static readonly MethodInfo SelectMany4;

	///<summary>
	///Boolean qy.SequenceEqual&lt;TSource&gt;(IEnumerable&lt;TSource&gt; source2)
	///</summary>
	public static readonly MethodInfo SequenceEqual;

	///<summary>
	///Boolean qy.SequenceEqual&lt;TSource&gt;(IEnumerable&lt;TSource&gt; source2, IEqualityComparer&lt;TSource&gt; comparer)
	///</summary>
	public static readonly MethodInfo SequenceEqual2;

	///<summary>
	///TSource qy.Single&lt;TSource&gt;()
	///</summary>
	public static readonly MethodInfo Single;

	///<summary>
	///TSource qy.Single&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Boolean&gt;&gt; predicate)
	///</summary>
	public static readonly MethodInfo Single2;

	///<summary>
	///TSource qy.SingleOrDefault&lt;TSource&gt;()
	///</summary>
	public static readonly MethodInfo SingleOrDefault;

	///<summary>
	///TSource qy.SingleOrDefault&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Boolean&gt;&gt; predicate)
	///</summary>
	public static readonly MethodInfo SingleOrDefault2;

	///<summary>
	///IQueryable&lt;TSource&gt; qy.Skip&lt;TSource&gt;(Int32 count)
	///</summary>
	public static readonly MethodInfo Skip;

	///<summary>
	///IQueryable&lt;TSource&gt; qy.SkipWhile&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Boolean&gt;&gt; predicate)
	///</summary>
	public static readonly MethodInfo SkipWhile;

	///<summary>
	///IQueryable&lt;TSource&gt; qy.SkipWhile&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Int32, Boolean&gt;&gt; predicate)
	///</summary>
	public static readonly MethodInfo SkipWhile2;

	///<summary>
	///Nullable&lt;Decimal&gt; qy.Sum&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Nullable&lt;Decimal&gt;&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Sum;

	///<summary>
	///Int32 qy.Sum&lt;&gt;()
	///</summary>
	public static readonly MethodInfo Sum2;

	///<summary>
	///Nullable&lt;Int32&gt; qy.Sum&lt;&gt;()
	///</summary>
	public static readonly MethodInfo Sum3;

	///<summary>
	///Int64 qy.Sum&lt;&gt;()
	///</summary>
	public static readonly MethodInfo Sum4;

	///<summary>
	///Nullable&lt;Int64&gt; qy.Sum&lt;&gt;()
	///</summary>
	public static readonly MethodInfo Sum5;

	///<summary>
	///Single qy.Sum&lt;&gt;()
	///</summary>
	public static readonly MethodInfo Sum6;

	///<summary>
	///Nullable&lt;Single&gt; qy.Sum&lt;&gt;()
	///</summary>
	public static readonly MethodInfo Sum7;

	///<summary>
	///Double qy.Sum&lt;&gt;()
	///</summary>
	public static readonly MethodInfo Sum8;

	///<summary>
	///Nullable&lt;Double&gt; qy.Sum&lt;&gt;()
	///</summary>
	public static readonly MethodInfo Sum9;

	///<summary>
	///Decimal qy.Sum&lt;&gt;()
	///</summary>
	public static readonly MethodInfo Sum10;

	///<summary>
	///Nullable&lt;Decimal&gt; qy.Sum&lt;&gt;()
	///</summary>
	public static readonly MethodInfo Sum11;

	///<summary>
	///Int32 qy.Sum&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Int32&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Sum12;

	///<summary>
	///Nullable&lt;Int32&gt; qy.Sum&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Nullable&lt;Int32&gt;&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Sum13;

	///<summary>
	///Int64 qy.Sum&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Int64&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Sum14;

	///<summary>
	///Nullable&lt;Int64&gt; qy.Sum&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Nullable&lt;Int64&gt;&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Sum15;

	///<summary>
	///Single qy.Sum&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Single&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Sum16;

	///<summary>
	///Nullable&lt;Single&gt; qy.Sum&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Nullable&lt;Single&gt;&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Sum17;

	///<summary>
	///Double qy.Sum&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Double&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Sum18;

	///<summary>
	///Nullable&lt;Double&gt; qy.Sum&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Nullable&lt;Double&gt;&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Sum19;

	///<summary>
	///Decimal qy.Sum&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Decimal&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Sum20;

	///<summary>
	///IQueryable&lt;TSource&gt; qy.Take&lt;TSource&gt;(Int32 count)
	///</summary>
	public static readonly MethodInfo Take;

	///<summary>
	///IQueryable&lt;TSource&gt; qy.TakeWhile&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Boolean&gt;&gt; predicate)
	///</summary>
	public static readonly MethodInfo TakeWhile;

	///<summary>
	///IQueryable&lt;TSource&gt; qy.TakeWhile&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Int32, Boolean&gt;&gt; predicate)
	///</summary>
	public static readonly MethodInfo TakeWhile2;

	///<summary>
	///IOrderedQueryable&lt;TSource&gt; qy.ThenBy&lt;TSource, TKey&gt;(Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector)
	///</summary>
	public static readonly MethodInfo ThenBy;

	///<summary>
	///IOrderedQueryable&lt;TSource&gt; qy.ThenBy&lt;TSource, TKey&gt;(Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector, IComparer&lt;TKey&gt; comparer)
	///</summary>
	public static readonly MethodInfo ThenBy2;

	///<summary>
	///IOrderedQueryable&lt;TSource&gt; qy.ThenByDescending&lt;TSource, TKey&gt;(Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector)
	///</summary>
	public static readonly MethodInfo ThenByDescending;

	///<summary>
	///IOrderedQueryable&lt;TSource&gt; qy.ThenByDescending&lt;TSource, TKey&gt;(Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector, IComparer&lt;TKey&gt; comparer)
	///</summary>
	public static readonly MethodInfo ThenByDescending2;

	///<summary>
	///IQueryable&lt;TSource&gt; qy.Union&lt;TSource&gt;(IEnumerable&lt;TSource&gt; source2)
	///</summary>
	public static readonly MethodInfo Union;

	///<summary>
	///IQueryable&lt;TSource&gt; qy.Union&lt;TSource&gt;(IEnumerable&lt;TSource&gt; source2, IEqualityComparer&lt;TSource&gt; comparer)
	///</summary>
	public static readonly MethodInfo Union2;

	///<summary>
	///IQueryable&lt;TSource&gt; qy.Where&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Boolean&gt;&gt; predicate)
	///</summary>
	public static readonly MethodInfo Where;

	///<summary>
	///IQueryable&lt;TSource&gt; qy.Where&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Int32, Boolean&gt;&gt; predicate)
	///</summary>
	public static readonly MethodInfo Where2;

	///<summary>
	///IQueryable&lt;TResult&gt; qy.Zip&lt;TFirst, TSecond, TResult&gt;(IEnumerable&lt;TSecond&gt; source2, Expression&lt;Func&lt;TFirst, TSecond, TResult&gt;&gt; resultSelector)
	///</summary>
	public static readonly MethodInfo Zip;

	
	static QyMethods() 
	{
		//Have to replicate binding behaviour, up front, right here...

		var methods = typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
										.GroupBy(m => m.Name)
										.ToDictionary(g => g.Key, g => g.ToArray());

		//BELOW TO MATCH PARAM TYPES!!! Even though they are in many cases unresolved generic typespecs
		//as in metadata, we have to refer generic paramtypes to position in methodinfo... FUN!

		Aggregate = methods["Aggregate"].First(m => true);
		Aggregate2 = methods["Aggregate"].First(m => true);
		Aggregate3 = methods["Aggregate"].First(m => true);
		All = methods["All"].First(m => true);
		Any = methods["Any"].First(m => true);
		Any2 = methods["Any"].First(m => true);
		AsQueryable = methods["AsQueryable"].First(m => true);
		AsQueryable2 = methods["AsQueryable"].First(m => true);
		Average = methods["Average"].First(m => true);
		Average2 = methods["Average"].First(m => true);
		Average3 = methods["Average"].First(m => true);
		Average4 = methods["Average"].First(m => true);
		Average5 = methods["Average"].First(m => true);
		Average6 = methods["Average"].First(m => true);
		Average7 = methods["Average"].First(m => true);
		Average8 = methods["Average"].First(m => true);
		Average9 = methods["Average"].First(m => true);
		Average10 = methods["Average"].First(m => true);
		Average11 = methods["Average"].First(m => true);
		Average12 = methods["Average"].First(m => true);
		Average13 = methods["Average"].First(m => true);
		Average14 = methods["Average"].First(m => true);
		Average15 = methods["Average"].First(m => true);
		Average16 = methods["Average"].First(m => true);
		Average17 = methods["Average"].First(m => true);
		Average18 = methods["Average"].First(m => true);
		Average19 = methods["Average"].First(m => true);
		Average20 = methods["Average"].First(m => true);
		Cast = methods["Cast"].First(m => true);
		Concat = methods["Concat"].First(m => true);
		Contains = methods["Contains"].First(m => true);
		Contains2 = methods["Contains"].First(m => true);
		Count = methods["Count"].First(m => true);
		Count2 = methods["Count"].First(m => true);
		DefaultIfEmpty = methods["DefaultIfEmpty"].First(m => true);
		DefaultIfEmpty2 = methods["DefaultIfEmpty"].First(m => true);
		Distinct = methods["Distinct"].First(m => true);
		Distinct2 = methods["Distinct"].First(m => true);
		ElementAt = methods["ElementAt"].First(m => true);
		ElementAtOrDefault = methods["ElementAtOrDefault"].First(m => true);
		Except = methods["Except"].First(m => true);
		Except2 = methods["Except"].First(m => true);
		First = methods["First"].First(m => true);
		First2 = methods["First"].First(m => true);
		FirstOrDefault = methods["FirstOrDefault"].First(m => true);
		FirstOrDefault2 = methods["FirstOrDefault"].First(m => true);
		GroupBy = methods["GroupBy"].First(m => true);
		GroupBy2 = methods["GroupBy"].First(m => true);
		GroupBy3 = methods["GroupBy"].First(m => true);
		GroupBy4 = methods["GroupBy"].First(m => true);
		GroupBy5 = methods["GroupBy"].First(m => true);
		GroupBy6 = methods["GroupBy"].First(m => true);
		GroupBy7 = methods["GroupBy"].First(m => true);
		GroupBy8 = methods["GroupBy"].First(m => true);
		GroupJoin = methods["GroupJoin"].First(m => true);
		GroupJoin2 = methods["GroupJoin"].First(m => true);
		Intersect = methods["Intersect"].First(m => true);
		Intersect2 = methods["Intersect"].First(m => true);
		Join = methods["Join"].First(m => true);
		Join2 = methods["Join"].First(m => true);
		Last = methods["Last"].First(m => true);
		Last2 = methods["Last"].First(m => true);
		LastOrDefault = methods["LastOrDefault"].First(m => true);
		LastOrDefault2 = methods["LastOrDefault"].First(m => true);
		LongCount = methods["LongCount"].First(m => true);
		LongCount2 = methods["LongCount"].First(m => true);
		Max = methods["Max"].First(m => true);
		Max2 = methods["Max"].First(m => true);
		Min = methods["Min"].First(m => true);
		Min2 = methods["Min"].First(m => true);
		OfType = methods["OfType"].First(m => true);
		OrderBy = methods["OrderBy"].First(m => true);
		OrderBy2 = methods["OrderBy"].First(m => true);
		OrderByDescending = methods["OrderByDescending"].First(m => true);
		OrderByDescending2 = methods["OrderByDescending"].First(m => true);
		Reverse = methods["Reverse"].First(m => true);
		Select = methods["Select"].First(m => true);
		Select2 = methods["Select"].First(m => true);
		SelectMany = methods["SelectMany"].First(m => true);
		SelectMany2 = methods["SelectMany"].First(m => true);
		SelectMany3 = methods["SelectMany"].First(m => true);
		SelectMany4 = methods["SelectMany"].First(m => true);
		SequenceEqual = methods["SequenceEqual"].First(m => true);
		SequenceEqual2 = methods["SequenceEqual"].First(m => true);
		Single = methods["Single"].First(m => true);
		Single2 = methods["Single"].First(m => true);
		SingleOrDefault = methods["SingleOrDefault"].First(m => true);
		SingleOrDefault2 = methods["SingleOrDefault"].First(m => true);
		Skip = methods["Skip"].First(m => true);
		SkipWhile = methods["SkipWhile"].First(m => true);
		SkipWhile2 = methods["SkipWhile"].First(m => true);
		Sum = methods["Sum"].First(m => true);
		Sum2 = methods["Sum"].First(m => true);
		Sum3 = methods["Sum"].First(m => true);
		Sum4 = methods["Sum"].First(m => true);
		Sum5 = methods["Sum"].First(m => true);
		Sum6 = methods["Sum"].First(m => true);
		Sum7 = methods["Sum"].First(m => true);
		Sum8 = methods["Sum"].First(m => true);
		Sum9 = methods["Sum"].First(m => true);
		Sum10 = methods["Sum"].First(m => true);
		Sum11 = methods["Sum"].First(m => true);
		Sum12 = methods["Sum"].First(m => true);
		Sum13 = methods["Sum"].First(m => true);
		Sum14 = methods["Sum"].First(m => true);
		Sum15 = methods["Sum"].First(m => true);
		Sum16 = methods["Sum"].First(m => true);
		Sum17 = methods["Sum"].First(m => true);
		Sum18 = methods["Sum"].First(m => true);
		Sum19 = methods["Sum"].First(m => true);
		Sum20 = methods["Sum"].First(m => true);
		Take = methods["Take"].First(m => true);
		TakeWhile = methods["TakeWhile"].First(m => true);
		TakeWhile2 = methods["TakeWhile"].First(m => true);
		ThenBy = methods["ThenBy"].First(m => true);
		ThenBy2 = methods["ThenBy"].First(m => true);
		ThenByDescending = methods["ThenByDescending"].First(m => true);
		ThenByDescending2 = methods["ThenByDescending"].First(m => true);
		Union = methods["Union"].First(m => true);
		Union2 = methods["Union"].First(m => true);
		Where = methods["Where"].First(m => true);
		Where2 = methods["Where"].First(m => true);
		Zip = methods["Zip"].First(m => true);
	}
} 

