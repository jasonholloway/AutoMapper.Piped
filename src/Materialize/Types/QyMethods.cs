using System.Reflection;

internal static partial class QyMethods 
{
	///<summary>
	///TSource Aggregate&lt;TSource&gt;(Expression&lt;Func&lt;TSource, TSource, TSource&gt;&gt; func)
	///</summary>
	public static readonly MethodInfo Aggregate = SeqMethods.Aggregate.Qy;

	///<summary>
	///TAccumulate Aggregate&lt;TSource, TAccumulate&gt;(TAccumulate seed, Expression&lt;Func&lt;TAccumulate, TSource, TAccumulate&gt;&gt; func)
	///</summary>
	public static readonly MethodInfo Aggregate2 = SeqMethods.Aggregate2.Qy;

	///<summary>
	///TResult Aggregate&lt;TSource, TAccumulate, TResult&gt;(TAccumulate seed, Expression&lt;Func&lt;TAccumulate, TSource, TAccumulate&gt;&gt; func, Expression&lt;Func&lt;TAccumulate, TResult&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Aggregate3 = SeqMethods.Aggregate3.Qy;

	///<summary>
	///bool All&lt;TSource&gt;(Expression&lt;Func&lt;TSource, bool&gt;&gt; predicate)
	///</summary>
	public static readonly MethodInfo All = SeqMethods.All.Qy;

	///<summary>
	///bool Any&lt;TSource&gt;()
	///</summary>
	public static readonly MethodInfo Any = SeqMethods.Any.Qy;

	///<summary>
	///bool Any&lt;TSource&gt;(Expression&lt;Func&lt;TSource, bool&gt;&gt; predicate)
	///</summary>
	public static readonly MethodInfo Any2 = SeqMethods.Any2.Qy;

	///<summary>
	///double Average()
	///</summary>
	public static readonly MethodInfo Average = SeqMethods.Average.Qy;

	///<summary>
	///decimal? Average()
	///</summary>
	public static readonly MethodInfo Average10 = SeqMethods.Average10.Qy;

	///<summary>
	///double Average&lt;TSource&gt;(Expression&lt;Func&lt;TSource, int&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Average11 = SeqMethods.Average11.Qy;

	///<summary>
	///double? Average&lt;TSource&gt;(Expression&lt;Func&lt;TSource, int?&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Average12 = SeqMethods.Average12.Qy;

	///<summary>
	///float Average&lt;TSource&gt;(Expression&lt;Func&lt;TSource, float&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Average13 = SeqMethods.Average13.Qy;

	///<summary>
	///float? Average&lt;TSource&gt;(Expression&lt;Func&lt;TSource, float?&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Average14 = SeqMethods.Average14.Qy;

	///<summary>
	///double Average&lt;TSource&gt;(Expression&lt;Func&lt;TSource, long&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Average15 = SeqMethods.Average15.Qy;

	///<summary>
	///double? Average&lt;TSource&gt;(Expression&lt;Func&lt;TSource, long?&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Average16 = SeqMethods.Average16.Qy;

	///<summary>
	///double Average&lt;TSource&gt;(Expression&lt;Func&lt;TSource, double&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Average17 = SeqMethods.Average17.Qy;

	///<summary>
	///double? Average&lt;TSource&gt;(Expression&lt;Func&lt;TSource, double?&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Average18 = SeqMethods.Average18.Qy;

	///<summary>
	///decimal Average&lt;TSource&gt;(Expression&lt;Func&lt;TSource, decimal&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Average19 = SeqMethods.Average19.Qy;

	///<summary>
	///double? Average()
	///</summary>
	public static readonly MethodInfo Average2 = SeqMethods.Average2.Qy;

	///<summary>
	///decimal? Average&lt;TSource&gt;(Expression&lt;Func&lt;TSource, decimal?&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Average20 = SeqMethods.Average20.Qy;

	///<summary>
	///double Average()
	///</summary>
	public static readonly MethodInfo Average3 = SeqMethods.Average3.Qy;

	///<summary>
	///double? Average()
	///</summary>
	public static readonly MethodInfo Average4 = SeqMethods.Average4.Qy;

	///<summary>
	///float Average()
	///</summary>
	public static readonly MethodInfo Average5 = SeqMethods.Average5.Qy;

