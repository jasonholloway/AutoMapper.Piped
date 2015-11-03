using System.Reflection;

internal static class EnMethods 
{
	///<summary>
	///TSource Aggregate&lt;TSource&gt;(Func&lt;TSource, TSource, TSource&gt; func)
	///</summary>
	public static readonly MethodInfo Aggregate = SeqMethods.Aggregate.En;

	///<summary>
	///TAccumulate Aggregate&lt;TSource, TAccumulate&gt;(TAccumulate seed, Func&lt;TAccumulate, TSource, TAccumulate&gt; func)
	///</summary>
	public static readonly MethodInfo Aggregate2 = SeqMethods.Aggregate2.En;

	///<summary>
	///TResult Aggregate&lt;TSource, TAccumulate, TResult&gt;(TAccumulate seed, Func&lt;TAccumulate, TSource, TAccumulate&gt; func, Func&lt;TAccumulate, TResult&gt; resultSelector)
	///</summary>
	public static readonly MethodInfo Aggregate3 = SeqMethods.Aggregate3.En;

	///<summary>
	///bool All&lt;TSource&gt;(Func&lt;TSource, bool&gt; predicate)
	///</summary>
	public static readonly MethodInfo All = SeqMethods.All.En;

	///<summary>
	///bool Any&lt;TSource&gt;()
	///</summary>
	public static readonly MethodInfo Any = SeqMethods.Any.En;

	///<summary>
	///bool Any&lt;TSource&gt;(Func&lt;TSource, bool&gt; predicate)
	///</summary>
	public static readonly MethodInfo Any2 = SeqMethods.Any2.En;

	///<summary>
	///double Average()
	///</summary>
	public static readonly MethodInfo Average = SeqMethods.Average.En;

	///<summary>
	///decimal? Average()
	///</summary>
	public static readonly MethodInfo Average10 = SeqMethods.Average10.En;

	///<summary>
	///double Average&lt;TSource&gt;(Func&lt;TSource, int&gt; selector)
	///</summary>
	public static readonly MethodInfo Average11 = SeqMethods.Average11.En;

	///<summary>
	///double? Average&lt;TSource&gt;(Func&lt;TSource, int?&gt; selector)
	///</summary>
	public static readonly MethodInfo Average12 = SeqMethods.Average12.En;

	///<summary>
	///float Average&lt;TSource&gt;(Func&lt;TSource, float&gt; selector)
	///</summary>
	public static readonly MethodInfo Average13 = SeqMethods.Average13.En;

	///<summary>
	///float? Average&lt;TSource&gt;(Func&lt;TSource, float?&gt; selector)
	///</summary>
	public static readonly MethodInfo Average14 = SeqMethods.Average14.En;

	///<summary>
	///double Average&lt;TSource&gt;(Func&lt;TSource, long&gt; selector)
	///</summary>
	public static readonly MethodInfo Average15 = SeqMethods.Average15.En;

	///<summary>
	///double? Average&lt;TSource&gt;(Func&lt;TSource, long?&gt; selector)
	///</summary>
	public static readonly MethodInfo Average16 = SeqMethods.Average16.En;

	///<summary>
	///double Average&lt;TSource&gt;(Func&lt;TSource, double&gt; selector)
	///</summary>
	public static readonly MethodInfo Average17 = SeqMethods.Average17.En;

	///<summary>
	///double? Average&lt;TSource&gt;(Func&lt;TSource, double?&gt; selector)
	///</summary>
	public static readonly MethodInfo Average18 = SeqMethods.Average18.En;

	///<summary>
	///decimal Average&lt;TSource&gt;(Func&lt;TSource, decimal&gt; selector)
	///</summary>
	public static readonly MethodInfo Average19 = SeqMethods.Average19.En;

	///<summary>
	///double? Average()
	///</summary>
	public static readonly MethodInfo Average2 = SeqMethods.Average2.En;

	///<summary>
	///decimal? Average&lt;TSource&gt;(Func&lt;TSource, decimal?&gt; selector)
	///</summary>
	public static readonly MethodInfo Average20 = SeqMethods.Average20.En;

	///<summary>
	///double Average()
	///</summary>
	public static readonly MethodInfo Average3 = SeqMethods.Average3.En;

