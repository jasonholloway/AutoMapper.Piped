using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Materialize.Types;

internal static partial class EnMethods 
{
	///<summary>
	///TSource qy.Aggregate&lt;TSource&gt;(Func&lt;TSource, TSource, TSource&gt; func)
	///</summary>
	public static readonly MethodInfo Aggregate;

	///<summary>
	///TAccumulate qy.Aggregate&lt;TSource, TAccumulate&gt;(TAccumulate seed, Func&lt;TAccumulate, TSource, TAccumulate&gt; func)
	///</summary>
	public static readonly MethodInfo Aggregate2;

	///<summary>
	///TResult qy.Aggregate&lt;TSource, TAccumulate, TResult&gt;(TAccumulate seed, Func&lt;TAccumulate, TSource, TAccumulate&gt; func, Func&lt;TAccumulate, TResult&gt; resultSelector)
	///</summary>
	public static readonly MethodInfo Aggregate3;

	///<summary>
	///Boolean qy.All&lt;TSource&gt;(Func&lt;TSource, Boolean&gt; predicate)
	///</summary>
	public static readonly MethodInfo All;

	///<summary>
	///Boolean qy.Any&lt;TSource&gt;()
	///</summary>
	public static readonly MethodInfo Any;

	///<summary>
	///Boolean qy.Any&lt;TSource&gt;(Func&lt;TSource, Boolean&gt; predicate)
	///</summary>
	public static readonly MethodInfo Any2;

	///<summary>
	///IEnumerable&lt;TSource&gt; qy.AsEnumerable&lt;TSource&gt;()
	///</summary>
	public static readonly MethodInfo AsEnumerable;

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
	///Double qy.Average&lt;TSource&gt;(Func&lt;TSource, Int32&gt; selector)
	///</summary>
	public static readonly MethodInfo Average11;

	///<summary>
	///Nullable&lt;Double&gt; qy.Average&lt;TSource&gt;(Func&lt;TSource, Nullable&lt;Int32&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Average12;

	///<summary>
	///Double qy.Average&lt;TSource&gt;(Func&lt;TSource, Int64&gt; selector)
	///</summary>
	public static readonly MethodInfo Average13;

	///<summary>
	///Nullable&lt;Double&gt; qy.Average&lt;TSource&gt;(Func&lt;TSource, Nullable&lt;Int64&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Average14;

	///<summary>
	///Single qy.Average&lt;TSource&gt;(Func&lt;TSource, Single&gt; selector)
	///</summary>
	public static readonly MethodInfo Average15;

	///<summary>
	///Nullable&lt;Single&gt; qy.Average&lt;TSource&gt;(Func&lt;TSource, Nullable&lt;Single&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Average16;

	///<summary>
	///Double qy.Average&lt;TSource&gt;(Func&lt;TSource, Double&gt; selector)
	///</summary>
	public static readonly MethodInfo Average17;

	///<summary>
	///Nullable&lt;Double&gt; qy.Average&lt;TSource&gt;(Func&lt;TSource, Nullable&lt;Double&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Average18;

	///<summary>
	///Decimal qy.Average&lt;TSource&gt;(Func&lt;TSource, Decimal&gt; selector)
	///</summary>
	public static readonly MethodInfo Average19;

	///<summary>
	///Nullable&lt;Decimal&gt; qy.Average&lt;TSource&gt;(Func&lt;TSource, Nullable&lt;Decimal&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Average20;

	///<summary>
	///IEnumerable&lt;TResult&gt; qy.Cast&lt;TResult&gt;()
	///</summary>
	public static readonly MethodInfo Cast;

	///<summary>
	///IEnumerable&lt;TSource&gt; qy.Concat&lt;TSource&gt;(IEnumerable&lt;TSource&gt; second)
	///</summary>
	public static readonly MethodInfo Concat;

	///<summary>
	///Boolean qy.Contains&lt;TSource&gt;(TSource value)
	///</summary>
	public static readonly MethodInfo Contains;

	///<summary>
	///Boolean qy.Contains&lt;TSource&gt;(TSource value, IEqualityComparer&lt;TSource&gt; comparer)
	///</summary>
	public static readonly MethodInfo Contains2;

	///<summary>
	///Int32 qy.Count&lt;TSource&gt;()
	///</summary>
	public static readonly MethodInfo Count;

	///<summary>
	///Int32 qy.Count&lt;TSource&gt;(Func&lt;TSource, Boolean&gt; predicate)
	///</summary>
	public static readonly MethodInfo Count2;

	///<summary>
	///IEnumerable&lt;TSource&gt; qy.DefaultIfEmpty&lt;TSource&gt;()
	///</summary>
	public static readonly MethodInfo DefaultIfEmpty;

	///<summary>
	///IEnumerable&lt;TSource&gt; qy.DefaultIfEmpty&lt;TSource&gt;(TSource defaultValue)
	///</summary>
	public static readonly MethodInfo DefaultIfEmpty2;

	///<summary>
	///IEnumerable&lt;TSource&gt; qy.Distinct&lt;TSource&gt;()
	///</summary>
	public static readonly MethodInfo Distinct;

	///<summary>
	///IEnumerable&lt;TSource&gt; qy.Distinct&lt;TSource&gt;(IEqualityComparer&lt;TSource&gt; comparer)
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
	///IEnumerable&lt;TSource&gt; qy.Except&lt;TSource&gt;(IEnumerable&lt;TSource&gt; second)
	///</summary>
	public static readonly MethodInfo Except;

	///<summary>
	///IEnumerable&lt;TSource&gt; qy.Except&lt;TSource&gt;(IEnumerable&lt;TSource&gt; second, IEqualityComparer&lt;TSource&gt; comparer)
	///</summary>
	public static readonly MethodInfo Except2;

	///<summary>
	///TSource qy.First&lt;TSource&gt;()
	///</summary>
	public static readonly MethodInfo First;

	///<summary>
	///TSource qy.First&lt;TSource&gt;(Func&lt;TSource, Boolean&gt; predicate)
	///</summary>
	public static readonly MethodInfo First2;

	///<summary>
	///TSource qy.FirstOrDefault&lt;TSource&gt;()
	///</summary>
	public static readonly MethodInfo FirstOrDefault;

	///<summary>
	///TSource qy.FirstOrDefault&lt;TSource&gt;(Func&lt;TSource, Boolean&gt; predicate)
	///</summary>
	public static readonly MethodInfo FirstOrDefault2;

	///<summary>
	///IEnumerable&lt;IGrouping&lt;TKey, TSource&gt;&gt; qy.GroupBy&lt;TSource, TKey&gt;(Func&lt;TSource, TKey&gt; keySelector)
	///</summary>
	public static readonly MethodInfo GroupBy;

	///<summary>
	///IEnumerable&lt;IGrouping&lt;TKey, TSource&gt;&gt; qy.GroupBy&lt;TSource, TKey&gt;(Func&lt;TSource, TKey&gt; keySelector, IEqualityComparer&lt;TKey&gt; comparer)
	///</summary>
	public static readonly MethodInfo GroupBy2;

	///<summary>
	///IEnumerable&lt;IGrouping&lt;TKey, TElement&gt;&gt; qy.GroupBy&lt;TSource, TKey, TElement&gt;(Func&lt;TSource, TKey&gt; keySelector, Func&lt;TSource, TElement&gt; elementSelector)
	///</summary>
	public static readonly MethodInfo GroupBy3;