	///<summary>
	///float? Average()
	///</summary>
	public static readonly MethodInfo Average6 = SeqMethods.Average6.Qy;

	///<summary>
	///double Average()
	///</summary>
	public static readonly MethodInfo Average7 = SeqMethods.Average7.Qy;

	///<summary>
	///double? Average()
	///</summary>
	public static readonly MethodInfo Average8 = SeqMethods.Average8.Qy;

	///<summary>
	///decimal Average()
	///</summary>
	public static readonly MethodInfo Average9 = SeqMethods.Average9.Qy;

	///<summary>
	///IQueryable&lt;TResult&gt; Cast&lt;TResult&gt;()
	///</summary>
	public static readonly MethodInfo Cast = SeqMethods.Cast.Qy;

	///<summary>
	///IQueryable&lt;TSource&gt; Concat&lt;TSource&gt;(IEnumerable&lt;TSource&gt; source2)
	///</summary>
	public static readonly MethodInfo Concat = SeqMethods.Concat.Qy;

	///<summary>
	///bool Contains&lt;TSource&gt;(TSource item)
	///</summary>
	public static readonly MethodInfo Contains = SeqMethods.Contains.Qy;

	///<summary>
	///bool Contains&lt;TSource&gt;(TSource item, IEqualityComparer&lt;TSource&gt; comparer)
	///</summary>
	public static readonly MethodInfo Contains2 = SeqMethods.Contains2.Qy;

	///<summary>
	///int Count&lt;TSource&gt;()
	///</summary>
	public static readonly MethodInfo Count = SeqMethods.Count.Qy;

	///<summary>
	///int Count&lt;TSource&gt;(Expression&lt;Func&lt;TSource, bool&gt;&gt; predicate)
	///</summary>
	public static readonly MethodInfo Count2 = SeqMethods.Count2.Qy;

	///<summary>
	///IQueryable&lt;TSource&gt; DefaultIfEmpty&lt;TSource&gt;()
	///</summary>
	public static readonly MethodInfo DefaultIfEmpty = SeqMethods.DefaultIfEmpty.Qy;

	///<summary>
	///IQueryable&lt;TSource&gt; DefaultIfEmpty&lt;TSource&gt;(TSource defaultValue)
	///</summary>
	public static readonly MethodInfo DefaultIfEmpty2 = SeqMethods.DefaultIfEmpty2.Qy;

	///<summary>
	///IQueryable&lt;TSource&gt; Distinct&lt;TSource&gt;()
	///</summary>
	public static readonly MethodInfo Distinct = SeqMethods.Distinct.Qy;

	///<summary>
	///IQueryable&lt;TSource&gt; Distinct&lt;TSource&gt;(IEqualityComparer&lt;TSource&gt; comparer)
	///</summary>
	public static readonly MethodInfo Distinct2 = SeqMethods.Distinct2.Qy;

	///<summary>
	///TSource ElementAt&lt;TSource&gt;(int index)
	///</summary>
	public static readonly MethodInfo ElementAt = SeqMethods.ElementAt.Qy;

	///<summary>
	///TSource ElementAtOrDefault&lt;TSource&gt;(int index)
	///</summary>
	public static readonly MethodInfo ElementAtOrDefault = SeqMethods.ElementAtOrDefault.Qy;

	///<summary>
	///IQueryable&lt;TSource&gt; Except&lt;TSource&gt;(IEnumerable&lt;TSource&gt; source2)
	///</summary>
	public static readonly MethodInfo Except = SeqMethods.Except.Qy;

	///<summary>
	///IQueryable&lt;TSource&gt; Except&lt;TSource&gt;(IEnumerable&lt;TSource&gt; source2, IEqualityComparer&lt;TSource&gt; comparer)
	///</summary>
	public static readonly MethodInfo Except2 = SeqMethods.Except2.Qy;

	///<summary>
	///TSource First&lt;TSource&gt;()
	///</summary>
	public static readonly MethodInfo First = SeqMethods.First.Qy;

	///<summary>
	///TSource First&lt;TSource&gt;(Expression&lt;Func&lt;TSource, bool&gt;&gt; predicate)
	///</summary>
	public static readonly MethodInfo First2 = SeqMethods.First2.Qy;

