using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Materialize.Types;

internal static partial class QyMethods 
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
		Aggregate = Refl.GetGenMethod(() => Queryable.Aggregate<object>((IQueryable<object>)null, (Expression<Func<object, object, object>>)null));
		Aggregate2 = Refl.GetGenMethod(() => Queryable.Aggregate<object, object>((IQueryable<object>)null, (object)null, (Expression<Func<object, object, object>>)null));
		Aggregate3 = Refl.GetGenMethod(() => Queryable.Aggregate<object, object, object>((IQueryable<object>)null, (object)null, (Expression<Func<object, object, object>>)null, (Expression<Func<object, object>>)null));
		All = Refl.GetGenMethod(() => Queryable.All<object>((IQueryable<object>)null, (Expression<Func<object, Boolean>>)null));
		Any = Refl.GetGenMethod(() => Queryable.Any<object>((IQueryable<object>)null));
		Any2 = Refl.GetGenMethod(() => Queryable.Any<object>((IQueryable<object>)null, (Expression<Func<object, Boolean>>)null));
		Average = Refl.GetMethod(() => Queryable.Average((IQueryable<Int32>)null));
		Average2 = Refl.GetMethod(() => Queryable.Average((IQueryable<Nullable<Int32>>)null));
		Average3 = Refl.GetMethod(() => Queryable.Average((IQueryable<Int64>)null));
		Average4 = Refl.GetMethod(() => Queryable.Average((IQueryable<Nullable<Int64>>)null));
		Average5 = Refl.GetMethod(() => Queryable.Average((IQueryable<Single>)null));
		Average6 = Refl.GetMethod(() => Queryable.Average((IQueryable<Nullable<Single>>)null));
		Average7 = Refl.GetMethod(() => Queryable.Average((IQueryable<Double>)null));
		Average8 = Refl.GetMethod(() => Queryable.Average((IQueryable<Nullable<Double>>)null));
		Average9 = Refl.GetMethod(() => Queryable.Average((IQueryable<Decimal>)null));
		Average10 = Refl.GetMethod(() => Queryable.Average((IQueryable<Nullable<Decimal>>)null));
		Average11 = Refl.GetGenMethod(() => Queryable.Average<object>((IQueryable<object>)null, (Expression<Func<object, Int32>>)null));
		Average12 = Refl.GetGenMethod(() => Queryable.Average<object>((IQueryable<object>)null, (Expression<Func<object, Nullable<Int32>>>)null));
		Average13 = Refl.GetGenMethod(() => Queryable.Average<object>((IQueryable<object>)null, (Expression<Func<object, Single>>)null));
		Average14 = Refl.GetGenMethod(() => Queryable.Average<object>((IQueryable<object>)null, (Expression<Func<object, Nullable<Single>>>)null));
		Average15 = Refl.GetGenMethod(() => Queryable.Average<object>((IQueryable<object>)null, (Expression<Func<object, Int64>>)null));
		Average16 = Refl.GetGenMethod(() => Queryable.Average<object>((IQueryable<object>)null, (Expression<Func<object, Nullable<Int64>>>)null));
		Average17 = Refl.GetGenMethod(() => Queryable.Average<object>((IQueryable<object>)null, (Expression<Func<object, Double>>)null));
		Average18 = Refl.GetGenMethod(() => Queryable.Average<object>((IQueryable<object>)null, (Expression<Func<object, Nullable<Double>>>)null));
		Average19 = Refl.GetGenMethod(() => Queryable.Average<object>((IQueryable<object>)null, (Expression<Func<object, Decimal>>)null));
		Average20 = Refl.GetGenMethod(() => Queryable.Average<object>((IQueryable<object>)null, (Expression<Func<object, Nullable<Decimal>>>)null));
		Cast = Refl.GetGenMethod(() => Queryable.Cast<object>((IQueryable)null));
		Concat = Refl.GetGenMethod(() => Queryable.Concat<object>((IQueryable<object>)null, (IEnumerable<object>)null));
		Contains = Refl.GetGenMethod(() => Queryable.Contains<object>((IQueryable<object>)null, (object)null));
		Contains2 = Refl.GetGenMethod(() => Queryable.Contains<object>((IQueryable<object>)null, (object)null, (IEqualityComparer<object>)null));
		Count = Refl.GetGenMethod(() => Queryable.Count<object>((IQueryable<object>)null));
		Count2 = Refl.GetGenMethod(() => Queryable.Count<object>((IQueryable<object>)null, (Expression<Func<object, Boolean>>)null));
		DefaultIfEmpty = Refl.GetGenMethod(() => Queryable.DefaultIfEmpty<object>((IQueryable<object>)null));
		DefaultIfEmpty2 = Refl.GetGenMethod(() => Queryable.DefaultIfEmpty<object>((IQueryable<object>)null, (object)null));
		Distinct = Refl.GetGenMethod(() => Queryable.Distinct<object>((IQueryable<object>)null));
		Distinct2 = Refl.GetGenMethod(() => Queryable.Distinct<object>((IQueryable<object>)null, (IEqualityComparer<object>)null));
		ElementAt = Refl.GetGenMethod(() => Queryable.ElementAt<object>((IQueryable<object>)null, 0));
		ElementAtOrDefault = Refl.GetGenMethod(() => Queryable.ElementAtOrDefault<object>((IQueryable<object>)null, 0));
		Except = Refl.GetGenMethod(() => Queryable.Except<object>((IQueryable<object>)null, (IEnumerable<object>)null));
		Except2 = Refl.GetGenMethod(() => Queryable.Except<object>((IQueryable<object>)null, (IEnumerable<object>)null, (IEqualityComparer<object>)null));
		First = Refl.GetGenMethod(() => Queryable.First<object>((IQueryable<object>)null));
		First2 = Refl.GetGenMethod(() => Queryable.First<object>((IQueryable<object>)null, (Expression<Func<object, Boolean>>)null));
		FirstOrDefault = Refl.GetGenMethod(() => Queryable.FirstOrDefault<object>((IQueryable<object>)null));
		FirstOrDefault2 = Refl.GetGenMethod(() => Queryable.FirstOrDefault<object>((IQueryable<object>)null, (Expression<Func<object, Boolean>>)null));
		GroupBy = Refl.GetGenMethod(() => Queryable.GroupBy<object, object>((IQueryable<object>)null, (Expression<Func<object, object>>)null));
		GroupBy2 = Refl.GetGenMethod(() => Queryable.GroupBy<object, object, object>((IQueryable<object>)null, (Expression<Func<object, object>>)null, (Expression<Func<object, object>>)null));
		GroupBy3 = Refl.GetGenMethod(() => Queryable.GroupBy<object, object>((IQueryable<object>)null, (Expression<Func<object, object>>)null, (IEqualityComparer<object>)null));
		GroupBy4 = Refl.GetGenMethod(() => Queryable.GroupBy<object, object, object>((IQueryable<object>)null, (Expression<Func<object, object>>)null, (Expression<Func<object, object>>)null, (IEqualityComparer<object>)null));
		GroupBy5 = Refl.GetGenMethod(() => Queryable.GroupBy<object, object, object, object>((IQueryable<object>)null, (Expression<Func<object, object>>)null, (Expression<Func<object, object>>)null, (Expression<Func<object, IEnumerable<object>, object>>)null));
		GroupBy6 = Refl.GetGenMethod(() => Queryable.GroupBy<object, object, object>((IQueryable<object>)null, (Expression<Func<object, object>>)null, (Expression<Func<object, IEnumerable<object>, object>>)null));
		GroupBy7 = Refl.GetGenMethod(() => Queryable.GroupBy<object, object, object>((IQueryable<object>)null, (Expression<Func<object, object>>)null, (Expression<Func<object, IEnumerable<object>, object>>)null, (IEqualityComparer<object>)null));
		GroupBy8 = Refl.GetGenMethod(() => Queryable.GroupBy<object, object, object, object>((IQueryable<object>)null, (Expression<Func<object, object>>)null, (Expression<Func<object, object>>)null, (Expression<Func<object, IEnumerable<object>, object>>)null, (IEqualityComparer<object>)null));
		GroupJoin = Refl.GetGenMethod(() => Queryable.GroupJoin<object, object, object, object>((IQueryable<object>)null, (IEnumerable<object>)null, (Expression<Func<object, object>>)null, (Expression<Func<object, object>>)null, (Expression<Func<object, IEnumerable<object>, object>>)null));
		GroupJoin2 = Refl.GetGenMethod(() => Queryable.GroupJoin<object, object, object, object>((IQueryable<object>)null, (IEnumerable<object>)null, (Expression<Func<object, object>>)null, (Expression<Func<object, object>>)null, (Expression<Func<object, IEnumerable<object>, object>>)null, (IEqualityComparer<object>)null));
		Intersect = Refl.GetGenMethod(() => Queryable.Intersect<object>((IQueryable<object>)null, (IEnumerable<object>)null));
		Intersect2 = Refl.GetGenMethod(() => Queryable.Intersect<object>((IQueryable<object>)null, (IEnumerable<object>)null, (IEqualityComparer<object>)null));
		Join = Refl.GetGenMethod(() => Queryable.Join<object, object, object, object>((IQueryable<object>)null, (IEnumerable<object>)null, (Expression<Func<object, object>>)null, (Expression<Func<object, object>>)null, (Expression<Func<object, object, object>>)null));
		Join2 = Refl.GetGenMethod(() => Queryable.Join<object, object, object, object>((IQueryable<object>)null, (IEnumerable<object>)null, (Expression<Func<object, object>>)null, (Expression<Func<object, object>>)null, (Expression<Func<object, object, object>>)null, (IEqualityComparer<object>)null));
		Last = Refl.GetGenMethod(() => Queryable.Last<object>((IQueryable<object>)null));
		Last2 = Refl.GetGenMethod(() => Queryable.Last<object>((IQueryable<object>)null, (Expression<Func<object, Boolean>>)null));
		LastOrDefault = Refl.GetGenMethod(() => Queryable.LastOrDefault<object>((IQueryable<object>)null));
		LastOrDefault2 = Refl.GetGenMethod(() => Queryable.LastOrDefault<object>((IQueryable<object>)null, (Expression<Func<object, Boolean>>)null));
		LongCount = Refl.GetGenMethod(() => Queryable.LongCount<object>((IQueryable<object>)null));
		LongCount2 = Refl.GetGenMethod(() => Queryable.LongCount<object>((IQueryable<object>)null, (Expression<Func<object, Boolean>>)null));
		Max = Refl.GetGenMethod(() => Queryable.Max<object>((IQueryable<object>)null));
		Max2 = Refl.GetGenMethod(() => Queryable.Max<object, object>((IQueryable<object>)null, (Expression<Func<object, object>>)null));
		Min = Refl.GetGenMethod(() => Queryable.Min<object>((IQueryable<object>)null));
		Min2 = Refl.GetGenMethod(() => Queryable.Min<object, object>((IQueryable<object>)null, (Expression<Func<object, object>>)null));
		OfType = Refl.GetGenMethod(() => Queryable.OfType<object>((IQueryable)null));
		OrderBy = Refl.GetGenMethod(() => Queryable.OrderBy<object, object>((IQueryable<object>)null, (Expression<Func<object, object>>)null));
		OrderBy2 = Refl.GetGenMethod(() => Queryable.OrderBy<object, object>((IQueryable<object>)null, (Expression<Func<object, object>>)null, (IComparer<object>)null));
		OrderByDescending = Refl.GetGenMethod(() => Queryable.OrderByDescending<object, object>((IQueryable<object>)null, (Expression<Func<object, object>>)null));
		OrderByDescending2 = Refl.GetGenMethod(() => Queryable.OrderByDescending<object, object>((IQueryable<object>)null, (Expression<Func<object, object>>)null, (IComparer<object>)null));
		Reverse = Refl.GetGenMethod(() => Queryable.Reverse<object>((IQueryable<object>)null));
		Select = Refl.GetGenMethod(() => Queryable.Select<object, object>((IQueryable<object>)null, (Expression<Func<object, object>>)null));
		Select2 = Refl.GetGenMethod(() => Queryable.Select<object, object>((IQueryable<object>)null, (Expression<Func<object, Int32, object>>)null));
		SelectMany = Refl.GetGenMethod(() => Queryable.SelectMany<object, object>((IQueryable<object>)null, (Expression<Func<object, IEnumerable<object>>>)null));
		SelectMany2 = Refl.GetGenMethod(() => Queryable.SelectMany<object, object>((IQueryable<object>)null, (Expression<Func<object, Int32, IEnumerable<object>>>)null));
		SelectMany3 = Refl.GetGenMethod(() => Queryable.SelectMany<object, object, object>((IQueryable<object>)null, (Expression<Func<object, Int32, IEnumerable<object>>>)null, (Expression<Func<object, object, object>>)null));
		SelectMany4 = Refl.GetGenMethod(() => Queryable.SelectMany<object, object, object>((IQueryable<object>)null, (Expression<Func<object, IEnumerable<object>>>)null, (Expression<Func<object, object, object>>)null));
		SequenceEqual = Refl.GetGenMethod(() => Queryable.SequenceEqual<object>((IQueryable<object>)null, (IEnumerable<object>)null));
		SequenceEqual2 = Refl.GetGenMethod(() => Queryable.SequenceEqual<object>((IQueryable<object>)null, (IEnumerable<object>)null, (IEqualityComparer<object>)null));
		Single = Refl.GetGenMethod(() => Queryable.Single<object>((IQueryable<object>)null));
		Single2 = Refl.GetGenMethod(() => Queryable.Single<object>((IQueryable<object>)null, (Expression<Func<object, Boolean>>)null));
		SingleOrDefault = Refl.GetGenMethod(() => Queryable.SingleOrDefault<object>((IQueryable<object>)null));
		SingleOrDefault2 = Refl.GetGenMethod(() => Queryable.SingleOrDefault<object>((IQueryable<object>)null, (Expression<Func<object, Boolean>>)null));
		Skip = Refl.GetGenMethod(() => Queryable.Skip<object>((IQueryable<object>)null, 0));
		SkipWhile = Refl.GetGenMethod(() => Queryable.SkipWhile<object>((IQueryable<object>)null, (Expression<Func<object, Boolean>>)null));
		SkipWhile2 = Refl.GetGenMethod(() => Queryable.SkipWhile<object>((IQueryable<object>)null, (Expression<Func<object, Int32, Boolean>>)null));
		Sum = Refl.GetGenMethod(() => Queryable.Sum<object>((IQueryable<object>)null, (Expression<Func<object, Nullable<Decimal>>>)null));
		Sum2 = Refl.GetMethod(() => Queryable.Sum((IQueryable<Int32>)null));
		Sum3 = Refl.GetMethod(() => Queryable.Sum((IQueryable<Nullable<Int32>>)null));
		Sum4 = Refl.GetMethod(() => Queryable.Sum((IQueryable<Int64>)null));
		Sum5 = Refl.GetMethod(() => Queryable.Sum((IQueryable<Nullable<Int64>>)null));
		Sum6 = Refl.GetMethod(() => Queryable.Sum((IQueryable<Single>)null));
		Sum7 = Refl.GetMethod(() => Queryable.Sum((IQueryable<Nullable<Single>>)null));
		Sum8 = Refl.GetMethod(() => Queryable.Sum((IQueryable<Double>)null));
		Sum9 = Refl.GetMethod(() => Queryable.Sum((IQueryable<Nullable<Double>>)null));
		Sum10 = Refl.GetMethod(() => Queryable.Sum((IQueryable<Decimal>)null));
		Sum11 = Refl.GetMethod(() => Queryable.Sum((IQueryable<Nullable<Decimal>>)null));
		Sum12 = Refl.GetGenMethod(() => Queryable.Sum<object>((IQueryable<object>)null, (Expression<Func<object, Int32>>)null));
		Sum13 = Refl.GetGenMethod(() => Queryable.Sum<object>((IQueryable<object>)null, (Expression<Func<object, Nullable<Int32>>>)null));
		Sum14 = Refl.GetGenMethod(() => Queryable.Sum<object>((IQueryable<object>)null, (Expression<Func<object, Int64>>)null));
		Sum15 = Refl.GetGenMethod(() => Queryable.Sum<object>((IQueryable<object>)null, (Expression<Func<object, Nullable<Int64>>>)null));
		Sum16 = Refl.GetGenMethod(() => Queryable.Sum<object>((IQueryable<object>)null, (Expression<Func<object, Single>>)null));
		Sum17 = Refl.GetGenMethod(() => Queryable.Sum<object>((IQueryable<object>)null, (Expression<Func<object, Nullable<Single>>>)null));
		Sum18 = Refl.GetGenMethod(() => Queryable.Sum<object>((IQueryable<object>)null, (Expression<Func<object, Double>>)null));
		Sum19 = Refl.GetGenMethod(() => Queryable.Sum<object>((IQueryable<object>)null, (Expression<Func<object, Nullable<Double>>>)null));
		Sum20 = Refl.GetGenMethod(() => Queryable.Sum<object>((IQueryable<object>)null, (Expression<Func<object, Decimal>>)null));
		Take = Refl.GetGenMethod(() => Queryable.Take<object>((IQueryable<object>)null, 0));
		TakeWhile = Refl.GetGenMethod(() => Queryable.TakeWhile<object>((IQueryable<object>)null, (Expression<Func<object, Boolean>>)null));
		TakeWhile2 = Refl.GetGenMethod(() => Queryable.TakeWhile<object>((IQueryable<object>)null, (Expression<Func<object, Int32, Boolean>>)null));
		ThenBy = Refl.GetGenMethod(() => Queryable.ThenBy<object, object>((IOrderedQueryable<object>)null, (Expression<Func<object, object>>)null));
		ThenBy2 = Refl.GetGenMethod(() => Queryable.ThenBy<object, object>((IOrderedQueryable<object>)null, (Expression<Func<object, object>>)null, (IComparer<object>)null));
		ThenByDescending = Refl.GetGenMethod(() => Queryable.ThenByDescending<object, object>((IOrderedQueryable<object>)null, (Expression<Func<object, object>>)null));
		ThenByDescending2 = Refl.GetGenMethod(() => Queryable.ThenByDescending<object, object>((IOrderedQueryable<object>)null, (Expression<Func<object, object>>)null, (IComparer<object>)null));
		Union = Refl.GetGenMethod(() => Queryable.Union<object>((IQueryable<object>)null, (IEnumerable<object>)null));
		Union2 = Refl.GetGenMethod(() => Queryable.Union<object>((IQueryable<object>)null, (IEnumerable<object>)null, (IEqualityComparer<object>)null));
		Where = Refl.GetGenMethod(() => Queryable.Where<object>((IQueryable<object>)null, (Expression<Func<object, Boolean>>)null));
		Where2 = Refl.GetGenMethod(() => Queryable.Where<object>((IQueryable<object>)null, (Expression<Func<object, Int32, Boolean>>)null));
		Zip = Refl.GetGenMethod(() => Queryable.Zip<object, object, object>((IQueryable<object>)null, (IEnumerable<object>)null, (Expression<Func<object, object, object>>)null));
	}
} 