	///<summary>
	///double? Average()
	///</summary>
	public static readonly MethodInfo Average4 = SeqMethods.Average4.En;

	///<summary>
	///float Average()
	///</summary>
	public static readonly MethodInfo Average5 = SeqMethods.Average5.En;

	///<summary>
	///float? Average()
	///</summary>
	public static readonly MethodInfo Average6 = SeqMethods.Average6.En;

	///<summary>
	///double Average()
	///</summary>
	public static readonly MethodInfo Average7 = SeqMethods.Average7.En;

	///<summary>
	///double? Average()
	///</summary>
	public static readonly MethodInfo Average8 = SeqMethods.Average8.En;

	///<summary>
	///decimal Average()
	///</summary>
	public static readonly MethodInfo Average9 = SeqMethods.Average9.En;

	///<summary>
	///IEnumerable&lt;TResult&gt; Cast&lt;TResult&gt;()
	///</summary>
	public static readonly MethodInfo Cast = SeqMethods.Cast.En;

	///<summary>
	///IEnumerable&lt;TSource&gt; Concat&lt;TSource&gt;(IEnumerable&lt;TSource&gt; second)
	///</summary>
	public static readonly MethodInfo Concat = SeqMethods.Concat.En;

	///<summary>
	///bool Contains&lt;TSource&gt;(TSource value)
	///</summary>
	public static readonly MethodInfo Contains = SeqMethods.Contains.En;

	///<summary>
	///bool Contains&lt;TSource&gt;(TSource value, IEqualityComparer&lt;TSource&gt; comparer)
	///</summary>
	public static readonly MethodInfo Contains2 = SeqMethods.Contains2.En;

	///<summary>
	///int Count&lt;TSource&gt;()
	///</summary>
	public static readonly MethodInfo Count = SeqMethods.Count.En;

	///<summary>
	///int Count&lt;TSource&gt;(Func&lt;TSource, bool&gt; predicate)
	///</summary>
	public static readonly MethodInfo Count2 = SeqMethods.Count2.En;

	///<summary>
	///IEnumerable&lt;TSource&gt; DefaultIfEmpty&lt;TSource&gt;()
	///</summary>
	public static readonly MethodInfo DefaultIfEmpty = SeqMethods.DefaultIfEmpty.En;

	///<summary>
	///IEnumerable&lt;TSource&gt; DefaultIfEmpty&lt;TSource&gt;(TSource defaultValue)
	///</summary>
	public static readonly MethodInfo DefaultIfEmpty2 = SeqMethods.DefaultIfEmpty2.En;

	///<summary>
	///IEnumerable&lt;TSource&gt; Distinct&lt;TSource&gt;()
	///</summary>
	public static readonly MethodInfo Distinct = SeqMethods.Distinct.En;

	///<summary>
	///IEnumerable&lt;TSource&gt; Distinct&lt;TSource&gt;(IEqualityComparer&lt;TSource&gt; comparer)
	///</summary>
	public static readonly MethodInfo Distinct2 = SeqMethods.Distinct2.En;

	///<summary>
	///TSource ElementAt&lt;TSource&gt;(int index)
	///</summary>
	public static readonly MethodInfo ElementAt = SeqMethods.ElementAt.En;

	///<summary>
	///TSource ElementAtOrDefault&lt;TSource&gt;(int index)
	///</summary>
	public static readonly MethodInfo ElementAtOrDefault = SeqMethods.ElementAtOrDefault.En;

	///<summary>
	///IEnumerable&lt;TSource&gt; Except&lt;TSource&gt;(IEnumerable&lt;TSource&gt; second)
	///</summary>
	public static readonly MethodInfo Except = SeqMethods.Except.En;

	///<summary>
	///IEnumerable&lt;TSource&gt; Except&lt;TSource&gt;(IEnumerable&lt;TSource&gt; second, IEqualityComparer&lt;TSource&gt; comparer)
	///</summary>
	public static readonly MethodInfo Except2 = SeqMethods.Except2.En;

	///<summary>
	///TSource First&lt;TSource&gt;()
	///</summary>
	public static readonly MethodInfo First = SeqMethods.First.En;

	///<summary>
	///TSource First&lt;TSource&gt;(Func&lt;TSource, bool&gt; predicate)
	///</summary>
	public static readonly MethodInfo First2 = SeqMethods.First2.En;