	///<summary>
	///TSource FirstOrDefault&lt;TSource&gt;()
	///</summary>
	public static readonly MethodInfo FirstOrDefault = SeqMethods.FirstOrDefault.Qy;

	///<summary>
	///TSource FirstOrDefault&lt;TSource&gt;(Expression&lt;Func&lt;TSource, bool&gt;&gt; predicate)
	///</summary>
	public static readonly MethodInfo FirstOrDefault2 = SeqMethods.FirstOrDefault2.Qy;

	///<summary>
	///IQueryable&lt;IGrouping&lt;TKey, TSource&gt;&gt; GroupBy&lt;TSource, TKey&gt;(Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector)
	///</summary>
	public static readonly MethodInfo GroupBy = SeqMethods.GroupBy.Qy;

	///<summary>
	///IQueryable&lt;IGrouping&lt;TKey, TElement&gt;&gt; GroupBy&lt;TSource, TKey, TElement&gt;(Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector, Expression&lt;Func&lt;TSource, TElement&gt;&gt; elementSelector)
	///</summary>
	public static readonly MethodInfo GroupBy2 = SeqMethods.GroupBy2.Qy;

	///<summary>
	///IQueryable&lt;IGrouping&lt;TKey, TSource&gt;&gt; GroupBy&lt;TSource, TKey&gt;(Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector, IEqualityComparer&lt;TKey&gt; comparer)
	///</summary>
	public static readonly MethodInfo GroupBy3 = SeqMethods.GroupBy3.Qy;

	///<summary>
	///IQueryable&lt;IGrouping&lt;TKey, TElement&gt;&gt; GroupBy&lt;TSource, TKey, TElement&gt;(Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector, Expression&lt;Func&lt;TSource, TElement&gt;&gt; elementSelector, IEqualityComparer&lt;TKey&gt; comparer)
	///</summary>
	public static readonly MethodInfo GroupBy4 = SeqMethods.GroupBy4.Qy;

	///<summary>
	///IQueryable&lt;TResult&gt; GroupBy&lt;TSource, TKey, TElement, TResult&gt;(Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector, Expression&lt;Func&lt;TSource, TElement&gt;&gt; elementSelector, Expression&lt;Func&lt;TKey, IEnumerable&lt;TElement&gt;, TResult&gt;&gt; resultSelector)
	///</summary>
	public static readonly MethodInfo GroupBy5 = SeqMethods.GroupBy5.Qy;

	///<summary>
	///IQueryable&lt;TResult&gt; GroupBy&lt;TSource, TKey, TResult&gt;(Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector, Expression&lt;Func&lt;TKey, IEnumerable&lt;TSource&gt;, TResult&gt;&gt; resultSelector)
	///</summary>
	public static readonly MethodInfo GroupBy6 = SeqMethods.GroupBy6.Qy;

	///<summary>
	///IQueryable&lt;TResult&gt; GroupBy&lt;TSource, TKey, TResult&gt;(Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector, Expression&lt;Func&lt;TKey, IEnumerable&lt;TSource&gt;, TResult&gt;&gt; resultSelector, IEqualityComparer&lt;TKey&gt; comparer)
	///</summary>
	public static readonly MethodInfo GroupBy7 = SeqMethods.GroupBy7.Qy;

	///<summary>
	///IQueryable&lt;TResult&gt; GroupBy&lt;TSource, TKey, TElement, TResult&gt;(Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector, Expression&lt;Func&lt;TSource, TElement&gt;&gt; elementSelector, Expression&lt;Func&lt;TKey, IEnumerable&lt;TElement&gt;, TResult&gt;&gt; resultSelector, IEqualityComparer&lt;TKey&gt; comparer)
	///</summary>
	public static readonly MethodInfo GroupBy8 = SeqMethods.GroupBy8.Qy;

	///<summary>
	///IQueryable&lt;TResult&gt; GroupJoin&lt;TOuter, TInner, TKey, TResult&gt;(IEnumerable&lt;TInner&gt; inner, Expression&lt;Func&lt;TOuter, TKey&gt;&gt; outerKeySelector, Expression&lt;Func&lt;TInner, TKey&gt;&gt; innerKeySelector, Expression&lt;Func&lt;TOuter, IEnumerable&lt;TInner&gt;, TResult&gt;&gt; resultSelector)
	///</summary>
	public static readonly MethodInfo GroupJoin = SeqMethods.GroupJoin.Qy;