	///<summary>
	///IEnumerable&lt;IGrouping&lt;TKey, TElement&gt;&gt; qy.GroupBy&lt;TSource, TKey, TElement&gt;(Func&lt;TSource, TKey&gt; keySelector, Func&lt;TSource, TElement&gt; elementSelector, IEqualityComparer&lt;TKey&gt; comparer)
	///</summary>
	public static readonly MethodInfo GroupBy4;

	///<summary>
	///IEnumerable&lt;TResult&gt; qy.GroupBy&lt;TSource, TKey, TResult&gt;(Func&lt;TSource, TKey&gt; keySelector, Func&lt;TKey, IEnumerable&lt;TSource&gt;, TResult&gt; resultSelector)
	///</summary>
	public static readonly MethodInfo GroupBy5;

	///<summary>
	///IEnumerable&lt;TResult&gt; qy.GroupBy&lt;TSource, TKey, TElement, TResult&gt;(Func&lt;TSource, TKey&gt; keySelector, Func&lt;TSource, TElement&gt; elementSelector, Func&lt;TKey, IEnumerable&lt;TElement&gt;, TResult&gt; resultSelector)
	///</summary>
	public static readonly MethodInfo GroupBy6;

	///<summary>
	///IEnumerable&lt;TResult&gt; qy.GroupBy&lt;TSource, TKey, TResult&gt;(Func&lt;TSource, TKey&gt; keySelector, Func&lt;TKey, IEnumerable&lt;TSource&gt;, TResult&gt; resultSelector, IEqualityComparer&lt;TKey&gt; comparer)
	///</summary>
	public static readonly MethodInfo GroupBy7;

	///<summary>
	///IEnumerable&lt;TResult&gt; qy.GroupBy&lt;TSource, TKey, TElement, TResult&gt;(Func&lt;TSource, TKey&gt; keySelector, Func&lt;TSource, TElement&gt; elementSelector, Func&lt;TKey, IEnumerable&lt;TElement&gt;, TResult&gt; resultSelector, IEqualityComparer&lt;TKey&gt; comparer)
	///</summary>
	public static readonly MethodInfo GroupBy8;

	///<summary>
	///IEnumerable&lt;TResult&gt; qy.GroupJoin&lt;TOuter, TInner, TKey, TResult&gt;(IEnumerable&lt;TInner&gt; inner, Func&lt;TOuter, TKey&gt; outerKeySelector, Func&lt;TInner, TKey&gt; innerKeySelector, Func&lt;TOuter, IEnumerable&lt;TInner&gt;, TResult&gt; resultSelector)
	///</summary>
	public static readonly MethodInfo GroupJoin;

	///<summary>
	///IEnumerable&lt;TResult&gt; qy.GroupJoin&lt;TOuter, TInner, TKey, TResult&gt;(IEnumerable&lt;TInner&gt; inner, Func&lt;TOuter, TKey&gt; outerKeySelector, Func&lt;TInner, TKey&gt; innerKeySelector, Func&lt;TOuter, IEnumerable&lt;TInner&gt;, TResult&gt; resultSelector, IEqualityComparer&lt;TKey&gt; comparer)
	///</summary>
	public static readonly MethodInfo GroupJoin2;

	///<summary>
	///IEnumerable&lt;TSource&gt; qy.Intersect&lt;TSource&gt;(IEnumerable&lt;TSource&gt; second)
	///</summary>
	public static readonly MethodInfo Intersect;

	///<summary>
	///IEnumerable&lt;TSource&gt; qy.Intersect&lt;TSource&gt;(IEnumerable&lt;TSource&gt; second, IEqualityComparer&lt;TSource&gt; comparer)
	///</summary>
	public static readonly MethodInfo Intersect2;

	///<summary>
	///IEnumerable&lt;TResult&gt; qy.Join&lt;TOuter, TInner, TKey, TResult&gt;(IEnumerable&lt;TInner&gt; inner, Func&lt;TOuter, TKey&gt; outerKeySelector, Func&lt;TInner, TKey&gt; innerKeySelector, Func&lt;TOuter, TInner, TResult&gt; resultSelector)
	///</summary>
	public static readonly MethodInfo Join;

	///<summary>
	///IEnumerable&lt;TResult&gt; qy.Join&lt;TOuter, TInner, TKey, TResult&gt;(IEnumerable&lt;TInner&gt; inner, Func&lt;TOuter, TKey&gt; outerKeySelector, Func&lt;TInner, TKey&gt; innerKeySelector, Func&lt;TOuter, TInner, TResult&gt; resultSelector, IEqualityComparer&lt;TKey&gt; comparer)
	///</summary>
	public static readonly MethodInfo Join2;

	///<summary>
	///TSource qy.Last&lt;TSource&gt;()
	///</summary>
	public static readonly MethodInfo Last;

	///<summary>
	///TSource qy.Last&lt;TSource&gt;(Func&lt;TSource, Boolean&gt; predicate)
	///</summary>
	public static readonly MethodInfo Last2;

	///<summary>
	///TSource qy.LastOrDefault&lt;TSource&gt;()
	///</summary>
	public static readonly MethodInfo LastOrDefault;

	///<summary>
	///TSource qy.LastOrDefault&lt;TSource&gt;(Func&lt;TSource, Boolean&gt; predicate)
	///</summary>
	public static readonly MethodInfo LastOrDefault2;

	///<summary>
	///Int64 qy.LongCount&lt;TSource&gt;()
	///</summary>
	public static readonly MethodInfo LongCount;

	///<summary>
	///Int64 qy.LongCount&lt;TSource&gt;(Func&lt;TSource, Boolean&gt; predicate)
	///</summary>
	public static readonly MethodInfo LongCount2;

	///<summary>
	///Nullable&lt;Int32&gt; qy.Max&lt;&gt;()
	///</summary>
	public static readonly MethodInfo Max;

	///<summary>
	///Int64 qy.Max&lt;&gt;()
	///</summary>
	public static readonly MethodInfo Max2;

	///<summary>
	///Nullable&lt;Int64&gt; qy.Max&lt;&gt;()
	///</summary>
	public static readonly MethodInfo Max3;

	///<summary>
	///Double qy.Max&lt;&gt;()
	///</summary>
	public static readonly MethodInfo Max4;

	///<summary>
	///Nullable&lt;Double&gt; qy.Max&lt;&gt;()
	///</summary>
	public static readonly MethodInfo Max5;

	///<summary>
	///Single qy.Max&lt;&gt;()
	///</summary>
	public static readonly MethodInfo Max6;

	///<summary>
	///Nullable&lt;Single&gt; qy.Max&lt;&gt;()
	///</summary>
	public static readonly MethodInfo Max7;

	///<summary>
	///Decimal qy.Max&lt;&gt;()
	///</summary>
	public static readonly MethodInfo Max8;

	///<summary>
	///Nullable&lt;Decimal&gt; qy.Max&lt;&gt;()
	///</summary>
	public static readonly MethodInfo Max9;

	///<summary>
	///TSource qy.Max&lt;TSource&gt;()
	///</summary>
	public static readonly MethodInfo Max10;

	///<summary>
	///Int32 qy.Max&lt;TSource&gt;(Func&lt;TSource, Int32&gt; selector)
	///</summary>
	public static readonly MethodInfo Max11;

	///<summary>
	///Nullable&lt;Int32&gt; qy.Max&lt;TSource&gt;(Func&lt;TSource, Nullable&lt;Int32&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Max12;

	///<summary>
	///Int64 qy.Max&lt;TSource&gt;(Func&lt;TSource, Int64&gt; selector)
	///</summary>
	public static readonly MethodInfo Max13;

	///<summary>
	///Nullable&lt;Int64&gt; qy.Max&lt;TSource&gt;(Func&lt;TSource, Nullable&lt;Int64&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Max14;