	///<summary>
	///TSource FirstOrDefault&lt;TSource&gt;()
	///</summary>
	public static readonly MethodInfo FirstOrDefault = SeqMethods.FirstOrDefault.En;

	///<summary>
	///TSource FirstOrDefault&lt;TSource&gt;(Func&lt;TSource, bool&gt; predicate)
	///</summary>
	public static readonly MethodInfo FirstOrDefault2 = SeqMethods.FirstOrDefault2.En;

	///<summary>
	///IEnumerable&lt;IGrouping&lt;TKey, TSource&gt;&gt; GroupBy&lt;TSource, TKey&gt;(Func&lt;TSource, TKey&gt; keySelector)
	///</summary>
	public static readonly MethodInfo GroupBy = SeqMethods.GroupBy.En;

	///<summary>
	///IEnumerable&lt;IGrouping&lt;TKey, TElement&gt;&gt; GroupBy&lt;TSource, TKey, TElement&gt;(Func&lt;TSource, TKey&gt; keySelector, Func&lt;TSource, TElement&gt; elementSelector)
	///</summary>
	public static readonly MethodInfo GroupBy2 = SeqMethods.GroupBy2.En;

	///<summary>
	///IEnumerable&lt;IGrouping&lt;TKey, TSource&gt;&gt; GroupBy&lt;TSource, TKey&gt;(Func&lt;TSource, TKey&gt; keySelector, IEqualityComparer&lt;TKey&gt; comparer)
	///</summary>
	public static readonly MethodInfo GroupBy3 = SeqMethods.GroupBy3.En;

	///<summary>
	///IEnumerable&lt;IGrouping&lt;TKey, TElement&gt;&gt; GroupBy&lt;TSource, TKey, TElement&gt;(Func&lt;TSource, TKey&gt; keySelector, Func&lt;TSource, TElement&gt; elementSelector, IEqualityComparer&lt;TKey&gt; comparer)
	///</summary>
	public static readonly MethodInfo GroupBy4 = SeqMethods.GroupBy4.En;

	///<summary>
	///IEnumerable&lt;TResult&gt; GroupBy&lt;TSource, TKey, TElement, TResult&gt;(Func&lt;TSource, TKey&gt; keySelector, Func&lt;TSource, TElement&gt; elementSelector, Func&lt;TKey, IEnumerable&lt;TElement&gt;, TResult&gt; resultSelector)
	///</summary>
	public static readonly MethodInfo GroupBy5 = SeqMethods.GroupBy5.En;

	///<summary>
	///IEnumerable&lt;TResult&gt; GroupBy&lt;TSource, TKey, TResult&gt;(Func&lt;TSource, TKey&gt; keySelector, Func&lt;TKey, IEnumerable&lt;TSource&gt;, TResult&gt; resultSelector)
	///</summary>
	public static readonly MethodInfo GroupBy6 = SeqMethods.GroupBy6.En;

	///<summary>
	///IEnumerable&lt;TResult&gt; GroupBy&lt;TSource, TKey, TResult&gt;(Func&lt;TSource, TKey&gt; keySelector, Func&lt;TKey, IEnumerable&lt;TSource&gt;, TResult&gt; resultSelector, IEqualityComparer&lt;TKey&gt; comparer)
	///</summary>
	public static readonly MethodInfo GroupBy7 = SeqMethods.GroupBy7.En;

	///<summary>
	///IEnumerable&lt;TResult&gt; GroupBy&lt;TSource, TKey, TElement, TResult&gt;(Func&lt;TSource, TKey&gt; keySelector, Func&lt;TSource, TElement&gt; elementSelector, Func&lt;TKey, IEnumerable&lt;TElement&gt;, TResult&gt; resultSelector, IEqualityComparer&lt;TKey&gt; comparer)
	///</summary>
	public static readonly MethodInfo GroupBy8 = SeqMethods.GroupBy8.En;

	///<summary>
	///IEnumerable&lt;TResult&gt; GroupJoin&lt;TOuter, TInner, TKey, TResult&gt;(IEnumerable&lt;TInner&gt; inner, Func&lt;TOuter, TKey&gt; outerKeySelector, Func&lt;TInner, TKey&gt; innerKeySelector, Func&lt;TOuter, IEnumerable&lt;TInner&gt;, TResult&gt; resultSelector)
	///</summary>
	public static readonly MethodInfo GroupJoin = SeqMethods.GroupJoin.En;