	///<summary>
	///IQueryable&lt;TResult&gt; GroupJoin&lt;TOuter, TInner, TKey, TResult&gt;(IEnumerable&lt;TInner&gt; inner, Expression&lt;Func&lt;TOuter, TKey&gt;&gt; outerKeySelector, Expression&lt;Func&lt;TInner, TKey&gt;&gt; innerKeySelector, Expression&lt;Func&lt;TOuter, IEnumerable&lt;TInner&gt;, TResult&gt;&gt; resultSelector, IEqualityComparer&lt;TKey&gt; comparer)
	///</summary>
	public static readonly MethodInfo GroupJoin2 = SeqMethods.GroupJoin2.Qy;

	///<summary>
	///IQueryable&lt;TSource&gt; Intersect&lt;TSource&gt;(IEnumerable&lt;TSource&gt; source2)
	///</summary>
	public static readonly MethodInfo Intersect = SeqMethods.Intersect.Qy;

	///<summary>
	///IQueryable&lt;TSource&gt; Intersect&lt;TSource&gt;(IEnumerable&lt;TSource&gt; source2, IEqualityComparer&lt;TSource&gt; comparer)
	///</summary>
	public static readonly MethodInfo Intersect2 = SeqMethods.Intersect2.Qy;

	///<summary>
	///IQueryable&lt;TResult&gt; Join&lt;TOuter, TInner, TKey, TResult&gt;(IEnumerable&lt;TInner&gt; inner, Expression&lt;Func&lt;TOuter, TKey&gt;&gt; outerKeySelector, Expression&lt;Func&lt;TInner, TKey&gt;&gt; innerKeySelector, Expression&lt;Func&lt;TOuter, TInner, TResult&gt;&gt; resultSelector)
	///</summary>
	public static readonly MethodInfo Join = SeqMethods.Join.Qy;

	///<summary>
	///IQueryable&lt;TResult&gt; Join&lt;TOuter, TInner, TKey, TResult&gt;(IEnumerable&lt;TInner&gt; inner, Expression&lt;Func&lt;TOuter, TKey&gt;&gt; outerKeySelector, Expression&lt;Func&lt;TInner, TKey&gt;&gt; innerKeySelector, Expression&lt;Func&lt;TOuter, TInner, TResult&gt;&gt; resultSelector, IEqualityComparer&lt;TKey&gt; comparer)
	///</summary>
	public static readonly MethodInfo Join2 = SeqMethods.Join2.Qy;

	///<summary>
	///TSource Last&lt;TSource&gt;()
	///</summary>
	public static readonly MethodInfo Last = SeqMethods.Last.Qy;

	///<summary>
	///TSource Last&lt;TSource&gt;(Expression&lt;Func&lt;TSource, bool&gt;&gt; predicate)
	///</summary>
	public static readonly MethodInfo Last2 = SeqMethods.Last2.Qy;

	///<summary>
	///TSource LastOrDefault&lt;TSource&gt;()
	///</summary>
	public static readonly MethodInfo LastOrDefault = SeqMethods.LastOrDefault.Qy;

	///<summary>
	///TSource LastOrDefault&lt;TSource&gt;(Expression&lt;Func&lt;TSource, bool&gt;&gt; predicate)
	///</summary>
	public static readonly MethodInfo LastOrDefault2 = SeqMethods.LastOrDefault2.Qy;

	///<summary>
	///long LongCount&lt;TSource&gt;()
	///</summary>
	public static readonly MethodInfo LongCount = SeqMethods.LongCount.Qy;

	///<summary>
	///long LongCount&lt;TSource&gt;(Expression&lt;Func&lt;TSource, bool&gt;&gt; predicate)
	///</summary>
	public static readonly MethodInfo LongCount2 = SeqMethods.LongCount2.Qy;

	///<summary>
	///TSource Max&lt;TSource&gt;()
	///</summary>
	public static readonly MethodInfo Max = SeqMethods.Max.Qy;

	///<summary>
	///TResult Max&lt;TSource, TResult&gt;(Expression&lt;Func&lt;TSource, TResult&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Max2 = SeqMethods.Max2.Qy;

