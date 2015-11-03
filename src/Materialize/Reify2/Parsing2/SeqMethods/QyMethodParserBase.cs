using System;
using System.Collections.Generic;
using System.Reflection;

namespace Materialize.Reify2.Parsing2.SeqMethods 
{
	abstract class QyMethodParserBase 
	{
		protected delegate IEnumerable<ITransition> SubParser(MethodParseSubject s);


		protected IDictionary<MethodInfo, Func<QyMethodParserBase, SubParser>> _dSubParsers 
			= new Dictionary<MethodInfo, Func<QyMethodParserBase, SubParser>>() {
				{ QyMethods.Aggregate, @this => @this.ParseAggregate },
				{ QyMethods.Aggregate2, @this => @this.ParseAggregate2 },
				{ QyMethods.Aggregate3, @this => @this.ParseAggregate3 },
				{ QyMethods.All, @this => @this.ParseAll },
				{ QyMethods.Any, @this => @this.ParseAny },
				{ QyMethods.Any2, @this => @this.ParseAny2 },
				{ QyMethods.Average, @this => @this.ParseAverage },
				{ QyMethods.Average10, @this => @this.ParseAverage10 },
				{ QyMethods.Average11, @this => @this.ParseAverage11 },
				{ QyMethods.Average12, @this => @this.ParseAverage12 },
				{ QyMethods.Average13, @this => @this.ParseAverage13 },
				{ QyMethods.Average14, @this => @this.ParseAverage14 },
				{ QyMethods.Average15, @this => @this.ParseAverage15 },
				{ QyMethods.Average16, @this => @this.ParseAverage16 },
				{ QyMethods.Average17, @this => @this.ParseAverage17 },
				{ QyMethods.Average18, @this => @this.ParseAverage18 },
				{ QyMethods.Average19, @this => @this.ParseAverage19 },
				{ QyMethods.Average2, @this => @this.ParseAverage2 },
				{ QyMethods.Average20, @this => @this.ParseAverage20 },
				{ QyMethods.Average3, @this => @this.ParseAverage3 },
				{ QyMethods.Average4, @this => @this.ParseAverage4 },
				{ QyMethods.Average5, @this => @this.ParseAverage5 },
				{ QyMethods.Average6, @this => @this.ParseAverage6 },
				{ QyMethods.Average7, @this => @this.ParseAverage7 },
				{ QyMethods.Average8, @this => @this.ParseAverage8 },
				{ QyMethods.Average9, @this => @this.ParseAverage9 },
				{ QyMethods.Cast, @this => @this.ParseCast },
				{ QyMethods.Concat, @this => @this.ParseConcat },
				{ QyMethods.Contains, @this => @this.ParseContains },
				{ QyMethods.Contains2, @this => @this.ParseContains2 },
				{ QyMethods.Count, @this => @this.ParseCount },
				{ QyMethods.Count2, @this => @this.ParseCount2 },
				{ QyMethods.DefaultIfEmpty, @this => @this.ParseDefaultIfEmpty },
				{ QyMethods.DefaultIfEmpty2, @this => @this.ParseDefaultIfEmpty2 },
				{ QyMethods.Distinct, @this => @this.ParseDistinct },
				{ QyMethods.Distinct2, @this => @this.ParseDistinct2 },
				{ QyMethods.ElementAt, @this => @this.ParseElementAt },
				{ QyMethods.ElementAtOrDefault, @this => @this.ParseElementAtOrDefault },
				{ QyMethods.Except, @this => @this.ParseExcept },
				{ QyMethods.Except2, @this => @this.ParseExcept2 },
				{ QyMethods.First, @this => @this.ParseFirst },
				{ QyMethods.First2, @this => @this.ParseFirst2 },
				{ QyMethods.FirstOrDefault, @this => @this.ParseFirstOrDefault },
				{ QyMethods.FirstOrDefault2, @this => @this.ParseFirstOrDefault2 },
				{ QyMethods.GroupBy, @this => @this.ParseGroupBy },
				{ QyMethods.GroupBy2, @this => @this.ParseGroupBy2 },
				{ QyMethods.GroupBy3, @this => @this.ParseGroupBy3 },
				{ QyMethods.GroupBy4, @this => @this.ParseGroupBy4 },
				{ QyMethods.GroupBy5, @this => @this.ParseGroupBy5 },
				{ QyMethods.GroupBy6, @this => @this.ParseGroupBy6 },
				{ QyMethods.GroupBy7, @this => @this.ParseGroupBy7 },
				{ QyMethods.GroupBy8, @this => @this.ParseGroupBy8 },
				{ QyMethods.GroupJoin, @this => @this.ParseGroupJoin },
				{ QyMethods.GroupJoin2, @this => @this.ParseGroupJoin2 },
				{ QyMethods.Intersect, @this => @this.ParseIntersect },
				{ QyMethods.Intersect2, @this => @this.ParseIntersect2 },
				{ QyMethods.Join, @this => @this.ParseJoin },
				{ QyMethods.Join2, @this => @this.ParseJoin2 },
				{ QyMethods.Last, @this => @this.ParseLast },
				{ QyMethods.Last2, @this => @this.ParseLast2 },
				{ QyMethods.LastOrDefault, @this => @this.ParseLastOrDefault },
				{ QyMethods.LastOrDefault2, @this => @this.ParseLastOrDefault2 },
				{ QyMethods.LongCount, @this => @this.ParseLongCount },
				{ QyMethods.LongCount2, @this => @this.ParseLongCount2 },
				{ QyMethods.Max, @this => @this.ParseMax },
				{ QyMethods.Max2, @this => @this.ParseMax2 },
				{ QyMethods.Min, @this => @this.ParseMin },
				{ QyMethods.Min2, @this => @this.ParseMin2 },
				{ QyMethods.OfType, @this => @this.ParseOfType },
				{ QyMethods.OrderBy, @this => @this.ParseOrderBy },
				{ QyMethods.OrderBy2, @this => @this.ParseOrderBy2 },
				{ QyMethods.OrderByDescending, @this => @this.ParseOrderByDescending },
				{ QyMethods.OrderByDescending2, @this => @this.ParseOrderByDescending2 },
				{ QyMethods.Reverse, @this => @this.ParseReverse },
				{ QyMethods.Select, @this => @this.ParseSelect },
				{ QyMethods.Select2, @this => @this.ParseSelect2 },
				{ QyMethods.SelectMany, @this => @this.ParseSelectMany },
				{ QyMethods.SelectMany2, @this => @this.ParseSelectMany2 },
				{ QyMethods.SelectMany3, @this => @this.ParseSelectMany3 },
				{ QyMethods.SelectMany4, @this => @this.ParseSelectMany4 },
				{ QyMethods.SequenceEqual, @this => @this.ParseSequenceEqual },
				{ QyMethods.SequenceEqual2, @this => @this.ParseSequenceEqual2 },
				{ QyMethods.Single, @this => @this.ParseSingle },
				{ QyMethods.Single2, @this => @this.ParseSingle2 },
				{ QyMethods.SingleOrDefault, @this => @this.ParseSingleOrDefault },
				{ QyMethods.SingleOrDefault2, @this => @this.ParseSingleOrDefault2 },
				{ QyMethods.Skip, @this => @this.ParseSkip },
				{ QyMethods.SkipWhile, @this => @this.ParseSkipWhile },
				{ QyMethods.SkipWhile2, @this => @this.ParseSkipWhile2 },
				{ QyMethods.Sum, @this => @this.ParseSum },
				{ QyMethods.Sum10, @this => @this.ParseSum10 },
				{ QyMethods.Sum11, @this => @this.ParseSum11 },
				{ QyMethods.Sum12, @this => @this.ParseSum12 },
				{ QyMethods.Sum13, @this => @this.ParseSum13 },
				{ QyMethods.Sum14, @this => @this.ParseSum14 },
				{ QyMethods.Sum15, @this => @this.ParseSum15 },
				{ QyMethods.Sum16, @this => @this.ParseSum16 },
				{ QyMethods.Sum17, @this => @this.ParseSum17 },
				{ QyMethods.Sum18, @this => @this.ParseSum18 },
				{ QyMethods.Sum19, @this => @this.ParseSum19 },
				{ QyMethods.Sum2, @this => @this.ParseSum2 },
				{ QyMethods.Sum20, @this => @this.ParseSum20 },
				{ QyMethods.Sum3, @this => @this.ParseSum3 },
				{ QyMethods.Sum4, @this => @this.ParseSum4 },
				{ QyMethods.Sum5, @this => @this.ParseSum5 },
				{ QyMethods.Sum6, @this => @this.ParseSum6 },
				{ QyMethods.Sum7, @this => @this.ParseSum7 },
				{ QyMethods.Sum8, @this => @this.ParseSum8 },
				{ QyMethods.Sum9, @this => @this.ParseSum9 },
				{ QyMethods.Take, @this => @this.ParseTake },
				{ QyMethods.TakeWhile, @this => @this.ParseTakeWhile },
				{ QyMethods.TakeWhile2, @this => @this.ParseTakeWhile2 },
				{ QyMethods.ThenBy, @this => @this.ParseThenBy },
				{ QyMethods.ThenBy2, @this => @this.ParseThenBy2 },
				{ QyMethods.ThenByDescending, @this => @this.ParseThenByDescending },
				{ QyMethods.ThenByDescending2, @this => @this.ParseThenByDescending2 },
				{ QyMethods.Union, @this => @this.ParseUnion },
				{ QyMethods.Union2, @this => @this.ParseUnion2 },
				{ QyMethods.Where, @this => @this.ParseWhere },
				{ QyMethods.Where2, @this => @this.ParseWhere2 },
				{ QyMethods.Zip, @this => @this.ParseZip },
			};