	///<summary>
	///IEnumerable&lt;TResult&gt; GroupJoin&lt;TOuter, TInner, TKey, TResult&gt;(IEnumerable&lt;TInner&gt; inner, Func&lt;TOuter, TKey&gt; outerKeySelector, Func&lt;TInner, TKey&gt; innerKeySelector, Func&lt;TOuter, IEnumerable&lt;TInner&gt;, TResult&gt; resultSelector, IEqualityComparer&lt;TKey&gt; comparer)
	///</summary>
	public static readonly MethodInfo GroupJoin2 = SeqMethods.GroupJoin2.En;

	///<summary>
	///IEnumerable&lt;TSource&gt; Intersect&lt;TSource&gt;(IEnumerable&lt;TSource&gt; second)
	///</summary>
	public static readonly MethodInfo Intersect = SeqMethods.Intersect.En;

	///<summary>
	///IEnumerable&lt;TSource&gt; Intersect&lt;TSource&gt;(IEnumerable&lt;TSource&gt; second, IEqualityComparer&lt;TSource&gt; comparer)
	///</summary>
	public static readonly MethodInfo Intersect2 = SeqMethods.Intersect2.En;

	///<summary>
	///IEnumerable&lt;TResult&gt; Join&lt;TOuter, TInner, TKey, TResult&gt;(IEnumerable&lt;TInner&gt; inner, Func&lt;TOuter, TKey&gt; outerKeySelector, Func&lt;TInner, TKey&gt; innerKeySelector, Func&lt;TOuter, TInner, TResult&gt; resultSelector)
	///</summary>
	public static readonly MethodInfo Join = SeqMethods.Join.En;

	///<summary>
	///IEnumerable&lt;TResult&gt; Join&lt;TOuter, TInner, TKey, TResult&gt;(IEnumerable&lt;TInner&gt; inner, Func&lt;TOuter, TKey&gt; outerKeySelector, Func&lt;TInner, TKey&gt; innerKeySelector, Func&lt;TOuter, TInner, TResult&gt; resultSelector, IEqualityComparer&lt;TKey&gt; comparer)
	///</summary>
	public static readonly MethodInfo Join2 = SeqMethods.Join2.En;

	///<summary>
	///TSource Last&lt;TSource&gt;()
	///</summary>
	public static readonly MethodInfo Last = SeqMethods.Last.En;

	///<summary>
	///TSource Last&lt;TSource&gt;(Func&lt;TSource, bool&gt; predicate)
	///</summary>
	public static readonly MethodInfo Last2 = SeqMethods.Last2.En;

	///<summary>
	///TSource LastOrDefault&lt;TSource&gt;()
	///</summary>
	public static readonly MethodInfo LastOrDefault = SeqMethods.LastOrDefault.En;

	///<summary>
	///TSource LastOrDefault&lt;TSource&gt;(Func&lt;TSource, bool&gt; predicate)
	///</summary>
	public static readonly MethodInfo LastOrDefault2 = SeqMethods.LastOrDefault2.En;

	///<summary>
	///long LongCount&lt;TSource&gt;()
	///</summary>
	public static readonly MethodInfo LongCount = SeqMethods.LongCount.En;

	///<summary>
	///long LongCount&lt;TSource&gt;(Func&lt;TSource, bool&gt; predicate)
	///</summary>
	public static readonly MethodInfo LongCount2 = SeqMethods.LongCount2.En;

	///<summary>
	///TSource Max&lt;TSource&gt;()
	///</summary>
	public static readonly MethodInfo Max = SeqMethods.Max.En;

	///<summary>
	///TResult Max&lt;TSource, TResult&gt;(Func&lt;TSource, TResult&gt; selector)
	///</summary>
	public static readonly MethodInfo Max2 = SeqMethods.Max2.En;

	///<summary>
	///TSource Min&lt;TSource&gt;()
	///</summary>
	public static readonly MethodInfo Min = SeqMethods.Min.En;

	///<summary>
	///TResult Min&lt;TSource, TResult&gt;(Func&lt;TSource, TResult&gt; selector)
	///</summary>
	public static readonly MethodInfo Min2 = SeqMethods.Min2.En;

