using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Materialize.Types;

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
				{ QyMethods.Average2, @this => @this.ParseAverage2 },
				{ QyMethods.Average3, @this => @this.ParseAverage3 },
				{ QyMethods.Average4, @this => @this.ParseAverage4 },
				{ QyMethods.Average5, @this => @this.ParseAverage5 },
				{ QyMethods.Average6, @this => @this.ParseAverage6 },
				{ QyMethods.Average7, @this => @this.ParseAverage7 },
				{ QyMethods.Average8, @this => @this.ParseAverage8 },
				{ QyMethods.Average9, @this => @this.ParseAverage9 },
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
				{ QyMethods.Average20, @this => @this.ParseAverage20 },
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
				{ QyMethods.Sum2, @this => @this.ParseSum2 },
				{ QyMethods.Sum3, @this => @this.ParseSum3 },
				{ QyMethods.Sum4, @this => @this.ParseSum4 },
				{ QyMethods.Sum5, @this => @this.ParseSum5 },
				{ QyMethods.Sum6, @this => @this.ParseSum6 },
				{ QyMethods.Sum7, @this => @this.ParseSum7 },
				{ QyMethods.Sum8, @this => @this.ParseSum8 },
				{ QyMethods.Sum9, @this => @this.ParseSum9 },
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
				{ QyMethods.Sum20, @this => @this.ParseSum20 },
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
		///TSource qy.Aggregate&lt;TSource&gt;(Expression&lt;Func&lt;TSource, TSource, TSource&gt;&gt; func)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseAggregate(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method TSource qy.Aggregate<TSource>(Expression<Func<TSource, TSource, TSource>> func)");
		}

		///<summary>
		///TAccumulate qy.Aggregate&lt;TSource, TAccumulate&gt;(TAccumulate seed, Expression&lt;Func&lt;TAccumulate, TSource, TAccumulate&gt;&gt; func)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseAggregate2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method TAccumulate qy.Aggregate<TSource, TAccumulate>(TAccumulate seed, Expression<Func<TAccumulate, TSource, TAccumulate>> func)");
		}

		///<summary>
		///TResult qy.Aggregate&lt;TSource, TAccumulate, TResult&gt;(TAccumulate seed, Expression&lt;Func&lt;TAccumulate, TSource, TAccumulate&gt;&gt; func, Expression&lt;Func&lt;TAccumulate, TResult&gt;&gt; selector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseAggregate3(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method TResult qy.Aggregate<TSource, TAccumulate, TResult>(TAccumulate seed, Expression<Func<TAccumulate, TSource, TAccumulate>> func, Expression<Func<TAccumulate, TResult>> selector)");
		}

		///<summary>
		///Boolean qy.All&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Boolean&gt;&gt; predicate)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseAll(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method Boolean qy.All<TSource>(Expression<Func<TSource, Boolean>> predicate)");
		}

		///<summary>
		///Boolean qy.Any&lt;TSource&gt;()
		///</summary>
		protected virtual IEnumerable<ITransition> ParseAny(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method Boolean qy.Any<TSource>()");
		}

		///<summary>
		///Boolean qy.Any&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Boolean&gt;&gt; predicate)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseAny2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method Boolean qy.Any<TSource>(Expression<Func<TSource, Boolean>> predicate)");
		}

		///<summary>
		///Double qy.Average&lt;&gt;()
		///</summary>
		protected virtual IEnumerable<ITransition> ParseAverage(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method Double qy.Average<>()");
		}

		///<summary>
		///Nullable&lt;Double&gt; qy.Average&lt;&gt;()
		///</summary>
		protected virtual IEnumerable<ITransition> ParseAverage2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method Nullable<Double> qy.Average<>()");
		}

		///<summary>
		///Double qy.Average&lt;&gt;()
		///</summary>
		protected virtual IEnumerable<ITransition> ParseAverage3(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method Double qy.Average<>()");
		}

		///<summary>
		///Nullable&lt;Double&gt; qy.Average&lt;&gt;()
		///</summary>
		protected virtual IEnumerable<ITransition> ParseAverage4(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method Nullable<Double> qy.Average<>()");
		}

		///<summary>
		///Single qy.Average&lt;&gt;()
		///</summary>
		protected virtual IEnumerable<ITransition> ParseAverage5(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method Single qy.Average<>()");
		}

		///<summary>
		///Nullable&lt;Single&gt; qy.Average&lt;&gt;()
		///</summary>
		protected virtual IEnumerable<ITransition> ParseAverage6(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method Nullable<Single> qy.Average<>()");
		}

		///<summary>
		///Double qy.Average&lt;&gt;()
		///</summary>
		protected virtual IEnumerable<ITransition> ParseAverage7(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method Double qy.Average<>()");
		}

		///<summary>
		///Nullable&lt;Double&gt; qy.Average&lt;&gt;()
		///</summary>
		protected virtual IEnumerable<ITransition> ParseAverage8(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method Nullable<Double> qy.Average<>()");
		}

		///<summary>
		///Decimal qy.Average&lt;&gt;()
		///</summary>
		protected virtual IEnumerable<ITransition> ParseAverage9(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method Decimal qy.Average<>()");
		}

		///<summary>
		///Nullable&lt;Decimal&gt; qy.Average&lt;&gt;()
		///</summary>
		protected virtual IEnumerable<ITransition> ParseAverage10(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method Nullable<Decimal> qy.Average<>()");
		}

		///<summary>
		///Double qy.Average&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Int32&gt;&gt; selector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseAverage11(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method Double qy.Average<TSource>(Expression<Func<TSource, Int32>> selector)");
		}

		///<summary>
		///Nullable&lt;Double&gt; qy.Average&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Nullable&lt;Int32&gt;&gt;&gt; selector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseAverage12(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method Nullable<Double> qy.Average<TSource>(Expression<Func<TSource, Nullable<Int32>>> selector)");
		}

		///<summary>
		///Single qy.Average&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Single&gt;&gt; selector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseAverage13(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method Single qy.Average<TSource>(Expression<Func<TSource, Single>> selector)");
		}

		///<summary>
		///Nullable&lt;Single&gt; qy.Average&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Nullable&lt;Single&gt;&gt;&gt; selector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseAverage14(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method Nullable<Single> qy.Average<TSource>(Expression<Func<TSource, Nullable<Single>>> selector)");
		}

		///<summary>
		///Double qy.Average&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Int64&gt;&gt; selector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseAverage15(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method Double qy.Average<TSource>(Expression<Func<TSource, Int64>> selector)");
		}

		///<summary>
		///Nullable&lt;Double&gt; qy.Average&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Nullable&lt;Int64&gt;&gt;&gt; selector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseAverage16(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method Nullable<Double> qy.Average<TSource>(Expression<Func<TSource, Nullable<Int64>>> selector)");
		}

		///<summary>
		///Double qy.Average&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Double&gt;&gt; selector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseAverage17(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method Double qy.Average<TSource>(Expression<Func<TSource, Double>> selector)");
		}

		///<summary>
		///Nullable&lt;Double&gt; qy.Average&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Nullable&lt;Double&gt;&gt;&gt; selector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseAverage18(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method Nullable<Double> qy.Average<TSource>(Expression<Func<TSource, Nullable<Double>>> selector)");
		}

		///<summary>
		///Decimal qy.Average&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Decimal&gt;&gt; selector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseAverage19(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method Decimal qy.Average<TSource>(Expression<Func<TSource, Decimal>> selector)");
		}

		///<summary>
		///Nullable&lt;Decimal&gt; qy.Average&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Nullable&lt;Decimal&gt;&gt;&gt; selector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseAverage20(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method Nullable<Decimal> qy.Average<TSource>(Expression<Func<TSource, Nullable<Decimal>>> selector)");
		}

		///<summary>
		///IQueryable&lt;TResult&gt; qy.Cast&lt;TResult&gt;()
		///</summary>
		protected virtual IEnumerable<ITransition> ParseCast(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TResult> qy.Cast<TResult>()");
		}

		///<summary>
		///IQueryable&lt;TSource&gt; qy.Concat&lt;TSource&gt;(IEnumerable&lt;TSource&gt; source2)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseConcat(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TSource> qy.Concat<TSource>(IEnumerable<TSource> source2)");
		}

		///<summary>
		///Boolean qy.Contains&lt;TSource&gt;(TSource item)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseContains(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method Boolean qy.Contains<TSource>(TSource item)");
		}

		///<summary>
		///Boolean qy.Contains&lt;TSource&gt;(TSource item, IEqualityComparer&lt;TSource&gt; comparer)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseContains2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method Boolean qy.Contains<TSource>(TSource item, IEqualityComparer<TSource> comparer)");
		}

		///<summary>
		///Int32 qy.Count&lt;TSource&gt;()
		///</summary>
		protected virtual IEnumerable<ITransition> ParseCount(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method Int32 qy.Count<TSource>()");
		}

		///<summary>
		///Int32 qy.Count&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Boolean&gt;&gt; predicate)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseCount2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method Int32 qy.Count<TSource>(Expression<Func<TSource, Boolean>> predicate)");
		}

		///<summary>
		///IQueryable&lt;TSource&gt; qy.DefaultIfEmpty&lt;TSource&gt;()
		///</summary>
		protected virtual IEnumerable<ITransition> ParseDefaultIfEmpty(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TSource> qy.DefaultIfEmpty<TSource>()");
		}

		///<summary>
		///IQueryable&lt;TSource&gt; qy.DefaultIfEmpty&lt;TSource&gt;(TSource defaultValue)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseDefaultIfEmpty2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TSource> qy.DefaultIfEmpty<TSource>(TSource defaultValue)");
		}

		///<summary>
		///IQueryable&lt;TSource&gt; qy.Distinct&lt;TSource&gt;()
		///</summary>
		protected virtual IEnumerable<ITransition> ParseDistinct(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TSource> qy.Distinct<TSource>()");
		}

		///<summary>
		///IQueryable&lt;TSource&gt; qy.Distinct&lt;TSource&gt;(IEqualityComparer&lt;TSource&gt; comparer)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseDistinct2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TSource> qy.Distinct<TSource>(IEqualityComparer<TSource> comparer)");
		}

		///<summary>
		///TSource qy.ElementAt&lt;TSource&gt;(Int32 index)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseElementAt(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method TSource qy.ElementAt<TSource>(Int32 index)");
		}

		///<summary>
		///TSource qy.ElementAtOrDefault&lt;TSource&gt;(Int32 index)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseElementAtOrDefault(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method TSource qy.ElementAtOrDefault<TSource>(Int32 index)");
		}

		///<summary>
		///IQueryable&lt;TSource&gt; qy.Except&lt;TSource&gt;(IEnumerable&lt;TSource&gt; source2)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseExcept(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TSource> qy.Except<TSource>(IEnumerable<TSource> source2)");
		}

		///<summary>
		///IQueryable&lt;TSource&gt; qy.Except&lt;TSource&gt;(IEnumerable&lt;TSource&gt; source2, IEqualityComparer&lt;TSource&gt; comparer)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseExcept2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TSource> qy.Except<TSource>(IEnumerable<TSource> source2, IEqualityComparer<TSource> comparer)");
		}

		///<summary>
		///TSource qy.First&lt;TSource&gt;()
		///</summary>
		protected virtual IEnumerable<ITransition> ParseFirst(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method TSource qy.First<TSource>()");
		}

		///<summary>
		///TSource qy.First&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Boolean&gt;&gt; predicate)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseFirst2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method TSource qy.First<TSource>(Expression<Func<TSource, Boolean>> predicate)");
		}

		///<summary>
		///TSource qy.FirstOrDefault&lt;TSource&gt;()
		///</summary>
		protected virtual IEnumerable<ITransition> ParseFirstOrDefault(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method TSource qy.FirstOrDefault<TSource>()");
		}

		///<summary>
		///TSource qy.FirstOrDefault&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Boolean&gt;&gt; predicate)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseFirstOrDefault2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method TSource qy.FirstOrDefault<TSource>(Expression<Func<TSource, Boolean>> predicate)");
		}

		///<summary>
		///IQueryable&lt;IGrouping&lt;TKey, TSource&gt;&gt; qy.GroupBy&lt;TSource, TKey&gt;(Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseGroupBy(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<IGrouping<TKey, TSource>> qy.GroupBy<TSource, TKey>(Expression<Func<TSource, TKey>> keySelector)");
		}

		///<summary>
		///IQueryable&lt;IGrouping&lt;TKey, TElement&gt;&gt; qy.GroupBy&lt;TSource, TKey, TElement&gt;(Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector, Expression&lt;Func&lt;TSource, TElement&gt;&gt; elementSelector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseGroupBy2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<IGrouping<TKey, TElement>> qy.GroupBy<TSource, TKey, TElement>(Expression<Func<TSource, TKey>> keySelector, Expression<Func<TSource, TElement>> elementSelector)");
		}

		///<summary>
		///IQueryable&lt;IGrouping&lt;TKey, TSource&gt;&gt; qy.GroupBy&lt;TSource, TKey&gt;(Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector, IEqualityComparer&lt;TKey&gt; comparer)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseGroupBy3(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<IGrouping<TKey, TSource>> qy.GroupBy<TSource, TKey>(Expression<Func<TSource, TKey>> keySelector, IEqualityComparer<TKey> comparer)");
		}

		///<summary>
		///IQueryable&lt;IGrouping&lt;TKey, TElement&gt;&gt; qy.GroupBy&lt;TSource, TKey, TElement&gt;(Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector, Expression&lt;Func&lt;TSource, TElement&gt;&gt; elementSelector, IEqualityComparer&lt;TKey&gt; comparer)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseGroupBy4(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<IGrouping<TKey, TElement>> qy.GroupBy<TSource, TKey, TElement>(Expression<Func<TSource, TKey>> keySelector, Expression<Func<TSource, TElement>> elementSelector, IEqualityComparer<TKey> comparer)");
		}

		///<summary>
		///IQueryable&lt;TResult&gt; qy.GroupBy&lt;TSource, TKey, TElement, TResult&gt;(Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector, Expression&lt;Func&lt;TSource, TElement&gt;&gt; elementSelector, Expression&lt;Func&lt;TKey, IEnumerable&lt;TElement&gt;, TResult&gt;&gt; resultSelector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseGroupBy5(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TResult> qy.GroupBy<TSource, TKey, TElement, TResult>(Expression<Func<TSource, TKey>> keySelector, Expression<Func<TSource, TElement>> elementSelector, Expression<Func<TKey, IEnumerable<TElement>, TResult>> resultSelector)");
		}

		///<summary>
		///IQueryable&lt;TResult&gt; qy.GroupBy&lt;TSource, TKey, TResult&gt;(Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector, Expression&lt;Func&lt;TKey, IEnumerable&lt;TSource&gt;, TResult&gt;&gt; resultSelector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseGroupBy6(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TResult> qy.GroupBy<TSource, TKey, TResult>(Expression<Func<TSource, TKey>> keySelector, Expression<Func<TKey, IEnumerable<TSource>, TResult>> resultSelector)");
		}

		///<summary>
		///IQueryable&lt;TResult&gt; qy.GroupBy&lt;TSource, TKey, TResult&gt;(Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector, Expression&lt;Func&lt;TKey, IEnumerable&lt;TSource&gt;, TResult&gt;&gt; resultSelector, IEqualityComparer&lt;TKey&gt; comparer)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseGroupBy7(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TResult> qy.GroupBy<TSource, TKey, TResult>(Expression<Func<TSource, TKey>> keySelector, Expression<Func<TKey, IEnumerable<TSource>, TResult>> resultSelector, IEqualityComparer<TKey> comparer)");
		}

		///<summary>
		///IQueryable&lt;TResult&gt; qy.GroupBy&lt;TSource, TKey, TElement, TResult&gt;(Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector, Expression&lt;Func&lt;TSource, TElement&gt;&gt; elementSelector, Expression&lt;Func&lt;TKey, IEnumerable&lt;TElement&gt;, TResult&gt;&gt; resultSelector, IEqualityComparer&lt;TKey&gt; comparer)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseGroupBy8(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TResult> qy.GroupBy<TSource, TKey, TElement, TResult>(Expression<Func<TSource, TKey>> keySelector, Expression<Func<TSource, TElement>> elementSelector, Expression<Func<TKey, IEnumerable<TElement>, TResult>> resultSelector, IEqualityComparer<TKey> comparer)");
		}

		///<summary>
		///IQueryable&lt;TResult&gt; qy.GroupJoin&lt;TOuter, TInner, TKey, TResult&gt;(IEnumerable&lt;TInner&gt; inner, Expression&lt;Func&lt;TOuter, TKey&gt;&gt; outerKeySelector, Expression&lt;Func&lt;TInner, TKey&gt;&gt; innerKeySelector, Expression&lt;Func&lt;TOuter, IEnumerable&lt;TInner&gt;, TResult&gt;&gt; resultSelector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseGroupJoin(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TResult> qy.GroupJoin<TOuter, TInner, TKey, TResult>(IEnumerable<TInner> inner, Expression<Func<TOuter, TKey>> outerKeySelector, Expression<Func<TInner, TKey>> innerKeySelector, Expression<Func<TOuter, IEnumerable<TInner>, TResult>> resultSelector)");
		}

		///<summary>
		///IQueryable&lt;TResult&gt; qy.GroupJoin&lt;TOuter, TInner, TKey, TResult&gt;(IEnumerable&lt;TInner&gt; inner, Expression&lt;Func&lt;TOuter, TKey&gt;&gt; outerKeySelector, Expression&lt;Func&lt;TInner, TKey&gt;&gt; innerKeySelector, Expression&lt;Func&lt;TOuter, IEnumerable&lt;TInner&gt;, TResult&gt;&gt; resultSelector, IEqualityComparer&lt;TKey&gt; comparer)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseGroupJoin2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TResult> qy.GroupJoin<TOuter, TInner, TKey, TResult>(IEnumerable<TInner> inner, Expression<Func<TOuter, TKey>> outerKeySelector, Expression<Func<TInner, TKey>> innerKeySelector, Expression<Func<TOuter, IEnumerable<TInner>, TResult>> resultSelector, IEqualityComparer<TKey> comparer)");
		}

		///<summary>
		///IQueryable&lt;TSource&gt; qy.Intersect&lt;TSource&gt;(IEnumerable&lt;TSource&gt; source2)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseIntersect(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TSource> qy.Intersect<TSource>(IEnumerable<TSource> source2)");
		}

		///<summary>
		///IQueryable&lt;TSource&gt; qy.Intersect&lt;TSource&gt;(IEnumerable&lt;TSource&gt; source2, IEqualityComparer&lt;TSource&gt; comparer)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseIntersect2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TSource> qy.Intersect<TSource>(IEnumerable<TSource> source2, IEqualityComparer<TSource> comparer)");
		}

		///<summary>
		///IQueryable&lt;TResult&gt; qy.Join&lt;TOuter, TInner, TKey, TResult&gt;(IEnumerable&lt;TInner&gt; inner, Expression&lt;Func&lt;TOuter, TKey&gt;&gt; outerKeySelector, Expression&lt;Func&lt;TInner, TKey&gt;&gt; innerKeySelector, Expression&lt;Func&lt;TOuter, TInner, TResult&gt;&gt; resultSelector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseJoin(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TResult> qy.Join<TOuter, TInner, TKey, TResult>(IEnumerable<TInner> inner, Expression<Func<TOuter, TKey>> outerKeySelector, Expression<Func<TInner, TKey>> innerKeySelector, Expression<Func<TOuter, TInner, TResult>> resultSelector)");
		}

		///<summary>
		///IQueryable&lt;TResult&gt; qy.Join&lt;TOuter, TInner, TKey, TResult&gt;(IEnumerable&lt;TInner&gt; inner, Expression&lt;Func&lt;TOuter, TKey&gt;&gt; outerKeySelector, Expression&lt;Func&lt;TInner, TKey&gt;&gt; innerKeySelector, Expression&lt;Func&lt;TOuter, TInner, TResult&gt;&gt; resultSelector, IEqualityComparer&lt;TKey&gt; comparer)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseJoin2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TResult> qy.Join<TOuter, TInner, TKey, TResult>(IEnumerable<TInner> inner, Expression<Func<TOuter, TKey>> outerKeySelector, Expression<Func<TInner, TKey>> innerKeySelector, Expression<Func<TOuter, TInner, TResult>> resultSelector, IEqualityComparer<TKey> comparer)");
		}

		///<summary>
		///TSource qy.Last&lt;TSource&gt;()
		///</summary>
		protected virtual IEnumerable<ITransition> ParseLast(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method TSource qy.Last<TSource>()");
		}

		///<summary>
		///TSource qy.Last&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Boolean&gt;&gt; predicate)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseLast2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method TSource qy.Last<TSource>(Expression<Func<TSource, Boolean>> predicate)");
		}

		///<summary>
		///TSource qy.LastOrDefault&lt;TSource&gt;()
		///</summary>
		protected virtual IEnumerable<ITransition> ParseLastOrDefault(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method TSource qy.LastOrDefault<TSource>()");
		}

		///<summary>
		///TSource qy.LastOrDefault&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Boolean&gt;&gt; predicate)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseLastOrDefault2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method TSource qy.LastOrDefault<TSource>(Expression<Func<TSource, Boolean>> predicate)");
		}

		///<summary>
		///Int64 qy.LongCount&lt;TSource&gt;()
		///</summary>
		protected virtual IEnumerable<ITransition> ParseLongCount(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method Int64 qy.LongCount<TSource>()");
		}

		///<summary>
		///Int64 qy.LongCount&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Boolean&gt;&gt; predicate)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseLongCount2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method Int64 qy.LongCount<TSource>(Expression<Func<TSource, Boolean>> predicate)");
		}

		///<summary>
		///TSource qy.Max&lt;TSource&gt;()
		///</summary>
		protected virtual IEnumerable<ITransition> ParseMax(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method TSource qy.Max<TSource>()");
		}

		///<summary>
		///TResult qy.Max&lt;TSource, TResult&gt;(Expression&lt;Func&lt;TSource, TResult&gt;&gt; selector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseMax2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method TResult qy.Max<TSource, TResult>(Expression<Func<TSource, TResult>> selector)");
		}

		///<summary>
		///TSource qy.Min&lt;TSource&gt;()
		///</summary>
		protected virtual IEnumerable<ITransition> ParseMin(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method TSource qy.Min<TSource>()");
		}

		///<summary>
		///TResult qy.Min&lt;TSource, TResult&gt;(Expression&lt;Func&lt;TSource, TResult&gt;&gt; selector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseMin2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method TResult qy.Min<TSource, TResult>(Expression<Func<TSource, TResult>> selector)");
		}

		///<summary>
		///IQueryable&lt;TResult&gt; qy.OfType&lt;TResult&gt;()
		///</summary>
		protected virtual IEnumerable<ITransition> ParseOfType(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TResult> qy.OfType<TResult>()");
		}

		///<summary>
		///IOrderedQueryable&lt;TSource&gt; qy.OrderBy&lt;TSource, TKey&gt;(Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseOrderBy(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IOrderedQueryable<TSource> qy.OrderBy<TSource, TKey>(Expression<Func<TSource, TKey>> keySelector)");
		}

		///<summary>
		///IOrderedQueryable&lt;TSource&gt; qy.OrderBy&lt;TSource, TKey&gt;(Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector, IComparer&lt;TKey&gt; comparer)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseOrderBy2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IOrderedQueryable<TSource> qy.OrderBy<TSource, TKey>(Expression<Func<TSource, TKey>> keySelector, IComparer<TKey> comparer)");
		}

		///<summary>
		///IOrderedQueryable&lt;TSource&gt; qy.OrderByDescending&lt;TSource, TKey&gt;(Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseOrderByDescending(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IOrderedQueryable<TSource> qy.OrderByDescending<TSource, TKey>(Expression<Func<TSource, TKey>> keySelector)");
		}

		///<summary>
		///IOrderedQueryable&lt;TSource&gt; qy.OrderByDescending&lt;TSource, TKey&gt;(Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector, IComparer&lt;TKey&gt; comparer)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseOrderByDescending2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IOrderedQueryable<TSource> qy.OrderByDescending<TSource, TKey>(Expression<Func<TSource, TKey>> keySelector, IComparer<TKey> comparer)");
		}

		///<summary>
		///IQueryable&lt;TSource&gt; qy.Reverse&lt;TSource&gt;()
		///</summary>
		protected virtual IEnumerable<ITransition> ParseReverse(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TSource> qy.Reverse<TSource>()");
		}

		///<summary>
		///IQueryable&lt;TResult&gt; qy.Select&lt;TSource, TResult&gt;(Expression&lt;Func&lt;TSource, TResult&gt;&gt; selector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSelect(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TResult> qy.Select<TSource, TResult>(Expression<Func<TSource, TResult>> selector)");
		}

		///<summary>
		///IQueryable&lt;TResult&gt; qy.Select&lt;TSource, TResult&gt;(Expression&lt;Func&lt;TSource, Int32, TResult&gt;&gt; selector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSelect2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TResult> qy.Select<TSource, TResult>(Expression<Func<TSource, Int32, TResult>> selector)");
		}

		///<summary>
		///IQueryable&lt;TResult&gt; qy.SelectMany&lt;TSource, TResult&gt;(Expression&lt;Func&lt;TSource, IEnumerable&lt;TResult&gt;&gt;&gt; selector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSelectMany(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TResult> qy.SelectMany<TSource, TResult>(Expression<Func<TSource, IEnumerable<TResult>>> selector)");
		}

		///<summary>
		///IQueryable&lt;TResult&gt; qy.SelectMany&lt;TSource, TResult&gt;(Expression&lt;Func&lt;TSource, Int32, IEnumerable&lt;TResult&gt;&gt;&gt; selector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSelectMany2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TResult> qy.SelectMany<TSource, TResult>(Expression<Func<TSource, Int32, IEnumerable<TResult>>> selector)");
		}

		///<summary>
		///IQueryable&lt;TResult&gt; qy.SelectMany&lt;TSource, TCollection, TResult&gt;(Expression&lt;Func&lt;TSource, Int32, IEnumerable&lt;TCollection&gt;&gt;&gt; collectionSelector, Expression&lt;Func&lt;TSource, TCollection, TResult&gt;&gt; resultSelector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSelectMany3(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TResult> qy.SelectMany<TSource, TCollection, TResult>(Expression<Func<TSource, Int32, IEnumerable<TCollection>>> collectionSelector, Expression<Func<TSource, TCollection, TResult>> resultSelector)");
		}

		///<summary>
		///IQueryable&lt;TResult&gt; qy.SelectMany&lt;TSource, TCollection, TResult&gt;(Expression&lt;Func&lt;TSource, IEnumerable&lt;TCollection&gt;&gt;&gt; collectionSelector, Expression&lt;Func&lt;TSource, TCollection, TResult&gt;&gt; resultSelector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSelectMany4(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TResult> qy.SelectMany<TSource, TCollection, TResult>(Expression<Func<TSource, IEnumerable<TCollection>>> collectionSelector, Expression<Func<TSource, TCollection, TResult>> resultSelector)");
		}

		///<summary>
		///Boolean qy.SequenceEqual&lt;TSource&gt;(IEnumerable&lt;TSource&gt; source2)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSequenceEqual(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method Boolean qy.SequenceEqual<TSource>(IEnumerable<TSource> source2)");
		}

		///<summary>
		///Boolean qy.SequenceEqual&lt;TSource&gt;(IEnumerable&lt;TSource&gt; source2, IEqualityComparer&lt;TSource&gt; comparer)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSequenceEqual2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method Boolean qy.SequenceEqual<TSource>(IEnumerable<TSource> source2, IEqualityComparer<TSource> comparer)");
		}

		///<summary>
		///TSource qy.Single&lt;TSource&gt;()
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSingle(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method TSource qy.Single<TSource>()");
		}

		///<summary>
		///TSource qy.Single&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Boolean&gt;&gt; predicate)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSingle2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method TSource qy.Single<TSource>(Expression<Func<TSource, Boolean>> predicate)");
		}

		///<summary>
		///TSource qy.SingleOrDefault&lt;TSource&gt;()
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSingleOrDefault(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method TSource qy.SingleOrDefault<TSource>()");
		}

		///<summary>
		///TSource qy.SingleOrDefault&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Boolean&gt;&gt; predicate)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSingleOrDefault2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method TSource qy.SingleOrDefault<TSource>(Expression<Func<TSource, Boolean>> predicate)");
		}

		///<summary>
		///IQueryable&lt;TSource&gt; qy.Skip&lt;TSource&gt;(Int32 count)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSkip(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TSource> qy.Skip<TSource>(Int32 count)");
		}

		///<summary>
		///IQueryable&lt;TSource&gt; qy.SkipWhile&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Boolean&gt;&gt; predicate)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSkipWhile(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TSource> qy.SkipWhile<TSource>(Expression<Func<TSource, Boolean>> predicate)");
		}

		///<summary>
		///IQueryable&lt;TSource&gt; qy.SkipWhile&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Int32, Boolean&gt;&gt; predicate)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSkipWhile2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TSource> qy.SkipWhile<TSource>(Expression<Func<TSource, Int32, Boolean>> predicate)");
		}

		///<summary>
		///Nullable&lt;Decimal&gt; qy.Sum&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Nullable&lt;Decimal&gt;&gt;&gt; selector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSum(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method Nullable<Decimal> qy.Sum<TSource>(Expression<Func<TSource, Nullable<Decimal>>> selector)");
		}

		///<summary>
		///Int32 qy.Sum&lt;&gt;()
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSum2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method Int32 qy.Sum<>()");
		}

		///<summary>
		///Nullable&lt;Int32&gt; qy.Sum&lt;&gt;()
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSum3(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method Nullable<Int32> qy.Sum<>()");
		}

		///<summary>
		///Int64 qy.Sum&lt;&gt;()
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSum4(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method Int64 qy.Sum<>()");
		}

		///<summary>
		///Nullable&lt;Int64&gt; qy.Sum&lt;&gt;()
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSum5(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method Nullable<Int64> qy.Sum<>()");
		}

		///<summary>
		///Single qy.Sum&lt;&gt;()
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSum6(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method Single qy.Sum<>()");
		}

		///<summary>
		///Nullable&lt;Single&gt; qy.Sum&lt;&gt;()
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSum7(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method Nullable<Single> qy.Sum<>()");
		}

		///<summary>
		///Double qy.Sum&lt;&gt;()
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSum8(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method Double qy.Sum<>()");
		}

		///<summary>
		///Nullable&lt;Double&gt; qy.Sum&lt;&gt;()
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSum9(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method Nullable<Double> qy.Sum<>()");
		}

		///<summary>
		///Decimal qy.Sum&lt;&gt;()
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSum10(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method Decimal qy.Sum<>()");
		}

		///<summary>
		///Nullable&lt;Decimal&gt; qy.Sum&lt;&gt;()
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSum11(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method Nullable<Decimal> qy.Sum<>()");
		}

		///<summary>
		///Int32 qy.Sum&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Int32&gt;&gt; selector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSum12(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method Int32 qy.Sum<TSource>(Expression<Func<TSource, Int32>> selector)");
		}

		///<summary>
		///Nullable&lt;Int32&gt; qy.Sum&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Nullable&lt;Int32&gt;&gt;&gt; selector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSum13(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method Nullable<Int32> qy.Sum<TSource>(Expression<Func<TSource, Nullable<Int32>>> selector)");
		}

		///<summary>
		///Int64 qy.Sum&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Int64&gt;&gt; selector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSum14(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method Int64 qy.Sum<TSource>(Expression<Func<TSource, Int64>> selector)");
		}

		///<summary>
		///Nullable&lt;Int64&gt; qy.Sum&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Nullable&lt;Int64&gt;&gt;&gt; selector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSum15(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method Nullable<Int64> qy.Sum<TSource>(Expression<Func<TSource, Nullable<Int64>>> selector)");
		}

		///<summary>
		///Single qy.Sum&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Single&gt;&gt; selector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSum16(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method Single qy.Sum<TSource>(Expression<Func<TSource, Single>> selector)");
		}

		///<summary>
		///Nullable&lt;Single&gt; qy.Sum&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Nullable&lt;Single&gt;&gt;&gt; selector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSum17(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method Nullable<Single> qy.Sum<TSource>(Expression<Func<TSource, Nullable<Single>>> selector)");
		}

		///<summary>
		///Double qy.Sum&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Double&gt;&gt; selector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSum18(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method Double qy.Sum<TSource>(Expression<Func<TSource, Double>> selector)");
		}

		///<summary>
		///Nullable&lt;Double&gt; qy.Sum&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Nullable&lt;Double&gt;&gt;&gt; selector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSum19(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method Nullable<Double> qy.Sum<TSource>(Expression<Func<TSource, Nullable<Double>>> selector)");
		}

		///<summary>
		///Decimal qy.Sum&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Decimal&gt;&gt; selector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseSum20(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method Decimal qy.Sum<TSource>(Expression<Func<TSource, Decimal>> selector)");
		}

		///<summary>
		///IQueryable&lt;TSource&gt; qy.Take&lt;TSource&gt;(Int32 count)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseTake(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TSource> qy.Take<TSource>(Int32 count)");
		}

		///<summary>
		///IQueryable&lt;TSource&gt; qy.TakeWhile&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Boolean&gt;&gt; predicate)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseTakeWhile(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TSource> qy.TakeWhile<TSource>(Expression<Func<TSource, Boolean>> predicate)");
		}

		///<summary>
		///IQueryable&lt;TSource&gt; qy.TakeWhile&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Int32, Boolean&gt;&gt; predicate)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseTakeWhile2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TSource> qy.TakeWhile<TSource>(Expression<Func<TSource, Int32, Boolean>> predicate)");
		}

		///<summary>
		///IOrderedQueryable&lt;TSource&gt; qy.ThenBy&lt;TSource, TKey&gt;(Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseThenBy(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IOrderedQueryable<TSource> qy.ThenBy<TSource, TKey>(Expression<Func<TSource, TKey>> keySelector)");
		}

		///<summary>
		///IOrderedQueryable&lt;TSource&gt; qy.ThenBy&lt;TSource, TKey&gt;(Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector, IComparer&lt;TKey&gt; comparer)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseThenBy2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IOrderedQueryable<TSource> qy.ThenBy<TSource, TKey>(Expression<Func<TSource, TKey>> keySelector, IComparer<TKey> comparer)");
		}

		///<summary>
		///IOrderedQueryable&lt;TSource&gt; qy.ThenByDescending&lt;TSource, TKey&gt;(Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseThenByDescending(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IOrderedQueryable<TSource> qy.ThenByDescending<TSource, TKey>(Expression<Func<TSource, TKey>> keySelector)");
		}

		///<summary>
		///IOrderedQueryable&lt;TSource&gt; qy.ThenByDescending&lt;TSource, TKey&gt;(Expression&lt;Func&lt;TSource, TKey&gt;&gt; keySelector, IComparer&lt;TKey&gt; comparer)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseThenByDescending2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IOrderedQueryable<TSource> qy.ThenByDescending<TSource, TKey>(Expression<Func<TSource, TKey>> keySelector, IComparer<TKey> comparer)");
		}

		///<summary>
		///IQueryable&lt;TSource&gt; qy.Union&lt;TSource&gt;(IEnumerable&lt;TSource&gt; source2)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseUnion(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TSource> qy.Union<TSource>(IEnumerable<TSource> source2)");
		}

		///<summary>
		///IQueryable&lt;TSource&gt; qy.Union&lt;TSource&gt;(IEnumerable&lt;TSource&gt; source2, IEqualityComparer&lt;TSource&gt; comparer)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseUnion2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TSource> qy.Union<TSource>(IEnumerable<TSource> source2, IEqualityComparer<TSource> comparer)");
		}

		///<summary>
		///IQueryable&lt;TSource&gt; qy.Where&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Boolean&gt;&gt; predicate)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseWhere(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TSource> qy.Where<TSource>(Expression<Func<TSource, Boolean>> predicate)");
		}

		///<summary>
		///IQueryable&lt;TSource&gt; qy.Where&lt;TSource&gt;(Expression&lt;Func&lt;TSource, Int32, Boolean&gt;&gt; predicate)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseWhere2(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TSource> qy.Where<TSource>(Expression<Func<TSource, Int32, Boolean>> predicate)");
		}

		///<summary>
		///IQueryable&lt;TResult&gt; qy.Zip&lt;TFirst, TSecond, TResult&gt;(IEnumerable&lt;TSecond&gt; source2, Expression&lt;Func&lt;TFirst, TSecond, TResult&gt;&gt; resultSelector)
		///</summary>
		protected virtual IEnumerable<ITransition> ParseZip(MethodParseSubject s) {
			throw new NotImplementedException("No method subparser supplied for Queryable method IQueryable<TResult> qy.Zip<TFirst, TSecond, TResult>(IEnumerable<TSecond> source2, Expression<Func<TFirst, TSecond, TResult>> resultSelector)");
		}

		
	} 

}