	///<summary>
	///TSource Min&lt;TSource&gt;()
	///</summary>
	public static readonly MethodInfo Min = SeqMethods.Min.Qy;

	///<summary>
	///TResult Min&lt;TSource, TResult&gt;(Expression&lt;Func&lt;TSource, TResult&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Min2 = SeqMethods.Min2.Qy;

	///<summary>
	///IQueryable&lt;TResult&gt; OfType&lt;TResult&gt;()
	///</summary>
	public static readonly MethodInfo OfType = SeqMethods.OfType.Qy;

	///<summary>
	///IOrderedQueryable&lt;TSource&gt; OrderBy&lt;TSource, TKey&gt;(Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector)
	///</summary>
	public static readonly MethodInfo OrderBy = SeqMethods.OrderBy.Qy;

	///<summary>
	///IOrderedQueryable&lt;TSource&gt; OrderBy&lt;TSource, TKey&gt;(Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector, IComparer&lt;TKey&gt; comparer)
	///</summary>
	public static readonly MethodInfo OrderBy2 = SeqMethods.OrderBy2.Qy;

	///<summary>
	///IOrderedQueryable&lt;TSource&gt; OrderByDescending&lt;TSource, TKey&gt;(Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector)
	///</summary>
	public static readonly MethodInfo OrderByDescending = SeqMethods.OrderByDescending.Qy;

	///<summary>
	///IOrderedQueryable&lt;TSource&gt; OrderByDescending&lt;TSource, TKey&gt;(Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector, IComparer&lt;TKey&gt; comparer)
	///</summary>
	public static readonly MethodInfo OrderByDescending2 = SeqMethods.OrderByDescending2.Qy;

	///<summary>
	///IQueryable&lt;TSource&gt; Reverse&lt;TSource&gt;()
	///</summary>
	public static readonly MethodInfo Reverse = SeqMethods.Reverse.Qy;

	///<summary>
	///IQueryable&lt;TResult&gt; Select&lt;TSource, TResult&gt;(Expression&lt;Func&lt;TSource, TResult&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Select = SeqMethods.Select.Qy;

	///<summary>
	///IQueryable&lt;TResult&gt; Select&lt;TSource, TResult&gt;(Expression&lt;Func&lt;TSource, int, TResult&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Select2 = SeqMethods.Select2.Qy;

	///<summary>
	///IQueryable&lt;TResult&gt; SelectMany&lt;TSource, TResult&gt;(Expression&lt;Func&lt;TSource, IEnumerable&lt;TResult&gt;&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo SelectMany = SeqMethods.SelectMany.Qy;

	///<summary>
	///IQueryable&lt;TResult&gt; SelectMany&lt;TSource, TResult&gt;(Expression&lt;Func&lt;TSource, int, IEnumerable&lt;TResult&gt;&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo SelectMany2 = SeqMethods.SelectMany2.Qy;

	///<summary>
	///IQueryable&lt;TResult&gt; SelectMany&lt;TSource, TCollection, TResult&gt;(Expression&lt;Func&lt;TSource, int, IEnumerable&lt;TCollection&gt;&gt;&gt; collectionSelector, Expression&lt;Func&lt;TSource, TCollection, TResult&gt;&gt; resultSelector)
	///</summary>
	public static readonly MethodInfo SelectMany3 = SeqMethods.SelectMany3.Qy;

	///<summary>
	///IQueryable&lt;TResult&gt; SelectMany&lt;TSource, TCollection, TResult&gt;(Expression&lt;Func&lt;TSource, IEnumerable&lt;TCollection&gt;&gt;&gt; collectionSelector, Expression&lt;Func&lt;TSource, TCollection, TResult&gt;&gt; resultSelector)
	///</summary>
	public static readonly MethodInfo SelectMany4 = SeqMethods.SelectMany4.Qy;

	///<summary>
	///bool SequenceEqual&lt;TSource&gt;(IEnumerable&lt;TSource&gt; source2)
	///</summary>
	public static readonly MethodInfo SequenceEqual = SeqMethods.SequenceEqual.Qy;

	///<summary>
	///bool SequenceEqual&lt;TSource&gt;(IEnumerable&lt;TSource&gt; source2, IEqualityComparer&lt;TSource&gt; comparer)
	///</summary>
	public static readonly MethodInfo SequenceEqual2 = SeqMethods.SequenceEqual2.Qy;