	///<summary>
	///Single qy.Max&lt;TSource&gt;(Func&lt;TSource, Single&gt; selector)
	///</summary>
	public static readonly MethodInfo Max15;

	///<summary>
	///Nullable&lt;Single&gt; qy.Max&lt;TSource&gt;(Func&lt;TSource, Nullable&lt;Single&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Max16;

	///<summary>
	///Double qy.Max&lt;TSource&gt;(Func&lt;TSource, Double&gt; selector)
	///</summary>
	public static readonly MethodInfo Max17;

	///<summary>
	///Nullable&lt;Double&gt; qy.Max&lt;TSource&gt;(Func&lt;TSource, Nullable&lt;Double&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Max18;

	///<summary>
	///Decimal qy.Max&lt;TSource&gt;(Func&lt;TSource, Decimal&gt; selector)
	///</summary>
	public static readonly MethodInfo Max19;

	///<summary>
	///Nullable&lt;Decimal&gt; qy.Max&lt;TSource&gt;(Func&lt;TSource, Nullable&lt;Decimal&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Max20;

	///<summary>
	///TResult qy.Max&lt;TSource, TResult&gt;(Func&lt;TSource, TResult&gt; selector)
	///</summary>
	public static readonly MethodInfo Max21;

	///<summary>
	///Int32 qy.Max&lt;&gt;()
	///</summary>
	public static readonly MethodInfo Max22;

	///<summary>
	///Int32 qy.Min&lt;&gt;()
	///</summary>
	public static readonly MethodInfo Min;

	///<summary>
	///Nullable&lt;Int32&gt; qy.Min&lt;&gt;()
	///</summary>
	public static readonly MethodInfo Min2;

	///<summary>
	///Int64 qy.Min&lt;&gt;()
	///</summary>
	public static readonly MethodInfo Min3;

	///<summary>
	///Nullable&lt;Int64&gt; qy.Min&lt;&gt;()
	///</summary>
	public static readonly MethodInfo Min4;

	///<summary>
	///Single qy.Min&lt;&gt;()
	///</summary>
	public static readonly MethodInfo Min5;

	///<summary>
	///Nullable&lt;Single&gt; qy.Min&lt;&gt;()
	///</summary>
	public static readonly MethodInfo Min6;

	///<summary>
	///Double qy.Min&lt;&gt;()
	///</summary>
	public static readonly MethodInfo Min7;

	///<summary>
	///Nullable&lt;Double&gt; qy.Min&lt;&gt;()
	///</summary>
	public static readonly MethodInfo Min8;

	///<summary>
	///Decimal qy.Min&lt;&gt;()
	///</summary>
	public static readonly MethodInfo Min9;

	///<summary>
	///Nullable&lt;Decimal&gt; qy.Min&lt;&gt;()
	///</summary>
	public static readonly MethodInfo Min10;

	///<summary>
	///TSource qy.Min&lt;TSource&gt;()
	///</summary>
	public static readonly MethodInfo Min11;

	///<summary>
	///Int32 qy.Min&lt;TSource&gt;(Func&lt;TSource, Int32&gt; selector)
	///</summary>
	public static readonly MethodInfo Min12;

	///<summary>
	///Nullable&lt;Int32&gt; qy.Min&lt;TSource&gt;(Func&lt;TSource, Nullable&lt;Int32&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Min13;

	///<summary>
	///Int64 qy.Min&lt;TSource&gt;(Func&lt;TSource, Int64&gt; selector)
	///</summary>
	public static readonly MethodInfo Min14;

	///<summary>
	///Nullable&lt;Int64&gt; qy.Min&lt;TSource&gt;(Func&lt;TSource, Nullable&lt;Int64&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Min15;

	///<summary>
	///Single qy.Min&lt;TSource&gt;(Func&lt;TSource, Single&gt; selector)
	///</summary>
	public static readonly MethodInfo Min16;

	///<summary>
	///Nullable&lt;Single&gt; qy.Min&lt;TSource&gt;(Func&lt;TSource, Nullable&lt;Single&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Min17;

	///<summary>
	///Double qy.Min&lt;TSource&gt;(Func&lt;TSource, Double&gt; selector)
	///</summary>
	public static readonly MethodInfo Min18;

	///<summary>
	///Nullable&lt;Double&gt; qy.Min&lt;TSource&gt;(Func&lt;TSource, Nullable&lt;Double&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Min19;

	///<summary>
	///Decimal qy.Min&lt;TSource&gt;(Func&lt;TSource, Decimal&gt; selector)
	///</summary>
	public static readonly MethodInfo Min20;

	///<summary>
	///Nullable&lt;Decimal&gt; qy.Min&lt;TSource&gt;(Func&lt;TSource, Nullable&lt;Decimal&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Min21;

	///<summary>
	///TResult qy.Min&lt;TSource, TResult&gt;(Func&lt;TSource, TResult&gt; selector)
	///</summary>
	public static readonly MethodInfo Min22;

	///<summary>
	///IEnumerable&lt;TResult&gt; qy.OfType&lt;TResult&gt;()
	///</summary>
	public static readonly MethodInfo OfType;

	///<summary>
	///IOrderedEnumerable&lt;TSource&gt; qy.OrderBy&lt;TSource, TKey&gt;(Func&lt;TSource, TKey&gt; keySelector)
	///</summary>
	public static readonly MethodInfo OrderBy;

	///<summary>
	///IOrderedEnumerable&lt;TSource&gt; qy.OrderBy&lt;TSource, TKey&gt;(Func&lt;TSource, TKey&gt; keySelector, IComparer&lt;TKey&gt; comparer)
	///</summary>
	public static readonly MethodInfo OrderBy2;

	///<summary>
	///IOrderedEnumerable&lt;TSource&gt; qy.OrderByDescending&lt;TSource, TKey&gt;(Func&lt;TSource, TKey&gt; keySelector)
	///</summary>
	public static readonly MethodInfo OrderByDescending;

	///<summary>
	///IOrderedEnumerable&lt;TSource&gt; qy.OrderByDescending&lt;TSource, TKey&gt;(Func&lt;TSource, TKey&gt; keySelector, IComparer&lt;TKey&gt; comparer)
	///</summary>
	public static readonly MethodInfo OrderByDescending2;

	///<summary>
	///IEnumerable&lt;TSource&gt; qy.Reverse&lt;TSource&gt;()
	///</summary>
	public static readonly MethodInfo Reverse;

	///<summary>
	///IEnumerable&lt;TResult&gt; qy.Select&lt;TSource, TResult&gt;(Func&lt;TSource, TResult&gt; selector)
	///</summary>
	public static readonly MethodInfo Select;

	///<summary>
	///IEnumerable&lt;TResult&gt; qy.Select&lt;TSource, TResult&gt;(Func&lt;TSource, Int32, TResult&gt; selector)
	///</summary>
	public static readonly MethodInfo Select2;

	///<summary>
	///IEnumerable&lt;TResult&gt; qy.SelectMany&lt;TSource, TResult&gt;(Func&lt;TSource, IEnumerable&lt;TResult&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo SelectMany;

	///<summary>
	///IEnumerable&lt;TResult&gt; qy.SelectMany&lt;TSource, TResult&gt;(Func&lt;TSource, Int32, IEnumerable&lt;TResult&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo SelectMany2;

	///<summary>
	///IEnumerable&lt;TResult&gt; qy.SelectMany&lt;TSource, TCollection, TResult&gt;(Func&lt;TSource, Int32, IEnumerable&lt;TCollection&gt;&gt; collectionSelector, Func&lt;TSource, TCollection, TResult&gt; resultSelector)
	///</summary>
	public static readonly MethodInfo SelectMany3;