	///<summary>
	///IEnumerable&lt;TResult&gt; OfType&lt;TResult&gt;()
	///</summary>
	public static readonly MethodInfo OfType = SeqMethods.OfType.En;

	///<summary>
	///IOrderedEnumerable&lt;TSource&gt; OrderBy&lt;TSource, TKey&gt;(Func&lt;TSource, TKey&gt; keySelector)
	///</summary>
	public static readonly MethodInfo OrderBy = SeqMethods.OrderBy.En;

	///<summary>
	///IOrderedEnumerable&lt;TSource&gt; OrderBy&lt;TSource, TKey&gt;(Func&lt;TSource, TKey&gt; keySelector, IComparer&lt;TKey&gt; comparer)
	///</summary>
	public static readonly MethodInfo OrderBy2 = SeqMethods.OrderBy2.En;

	///<summary>
	///IOrderedEnumerable&lt;TSource&gt; OrderByDescending&lt;TSource, TKey&gt;(Func&lt;TSource, TKey&gt; keySelector)
	///</summary>
	public static readonly MethodInfo OrderByDescending = SeqMethods.OrderByDescending.En;

	///<summary>
	///IOrderedEnumerable&lt;TSource&gt; OrderByDescending&lt;TSource, TKey&gt;(Func&lt;TSource, TKey&gt; keySelector, IComparer&lt;TKey&gt; comparer)
	///</summary>
	public static readonly MethodInfo OrderByDescending2 = SeqMethods.OrderByDescending2.En;

	///<summary>
	///IEnumerable&lt;TSource&gt; Reverse&lt;TSource&gt;()
	///</summary>
	public static readonly MethodInfo Reverse = SeqMethods.Reverse.En;

	///<summary>
	///IEnumerable&lt;TResult&gt; Select&lt;TSource, TResult&gt;(Func&lt;TSource, TResult&gt; selector)
	///</summary>
	public static readonly MethodInfo Select = SeqMethods.Select.En;

	///<summary>
	///IEnumerable&lt;TResult&gt; Select&lt;TSource, TResult&gt;(Func&lt;TSource, int, TResult&gt; selector)
	///</summary>
	public static readonly MethodInfo Select2 = SeqMethods.Select2.En;

	///<summary>
	///IEnumerable&lt;TResult&gt; SelectMany&lt;TSource, TResult&gt;(Func&lt;TSource, IEnumerable&lt;TResult&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo SelectMany = SeqMethods.SelectMany.En;

	///<summary>
	///IEnumerable&lt;TResult&gt; SelectMany&lt;TSource, TResult&gt;(Func&lt;TSource, int, IEnumerable&lt;TResult&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo SelectMany2 = SeqMethods.SelectMany2.En;

	///<summary>
	///IEnumerable&lt;TResult&gt; SelectMany&lt;TSource, TCollection, TResult&gt;(Func&lt;TSource, int, IEnumerable&lt;TCollection&gt;&gt; collectionSelector, Func&lt;TSource, TCollection, TResult&gt; resultSelector)
	///</summary>
	public static readonly MethodInfo SelectMany3 = SeqMethods.SelectMany3.En;

	///<summary>
	///IEnumerable&lt;TResult&gt; SelectMany&lt;TSource, TCollection, TResult&gt;(Func&lt;TSource, IEnumerable&lt;TCollection&gt;&gt; collectionSelector, Func&lt;TSource, TCollection, TResult&gt; resultSelector)
	///</summary>
	public static readonly MethodInfo SelectMany4 = SeqMethods.SelectMany4.En;

	///<summary>
	///bool SequenceEqual&lt;TSource&gt;(IEnumerable&lt;TSource&gt; second)
	///</summary>
	public static readonly MethodInfo SequenceEqual = SeqMethods.SequenceEqual.En;

	///<summary>
	///bool SequenceEqual&lt;TSource&gt;(IEnumerable&lt;TSource&gt; second, IEqualityComparer&lt;TSource&gt; comparer)
	///</summary>
	public static readonly MethodInfo SequenceEqual2 = SeqMethods.SequenceEqual2.En;

	///<summary>
	///TSource Single&lt;TSource&gt;()
	///</summary>
	public static readonly MethodInfo Single = SeqMethods.Single.En;