	///<summary>
	///TSource Single&lt;TSource&gt;()
	///</summary>
	public static readonly MethodInfo Single = SeqMethods.Single.Qy;

	///<summary>
	///TSource Single&lt;TSource&gt;(Expression&lt;Func&lt;TSource, bool&gt;&gt; predicate)
	///</summary>
	public static readonly MethodInfo Single2 = SeqMethods.Single2.Qy;

	///<summary>
	///TSource SingleOrDefault&lt;TSource&gt;()
	///</summary>
	public static readonly MethodInfo SingleOrDefault = SeqMethods.SingleOrDefault.Qy;

	///<summary>
	///TSource SingleOrDefault&lt;TSource&gt;(Expression&lt;Func&lt;TSource, bool&gt;&gt; predicate)
	///</summary>
	public static readonly MethodInfo SingleOrDefault2 = SeqMethods.SingleOrDefault2.Qy;

	///<summary>
	///IQueryable&lt;TSource&gt; Skip&lt;TSource&gt;(int count)
	///</summary>
	public static readonly MethodInfo Skip = SeqMethods.Skip.Qy;

	///<summary>
	///IQueryable&lt;TSource&gt; SkipWhile&lt;TSource&gt;(Expression&lt;Func&lt;TSource, bool&gt;&gt; predicate)
	///</summary>
	public static readonly MethodInfo SkipWhile = SeqMethods.SkipWhile.Qy;

	///<summary>
	///IQueryable&lt;TSource&gt; SkipWhile&lt;TSource&gt;(Expression&lt;Func&lt;TSource, int, bool&gt;&gt; predicate)
	///</summary>
	public static readonly MethodInfo SkipWhile2 = SeqMethods.SkipWhile2.Qy;

	///<summary>
	///decimal? Sum&lt;TSource&gt;(Expression&lt;Func&lt;TSource, decimal?&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Sum = SeqMethods.Sum.Qy;

	///<summary>
	///decimal Sum()
	///</summary>
	public static readonly MethodInfo Sum10 = SeqMethods.Sum10.Qy;

	///<summary>
	///decimal? Sum()
	///</summary>
	public static readonly MethodInfo Sum11 = SeqMethods.Sum11.Qy;

	///<summary>
	///int Sum&lt;TSource&gt;(Expression&lt;Func&lt;TSource, int&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Sum12 = SeqMethods.Sum12.Qy;

	///<summary>
	///int? Sum&lt;TSource&gt;(Expression&lt;Func&lt;TSource, int?&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Sum13 = SeqMethods.Sum13.Qy;

	///<summary>
	///long Sum&lt;TSource&gt;(Expression&lt;Func&lt;TSource, long&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Sum14 = SeqMethods.Sum14.Qy;

	///<summary>
	///long? Sum&lt;TSource&gt;(Expression&lt;Func&lt;TSource, long?&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Sum15 = SeqMethods.Sum15.Qy;

	///<summary>
	///float Sum&lt;TSource&gt;(Expression&lt;Func&lt;TSource, float&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Sum16 = SeqMethods.Sum16.Qy;

	///<summary>
	///float? Sum&lt;TSource&gt;(Expression&lt;Func&lt;TSource, float?&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Sum17 = SeqMethods.Sum17.Qy;

	///<summary>
	///double Sum&lt;TSource&gt;(Expression&lt;Func&lt;TSource, double&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Sum18 = SeqMethods.Sum18.Qy;

	///<summary>
	///double? Sum&lt;TSource&gt;(Expression&lt;Func&lt;TSource, double?&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Sum19 = SeqMethods.Sum19.Qy;

	///<summary>
	///int Sum()
	///</summary>
	public static readonly MethodInfo Sum2 = SeqMethods.Sum2.Qy;

	///<summary>
	///decimal Sum&lt;TSource&gt;(Expression&lt;Func&lt;TSource, decimal&gt;&gt; selector)
	///</summary>
	public static readonly MethodInfo Sum20 = SeqMethods.Sum20.Qy;

	///<summary>
	///int? Sum()
	///</summary>
	public static readonly MethodInfo Sum3 = SeqMethods.Sum3.Qy;