		///<summary>
		///TSource Queryable.Aggregate&lt;TSource&gt;(IQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, TSource, TSource&gt;&gt; func)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseAggregate(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method TSource Queryable.Aggregate<TSource>(IQueryable<TSource> source, Expression<Func<TSource, TSource, TSource>> func)");
		}

		///<summary>
		///TAccumulate Queryable.Aggregate&lt;TSource, TAccumulate&gt;(IQueryable&lt;TSource&gt; source, TAccumulate seed, Expression&lt;Func&lt;TAccumulate, TSource, TAccumulate&gt;&gt; func)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseAggregate2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method TAccumulate Queryable.Aggregate<TSource, TAccumulate>(IQueryable<TSource> source, TAccumulate seed, Expression<Func<TAccumulate, TSource, TAccumulate>> func)");
		}

		///<summary>
		///TResult Queryable.Aggregate&lt;TSource, TAccumulate, TResult&gt;(IQueryable&lt;TSource&gt; source, TAccumulate seed, Expression&lt;Func&lt;TAccumulate, TSource, TAccumulate&gt;&gt; func, Expression&lt;Func&lt;TAccumulate, TResult&gt;&gt; selector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseAggregate3(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method TResult Queryable.Aggregate<TSource, TAccumulate, TResult>(IQueryable<TSource> source, TAccumulate seed, Expression<Func<TAccumulate, TSource, TAccumulate>> func, Expression<Func<TAccumulate, TResult>> selector)");
		}

		///<summary>
		///bool Queryable.All&lt;TSource&gt;(IQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, bool&gt;&gt; predicate)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseAll(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method bool Queryable.All<TSource>(IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate)");
		}

		///<summary>
		///bool Queryable.Any&lt;TSource&gt;(IQueryable&lt;TSource&gt; source)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseAny(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method bool Queryable.Any<TSource>(IQueryable<TSource> source)");
		}

		///<summary>
		///bool Queryable.Any&lt;TSource&gt;(IQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, bool&gt;&gt; predicate)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseAny2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method bool Queryable.Any<TSource>(IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate)");
		}

		///<summary>
		///double Queryable.Average(IQueryable&lt;int&gt; source)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseAverage(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method double Queryable.Average(IQueryable<int> source)");
		}

		///<summary>
		///decimal? Queryable.Average(IQueryable&lt;decimal?&gt; source)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseAverage10(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method decimal? Queryable.Average(IQueryable<decimal?> source)");
		}

		///<summary>
		///double Queryable.Average&lt;TSource&gt;(IQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, int&gt;&gt; selector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseAverage11(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method double Queryable.Average<TSource>(IQueryable<TSource> source, Expression<Func<TSource, int>> selector)");
		}

		///<summary>
		///double? Queryable.Average&lt;TSource&gt;(IQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, int?&gt;&gt; selector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseAverage12(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method double? Queryable.Average<TSource>(IQueryable<TSource> source, Expression<Func<TSource, int?>> selector)");
		}

		///<summary>
		///float Queryable.Average&lt;TSource&gt;(IQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, float&gt;&gt; selector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseAverage13(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method float Queryable.Average<TSource>(IQueryable<TSource> source, Expression<Func<TSource, float>> selector)");
		}

		///<summary>
		///float? Queryable.Average&lt;TSource&gt;(IQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, float?&gt;&gt; selector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseAverage14(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method float? Queryable.Average<TSource>(IQueryable<TSource> source, Expression<Func<TSource, float?>> selector)");
		}

		///<summary>
		///double Queryable.Average&lt;TSource&gt;(IQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, long&gt;&gt; selector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseAverage15(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method double Queryable.Average<TSource>(IQueryable<TSource> source, Expression<Func<TSource, long>> selector)");
		}

		///<summary>
		///double? Queryable.Average&lt;TSource&gt;(IQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, long?&gt;&gt; selector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseAverage16(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method double? Queryable.Average<TSource>(IQueryable<TSource> source, Expression<Func<TSource, long?>> selector)");
		}

		///<summary>
		///double Queryable.Average&lt;TSource&gt;(IQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, double&gt;&gt; selector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseAverage17(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method double Queryable.Average<TSource>(IQueryable<TSource> source, Expression<Func<TSource, double>> selector)");
		}

		///<summary>
		///double? Queryable.Average&lt;TSource&gt;(IQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, double?&gt;&gt; selector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseAverage18(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method double? Queryable.Average<TSource>(IQueryable<TSource> source, Expression<Func<TSource, double?>> selector)");
		}

		///<summary>
		///decimal Queryable.Average&lt;TSource&gt;(IQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, decimal&gt;&gt; selector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseAverage19(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method decimal Queryable.Average<TSource>(IQueryable<TSource> source, Expression<Func<TSource, decimal>> selector)");
		}

		///<summary>
		///double? Queryable.Average(IQueryable&lt;int?&gt; source)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseAverage2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method double? Queryable.Average(IQueryable<int?> source)");
		}

		///<summary>
		///decimal? Queryable.Average&lt;TSource&gt;(IQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, decimal?&gt;&gt; selector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseAverage20(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method decimal? Queryable.Average<TSource>(IQueryable<TSource> source, Expression<Func<TSource, decimal?>> selector)");
		}

		///<summary>
		///double Queryable.Average(IQueryable&lt;long&gt; source)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseAverage3(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method double Queryable.Average(IQueryable<long> source)");
		}

		///<summary>
		///double? Queryable.Average(IQueryable&lt;long?&gt; source)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseAverage4(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method double? Queryable.Average(IQueryable<long?> source)");
		}

		///<summary>
		///float Queryable.Average(IQueryable&lt;float&gt; source)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseAverage5(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method float Queryable.Average(IQueryable<float> source)");
		}

		///<summary>
		///float? Queryable.Average(IQueryable&lt;float?&gt; source)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseAverage6(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method float? Queryable.Average(IQueryable<float?> source)");
		}

		///<summary>
		///double Queryable.Average(IQueryable&lt;double&gt; source)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseAverage7(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method double Queryable.Average(IQueryable<double> source)");
		}

		///<summary>
		///double? Queryable.Average(IQueryable&lt;double?&gt; source)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseAverage8(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method double? Queryable.Average(IQueryable<double?> source)");
		}

		///<summary>
		///decimal Queryable.Average(IQueryable&lt;decimal&gt; source)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseAverage9(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method decimal Queryable.Average(IQueryable<decimal> source)");
		}

		///<summary>
		///IQueryable&lt;TResult&gt; Queryable.Cast&lt;TResult&gt;(IQueryable source)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseCast(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TResult> Queryable.Cast<TResult>(IQueryable source)");
		}

		///<summary>
		///IQueryable&lt;TSource&gt; Queryable.Concat&lt;TSource&gt;(IQueryable&lt;TSource&gt; source1, IEnumerable&lt;TSource&gt; source2)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseConcat(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TSource> Queryable.Concat<TSource>(IQueryable<TSource> source1, IEnumerable<TSource> source2)");
		}

		///<summary>
		///bool Queryable.Contains&lt;TSource&gt;(IQueryable&lt;TSource&gt; source, TSource item)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseContains(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method bool Queryable.Contains<TSource>(IQueryable<TSource> source, TSource item)");
		}

		///<summary>
		///bool Queryable.Contains&lt;TSource&gt;(IQueryable&lt;TSource&gt; source, TSource item, IEqualityComparer&lt;TSource&gt; comparer)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseContains2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method bool Queryable.Contains<TSource>(IQueryable<TSource> source, TSource item, IEqualityComparer<TSource> comparer)");
		}

		///<summary>
		///int Queryable.Count&lt;TSource&gt;(IQueryable&lt;TSource&gt; source)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseCount(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method int Queryable.Count<TSource>(IQueryable<TSource> source)");
		}

		///<summary>
		///int Queryable.Count&lt;TSource&gt;(IQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, bool&gt;&gt; predicate)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseCount2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method int Queryable.Count<TSource>(IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate)");
		}

		///<summary>
		///IQueryable&lt;TSource&gt; Queryable.DefaultIfEmpty&lt;TSource&gt;(IQueryable&lt;TSource&gt; source)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseDefaultIfEmpty(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TSource> Queryable.DefaultIfEmpty<TSource>(IQueryable<TSource> source)");
		}

		///<summary>
		///IQueryable&lt;TSource&gt; Queryable.DefaultIfEmpty&lt;TSource&gt;(IQueryable&lt;TSource&gt; source, TSource defaultValue)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseDefaultIfEmpty2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TSource> Queryable.DefaultIfEmpty<TSource>(IQueryable<TSource> source, TSource defaultValue)");
		}

		///<summary>
		///IQueryable&lt;TSource&gt; Queryable.Distinct&lt;TSource&gt;(IQueryable&lt;TSource&gt; source)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseDistinct(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TSource> Queryable.Distinct<TSource>(IQueryable<TSource> source)");
		}

		///<summary>
		///IQueryable&lt;TSource&gt; Queryable.Distinct&lt;TSource&gt;(IQueryable&lt;TSource&gt; source, IEqualityComparer&lt;TSource&gt; comparer)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseDistinct2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TSource> Queryable.Distinct<TSource>(IQueryable<TSource> source, IEqualityComparer<TSource> comparer)");
		}

		///<summary>
		///TSource Queryable.ElementAt&lt;TSource&gt;(IQueryable&lt;TSource&gt; source, int index)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseElementAt(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method TSource Queryable.ElementAt<TSource>(IQueryable<TSource> source, int index)");
		}

		///<summary>
		///TSource Queryable.ElementAtOrDefault&lt;TSource&gt;(IQueryable&lt;TSource&gt; source, int index)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseElementAtOrDefault(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method TSource Queryable.ElementAtOrDefault<TSource>(IQueryable<TSource> source, int index)");
		}

		///<summary>
		///IQueryable&lt;TSource&gt; Queryable.Except&lt;TSource&gt;(IQueryable&lt;TSource&gt; source1, IEnumerable&lt;TSource&gt; source2)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseExcept(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TSource> Queryable.Except<TSource>(IQueryable<TSource> source1, IEnumerable<TSource> source2)");
		}

		///<summary>
		///IQueryable&lt;TSource&gt; Queryable.Except&lt;TSource&gt;(IQueryable&lt;TSource&gt; source1, IEnumerable&lt;TSource&gt; source2, IEqualityComparer&lt;TSource&gt; comparer)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseExcept2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TSource> Queryable.Except<TSource>(IQueryable<TSource> source1, IEnumerable<TSource> source2, IEqualityComparer<TSource> comparer)");
		}

		///<summary>
		///TSource Queryable.First&lt;TSource&gt;(IQueryable&lt;TSource&gt; source)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseFirst(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method TSource Queryable.First<TSource>(IQueryable<TSource> source)");
		}

		///<summary>
		///TSource Queryable.First&lt;TSource&gt;(IQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, bool&gt;&gt; predicate)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseFirst2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method TSource Queryable.First<TSource>(IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate)");
		}

		///<summary>
		///TSource Queryable.FirstOrDefault&lt;TSource&gt;(IQueryable&lt;TSource&gt; source)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseFirstOrDefault(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method TSource Queryable.FirstOrDefault<TSource>(IQueryable<TSource> source)");
		}

		///<summary>
		///TSource Queryable.FirstOrDefault&lt;TSource&gt;(IQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, bool&gt;&gt; predicate)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseFirstOrDefault2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method TSource Queryable.FirstOrDefault<TSource>(IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate)");
		}

		///<summary>
		///IQueryable&lt;IGrouping&lt;TKey, TSource&gt;&gt; Queryable.GroupBy&lt;TSource, TKey&gt;(IQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseGroupBy(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<IGrouping<TKey, TSource>> Queryable.GroupBy<TSource, TKey>(IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector)");
		}

		///<summary>
		///IQueryable&lt;IGrouping&lt;TKey, TElement&gt;&gt; Queryable.GroupBy&lt;TSource, TKey, TElement&gt;(IQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector, Expression&lt;Func&lt;TSource, TElement&gt;&gt; elementSelector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseGroupBy2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<IGrouping<TKey, TElement>> Queryable.GroupBy<TSource, TKey, TElement>(IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector, Expression<Func<TSource, TElement>> elementSelector)");
		}

		///<summary>
		///IQueryable&lt;IGrouping&lt;TKey, TSource&gt;&gt; Queryable.GroupBy&lt;TSource, TKey&gt;(IQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector, IEqualityComparer&lt;TKey&gt; comparer)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseGroupBy3(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<IGrouping<TKey, TSource>> Queryable.GroupBy<TSource, TKey>(IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector, IEqualityComparer<TKey> comparer)");
		}

		///<summary>
		///IQueryable&lt;IGrouping&lt;TKey, TElement&gt;&gt; Queryable.GroupBy&lt;TSource, TKey, TElement&gt;(IQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector, Expression&lt;Func&lt;TSource, TElement&gt;&gt; elementSelector, IEqualityComparer&lt;TKey&gt; comparer)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseGroupBy4(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<IGrouping<TKey, TElement>> Queryable.GroupBy<TSource, TKey, TElement>(IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector, Expression<Func<TSource, TElement>> elementSelector, IEqualityComparer<TKey> comparer)");
		}

		///<summary>
		///IQueryable&lt;TResult&gt; Queryable.GroupBy&lt;TSource, TKey, TElement, TResult&gt;(IQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector, Expression&lt;Func&lt;TSource, TElement&gt;&gt; elementSelector, Expression&lt;Func&lt;TKey, IEnumerable&lt;TElement&gt;, TResult&gt;&gt; resultSelector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseGroupBy5(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TResult> Queryable.GroupBy<TSource, TKey, TElement, TResult>(IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector, Expression<Func<TSource, TElement>> elementSelector, Expression<Func<TKey, IEnumerable<TElement>, TResult>> resultSelector)");
		}

		///<summary>
		///IQueryable&lt;TResult&gt; Queryable.GroupBy&lt;TSource, TKey, TResult&gt;(IQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector, Expression&lt;Func&lt;TKey, IEnumerable&lt;TSource&gt;, TResult&gt;&gt; resultSelector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseGroupBy6(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TResult> Queryable.GroupBy<TSource, TKey, TResult>(IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector, Expression<Func<TKey, IEnumerable<TSource>, TResult>> resultSelector)");
		}

		///<summary>
		///IQueryable&lt;TResult&gt; Queryable.GroupBy&lt;TSource, TKey, TResult&gt;(IQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector, Expression&lt;Func&lt;TKey, IEnumerable&lt;TSource&gt;, TResult&gt;&gt; resultSelector, IEqualityComparer&lt;TKey&gt; comparer)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseGroupBy7(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TResult> Queryable.GroupBy<TSource, TKey, TResult>(IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector, Expression<Func<TKey, IEnumerable<TSource>, TResult>> resultSelector, IEqualityComparer<TKey> comparer)");
		}

		///<summary>
		///IQueryable&lt;TResult&gt; Queryable.GroupBy&lt;TSource, TKey, TElement, TResult&gt;(IQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector, Expression&lt;Func&lt;TSource, TElement&gt;&gt; elementSelector, Expression&lt;Func&lt;TKey, IEnumerable&lt;TElement&gt;, TResult&gt;&gt; resultSelector, IEqualityComparer&lt;TKey&gt; comparer)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseGroupBy8(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TResult> Queryable.GroupBy<TSource, TKey, TElement, TResult>(IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector, Expression<Func<TSource, TElement>> elementSelector, Expression<Func<TKey, IEnumerable<TElement>, TResult>> resultSelector, IEqualityComparer<TKey> comparer)");
		}

		///<summary>
		///IQueryable&lt;TResult&gt; Queryable.GroupJoin&lt;TOuter, TInner, TKey, TResult&gt;(IQueryable&lt;TOuter&gt; outer, IEnumerable&lt;TInner&gt; inner, Expression&lt;Func&lt;TOuter, TKey&gt;&gt; outerKeySelector, Expression&lt;Func&lt;TInner, TKey&gt;&gt; innerKeySelector, Expression&lt;Func&lt;TOuter, IEnumerable&lt;TInner&gt;, TResult&gt;&gt; resultSelector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseGroupJoin(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TResult> Queryable.GroupJoin<TOuter, TInner, TKey, TResult>(IQueryable<TOuter> outer, IEnumerable<TInner> inner, Expression<Func<TOuter, TKey>> outerKeySelector, Expression<Func<TInner, TKey>> innerKeySelector, Expression<Func<TOuter, IEnumerable<TInner>, TResult>> resultSelector)");
		}

		///<summary>
		///IQueryable&lt;TResult&gt; Queryable.GroupJoin&lt;TOuter, TInner, TKey, TResult&gt;(IQueryable&lt;TOuter&gt; outer, IEnumerable&lt;TInner&gt; inner, Expression&lt;Func&lt;TOuter, TKey&gt;&gt; outerKeySelector, Expression&lt;Func&lt;TInner, TKey&gt;&gt; innerKeySelector, Expression&lt;Func&lt;TOuter, IEnumerable&lt;TInner&gt;, TResult&gt;&gt; resultSelector, IEqualityComparer&lt;TKey&gt; comparer)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseGroupJoin2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TResult> Queryable.GroupJoin<TOuter, TInner, TKey, TResult>(IQueryable<TOuter> outer, IEnumerable<TInner> inner, Expression<Func<TOuter, TKey>> outerKeySelector, Expression<Func<TInner, TKey>> innerKeySelector, Expression<Func<TOuter, IEnumerable<TInner>, TResult>> resultSelector, IEqualityComparer<TKey> comparer)");
		}

		///<summary>
		///IQueryable&lt;TSource&gt; Queryable.Intersect&lt;TSource&gt;(IQueryable&lt;TSource&gt; source1, IEnumerable&lt;TSource&gt; source2)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseIntersect(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TSource> Queryable.Intersect<TSource>(IQueryable<TSource> source1, IEnumerable<TSource> source2)");
		}

		///<summary>
		///IQueryable&lt;TSource&gt; Queryable.Intersect&lt;TSource&gt;(IQueryable&lt;TSource&gt; source1, IEnumerable&lt;TSource&gt; source2, IEqualityComparer&lt;TSource&gt; comparer)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseIntersect2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TSource> Queryable.Intersect<TSource>(IQueryable<TSource> source1, IEnumerable<TSource> source2, IEqualityComparer<TSource> comparer)");
		}

		///<summary>
		///IQueryable&lt;TResult&gt; Queryable.Join&lt;TOuter, TInner, TKey, TResult&gt;(IQueryable&lt;TOuter&gt; outer, IEnumerable&lt;TInner&gt; inner, Expression&lt;Func&lt;TOuter, TKey&gt;&gt; outerKeySelector, Expression&lt;Func&lt;TInner, TKey&gt;&gt; innerKeySelector, Expression&lt;Func&lt;TOuter, TInner, TResult&gt;&gt; resultSelector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseJoin(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TResult> Queryable.Join<TOuter, TInner, TKey, TResult>(IQueryable<TOuter> outer, IEnumerable<TInner> inner, Expression<Func<TOuter, TKey>> outerKeySelector, Expression<Func<TInner, TKey>> innerKeySelector, Expression<Func<TOuter, TInner, TResult>> resultSelector)");
		}

		///<summary>
		///IQueryable&lt;TResult&gt; Queryable.Join&lt;TOuter, TInner, TKey, TResult&gt;(IQueryable&lt;TOuter&gt; outer, IEnumerable&lt;TInner&gt; inner, Expression&lt;Func&lt;TOuter, TKey&gt;&gt; outerKeySelector, Expression&lt;Func&lt;TInner, TKey&gt;&gt; innerKeySelector, Expression&lt;Func&lt;TOuter, TInner, TResult&gt;&gt; resultSelector, IEqualityComparer&lt;TKey&gt; comparer)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseJoin2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TResult> Queryable.Join<TOuter, TInner, TKey, TResult>(IQueryable<TOuter> outer, IEnumerable<TInner> inner, Expression<Func<TOuter, TKey>> outerKeySelector, Expression<Func<TInner, TKey>> innerKeySelector, Expression<Func<TOuter, TInner, TResult>> resultSelector, IEqualityComparer<TKey> comparer)");
		}

		///<summary>
		///TSource Queryable.Last&lt;TSource&gt;(IQueryable&lt;TSource&gt; source)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseLast(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method TSource Queryable.Last<TSource>(IQueryable<TSource> source)");
		}

		///<summary>
		///TSource Queryable.Last&lt;TSource&gt;(IQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, bool&gt;&gt; predicate)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseLast2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method TSource Queryable.Last<TSource>(IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate)");
		}

		///<summary>
		///TSource Queryable.LastOrDefault&lt;TSource&gt;(IQueryable&lt;TSource&gt; source)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseLastOrDefault(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method TSource Queryable.LastOrDefault<TSource>(IQueryable<TSource> source)");
		}

		///<summary>
		///TSource Queryable.LastOrDefault&lt;TSource&gt;(IQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, bool&gt;&gt; predicate)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseLastOrDefault2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method TSource Queryable.LastOrDefault<TSource>(IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate)");
		}

		///<summary>
		///long Queryable.LongCount&lt;TSource&gt;(IQueryable&lt;TSource&gt; source)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseLongCount(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method long Queryable.LongCount<TSource>(IQueryable<TSource> source)");
		}

		///<summary>
		///long Queryable.LongCount&lt;TSource&gt;(IQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, bool&gt;&gt; predicate)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseLongCount2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method long Queryable.LongCount<TSource>(IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate)");
		}

		///<summary>
		///TSource Queryable.Max&lt;TSource&gt;(IQueryable&lt;TSource&gt; source)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseMax(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method TSource Queryable.Max<TSource>(IQueryable<TSource> source)");
		}

		///<summary>
		///TResult Queryable.Max&lt;TSource, TResult&gt;(IQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, TResult&gt;&gt; selector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseMax2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method TResult Queryable.Max<TSource, TResult>(IQueryable<TSource> source, Expression<Func<TSource, TResult>> selector)");
		}

		///<summary>
		///TSource Queryable.Min&lt;TSource&gt;(IQueryable&lt;TSource&gt; source)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseMin(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method TSource Queryable.Min<TSource>(IQueryable<TSource> source)");
		}

		///<summary>
		///TResult Queryable.Min&lt;TSource, TResult&gt;(IQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, TResult&gt;&gt; selector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseMin2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method TResult Queryable.Min<TSource, TResult>(IQueryable<TSource> source, Expression<Func<TSource, TResult>> selector)");
		}

		///<summary>
		///IQueryable&lt;TResult&gt; Queryable.OfType&lt;TResult&gt;(IQueryable source)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseOfType(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TResult> Queryable.OfType<TResult>(IQueryable source)");
		}

		///<summary>
		///IOrderedQueryable&lt;TSource&gt; Queryable.OrderBy&lt;TSource, TKey&gt;(IQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseOrderBy(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IOrderedQueryable<TSource> Queryable.OrderBy<TSource, TKey>(IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector)");
		}

		///<summary>
		///IOrderedQueryable&lt;TSource&gt; Queryable.OrderBy&lt;TSource, TKey&gt;(IQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector, IComparer&lt;TKey&gt; comparer)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseOrderBy2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IOrderedQueryable<TSource> Queryable.OrderBy<TSource, TKey>(IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector, IComparer<TKey> comparer)");
		}

		///<summary>
		///IOrderedQueryable&lt;TSource&gt; Queryable.OrderByDescending&lt;TSource, TKey&gt;(IQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseOrderByDescending(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IOrderedQueryable<TSource> Queryable.OrderByDescending<TSource, TKey>(IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector)");
		}

		///<summary>
		///IOrderedQueryable&lt;TSource&gt; Queryable.OrderByDescending&lt;TSource, TKey&gt;(IQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector, IComparer&lt;TKey&gt; comparer)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseOrderByDescending2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IOrderedQueryable<TSource> Queryable.OrderByDescending<TSource, TKey>(IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector, IComparer<TKey> comparer)");
		}

		///<summary>
		///IQueryable&lt;TSource&gt; Queryable.Reverse&lt;TSource&gt;(IQueryable&lt;TSource&gt; source)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseReverse(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TSource> Queryable.Reverse<TSource>(IQueryable<TSource> source)");
		}

		///<summary>
		///IQueryable&lt;TResult&gt; Queryable.Select&lt;TSource, TResult&gt;(IQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, TResult&gt;&gt; selector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSelect(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TResult> Queryable.Select<TSource, TResult>(IQueryable<TSource> source, Expression<Func<TSource, TResult>> selector)");
		}

		///<summary>
		///IQueryable&lt;TResult&gt; Queryable.Select&lt;TSource, TResult&gt;(IQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, int, TResult&gt;&gt; selector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSelect2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TResult> Queryable.Select<TSource, TResult>(IQueryable<TSource> source, Expression<Func<TSource, int, TResult>> selector)");
		}

		///<summary>
		///IQueryable&lt;TResult&gt; Queryable.SelectMany&lt;TSource, TResult&gt;(IQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, IEnumerable&lt;TResult&gt;&gt;&gt; selector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSelectMany(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TResult> Queryable.SelectMany<TSource, TResult>(IQueryable<TSource> source, Expression<Func<TSource, IEnumerable<TResult>>> selector)");
		}

		///<summary>
		///IQueryable&lt;TResult&gt; Queryable.SelectMany&lt;TSource, TResult&gt;(IQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, int, IEnumerable&lt;TResult&gt;&gt;&gt; selector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSelectMany2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TResult> Queryable.SelectMany<TSource, TResult>(IQueryable<TSource> source, Expression<Func<TSource, int, IEnumerable<TResult>>> selector)");
		}

		///<summary>
		///IQueryable&lt;TResult&gt; Queryable.SelectMany&lt;TSource, TCollection, TResult&gt;(IQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, int, IEnumerable&lt;TCollection&gt;&gt;&gt; collectionSelector, Expression&lt;Func&lt;TSource, TCollection, TResult&gt;&gt; resultSelector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSelectMany3(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TResult> Queryable.SelectMany<TSource, TCollection, TResult>(IQueryable<TSource> source, Expression<Func<TSource, int, IEnumerable<TCollection>>> collectionSelector, Expression<Func<TSource, TCollection, TResult>> resultSelector)");
		}

		///<summary>
		///IQueryable&lt;TResult&gt; Queryable.SelectMany&lt;TSource, TCollection, TResult&gt;(IQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, IEnumerable&lt;TCollection&gt;&gt;&gt; collectionSelector, Expression&lt;Func&lt;TSource, TCollection, TResult&gt;&gt; resultSelector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSelectMany4(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TResult> Queryable.SelectMany<TSource, TCollection, TResult>(IQueryable<TSource> source, Expression<Func<TSource, IEnumerable<TCollection>>> collectionSelector, Expression<Func<TSource, TCollection, TResult>> resultSelector)");
		}

		///<summary>
		///bool Queryable.SequenceEqual&lt;TSource&gt;(IQueryable&lt;TSource&gt; source1, IEnumerable&lt;TSource&gt; source2)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSequenceEqual(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method bool Queryable.SequenceEqual<TSource>(IQueryable<TSource> source1, IEnumerable<TSource> source2)");
		}

		///<summary>
		///bool Queryable.SequenceEqual&lt;TSource&gt;(IQueryable&lt;TSource&gt; source1, IEnumerable&lt;TSource&gt; source2, IEqualityComparer&lt;TSource&gt; comparer)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSequenceEqual2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method bool Queryable.SequenceEqual<TSource>(IQueryable<TSource> source1, IEnumerable<TSource> source2, IEqualityComparer<TSource> comparer)");
		}

		///<summary>
		///TSource Queryable.Single&lt;TSource&gt;(IQueryable&lt;TSource&gt; source)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSingle(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method TSource Queryable.Single<TSource>(IQueryable<TSource> source)");
		}

		///<summary>
		///TSource Queryable.Single&lt;TSource&gt;(IQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, bool&gt;&gt; predicate)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSingle2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method TSource Queryable.Single<TSource>(IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate)");
		}

		///<summary>
		///TSource Queryable.SingleOrDefault&lt;TSource&gt;(IQueryable&lt;TSource&gt; source)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSingleOrDefault(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method TSource Queryable.SingleOrDefault<TSource>(IQueryable<TSource> source)");
		}

		///<summary>
		///TSource Queryable.SingleOrDefault&lt;TSource&gt;(IQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, bool&gt;&gt; predicate)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSingleOrDefault2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method TSource Queryable.SingleOrDefault<TSource>(IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate)");
		}

		///<summary>
		///IQueryable&lt;TSource&gt; Queryable.Skip&lt;TSource&gt;(IQueryable&lt;TSource&gt; source, int count)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSkip(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TSource> Queryable.Skip<TSource>(IQueryable<TSource> source, int count)");
		}

		///<summary>
		///IQueryable&lt;TSource&gt; Queryable.SkipWhile&lt;TSource&gt;(IQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, bool&gt;&gt; predicate)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSkipWhile(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TSource> Queryable.SkipWhile<TSource>(IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate)");
		}

		///<summary>
		///IQueryable&lt;TSource&gt; Queryable.SkipWhile&lt;TSource&gt;(IQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, int, bool&gt;&gt; predicate)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSkipWhile2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TSource> Queryable.SkipWhile<TSource>(IQueryable<TSource> source, Expression<Func<TSource, int, bool>> predicate)");
		}

		///<summary>
		///decimal? Queryable.Sum&lt;TSource&gt;(IQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, decimal?&gt;&gt; selector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSum(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method decimal? Queryable.Sum<TSource>(IQueryable<TSource> source, Expression<Func<TSource, decimal?>> selector)");
		}

		///<summary>
		///decimal Queryable.Sum(IQueryable&lt;decimal&gt; source)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSum10(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method decimal Queryable.Sum(IQueryable<decimal> source)");
		}

		///<summary>
		///decimal? Queryable.Sum(IQueryable&lt;decimal?&gt; source)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSum11(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method decimal? Queryable.Sum(IQueryable<decimal?> source)");
		}

		///<summary>
		///int Queryable.Sum&lt;TSource&gt;(IQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, int&gt;&gt; selector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSum12(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method int Queryable.Sum<TSource>(IQueryable<TSource> source, Expression<Func<TSource, int>> selector)");
		}

		///<summary>
		///int? Queryable.Sum&lt;TSource&gt;(IQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, int?&gt;&gt; selector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSum13(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method int? Queryable.Sum<TSource>(IQueryable<TSource> source, Expression<Func<TSource, int?>> selector)");
		}

		///<summary>
		///long Queryable.Sum&lt;TSource&gt;(IQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, long&gt;&gt; selector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSum14(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method long Queryable.Sum<TSource>(IQueryable<TSource> source, Expression<Func<TSource, long>> selector)");
		}

		///<summary>
		///long? Queryable.Sum&lt;TSource&gt;(IQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, long?&gt;&gt; selector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSum15(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method long? Queryable.Sum<TSource>(IQueryable<TSource> source, Expression<Func<TSource, long?>> selector)");
		}

		///<summary>
		///float Queryable.Sum&lt;TSource&gt;(IQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, float&gt;&gt; selector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSum16(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method float Queryable.Sum<TSource>(IQueryable<TSource> source, Expression<Func<TSource, float>> selector)");
		}

		///<summary>
		///float? Queryable.Sum&lt;TSource&gt;(IQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, float?&gt;&gt; selector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSum17(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method float? Queryable.Sum<TSource>(IQueryable<TSource> source, Expression<Func<TSource, float?>> selector)");
		}

		///<summary>
		///double Queryable.Sum&lt;TSource&gt;(IQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, double&gt;&gt; selector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSum18(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method double Queryable.Sum<TSource>(IQueryable<TSource> source, Expression<Func<TSource, double>> selector)");
		}

		///<summary>
		///double? Queryable.Sum&lt;TSource&gt;(IQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, double?&gt;&gt; selector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSum19(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method double? Queryable.Sum<TSource>(IQueryable<TSource> source, Expression<Func<TSource, double?>> selector)");
		}

		///<summary>
		///int Queryable.Sum(IQueryable&lt;int&gt; source)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSum2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method int Queryable.Sum(IQueryable<int> source)");
		}

		///<summary>
		///decimal Queryable.Sum&lt;TSource&gt;(IQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, decimal&gt;&gt; selector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSum20(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method decimal Queryable.Sum<TSource>(IQueryable<TSource> source, Expression<Func<TSource, decimal>> selector)");
		}

		///<summary>
		///int? Queryable.Sum(IQueryable&lt;int?&gt; source)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSum3(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method int? Queryable.Sum(IQueryable<int?> source)");
		}

		///<summary>
		///long Queryable.Sum(IQueryable&lt;long&gt; source)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSum4(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method long Queryable.Sum(IQueryable<long> source)");
		}

		///<summary>
		///long? Queryable.Sum(IQueryable&lt;long?&gt; source)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSum5(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method long? Queryable.Sum(IQueryable<long?> source)");
		}

		///<summary>
		///float Queryable.Sum(IQueryable&lt;float&gt; source)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSum6(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method float Queryable.Sum(IQueryable<float> source)");
		}

		///<summary>
		///float? Queryable.Sum(IQueryable&lt;float?&gt; source)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSum7(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method float? Queryable.Sum(IQueryable<float?> source)");
		}

		///<summary>
		///double Queryable.Sum(IQueryable&lt;double&gt; source)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSum8(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method double Queryable.Sum(IQueryable<double> source)");
		}

		///<summary>
		///double? Queryable.Sum(IQueryable&lt;double?&gt; source)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSum9(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method double? Queryable.Sum(IQueryable<double?> source)");
		}

		///<summary>
		///IQueryable&lt;TSource&gt; Queryable.Take&lt;TSource&gt;(IQueryable&lt;TSource&gt; source, int count)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseTake(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TSource> Queryable.Take<TSource>(IQueryable<TSource> source, int count)");
		}

		///<summary>
		///IQueryable&lt;TSource&gt; Queryable.TakeWhile&lt;TSource&gt;(IQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, bool&gt;&gt; predicate)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseTakeWhile(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TSource> Queryable.TakeWhile<TSource>(IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate)");
		}

		///<summary>
		///IQueryable&lt;TSource&gt; Queryable.TakeWhile&lt;TSource&gt;(IQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, int, bool&gt;&gt; predicate)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseTakeWhile2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TSource> Queryable.TakeWhile<TSource>(IQueryable<TSource> source, Expression<Func<TSource, int, bool>> predicate)");
		}

		///<summary>
		///IOrderedQueryable&lt;TSource&gt; Queryable.ThenBy&lt;TSource, TKey&gt;(IOrderedQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseThenBy(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IOrderedQueryable<TSource> Queryable.ThenBy<TSource, TKey>(IOrderedQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector)");
		}

		///<summary>
		///IOrderedQueryable&lt;TSource&gt; Queryable.ThenBy&lt;TSource, TKey&gt;(IOrderedQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector, IComparer&lt;TKey&gt; comparer)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseThenBy2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IOrderedQueryable<TSource> Queryable.ThenBy<TSource, TKey>(IOrderedQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector, IComparer<TKey> comparer)");
		}

		///<summary>
		///IOrderedQueryable&lt;TSource&gt; Queryable.ThenByDescending&lt;TSource, TKey&gt;(IOrderedQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseThenByDescending(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IOrderedQueryable<TSource> Queryable.ThenByDescending<TSource, TKey>(IOrderedQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector)");
		}

		///<summary>
		///IOrderedQueryable&lt;TSource&gt; Queryable.ThenByDescending&lt;TSource, TKey&gt;(IOrderedQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector, IComparer&lt;TKey&gt; comparer)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseThenByDescending2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IOrderedQueryable<TSource> Queryable.ThenByDescending<TSource, TKey>(IOrderedQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector, IComparer<TKey> comparer)");
		}

		///<summary>
		///IQueryable&lt;TSource&gt; Queryable.Union&lt;TSource&gt;(IQueryable&lt;TSource&gt; source1, IEnumerable&lt;TSource&gt; source2)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseUnion(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TSource> Queryable.Union<TSource>(IQueryable<TSource> source1, IEnumerable<TSource> source2)");
		}

		///<summary>
		///IQueryable&lt;TSource&gt; Queryable.Union&lt;TSource&gt;(IQueryable&lt;TSource&gt; source1, IEnumerable&lt;TSource&gt; source2, IEqualityComparer&lt;TSource&gt; comparer)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseUnion2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TSource> Queryable.Union<TSource>(IQueryable<TSource> source1, IEnumerable<TSource> source2, IEqualityComparer<TSource> comparer)");
		}

		///<summary>
		///IQueryable&lt;TSource&gt; Queryable.Where&lt;TSource&gt;(IQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, bool&gt;&gt; predicate)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseWhere(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TSource> Queryable.Where<TSource>(IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate)");
		}

		///<summary>
		///IQueryable&lt;TSource&gt; Queryable.Where&lt;TSource&gt;(IQueryable&lt;TSource&gt; source, Expression&lt;Func&lt;TSource, int, bool&gt;&gt; predicate)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseWhere2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TSource> Queryable.Where<TSource>(IQueryable<TSource> source, Expression<Func<TSource, int, bool>> predicate)");
		}

		///<summary>
		///IQueryable&lt;TResult&gt; Queryable.Zip&lt;TFirst, TSecond, TResult&gt;(IQueryable&lt;TFirst&gt; source1, IEnumerable&lt;TSecond&gt; source2, Expression&lt;Func&lt;TFirst, TSecond, TResult&gt;&gt; resultSelector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseZip(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TResult> Queryable.Zip<TFirst, TSecond, TResult>(IQueryable<TFirst> source1, IEnumerable<TSecond> source2, Expression<Func<TFirst, TSecond, TResult>> resultSelector)");
		}

		
	} 

}