	///<summary>
	///IEnumerable&lt;TResult&gt; qy.SelectMany&lt;TSource, TCollection, TResult&gt;(Func&lt;TSource, IEnumerable&lt;TCollection&gt;&gt; collectionSelector, Func&lt;TSource, TCollection, TResult&gt; resultSelector)
	///</summary>
	public static readonly MethodInfo SelectMany4;

	///<summary>
	///Boolean qy.SequenceEqual&lt;TSource&gt;(IEnumerable&lt;TSource&gt; second)
	///</summary>
	public static readonly MethodInfo SequenceEqual;

	///<summary>
	///Boolean qy.SequenceEqual&lt;TSource&gt;(IEnumerable&lt;TSource&gt; second, IEqualityComparer&lt;TSource&gt; comparer)
	///</summary>
	public static readonly MethodInfo SequenceEqual2;

	///<summary>
	///TSource qy.Single&lt;TSource&gt;()
	///</summary>
	public static readonly MethodInfo Single;

	///<summary>
	///TSource qy.Single&lt;TSource&gt;(Func&lt;TSource, Boolean&gt; predicate)
	///</summary>
	public static readonly MethodInfo Single2;

	///<summary>
	///TSource qy.SingleOrDefault&lt;TSource&gt;()
	///</summary>
	public static readonly MethodInfo SingleOrDefault;

	///<summary>
	///TSource qy.SingleOrDefault&lt;TSource&gt;(Func&lt;TSource, Boolean&gt; predicate)
	///</summary>
	public static readonly MethodInfo SingleOrDefault2;

	///<summary>
	///IEnumerable&lt;TSource&gt; qy.Skip&lt;TSource&gt;(Int32 count)
	///</summary>
	public static readonly MethodInfo Skip;

	///<summary>
	///IEnumerable&lt;TSource&gt; qy.SkipWhile&lt;TSource&gt;(Func&lt;TSource, Boolean&gt; predicate)
	///</summary>
	public static readonly MethodInfo SkipWhile;

	///<summary>
	///IEnumerable&lt;TSource&gt; qy.SkipWhile&lt;TSource&gt;(Func&lt;TSource, Int32, Boolean&gt; predicate)
	///</summary>
	public static readonly MethodInfo SkipWhile2;

	///<summary>
	///Int32 qy.Sum&lt;&gt;()
	///</summary>
	public static readonly MethodInfo Sum;

	///<summary>
	///Nullable&lt;Int32&gt; qy.Sum&lt;&gt;()
	///</summary>
	public static readonly MethodInfo Sum2;

	///<summary>
	///Int64 qy.Sum&lt;&gt;()
	///</summary>
	public static readonly MethodInfo Sum3;

	///<summary>
	///Nullable&lt;Int64&gt; qy.Sum&lt;&gt;()
	///</summary>
	public static readonly MethodInfo Sum4;

	///<summary>
	///Single qy.Sum&lt;&gt;()
	///</summary>
	public static readonly MethodInfo Sum5;

	///<summary>
	///Nullable&lt;Single&gt; qy.Sum&lt;&gt;()
	///</summary>
	public static readonly MethodInfo Sum6;

	///<summary>
	///Double qy.Sum&lt;&gt;()
	///</summary>
	public static readonly MethodInfo Sum7;

	///<summary>
	///Nullable&lt;Double&gt; qy.Sum&lt;&gt;()
	///</summary>
	public static readonly MethodInfo Sum8;

	///<summary>
	///Decimal qy.Sum&lt;&gt;()
	///</summary>
	public static readonly MethodInfo Sum9;

	///<summary>
	///Nullable&lt;Decimal&gt; qy.Sum&lt;&gt;()
	///</summary>
	public static readonly MethodInfo Sum10;

	///<summary>
	///Int32 qy.Sum&lt;TSource&gt;(Func&lt;TSource, Int32&gt; selector)
	///</summary>
	public static readonly MethodInfo Sum11;

	///<summary>
	///Nullable&lt;Int32&gt; qy.Sum&lt;TSource&gt;(Func&lt;TSource, Nullable&lt;Int32&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Sum12;

	///<summary>
	///Int64 qy.Sum&lt;TSource&gt;(Func&lt;TSource, Int64&gt; selector)
	///</summary>
	public static readonly MethodInfo Sum13;

	///<summary>
	///Nullable&lt;Int64&gt; qy.Sum&lt;TSource&gt;(Func&lt;TSource, Nullable&lt;Int64&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Sum14;

	///<summary>
	///Single qy.Sum&lt;TSource&gt;(Func&lt;TSource, Single&gt; selector)
	///</summary>
	public static readonly MethodInfo Sum15;

	///<summary>
	///Nullable&lt;Single&gt; qy.Sum&lt;TSource&gt;(Func&lt;TSource, Nullable&lt;Single&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Sum16;

	///<summary>
	///Double qy.Sum&lt;TSource&gt;(Func&lt;TSource, Double&gt; selector)
	///</summary>
	public static readonly MethodInfo Sum17;

	///<summary>
	///Nullable&lt;Double&gt; qy.Sum&lt;TSource&gt;(Func&lt;TSource, Nullable&lt;Double&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Sum18;

	///<summary>
	///Decimal qy.Sum&lt;TSource&gt;(Func&lt;TSource, Decimal&gt; selector)
	///</summary>
	public static readonly MethodInfo Sum19;

	///<summary>
	///Nullable&lt;Decimal&gt; qy.Sum&lt;TSource&gt;(Func&lt;TSource, Nullable&lt;Decimal&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Sum20;

	///<summary>
	///IEnumerable&lt;TSource&gt; qy.Take&lt;TSource&gt;(Int32 count)
	///</summary>
	public static readonly MethodInfo Take;

	///<summary>
	///IEnumerable&lt;TSource&gt; qy.TakeWhile&lt;TSource&gt;(Func&lt;TSource, Boolean&gt; predicate)
	///</summary>
	public static readonly MethodInfo TakeWhile;

	///<summary>
	///IEnumerable&lt;TSource&gt; qy.TakeWhile&lt;TSource&gt;(Func&lt;TSource, Int32, Boolean&gt; predicate)
	///</summary>
	public static readonly MethodInfo TakeWhile2;

	///<summary>
	///IOrderedEnumerable&lt;TSource&gt; qy.ThenBy&lt;TSource, TKey&gt;(Func&lt;TSource, TKey&gt; keySelector)
	///</summary>
	public static readonly MethodInfo ThenBy;

	///<summary>
	///IOrderedEnumerable&lt;TSource&gt; qy.ThenBy&lt;TSource, TKey&gt;(Func&lt;TSource, TKey&gt; keySelector, IComparer&lt;TKey&gt; comparer)
	///</summary>
	public static readonly MethodInfo ThenBy2;

	///<summary>
	///IOrderedEnumerable&lt;TSource&gt; qy.ThenByDescending&lt;TSource, TKey&gt;(Func&lt;TSource, TKey&gt; keySelector)
	///</summary>
	public static readonly MethodInfo ThenByDescending;

	///<summary>
	///IOrderedEnumerable&lt;TSource&gt; qy.ThenByDescending&lt;TSource, TKey&gt;(Func&lt;TSource, TKey&gt; keySelector, IComparer&lt;TKey&gt; comparer)
	///</summary>
	public static readonly MethodInfo ThenByDescending2;

	///<summary>
	///TSource[] qy.ToArray&lt;TSource&gt;()
	///</summary>
	public static readonly MethodInfo ToArray;