	///<summary>
	///TSource Single&lt;TSource&gt;(Func&lt;TSource, bool&gt; predicate)
	///</summary>
	public static readonly MethodInfo Single2 = SeqMethods.Single2.En;

	///<summary>
	///TSource SingleOrDefault&lt;TSource&gt;()
	///</summary>
	public static readonly MethodInfo SingleOrDefault = SeqMethods.SingleOrDefault.En;

	///<summary>
	///TSource SingleOrDefault&lt;TSource&gt;(Func&lt;TSource, bool&gt; predicate)
	///</summary>
	public static readonly MethodInfo SingleOrDefault2 = SeqMethods.SingleOrDefault2.En;

	///<summary>
	///IEnumerable&lt;TSource&gt; Skip&lt;TSource&gt;(int count)
	///</summary>
	public static readonly MethodInfo Skip = SeqMethods.Skip.En;

	///<summary>
	///IEnumerable&lt;TSource&gt; SkipWhile&lt;TSource&gt;(Func&lt;TSource, bool&gt; predicate)
	///</summary>
	public static readonly MethodInfo SkipWhile = SeqMethods.SkipWhile.En;

	///<summary>
	///IEnumerable&lt;TSource&gt; SkipWhile&lt;TSource&gt;(Func&lt;TSource, int, bool&gt; predicate)
	///</summary>
	public static readonly MethodInfo SkipWhile2 = SeqMethods.SkipWhile2.En;

	///<summary>
	///decimal? Sum&lt;TSource&gt;(Func&lt;TSource, decimal?&gt; selector)
	///</summary>
	public static readonly MethodInfo Sum = SeqMethods.Sum.En;

	///<summary>
	///decimal Sum()
	///</summary>
	public static readonly MethodInfo Sum10 = SeqMethods.Sum10.En;

	///<summary>
	///decimal? Sum()
	///</summary>
	public static readonly MethodInfo Sum11 = SeqMethods.Sum11.En;

	///<summary>
	///int Sum&lt;TSource&gt;(Func&lt;TSource, int&gt; selector)
	///</summary>
	public static readonly MethodInfo Sum12 = SeqMethods.Sum12.En;

	///<summary>
	///int? Sum&lt;TSource&gt;(Func&lt;TSource, int?&gt; selector)
	///</summary>
	public static readonly MethodInfo Sum13 = SeqMethods.Sum13.En;

	///<summary>
	///long Sum&lt;TSource&gt;(Func&lt;TSource, long&gt; selector)
	///</summary>
	public static readonly MethodInfo Sum14 = SeqMethods.Sum14.En;

	///<summary>
	///long? Sum&lt;TSource&gt;(Func&lt;TSource, long?&gt; selector)
	///</summary>
	public static readonly MethodInfo Sum15 = SeqMethods.Sum15.En;

	///<summary>
	///float Sum&lt;TSource&gt;(Func&lt;TSource, float&gt; selector)
	///</summary>
	public static readonly MethodInfo Sum16 = SeqMethods.Sum16.En;

	///<summary>
	///float? Sum&lt;TSource&gt;(Func&lt;TSource, float?&gt; selector)
	///</summary>
	public static readonly MethodInfo Sum17 = SeqMethods.Sum17.En;

	///<summary>
	///double Sum&lt;TSource&gt;(Func&lt;TSource, double&gt; selector)
	///</summary>
	public static readonly MethodInfo Sum18 = SeqMethods.Sum18.En;

	///<summary>
	///double? Sum&lt;TSource&gt;(Func&lt;TSource, double?&gt; selector)
	///</summary>
	public static readonly MethodInfo Sum19 = SeqMethods.Sum19.En;

	///<summary>
	///int Sum()
	///</summary>
	public static readonly MethodInfo Sum2 = SeqMethods.Sum2.En;

	///<summary>
	///decimal Sum&lt;TSource&gt;(Func&lt;TSource, decimal&gt; selector)
	///</summary>
	public static readonly MethodInfo Sum20 = SeqMethods.Sum20.En;

	///<summary>
	///int? Sum()
	///</summary>
	public static readonly MethodInfo Sum3 = SeqMethods.Sum3.En;