	///<summary>
	///long Sum()
	///</summary>
	public static readonly MethodInfo Sum4 = SeqMethods.Sum4.Qy;

	///<summary>
	///long? Sum()
	///</summary>
	public static readonly MethodInfo Sum5 = SeqMethods.Sum5.Qy;

	///<summary>
	///float Sum()
	///</summary>
	public static readonly MethodInfo Sum6 = SeqMethods.Sum6.Qy;

	///<summary>
	///float? Sum()
	///</summary>
	public static readonly MethodInfo Sum7 = SeqMethods.Sum7.Qy;

	///<summary>
	///double Sum()
	///</summary>
	public static readonly MethodInfo Sum8 = SeqMethods.Sum8.Qy;

	///<summary>
	///double? Sum()
	///</summary>
	public static readonly MethodInfo Sum9 = SeqMethods.Sum9.Qy;

	///<summary>
	///IQueryable&lt;TSource&gt; Take&lt;TSource&gt;(int count)
	///</summary>
	public static readonly MethodInfo Take = SeqMethods.Take.Qy;

	///<summary>
	///IQueryable&lt;TSource&gt; TakeWhile&lt;TSource&gt;(Expression&lt;Func&lt;TSource, bool&gt;&gt; predicate)
	///</summary>
	public static readonly MethodInfo TakeWhile = SeqMethods.TakeWhile.Qy;

	///<summary>
	///IQueryable&lt;TSource&gt; TakeWhile&lt;TSource&gt;(Expression&lt;Func&lt;TSource, int, bool&gt;&gt; predicate)
	///</summary>
	public static readonly MethodInfo TakeWhile2 = SeqMethods.TakeWhile2.Qy;

	///<summary>
	///IOrderedQueryable&lt;TSource&gt; ThenBy&lt;TSource, TKey&gt;(Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector)
	///</summary>
	public static readonly MethodInfo ThenBy = SeqMethods.ThenBy.Qy;

	///<summary>
	///IOrderedQueryable&lt;TSource&gt; ThenBy&lt;TSource, TKey&gt;(Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector, IComparer&lt;TKey&gt; comparer)
	///</summary>
	public static readonly MethodInfo ThenBy2 = SeqMethods.ThenBy2.Qy;

	///<summary>
	///IOrderedQueryable&lt;TSource&gt; ThenByDescending&lt;TSource, TKey&gt;(Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector)
	///</summary>
	public static readonly MethodInfo ThenByDescending = SeqMethods.ThenByDescending.Qy;

	///<summary>
	///IOrderedQueryable&lt;TSource&gt; ThenByDescending&lt;TSource, TKey&gt;(Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector, IComparer&lt;TKey&gt; comparer)
	///</summary>
	public static readonly MethodInfo ThenByDescending2 = SeqMethods.ThenByDescending2.Qy;

	///<summary>
	///IQueryable&lt;TSource&gt; Union&lt;TSource&gt;(IEnumerable&lt;TSource&gt; source2)
	///</summary>
	public static readonly MethodInfo Union = SeqMethods.Union.Qy;

	///<summary>
	///IQueryable&lt;TSource&gt; Union&lt;TSource&gt;(IEnumerable&lt;TSource&gt; source2, IEqualityComparer&lt;TSource&gt; comparer)
	///</summary>
	public static readonly MethodInfo Union2 = SeqMethods.Union2.Qy;

	///<summary>
	///IQueryable&lt;TSource&gt; Where&lt;TSource&gt;(Expression&lt;Func&lt;TSource, bool&gt;&gt; predicate)
	///</summary>
	public static readonly MethodInfo Where = SeqMethods.Where.Qy;

	///<summary>
	///IQueryable&lt;TSource&gt; Where&lt;TSource&gt;(Expression&lt;Func&lt;TSource, int, bool&gt;&gt; predicate)
	///</summary>
	public static readonly MethodInfo Where2 = SeqMethods.Where2.Qy;

	///<summary>
	///IQueryable&lt;TResult&gt; Zip&lt;TFirst, TSecond, TResult&gt;(IEnumerable&lt;TSecond&gt; source2, Expression&lt;Func&lt;TFirst, TSecond, TResult&gt;&gt; resultSelector)
	///</summary>
	public static readonly MethodInfo Zip = SeqMethods.Zip.Qy;

	
} 