	///<summary>
	///Dictionary&lt;TKey, TSource&gt; qy.ToDictionary&lt;TSource, TKey&gt;(Func&lt;TSource, TKey&gt; keySelector)
	///</summary>
	public static readonly MethodInfo ToDictionary;

	///<summary>
	///Dictionary&lt;TKey, TSource&gt; qy.ToDictionary&lt;TSource, TKey&gt;(Func&lt;TSource, TKey&gt; keySelector, IEqualityComparer&lt;TKey&gt; comparer)
	///</summary>
	public static readonly MethodInfo ToDictionary2;

	///<summary>
	///Dictionary&lt;TKey, TElement&gt; qy.ToDictionary&lt;TSource, TKey, TElement&gt;(Func&lt;TSource, TKey&gt; keySelector, Func&lt;TSource, TElement&gt; elementSelector)
	///</summary>
	public static readonly MethodInfo ToDictionary3;

	///<summary>
	///Dictionary&lt;TKey, TElement&gt; qy.ToDictionary&lt;TSource, TKey, TElement&gt;(Func&lt;TSource, TKey&gt; keySelector, Func&lt;TSource, TElement&gt; elementSelector, IEqualityComparer&lt;TKey&gt; comparer)
	///</summary>
	public static readonly MethodInfo ToDictionary4;

	///<summary>
	///List&lt;TSource&gt; qy.ToList&lt;TSource&gt;()
	///</summary>
	public static readonly MethodInfo ToList;

	///<summary>
	///ILookup&lt;TKey, TSource&gt; qy.ToLookup&lt;TSource, TKey&gt;(Func&lt;TSource, TKey&gt; keySelector)
	///</summary>
	public static readonly MethodInfo ToLookup;

	///<summary>
	///ILookup&lt;TKey, TSource&gt; qy.ToLookup&lt;TSource, TKey&gt;(Func&lt;TSource, TKey&gt; keySelector, IEqualityComparer&lt;TKey&gt; comparer)
	///</summary>
	public static readonly MethodInfo ToLookup2;

	///<summary>
	///ILookup&lt;TKey, TElement&gt; qy.ToLookup&lt;TSource, TKey, TElement&gt;(Func&lt;TSource, TKey&gt; keySelector, Func&lt;TSource, TElement&gt; elementSelector)
	///</summary>
	public static readonly MethodInfo ToLookup3;

	///<summary>
	///ILookup&lt;TKey, TElement&gt; qy.ToLookup&lt;TSource, TKey, TElement&gt;(Func&lt;TSource, TKey&gt; keySelector, Func&lt;TSource, TElement&gt; elementSelector, IEqualityComparer&lt;TKey&gt; comparer)
	///</summary>
	public static readonly MethodInfo ToLookup4;

	///<summary>
	///IEnumerable&lt;TSource&gt; qy.Union&lt;TSource&gt;(IEnumerable&lt;TSource&gt; second)
	///</summary>
	public static readonly MethodInfo Union;

	///<summary>
	///IEnumerable&lt;TSource&gt; qy.Union&lt;TSource&gt;(IEnumerable&lt;TSource&gt; second, IEqualityComparer&lt;TSource&gt; comparer)
	///</summary>
	public static readonly MethodInfo Union2;

	///<summary>
	///IEnumerable&lt;TSource&gt; qy.Where&lt;TSource&gt;(Func&lt;TSource, Boolean&gt; predicate)
	///</summary>
	public static readonly MethodInfo Where;

	///<summary>
	///IEnumerable&lt;TSource&gt; qy.Where&lt;TSource&gt;(Func&lt;TSource, Int32, Boolean&gt; predicate)
	///</summary>
	public static readonly MethodInfo Where2;