	///<summary>
	///long Sum()
	///</summary>
	public static readonly MethodInfo Sum4 = SeqMethods.Sum4.En;

	///<summary>
	///long? Sum()
	///</summary>
	public static readonly MethodInfo Sum5 = SeqMethods.Sum5.En;

	///<summary>
	///float Sum()
	///</summary>
	public static readonly MethodInfo Sum6 = SeqMethods.Sum6.En;

	///<summary>
	///float? Sum()
	///</summary>
	public static readonly MethodInfo Sum7 = SeqMethods.Sum7.En;

	///<summary>
	///double Sum()
	///</summary>
	public static readonly MethodInfo Sum8 = SeqMethods.Sum8.En;

	///<summary>
	///double? Sum()
	///</summary>
	public static readonly MethodInfo Sum9 = SeqMethods.Sum9.En;

	///<summary>
	///IEnumerable&lt;TSource&gt; Take&lt;TSource&gt;(int count)
	///</summary>
	public static readonly MethodInfo Take = SeqMethods.Take.En;

	///<summary>
	///IEnumerable&lt;TSource&gt; TakeWhile&lt;TSource&gt;(Func&lt;TSource, bool&gt; predicate)
	///</summary>
	public static readonly MethodInfo TakeWhile = SeqMethods.TakeWhile.En;

	///<summary>
	///IEnumerable&lt;TSource&gt; TakeWhile&lt;TSource&gt;(Func&lt;TSource, int, bool&gt; predicate)
	///</summary>
	public static readonly MethodInfo TakeWhile2 = SeqMethods.TakeWhile2.En;

	///<summary>
	///IOrderedEnumerable&lt;TSource&gt; ThenBy&lt;TSource, TKey&gt;(Func&lt;TSource, TKey&gt; keySelector)
	///</summary>
	public static readonly MethodInfo ThenBy = SeqMethods.ThenBy.En;

	///<summary>
	///IOrderedEnumerable&lt;TSource&gt; ThenBy&lt;TSource, TKey&gt;(Func&lt;TSource, TKey&gt; keySelector, IComparer&lt;TKey&gt; comparer)
	///</summary>
	public static readonly MethodInfo ThenBy2 = SeqMethods.ThenBy2.En;

	///<summary>
	///IOrderedEnumerable&lt;TSource&gt; ThenByDescending&lt;TSource, TKey&gt;(Func&lt;TSource, TKey&gt; keySelector)
	///</summary>
	public static readonly MethodInfo ThenByDescending = SeqMethods.ThenByDescending.En;

	///<summary>
	///IOrderedEnumerable&lt;TSource&gt; ThenByDescending&lt;TSource, TKey&gt;(Func&lt;TSource, TKey&gt; keySelector, IComparer&lt;TKey&gt; comparer)
	///</summary>
	public static readonly MethodInfo ThenByDescending2 = SeqMethods.ThenByDescending2.En;

	///<summary>
	///IEnumerable&lt;TSource&gt; Union&lt;TSource&gt;(IEnumerable&lt;TSource&gt; second)
	///</summary>
	public static readonly MethodInfo Union = SeqMethods.Union.En;

	///<summary>
	///IEnumerable&lt;TSource&gt; Union&lt;TSource&gt;(IEnumerable&lt;TSource&gt; second, IEqualityComparer&lt;TSource&gt; comparer)
	///</summary>
	public static readonly MethodInfo Union2 = SeqMethods.Union2.En;

	///<summary>
	///IEnumerable&lt;TSource&gt; Where&lt;TSource&gt;(Func&lt;TSource, bool&gt; predicate)
	///</summary>
	public static readonly MethodInfo Where = SeqMethods.Where.En;

	///<summary>
	///IEnumerable&lt;TSource&gt; Where&lt;TSource&gt;(Func&lt;TSource, int, bool&gt; predicate)
	///</summary>
	public static readonly MethodInfo Where2 = SeqMethods.Where2.En;

	///<summary>
	///IEnumerable&lt;TResult&gt; Zip&lt;TFirst, TSecond, TResult&gt;(IEnumerable&lt;TSecond&gt; second, Func&lt;TFirst, TSecond, TResult&gt; resultSelector)
	///</summary>
	public static readonly MethodInfo Zip = SeqMethods.Zip.En;

	
} 