	///<summary>
	///IEnumerable&lt;TResult&gt; qy.Zip&lt;TFirst, TSecond, TResult&gt;(IEnumerable&lt;TSecond&gt; second, Func&lt;TFirst, TSecond, TResult&gt; resultSelector)
	///</summary>
	public static readonly MethodInfo Zip;

	
	static EnMethods() 
	{
		Aggregate = Refl.GetGenMethod(() => Enumerable.Aggregate<object>((IEnumerable<object>)null, (Func<object, object, object>)null));
		Aggregate2 = Refl.GetGenMethod(() => Enumerable.Aggregate<object, object>((IEnumerable<object>)null, (object)null, (Func<object, object, object>)null));
		Aggregate3 = Refl.GetGenMethod(() => Enumerable.Aggregate<object, object, object>((IEnumerable<object>)null, (object)null, (Func<object, object, object>)null, (Func<object, object>)null));
		All = Refl.GetGenMethod(() => Enumerable.All<object>((IEnumerable<object>)null, (Func<object, Boolean>)null));
		Any = Refl.GetGenMethod(() => Enumerable.Any<object>((IEnumerable<object>)null));
		Any2 = Refl.GetGenMethod(() => Enumerable.Any<object>((IEnumerable<object>)null, (Func<object, Boolean>)null));
		AsEnumerable = Refl.GetGenMethod(() => Enumerable.AsEnumerable<object>((IEnumerable<object>)null));
		Average = Refl.GetGenMethod(() => Enumerable.Average((IEnumerable<Int32>)null));
		Average2 = Refl.GetGenMethod(() => Enumerable.Average((IEnumerable<Nullable<Int32>>)null));
		Average3 = Refl.GetGenMethod(() => Enumerable.Average((IEnumerable<Int64>)null));
		Average4 = Refl.GetGenMethod(() => Enumerable.Average((IEnumerable<Nullable<Int64>>)null));
		Average5 = Refl.GetGenMethod(() => Enumerable.Average((IEnumerable<Single>)null));
		Average6 = Refl.GetGenMethod(() => Enumerable.Average((IEnumerable<Nullable<Single>>)null));
		Average7 = Refl.GetGenMethod(() => Enumerable.Average((IEnumerable<Double>)null));
		Average8 = Refl.GetGenMethod(() => Enumerable.Average((IEnumerable<Nullable<Double>>)null));
		Average9 = Refl.GetGenMethod(() => Enumerable.Average((IEnumerable<Decimal>)null));
		Average10 = Refl.GetGenMethod(() => Enumerable.Average((IEnumerable<Nullable<Decimal>>)null));
		Average11 = Refl.GetGenMethod(() => Enumerable.Average<object>((IEnumerable<object>)null, (Func<object, Int32>)null));
		Average12 = Refl.GetGenMethod(() => Enumerable.Average<object>((IEnumerable<object>)null, (Func<object, Nullable<Int32>>)null));
		Average13 = Refl.GetGenMethod(() => Enumerable.Average<object>((IEnumerable<object>)null, (Func<object, Int64>)null));
		Average14 = Refl.GetGenMethod(() => Enumerable.Average<object>((IEnumerable<object>)null, (Func<object, Nullable<Int64>>)null));
		Average15 = Refl.GetGenMethod(() => Enumerable.Average<object>((IEnumerable<object>)null, (Func<object, Single>)null));
		Average16 = Refl.GetGenMethod(() => Enumerable.Average<object>((IEnumerable<object>)null, (Func<object, Nullable<Single>>)null));
		Average17 = Refl.GetGenMethod(() => Enumerable.Average<object>((IEnumerable<object>)null, (Func<object, Double>)null));
		Average18 = Refl.GetGenMethod(() => Enumerable.Average<object>((IEnumerable<object>)null, (Func<object, Nullable<Double>>)null));
		Average19 = Refl.GetGenMethod(() => Enumerable.Average<object>((IEnumerable<object>)null, (Func<object, Decimal>)null));
		Average20 = Refl.GetGenMethod(() => Enumerable.Average<object>((IEnumerable<object>)null, (Func<object, Nullable<Decimal>>)null));
		Cast = Refl.GetGenMethod(() => Enumerable.Cast<object>((IEnumerable)null));
		Concat = Refl.GetGenMethod(() => Enumerable.Concat<object>((IEnumerable<object>)null, (IEnumerable<object>)null));
		Contains = Refl.GetGenMethod(() => Enumerable.Contains<object>((IEnumerable<object>)null, (object)null));
		Contains2 = Refl.GetGenMethod(() => Enumerable.Contains<object>((IEnumerable<object>)null, (object)null, (IEqualityComparer<object>)null));
		Count = Refl.GetGenMethod(() => Enumerable.Count<object>((IEnumerable<object>)null));
		Count2 = Refl.GetGenMethod(() => Enumerable.Count<object>((IEnumerable<object>)null, (Func<object, Boolean>)null));
		DefaultIfEmpty = Refl.GetGenMethod(() => Enumerable.DefaultIfEmpty<object>((IEnumerable<object>)null));
		DefaultIfEmpty2 = Refl.GetGenMethod(() => Enumerable.DefaultIfEmpty<object>((IEnumerable<object>)null, (object)null));
		Distinct = Refl.GetGenMethod(() => Enumerable.Distinct<object>((IEnumerable<object>)null));
		Distinct2 = Refl.GetGenMethod(() => Enumerable.Distinct<object>((IEnumerable<object>)null, (IEqualityComparer<object>)null));
		ElementAt = Refl.GetGenMethod(() => Enumerable.ElementAt<object>((IEnumerable<object>)null, 0));
		ElementAtOrDefault = Refl.GetGenMethod(() => Enumerable.ElementAtOrDefault<object>((IEnumerable<object>)null, 0));
		Except = Refl.GetGenMethod(() => Enumerable.Except<object>((IEnumerable<object>)null, (IEnumerable<object>)null));
		Except2 = Refl.GetGenMethod(() => Enumerable.Except<object>((IEnumerable<object>)null, (IEnumerable<object>)null, (IEqualityComparer<object>)null));
		First = Refl.GetGenMethod(() => Enumerable.First<object>((IEnumerable<object>)null));
		First2 = Refl.GetGenMethod(() => Enumerable.First<object>((IEnumerable<object>)null, (Func<object, Boolean>)null));
		FirstOrDefault = Refl.GetGenMethod(() => Enumerable.FirstOrDefault<object>((IEnumerable<object>)null));
		FirstOrDefault2 = Refl.GetGenMethod(() => Enumerable.FirstOrDefault<object>((IEnumerable<object>)null, (Func<object, Boolean>)null));
		GroupBy = Refl.GetGenMethod(() => Enumerable.GroupBy<object, object>((IEnumerable<object>)null, (Func<object, object>)null));
		GroupBy2 = Refl.GetGenMethod(() => Enumerable.GroupBy<object, object>((IEnumerable<object>)null, (Func<object, object>)null, (IEqualityComparer<object>)null));
		GroupBy3 = Refl.GetGenMethod(() => Enumerable.GroupBy<object, object, object>((IEnumerable<object>)null, (Func<object, object>)null, (Func<object, object>)null));
		GroupBy4 = Refl.GetGenMethod(() => Enumerable.GroupBy<object, object, object>((IEnumerable<object>)null, (Func<object, object>)null, (Func<object, object>)null, (IEqualityComparer<object>)null));
		GroupBy5 = Refl.GetGenMethod(() => Enumerable.GroupBy<object, object, object>((IEnumerable<object>)null, (Func<object, object>)null, (Func<object, IEnumerable<object>, object>)null));
		GroupBy6 = Refl.GetGenMethod(() => Enumerable.GroupBy<object, object, object, object>((IEnumerable<object>)null, (Func<object, object>)null, (Func<object, object>)null, (Func<object, IEnumerable<object>, object>)null));
		GroupBy7 = Refl.GetGenMethod(() => Enumerable.GroupBy<object, object, object>((IEnumerable<object>)null, (Func<object, object>)null, (Func<object, IEnumerable<object>, object>)null, (IEqualityComparer<object>)null));
		GroupBy8 = Refl.GetGenMethod(() => Enumerable.GroupBy<object, object, object, object>((IEnumerable<object>)null, (Func<object, object>)null, (Func<object, object>)null, (Func<object, IEnumerable<object>, object>)null, (IEqualityComparer<object>)null));
		GroupJoin = Refl.GetGenMethod(() => Enumerable.GroupJoin<object, object, object, object>((IEnumerable<object>)null, (IEnumerable<object>)null, (Func<object, object>)null, (Func<object, object>)null, (Func<object, IEnumerable<object>, object>)null));
		GroupJoin2 = Refl.GetGenMethod(() => Enumerable.GroupJoin<object, object, object, object>((IEnumerable<object>)null, (IEnumerable<object>)null, (Func<object, object>)null, (Func<object, object>)null, (Func<object, IEnumerable<object>, object>)null, (IEqualityComparer<object>)null));
		Intersect = Refl.GetGenMethod(() => Enumerable.Intersect<object>((IEnumerable<object>)null, (IEnumerable<object>)null));
		Intersect2 = Refl.GetGenMethod(() => Enumerable.Intersect<object>((IEnumerable<object>)null, (IEnumerable<object>)null, (IEqualityComparer<object>)null));
		Join = Refl.GetGenMethod(() => Enumerable.Join<object, object, object, object>((IEnumerable<object>)null, (IEnumerable<object>)null, (Func<object, object>)null, (Func<object, object>)null, (Func<object, object, object>)null));
		Join2 = Refl.GetGenMethod(() => Enumerable.Join<object, object, object, object>((IEnumerable<object>)null, (IEnumerable<object>)null, (Func<object, object>)null, (Func<object, object>)null, (Func<object, object, object>)null, (IEqualityComparer<object>)null));
		Last = Refl.GetGenMethod(() => Enumerable.Last<object>((IEnumerable<object>)null));
		Last2 = Refl.GetGenMethod(() => Enumerable.Last<object>((IEnumerable<object>)null, (Func<object, Boolean>)null));
		LastOrDefault = Refl.GetGenMethod(() => Enumerable.LastOrDefault<object>((IEnumerable<object>)null));
		LastOrDefault2 = Refl.GetGenMethod(() => Enumerable.LastOrDefault<object>((IEnumerable<object>)null, (Func<object, Boolean>)null));
		LongCount = Refl.GetGenMethod(() => Enumerable.LongCount<object>((IEnumerable<object>)null));
		LongCount2 = Refl.GetGenMethod(() => Enumerable.LongCount<object>((IEnumerable<object>)null, (Func<object, Boolean>)null));
		Max = Refl.GetGenMethod(() => Enumerable.Max((IEnumerable<Nullable<Int32>>)null));
		Max2 = Refl.GetGenMethod(() => Enumerable.Max((IEnumerable<Int64>)null));
		Max3 = Refl.GetGenMethod(() => Enumerable.Max((IEnumerable<Nullable<Int64>>)null));
		Max4 = Refl.GetGenMethod(() => Enumerable.Max((IEnumerable<Double>)null));
		Max5 = Refl.GetGenMethod(() => Enumerable.Max((IEnumerable<Nullable<Double>>)null));
		Max6 = Refl.GetGenMethod(() => Enumerable.Max((IEnumerable<Single>)null));
		Max7 = Refl.GetGenMethod(() => Enumerable.Max((IEnumerable<Nullable<Single>>)null));
		Max8 = Refl.GetGenMethod(() => Enumerable.Max((IEnumerable<Decimal>)null));
		Max9 = Refl.GetGenMethod(() => Enumerable.Max((IEnumerable<Nullable<Decimal>>)null));
		Max10 = Refl.GetGenMethod(() => Enumerable.Max<object>((IEnumerable<object>)null));
		Max11 = Refl.GetGenMethod(() => Enumerable.Max<object>((IEnumerable<object>)null, (Func<object, Int32>)null));
		Max12 = Refl.GetGenMethod(() => Enumerable.Max<object>((IEnumerable<object>)null, (Func<object, Nullable<Int32>>)null));
		Max13 = Refl.GetGenMethod(() => Enumerable.Max<object>((IEnumerable<object>)null, (Func<object, Int64>)null));
		Max14 = Refl.GetGenMethod(() => Enumerable.Max<object>((IEnumerable<object>)null, (Func<object, Nullable<Int64>>)null));
		Max15 = Refl.GetGenMethod(() => Enumerable.Max<object>((IEnumerable<object>)null, (Func<object, Single>)null));
		Max16 = Refl.GetGenMethod(() => Enumerable.Max<object>((IEnumerable<object>)null, (Func<object, Nullable<Single>>)null));
		Max17 = Refl.GetGenMethod(() => Enumerable.Max<object>((IEnumerable<object>)null, (Func<object, Double>)null));
		Max18 = Refl.GetGenMethod(() => Enumerable.Max<object>((IEnumerable<object>)null, (Func<object, Nullable<Double>>)null));
		Max19 = Refl.GetGenMethod(() => Enumerable.Max<object>((IEnumerable<object>)null, (Func<object, Decimal>)null));
		Max20 = Refl.GetGenMethod(() => Enumerable.Max<object>((IEnumerable<object>)null, (Func<object, Nullable<Decimal>>)null));
		Max21 = Refl.GetGenMethod(() => Enumerable.Max<object, object>((IEnumerable<object>)null, (Func<object, object>)null));
		Max22 = Refl.GetGenMethod(() => Enumerable.Max((IEnumerable<Int32>)null));
		Min = Refl.GetGenMethod(() => Enumerable.Min((IEnumerable<Int32>)null));
		Min2 = Refl.GetGenMethod(() => Enumerable.Min((IEnumerable<Nullable<Int32>>)null));
		Min3 = Refl.GetGenMethod(() => Enumerable.Min((IEnumerable<Int64>)null));
		Min4 = Refl.GetGenMethod(() => Enumerable.Min((IEnumerable<Nullable<Int64>>)null));
		Min5 = Refl.GetGenMethod(() => Enumerable.Min((IEnumerable<Single>)null));
		Min6 = Refl.GetGenMethod(() => Enumerable.Min((IEnumerable<Nullable<Single>>)null));
		Min7 = Refl.GetGenMethod(() => Enumerable.Min((IEnumerable<Double>)null));
		Min8 = Refl.GetGenMethod(() => Enumerable.Min((IEnumerable<Nullable<Double>>)null));
		Min9 = Refl.GetGenMethod(() => Enumerable.Min((IEnumerable<Decimal>)null));
		Min10 = Refl.GetGenMethod(() => Enumerable.Min((IEnumerable<Nullable<Decimal>>)null));
		Min11 = Refl.GetGenMethod(() => Enumerable.Min<object>((IEnumerable<object>)null));
		Min12 = Refl.GetGenMethod(() => Enumerable.Min<object>((IEnumerable<object>)null, (Func<object, Int32>)null));
		Min13 = Refl.GetGenMethod(() => Enumerable.Min<object>((IEnumerable<object>)null, (Func<object, Nullable<Int32>>)null));
		Min14 = Refl.GetGenMethod(() => Enumerable.Min<object>((IEnumerable<object>)null, (Func<object, Int64>)null));
		Min15 = Refl.GetGenMethod(() => Enumerable.Min<object>((IEnumerable<object>)null, (Func<object, Nullable<Int64>>)null));
		Min16 = Refl.GetGenMethod(() => Enumerable.Min<object>((IEnumerable<object>)null, (Func<object, Single>)null));
		Min17 = Refl.GetGenMethod(() => Enumerable.Min<object>((IEnumerable<object>)null, (Func<object, Nullable<Single>>)null));
		Min18 = Refl.GetGenMethod(() => Enumerable.Min<object>((IEnumerable<object>)null, (Func<object, Double>)null));
		Min19 = Refl.GetGenMethod(() => Enumerable.Min<object>((IEnumerable<object>)null, (Func<object, Nullable<Double>>)null));
		Min20 = Refl.GetGenMethod(() => Enumerable.Min<object>((IEnumerable<object>)null, (Func<object, Decimal>)null));
		Min21 = Refl.GetGenMethod(() => Enumerable.Min<object>((IEnumerable<object>)null, (Func<object, Nullable<Decimal>>)null));
		Min22 = Refl.GetGenMethod(() => Enumerable.Min<object, object>((IEnumerable<object>)null, (Func<object, object>)null));
		OfType = Refl.GetGenMethod(() => Enumerable.OfType<object>((IEnumerable)null));
		OrderBy = Refl.GetGenMethod(() => Enumerable.OrderBy<object, object>((IEnumerable<object>)null, (Func<object, object>)null));
		OrderBy2 = Refl.GetGenMethod(() => Enumerable.OrderBy<object, object>((IEnumerable<object>)null, (Func<object, object>)null, (IComparer<object>)null));
		OrderByDescending = Refl.GetGenMethod(() => Enumerable.OrderByDescending<object, object>((IEnumerable<object>)null, (Func<object, object>)null));
		OrderByDescending2 = Refl.GetGenMethod(() => Enumerable.OrderByDescending<object, object>((IEnumerable<object>)null, (Func<object, object>)null, (IComparer<object>)null));
		Reverse = Refl.GetGenMethod(() => Enumerable.Reverse<object>((IEnumerable<object>)null));
		Select = Refl.GetGenMethod(() => Enumerable.Select<object, object>((IEnumerable<object>)null, (Func<object, object>)null));
		Select2 = Refl.GetGenMethod(() => Enumerable.Select<object, object>((IEnumerable<object>)null, (Func<object, Int32, object>)null));
		SelectMany = Refl.GetGenMethod(() => Enumerable.SelectMany<object, object>((IEnumerable<object>)null, (Func<object, IEnumerable<object>>)null));
		SelectMany2 = Refl.GetGenMethod(() => Enumerable.SelectMany<object, object>((IEnumerable<object>)null, (Func<object, Int32, IEnumerable<object>>)null));
		SelectMany3 = Refl.GetGenMethod(() => Enumerable.SelectMany<object, object, object>((IEnumerable<object>)null, (Func<object, Int32, IEnumerable<object>>)null, (Func<object, object, object>)null));
		SelectMany4 = Refl.GetGenMethod(() => Enumerable.SelectMany<object, object, object>((IEnumerable<object>)null, (Func<object, IEnumerable<object>>)null, (Func<object, object, object>)null));
		SequenceEqual = Refl.GetGenMethod(() => Enumerable.SequenceEqual<object>((IEnumerable<object>)null, (IEnumerable<object>)null));
		SequenceEqual2 = Refl.GetGenMethod(() => Enumerable.SequenceEqual<object>((IEnumerable<object>)null, (IEnumerable<object>)null, (IEqualityComparer<object>)null));
		Single = Refl.GetGenMethod(() => Enumerable.Single<object>((IEnumerable<object>)null));
		Single2 = Refl.GetGenMethod(() => Enumerable.Single<object>((IEnumerable<object>)null, (Func<object, Boolean>)null));
		SingleOrDefault = Refl.GetGenMethod(() => Enumerable.SingleOrDefault<object>((IEnumerable<object>)null));
		SingleOrDefault2 = Refl.GetGenMethod(() => Enumerable.SingleOrDefault<object>((IEnumerable<object>)null, (Func<object, Boolean>)null));
		Skip = Refl.GetGenMethod(() => Enumerable.Skip<object>((IEnumerable<object>)null, 0));
		SkipWhile = Refl.GetGenMethod(() => Enumerable.SkipWhile<object>((IEnumerable<object>)null, (Func<object, Boolean>)null));
		SkipWhile2 = Refl.GetGenMethod(() => Enumerable.SkipWhile<object>((IEnumerable<object>)null, (Func<object, Int32, Boolean>)null));
		Sum = Refl.GetGenMethod(() => Enumerable.Sum((IEnumerable<Int32>)null));
		Sum2 = Refl.GetGenMethod(() => Enumerable.Sum((IEnumerable<Nullable<Int32>>)null));
		Sum3 = Refl.GetGenMethod(() => Enumerable.Sum((IEnumerable<Int64>)null));
		Sum4 = Refl.GetGenMethod(() => Enumerable.Sum((IEnumerable<Nullable<Int64>>)null));
		Sum5 = Refl.GetGenMethod(() => Enumerable.Sum((IEnumerable<Single>)null));
		Sum6 = Refl.GetGenMethod(() => Enumerable.Sum((IEnumerable<Nullable<Single>>)null));
		Sum7 = Refl.GetGenMethod(() => Enumerable.Sum((IEnumerable<Double>)null));
		Sum8 = Refl.GetGenMethod(() => Enumerable.Sum((IEnumerable<Nullable<Double>>)null));
		Sum9 = Refl.GetGenMethod(() => Enumerable.Sum((IEnumerable<Decimal>)null));
		Sum10 = Refl.GetGenMethod(() => Enumerable.Sum((IEnumerable<Nullable<Decimal>>)null));
		Sum11 = Refl.GetGenMethod(() => Enumerable.Sum<object>((IEnumerable<object>)null, (Func<object, Int32>)null));
		Sum12 = Refl.GetGenMethod(() => Enumerable.Sum<object>((IEnumerable<object>)null, (Func<object, Nullable<Int32>>)null));
		Sum13 = Refl.GetGenMethod(() => Enumerable.Sum<object>((IEnumerable<object>)null, (Func<object, Int64>)null));
		Sum14 = Refl.GetGenMethod(() => Enumerable.Sum<object>((IEnumerable<object>)null, (Func<object, Nullable<Int64>>)null));
		Sum15 = Refl.GetGenMethod(() => Enumerable.Sum<object>((IEnumerable<object>)null, (Func<object, Single>)null));
		Sum16 = Refl.GetGenMethod(() => Enumerable.Sum<object>((IEnumerable<object>)null, (Func<object, Nullable<Single>>)null));
		Sum17 = Refl.GetGenMethod(() => Enumerable.Sum<object>((IEnumerable<object>)null, (Func<object, Double>)null));
		Sum18 = Refl.GetGenMethod(() => Enumerable.Sum<object>((IEnumerable<object>)null, (Func<object, Nullable<Double>>)null));
		Sum19 = Refl.GetGenMethod(() => Enumerable.Sum<object>((IEnumerable<object>)null, (Func<object, Decimal>)null));
		Sum20 = Refl.GetGenMethod(() => Enumerable.Sum<object>((IEnumerable<object>)null, (Func<object, Nullable<Decimal>>)null));
		Take = Refl.GetGenMethod(() => Enumerable.Take<object>((IEnumerable<object>)null, 0));
		TakeWhile = Refl.GetGenMethod(() => Enumerable.TakeWhile<object>((IEnumerable<object>)null, (Func<object, Boolean>)null));
		TakeWhile2 = Refl.GetGenMethod(() => Enumerable.TakeWhile<object>((IEnumerable<object>)null, (Func<object, Int32, Boolean>)null));
		ThenBy = Refl.GetGenMethod(() => Enumerable.ThenBy<object, object>((IOrderedEnumerable<object>)null, (Func<object, object>)null));
		ThenBy2 = Refl.GetGenMethod(() => Enumerable.ThenBy<object, object>((IOrderedEnumerable<object>)null, (Func<object, object>)null, (IComparer<object>)null));
		ThenByDescending = Refl.GetGenMethod(() => Enumerable.ThenByDescending<object, object>((IOrderedEnumerable<object>)null, (Func<object, object>)null));
		ThenByDescending2 = Refl.GetGenMethod(() => Enumerable.ThenByDescending<object, object>((IOrderedEnumerable<object>)null, (Func<object, object>)null, (IComparer<object>)null));
		ToArray = Refl.GetGenMethod(() => Enumerable.ToArray<object>((IEnumerable<object>)null));
		ToDictionary = Refl.GetGenMethod(() => Enumerable.ToDictionary<object, object>((IEnumerable<object>)null, (Func<object, object>)null));
		ToDictionary2 = Refl.GetGenMethod(() => Enumerable.ToDictionary<object, object>((IEnumerable<object>)null, (Func<object, object>)null, (IEqualityComparer<object>)null));
		ToDictionary3 = Refl.GetGenMethod(() => Enumerable.ToDictionary<object, object, object>((IEnumerable<object>)null, (Func<object, object>)null, (Func<object, object>)null));
		ToDictionary4 = Refl.GetGenMethod(() => Enumerable.ToDictionary<object, object, object>((IEnumerable<object>)null, (Func<object, object>)null, (Func<object, object>)null, (IEqualityComparer<object>)null));
		ToList = Refl.GetGenMethod(() => Enumerable.ToList<object>((IEnumerable<object>)null));
		ToLookup = Refl.GetGenMethod(() => Enumerable.ToLookup<object, object>((IEnumerable<object>)null, (Func<object, object>)null));
		ToLookup2 = Refl.GetGenMethod(() => Enumerable.ToLookup<object, object>((IEnumerable<object>)null, (Func<object, object>)null, (IEqualityComparer<object>)null));
		ToLookup3 = Refl.GetGenMethod(() => Enumerable.ToLookup<object, object, object>((IEnumerable<object>)null, (Func<object, object>)null, (Func<object, object>)null));
		ToLookup4 = Refl.GetGenMethod(() => Enumerable.ToLookup<object, object, object>((IEnumerable<object>)null, (Func<object, object>)null, (Func<object, object>)null, (IEqualityComparer<object>)null));
		Union = Refl.GetGenMethod(() => Enumerable.Union<object>((IEnumerable<object>)null, (IEnumerable<object>)null));
		Union2 = Refl.GetGenMethod(() => Enumerable.Union<object>((IEnumerable<object>)null, (IEnumerable<object>)null, (IEqualityComparer<object>)null));
		Where = Refl.GetGenMethod(() => Enumerable.Where<object>((IEnumerable<object>)null, (Func<object, Boolean>)null));
		Where2 = Refl.GetGenMethod(() => Enumerable.Where<object>((IEnumerable<object>)null, (Func<object, Int32, Boolean>)null));
		Zip = Refl.GetGenMethod(() => Enumerable.Zip<object, object, object>((IEnumerable<object>)null, (IEnumerable<object>)null, (Func<object, object, object>)null));
	}
} 

