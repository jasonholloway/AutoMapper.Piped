using Materialize.SequenceMethods;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify2.Transitions 
{
	  partial class AggregateTransition : QyTransitionBase 
	  { 
			Expression _func;

			public override SeqMethod SeqMethod { get; } = SeqMethods.Aggregate;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _func;
					yield break;
				}
			}
			
			public static AggregateTransition Create(MethodCallExpression ex) {
				return new AggregateTransition() {
					_func = ex.Arguments[1],
				};
			}
	  }

	  partial class Aggregate2Transition : QyTransitionBase 
	  { 
			Expression _seed;
			Expression _func;

			public override SeqMethod SeqMethod { get; } = SeqMethods.Aggregate2;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _seed;
					yield return _func;
					yield break;
				}
			}
			
			public static Aggregate2Transition Create(MethodCallExpression ex) {
				return new Aggregate2Transition() {
					_seed = ex.Arguments[1],
					_func = ex.Arguments[2],
				};
			}
	  }

	  partial class Aggregate3Transition : QyTransitionBase 
	  { 
			Expression _seed;
			Expression _func;
			Expression _selector;

			public override SeqMethod SeqMethod { get; } = SeqMethods.Aggregate3;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _seed;
					yield return _func;
					yield return _selector;
					yield break;
				}
			}
			
			public static Aggregate3Transition Create(MethodCallExpression ex) {
				return new Aggregate3Transition() {
					_seed = ex.Arguments[1],
					_func = ex.Arguments[2],
					_selector = ex.Arguments[3],
				};
			}
	  }

	  partial class AllTransition : QyTransitionBase 
	  { 
			Expression _predicate;

			public override SeqMethod SeqMethod { get; } = SeqMethods.All;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _predicate;
					yield break;
				}
			}
			
			public static AllTransition Create(MethodCallExpression ex) {
				return new AllTransition() {
					_predicate = ex.Arguments[1],
				};
			}
	  }

	  partial class AnyTransition : QyTransitionBase 
	  { 

			public override SeqMethod SeqMethod { get; } = SeqMethods.Any;

			public override IEnumerable<Expression> Args {
				get { 
					yield break;
				}
			}
			
			public static AnyTransition Create(MethodCallExpression ex) {
				return new AnyTransition() {
				};
			}
	  }

	  partial class Any2Transition : QyTransitionBase 
	  { 
			Expression _predicate;

			public override SeqMethod SeqMethod { get; } = SeqMethods.Any2;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _predicate;
					yield break;
				}
			}
			
			public static Any2Transition Create(MethodCallExpression ex) {
				return new Any2Transition() {
					_predicate = ex.Arguments[1],
				};
			}
	  }

	  partial class AverageTransition : QyTransitionBase 
	  { 

			public override SeqMethod SeqMethod { get; } = SeqMethods.Average;

			public override IEnumerable<Expression> Args {
				get { 
					yield break;
				}
			}
			
			public static AverageTransition Create(MethodCallExpression ex) {
				return new AverageTransition() {
				};
			}
	  }

	  partial class Average10Transition : QyTransitionBase 
	  { 

			public override SeqMethod SeqMethod { get; } = SeqMethods.Average10;

			public override IEnumerable<Expression> Args {
				get { 
					yield break;
				}
			}
			
			public static Average10Transition Create(MethodCallExpression ex) {
				return new Average10Transition() {
				};
			}
	  }

	  partial class Average11Transition : QyTransitionBase 
	  { 
			Expression _selector;

			public override SeqMethod SeqMethod { get; } = SeqMethods.Average11;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _selector;
					yield break;
				}
			}
			
			public static Average11Transition Create(MethodCallExpression ex) {
				return new Average11Transition() {
					_selector = ex.Arguments[1],
				};
			}
	  }

	  partial class Average12Transition : QyTransitionBase 
	  { 
			Expression _selector;

			public override SeqMethod SeqMethod { get; } = SeqMethods.Average12;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _selector;
					yield break;
				}
			}
			
			public static Average12Transition Create(MethodCallExpression ex) {
				return new Average12Transition() {
					_selector = ex.Arguments[1],
				};
			}
	  }

	  partial class Average13Transition : QyTransitionBase 
	  { 
			Expression _selector;

			public override SeqMethod SeqMethod { get; } = SeqMethods.Average13;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _selector;
					yield break;
				}
			}
			
			public static Average13Transition Create(MethodCallExpression ex) {
				return new Average13Transition() {
					_selector = ex.Arguments[1],
				};
			}
	  }

	  partial class Average14Transition : QyTransitionBase 
	  { 
			Expression _selector;

			public override SeqMethod SeqMethod { get; } = SeqMethods.Average14;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _selector;
					yield break;
				}
			}
			
			public static Average14Transition Create(MethodCallExpression ex) {
				return new Average14Transition() {
					_selector = ex.Arguments[1],
				};
			}
	  }

	  partial class Average15Transition : QyTransitionBase 
	  { 
			Expression _selector;

			public override SeqMethod SeqMethod { get; } = SeqMethods.Average15;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _selector;
					yield break;
				}
			}
			
			public static Average15Transition Create(MethodCallExpression ex) {
				return new Average15Transition() {
					_selector = ex.Arguments[1],
				};
			}
	  }

	  partial class Average16Transition : QyTransitionBase 
	  { 
			Expression _selector;

			public override SeqMethod SeqMethod { get; } = SeqMethods.Average16;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _selector;
					yield break;
				}
			}
			
			public static Average16Transition Create(MethodCallExpression ex) {
				return new Average16Transition() {
					_selector = ex.Arguments[1],
				};
			}
	  }

	  partial class Average17Transition : QyTransitionBase 
	  { 
			Expression _selector;

			public override SeqMethod SeqMethod { get; } = SeqMethods.Average17;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _selector;
					yield break;
				}
			}
			
			public static Average17Transition Create(MethodCallExpression ex) {
				return new Average17Transition() {
					_selector = ex.Arguments[1],
				};
			}
	  }

	  partial class Average18Transition : QyTransitionBase 
	  { 
			Expression _selector;

			public override SeqMethod SeqMethod { get; } = SeqMethods.Average18;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _selector;
					yield break;
				}
			}
			
			public static Average18Transition Create(MethodCallExpression ex) {
				return new Average18Transition() {
					_selector = ex.Arguments[1],
				};
			}
	  }

	  partial class Average19Transition : QyTransitionBase 
	  { 
			Expression _selector;

			public override SeqMethod SeqMethod { get; } = SeqMethods.Average19;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _selector;
					yield break;
				}
			}
			
			public static Average19Transition Create(MethodCallExpression ex) {
				return new Average19Transition() {
					_selector = ex.Arguments[1],
				};
			}
	  }

	  partial class Average2Transition : QyTransitionBase 
	  { 

			public override SeqMethod SeqMethod { get; } = SeqMethods.Average2;

			public override IEnumerable<Expression> Args {
				get { 
					yield break;
				}
			}
			
			public static Average2Transition Create(MethodCallExpression ex) {
				return new Average2Transition() {
				};
			}
	  }

	  partial class Average20Transition : QyTransitionBase 
	  { 
			Expression _selector;

			public override SeqMethod SeqMethod { get; } = SeqMethods.Average20;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _selector;
					yield break;
				}
			}
			
			public static Average20Transition Create(MethodCallExpression ex) {
				return new Average20Transition() {
					_selector = ex.Arguments[1],
				};
			}
	  }

	  partial class Average3Transition : QyTransitionBase 
	  { 

			public override SeqMethod SeqMethod { get; } = SeqMethods.Average3;

			public override IEnumerable<Expression> Args {
				get { 
					yield break;
				}
			}
			
			public static Average3Transition Create(MethodCallExpression ex) {
				return new Average3Transition() {
				};
			}
	  }

	  partial class Average4Transition : QyTransitionBase 
	  { 

			public override SeqMethod SeqMethod { get; } = SeqMethods.Average4;

			public override IEnumerable<Expression> Args {
				get { 
					yield break;
				}
			}
			
			public static Average4Transition Create(MethodCallExpression ex) {
				return new Average4Transition() {
				};
			}
	  }

	  partial class Average5Transition : QyTransitionBase 
	  { 

			public override SeqMethod SeqMethod { get; } = SeqMethods.Average5;

			public override IEnumerable<Expression> Args {
				get { 
					yield break;
				}
			}
			
			public static Average5Transition Create(MethodCallExpression ex) {
				return new Average5Transition() {
				};
			}
	  }

	  partial class Average6Transition : QyTransitionBase 
	  { 

			public override SeqMethod SeqMethod { get; } = SeqMethods.Average6;

			public override IEnumerable<Expression> Args {
				get { 
					yield break;
				}
			}
			
			public static Average6Transition Create(MethodCallExpression ex) {
				return new Average6Transition() {
				};
			}
	  }

	  partial class Average7Transition : QyTransitionBase 
	  { 

			public override SeqMethod SeqMethod { get; } = SeqMethods.Average7;

			public override IEnumerable<Expression> Args {
				get { 
					yield break;
				}
			}
			
			public static Average7Transition Create(MethodCallExpression ex) {
				return new Average7Transition() {
				};
			}
	  }

	  partial class Average8Transition : QyTransitionBase 
	  { 

			public override SeqMethod SeqMethod { get; } = SeqMethods.Average8;

			public override IEnumerable<Expression> Args {
				get { 
					yield break;
				}
			}
			
			public static Average8Transition Create(MethodCallExpression ex) {
				return new Average8Transition() {
				};
			}
	  }

	  partial class Average9Transition : QyTransitionBase 
	  { 

			public override SeqMethod SeqMethod { get; } = SeqMethods.Average9;

			public override IEnumerable<Expression> Args {
				get { 
					yield break;
				}
			}
			
			public static Average9Transition Create(MethodCallExpression ex) {
				return new Average9Transition() {
				};
			}
	  }

	  partial class CastTransition : QyTransitionBase 
	  { 

			public override SeqMethod SeqMethod { get; } = SeqMethods.Cast;

			public override IEnumerable<Expression> Args {
				get { 
					yield break;
				}
			}
			
			public static CastTransition Create(MethodCallExpression ex) {
				return new CastTransition() {
				};
			}
	  }

	  partial class ConcatTransition : QyTransitionBase 
	  { 
			Expression _source2;

			public override SeqMethod SeqMethod { get; } = SeqMethods.Concat;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _source2;
					yield break;
				}
			}
			
			public static ConcatTransition Create(MethodCallExpression ex) {
				return new ConcatTransition() {
					_source2 = ex.Arguments[1],
				};
			}
	  }

	  partial class ContainsTransition : QyTransitionBase 
	  { 
			Expression _item;

			public override SeqMethod SeqMethod { get; } = SeqMethods.Contains;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _item;
					yield break;
				}
			}
			
			public static ContainsTransition Create(MethodCallExpression ex) {
				return new ContainsTransition() {
					_item = ex.Arguments[1],
				};
			}
	  }

	  partial class Contains2Transition : QyTransitionBase 
	  { 
			Expression _item;
			Expression _comparer;

			public override SeqMethod SeqMethod { get; } = SeqMethods.Contains2;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _item;
					yield return _comparer;
					yield break;
				}
			}
			
			public static Contains2Transition Create(MethodCallExpression ex) {
				return new Contains2Transition() {
					_item = ex.Arguments[1],
					_comparer = ex.Arguments[2],
				};
			}
	  }

	  partial class CountTransition : QyTransitionBase 
	  { 

			public override SeqMethod SeqMethod { get; } = SeqMethods.Count;

			public override IEnumerable<Expression> Args {
				get { 
					yield break;
				}
			}
			
			public static CountTransition Create(MethodCallExpression ex) {
				return new CountTransition() {
				};
			}
	  }

	  partial class Count2Transition : QyTransitionBase 
	  { 
			Expression _predicate;

			public override SeqMethod SeqMethod { get; } = SeqMethods.Count2;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _predicate;
					yield break;
				}
			}
			
			public static Count2Transition Create(MethodCallExpression ex) {
				return new Count2Transition() {
					_predicate = ex.Arguments[1],
				};
			}
	  }

	  partial class DefaultIfEmptyTransition : QyTransitionBase 
	  { 

			public override SeqMethod SeqMethod { get; } = SeqMethods.DefaultIfEmpty;

			public override IEnumerable<Expression> Args {
				get { 
					yield break;
				}
			}
			
			public static DefaultIfEmptyTransition Create(MethodCallExpression ex) {
				return new DefaultIfEmptyTransition() {
				};
			}
	  }

	  partial class DefaultIfEmpty2Transition : QyTransitionBase 
	  { 
			Expression _defaultValue;

			public override SeqMethod SeqMethod { get; } = SeqMethods.DefaultIfEmpty2;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _defaultValue;
					yield break;
				}
			}
			
			public static DefaultIfEmpty2Transition Create(MethodCallExpression ex) {
				return new DefaultIfEmpty2Transition() {
					_defaultValue = ex.Arguments[1],
				};
			}
	  }

	  partial class DistinctTransition : QyTransitionBase 
	  { 

			public override SeqMethod SeqMethod { get; } = SeqMethods.Distinct;

			public override IEnumerable<Expression> Args {
				get { 
					yield break;
				}
			}
			
			public static DistinctTransition Create(MethodCallExpression ex) {
				return new DistinctTransition() {
				};
			}
	  }

	  partial class Distinct2Transition : QyTransitionBase 
	  { 
			Expression _comparer;

			public override SeqMethod SeqMethod { get; } = SeqMethods.Distinct2;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _comparer;
					yield break;
				}
			}
			
			public static Distinct2Transition Create(MethodCallExpression ex) {
				return new Distinct2Transition() {
					_comparer = ex.Arguments[1],
				};
			}
	  }

	  partial class ElementAtTransition : QyTransitionBase 
	  { 
			Expression _index;

			public override SeqMethod SeqMethod { get; } = SeqMethods.ElementAt;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _index;
					yield break;
				}
			}
			
			public static ElementAtTransition Create(MethodCallExpression ex) {
				return new ElementAtTransition() {
					_index = ex.Arguments[1],
				};
			}
	  }

	  partial class ElementAtOrDefaultTransition : QyTransitionBase 
	  { 
			Expression _index;

			public override SeqMethod SeqMethod { get; } = SeqMethods.ElementAtOrDefault;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _index;
					yield break;
				}
			}
			
			public static ElementAtOrDefaultTransition Create(MethodCallExpression ex) {
				return new ElementAtOrDefaultTransition() {
					_index = ex.Arguments[1],
				};
			}
	  }

	  partial class ExceptTransition : QyTransitionBase 
	  { 
			Expression _source2;

			public override SeqMethod SeqMethod { get; } = SeqMethods.Except;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _source2;
					yield break;
				}
			}
			
			public static ExceptTransition Create(MethodCallExpression ex) {
				return new ExceptTransition() {
					_source2 = ex.Arguments[1],
				};
			}
	  }

	  partial class Except2Transition : QyTransitionBase 
	  { 
			Expression _source2;
			Expression _comparer;

			public override SeqMethod SeqMethod { get; } = SeqMethods.Except2;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _source2;
					yield return _comparer;
					yield break;
				}
			}
			
			public static Except2Transition Create(MethodCallExpression ex) {
				return new Except2Transition() {
					_source2 = ex.Arguments[1],
					_comparer = ex.Arguments[2],
				};
			}
	  }

	  partial class FirstTransition : QyTransitionBase 
	  { 

			public override SeqMethod SeqMethod { get; } = SeqMethods.First;

			public override IEnumerable<Expression> Args {
				get { 
					yield break;
				}
			}
			
			public static FirstTransition Create(MethodCallExpression ex) {
				return new FirstTransition() {
				};
			}
	  }

	  partial class First2Transition : QyTransitionBase 
	  { 
			Expression _predicate;

			public override SeqMethod SeqMethod { get; } = SeqMethods.First2;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _predicate;
					yield break;
				}
			}
			
			public static First2Transition Create(MethodCallExpression ex) {
				return new First2Transition() {
					_predicate = ex.Arguments[1],
				};
			}
	  }

	  partial class FirstOrDefaultTransition : QyTransitionBase 
	  { 

			public override SeqMethod SeqMethod { get; } = SeqMethods.FirstOrDefault;

			public override IEnumerable<Expression> Args {
				get { 
					yield break;
				}
			}
			
			public static FirstOrDefaultTransition Create(MethodCallExpression ex) {
				return new FirstOrDefaultTransition() {
				};
			}
	  }

	  partial class FirstOrDefault2Transition : QyTransitionBase 
	  { 
			Expression _predicate;

			public override SeqMethod SeqMethod { get; } = SeqMethods.FirstOrDefault2;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _predicate;
					yield break;
				}
			}
			
			public static FirstOrDefault2Transition Create(MethodCallExpression ex) {
				return new FirstOrDefault2Transition() {
					_predicate = ex.Arguments[1],
				};
			}
	  }

	  partial class GroupByTransition : QyTransitionBase 
	  { 
			Expression _keySelector;

			public override SeqMethod SeqMethod { get; } = SeqMethods.GroupBy;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _keySelector;
					yield break;
				}
			}
			
			public static GroupByTransition Create(MethodCallExpression ex) {
				return new GroupByTransition() {
					_keySelector = ex.Arguments[1],
				};
			}
	  }

	  partial class GroupBy2Transition : QyTransitionBase 
	  { 
			Expression _keySelector;
			Expression _elementSelector;

			public override SeqMethod SeqMethod { get; } = SeqMethods.GroupBy2;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _keySelector;
					yield return _elementSelector;
					yield break;
				}
			}
			
			public static GroupBy2Transition Create(MethodCallExpression ex) {
				return new GroupBy2Transition() {
					_keySelector = ex.Arguments[1],
					_elementSelector = ex.Arguments[2],
				};
			}
	  }

	  partial class GroupBy3Transition : QyTransitionBase 
	  { 
			Expression _keySelector;
			Expression _comparer;

			public override SeqMethod SeqMethod { get; } = SeqMethods.GroupBy3;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _keySelector;
					yield return _comparer;
					yield break;
				}
			}
			
			public static GroupBy3Transition Create(MethodCallExpression ex) {
				return new GroupBy3Transition() {
					_keySelector = ex.Arguments[1],
					_comparer = ex.Arguments[2],
				};
			}
	  }

	  partial class GroupBy4Transition : QyTransitionBase 
	  { 
			Expression _keySelector;
			Expression _elementSelector;
			Expression _comparer;

			public override SeqMethod SeqMethod { get; } = SeqMethods.GroupBy4;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _keySelector;
					yield return _elementSelector;
					yield return _comparer;
					yield break;
				}
			}
			
			public static GroupBy4Transition Create(MethodCallExpression ex) {
				return new GroupBy4Transition() {
					_keySelector = ex.Arguments[1],
					_elementSelector = ex.Arguments[2],
					_comparer = ex.Arguments[3],
				};
			}
	  }

	  partial class GroupBy5Transition : QyTransitionBase 
	  { 
			Expression _keySelector;
			Expression _elementSelector;
			Expression _resultSelector;

			public override SeqMethod SeqMethod { get; } = SeqMethods.GroupBy5;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _keySelector;
					yield return _elementSelector;
					yield return _resultSelector;
					yield break;
				}
			}
			
			public static GroupBy5Transition Create(MethodCallExpression ex) {
				return new GroupBy5Transition() {
					_keySelector = ex.Arguments[1],
					_elementSelector = ex.Arguments[2],
					_resultSelector = ex.Arguments[3],
				};
			}
	  }

	  partial class GroupBy6Transition : QyTransitionBase 
	  { 
			Expression _keySelector;
			Expression _resultSelector;

			public override SeqMethod SeqMethod { get; } = SeqMethods.GroupBy6;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _keySelector;
					yield return _resultSelector;
					yield break;
				}
			}
			
			public static GroupBy6Transition Create(MethodCallExpression ex) {
				return new GroupBy6Transition() {
					_keySelector = ex.Arguments[1],
					_resultSelector = ex.Arguments[2],
				};
			}
	  }

	  partial class GroupBy7Transition : QyTransitionBase 
	  { 
			Expression _keySelector;
			Expression _resultSelector;
			Expression _comparer;

			public override SeqMethod SeqMethod { get; } = SeqMethods.GroupBy7;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _keySelector;
					yield return _resultSelector;
					yield return _comparer;
					yield break;
				}
			}
			
			public static GroupBy7Transition Create(MethodCallExpression ex) {
				return new GroupBy7Transition() {
					_keySelector = ex.Arguments[1],
					_resultSelector = ex.Arguments[2],
					_comparer = ex.Arguments[3],
				};
			}
	  }

	  partial class GroupBy8Transition : QyTransitionBase 
	  { 
			Expression _keySelector;
			Expression _elementSelector;
			Expression _resultSelector;
			Expression _comparer;

			public override SeqMethod SeqMethod { get; } = SeqMethods.GroupBy8;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _keySelector;
					yield return _elementSelector;
					yield return _resultSelector;
					yield return _comparer;
					yield break;
				}
			}
			
			public static GroupBy8Transition Create(MethodCallExpression ex) {
				return new GroupBy8Transition() {
					_keySelector = ex.Arguments[1],
					_elementSelector = ex.Arguments[2],
					_resultSelector = ex.Arguments[3],
					_comparer = ex.Arguments[4],
				};
			}
	  }

	  partial class GroupJoinTransition : QyTransitionBase 
	  { 
			Expression _inner;
			Expression _outerKeySelector;
			Expression _innerKeySelector;
			Expression _resultSelector;

			public override SeqMethod SeqMethod { get; } = SeqMethods.GroupJoin;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _inner;
					yield return _outerKeySelector;
					yield return _innerKeySelector;
					yield return _resultSelector;
					yield break;
				}
			}
			
			public static GroupJoinTransition Create(MethodCallExpression ex) {
				return new GroupJoinTransition() {
					_inner = ex.Arguments[1],
					_outerKeySelector = ex.Arguments[2],
					_innerKeySelector = ex.Arguments[3],
					_resultSelector = ex.Arguments[4],
				};
			}
	  }

	  partial class GroupJoin2Transition : QyTransitionBase 
	  { 
			Expression _inner;
			Expression _outerKeySelector;
			Expression _innerKeySelector;
			Expression _resultSelector;
			Expression _comparer;

			public override SeqMethod SeqMethod { get; } = SeqMethods.GroupJoin2;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _inner;
					yield return _outerKeySelector;
					yield return _innerKeySelector;
					yield return _resultSelector;
					yield return _comparer;
					yield break;
				}
			}
			
			public static GroupJoin2Transition Create(MethodCallExpression ex) {
				return new GroupJoin2Transition() {
					_inner = ex.Arguments[1],
					_outerKeySelector = ex.Arguments[2],
					_innerKeySelector = ex.Arguments[3],
					_resultSelector = ex.Arguments[4],
					_comparer = ex.Arguments[5],
				};
			}
	  }

	  partial class IntersectTransition : QyTransitionBase 
	  { 
			Expression _source2;

			public override SeqMethod SeqMethod { get; } = SeqMethods.Intersect;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _source2;
					yield break;
				}
			}
			
			public static IntersectTransition Create(MethodCallExpression ex) {
				return new IntersectTransition() {
					_source2 = ex.Arguments[1],
				};
			}
	  }

	  partial class Intersect2Transition : QyTransitionBase 
	  { 
			Expression _source2;
			Expression _comparer;

			public override SeqMethod SeqMethod { get; } = SeqMethods.Intersect2;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _source2;
					yield return _comparer;
					yield break;
				}
			}
			
			public static Intersect2Transition Create(MethodCallExpression ex) {
				return new Intersect2Transition() {
					_source2 = ex.Arguments[1],
					_comparer = ex.Arguments[2],
				};
			}
	  }

	  partial class JoinTransition : QyTransitionBase 
	  { 
			Expression _inner;
			Expression _outerKeySelector;
			Expression _innerKeySelector;
			Expression _resultSelector;

			public override SeqMethod SeqMethod { get; } = SeqMethods.Join;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _inner;
					yield return _outerKeySelector;
					yield return _innerKeySelector;
					yield return _resultSelector;
					yield break;
				}
			}
			
			public static JoinTransition Create(MethodCallExpression ex) {
				return new JoinTransition() {
					_inner = ex.Arguments[1],
					_outerKeySelector = ex.Arguments[2],
					_innerKeySelector = ex.Arguments[3],
					_resultSelector = ex.Arguments[4],
				};
			}
	  }

	  partial class Join2Transition : QyTransitionBase 
	  { 
			Expression _inner;
			Expression _outerKeySelector;
			Expression _innerKeySelector;
			Expression _resultSelector;
			Expression _comparer;

			public override SeqMethod SeqMethod { get; } = SeqMethods.Join2;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _inner;
					yield return _outerKeySelector;
					yield return _innerKeySelector;
					yield return _resultSelector;
					yield return _comparer;
					yield break;
				}
			}
			
			public static Join2Transition Create(MethodCallExpression ex) {
				return new Join2Transition() {
					_inner = ex.Arguments[1],
					_outerKeySelector = ex.Arguments[2],
					_innerKeySelector = ex.Arguments[3],
					_resultSelector = ex.Arguments[4],
					_comparer = ex.Arguments[5],
				};
			}
	  }

	  partial class LastTransition : QyTransitionBase 
	  { 

			public override SeqMethod SeqMethod { get; } = SeqMethods.Last;

			public override IEnumerable<Expression> Args {
				get { 
					yield break;
				}
			}
			
			public static LastTransition Create(MethodCallExpression ex) {
				return new LastTransition() {
				};
			}
	  }

	  partial class Last2Transition : QyTransitionBase 
	  { 
			Expression _predicate;

			public override SeqMethod SeqMethod { get; } = SeqMethods.Last2;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _predicate;
					yield break;
				}
			}
			
			public static Last2Transition Create(MethodCallExpression ex) {
				return new Last2Transition() {
					_predicate = ex.Arguments[1],
				};
			}
	  }

	  partial class LastOrDefaultTransition : QyTransitionBase 
	  { 

			public override SeqMethod SeqMethod { get; } = SeqMethods.LastOrDefault;

			public override IEnumerable<Expression> Args {
				get { 
					yield break;
				}
			}
			
			public static LastOrDefaultTransition Create(MethodCallExpression ex) {
				return new LastOrDefaultTransition() {
				};
			}
	  }

	  partial class LastOrDefault2Transition : QyTransitionBase 
	  { 
			Expression _predicate;

			public override SeqMethod SeqMethod { get; } = SeqMethods.LastOrDefault2;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _predicate;
					yield break;
				}
			}
			
			public static LastOrDefault2Transition Create(MethodCallExpression ex) {
				return new LastOrDefault2Transition() {
					_predicate = ex.Arguments[1],
				};
			}
	  }

	  partial class LongCountTransition : QyTransitionBase 
	  { 

			public override SeqMethod SeqMethod { get; } = SeqMethods.LongCount;

			public override IEnumerable<Expression> Args {
				get { 
					yield break;
				}
			}
			
			public static LongCountTransition Create(MethodCallExpression ex) {
				return new LongCountTransition() {
				};
			}
	  }

	  partial class LongCount2Transition : QyTransitionBase 
	  { 
			Expression _predicate;

			public override SeqMethod SeqMethod { get; } = SeqMethods.LongCount2;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _predicate;
					yield break;
				}
			}
			
			public static LongCount2Transition Create(MethodCallExpression ex) {
				return new LongCount2Transition() {
					_predicate = ex.Arguments[1],
				};
			}
	  }

	  partial class MaxTransition : QyTransitionBase 
	  { 

			public override SeqMethod SeqMethod { get; } = SeqMethods.Max;

			public override IEnumerable<Expression> Args {
				get { 
					yield break;
				}
			}
			
			public static MaxTransition Create(MethodCallExpression ex) {
				return new MaxTransition() {
				};
			}
	  }

	  partial class Max2Transition : QyTransitionBase 
	  { 
			Expression _selector;

			public override SeqMethod SeqMethod { get; } = SeqMethods.Max2;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _selector;
					yield break;
				}
			}
			
			public static Max2Transition Create(MethodCallExpression ex) {
				return new Max2Transition() {
					_selector = ex.Arguments[1],
				};
			}
	  }

	  partial class MinTransition : QyTransitionBase 
	  { 

			public override SeqMethod SeqMethod { get; } = SeqMethods.Min;

			public override IEnumerable<Expression> Args {
				get { 
					yield break;
				}
			}
			
			public static MinTransition Create(MethodCallExpression ex) {
				return new MinTransition() {
				};
			}
	  }

	  partial class Min2Transition : QyTransitionBase 
	  { 
			Expression _selector;

			public override SeqMethod SeqMethod { get; } = SeqMethods.Min2;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _selector;
					yield break;
				}
			}
			
			public static Min2Transition Create(MethodCallExpression ex) {
				return new Min2Transition() {
					_selector = ex.Arguments[1],
				};
			}
	  }

	  partial class OfTypeTransition : QyTransitionBase 
	  { 

			public override SeqMethod SeqMethod { get; } = SeqMethods.OfType;

			public override IEnumerable<Expression> Args {
				get { 
					yield break;
				}
			}
			
			public static OfTypeTransition Create(MethodCallExpression ex) {
				return new OfTypeTransition() {
				};
			}
	  }

	  partial class OrderByTransition : QyTransitionBase 
	  { 
			Expression _keySelector;

			public override SeqMethod SeqMethod { get; } = SeqMethods.OrderBy;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _keySelector;
					yield break;
				}
			}
			
			public static OrderByTransition Create(MethodCallExpression ex) {
				return new OrderByTransition() {
					_keySelector = ex.Arguments[1],
				};
			}
	  }

	  partial class OrderBy2Transition : QyTransitionBase 
	  { 
			Expression _keySelector;
			Expression _comparer;

			public override SeqMethod SeqMethod { get; } = SeqMethods.OrderBy2;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _keySelector;
					yield return _comparer;
					yield break;
				}
			}
			
			public static OrderBy2Transition Create(MethodCallExpression ex) {
				return new OrderBy2Transition() {
					_keySelector = ex.Arguments[1],
					_comparer = ex.Arguments[2],
				};
			}
	  }

	  partial class OrderByDescendingTransition : QyTransitionBase 
	  { 
			Expression _keySelector;

			public override SeqMethod SeqMethod { get; } = SeqMethods.OrderByDescending;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _keySelector;
					yield break;
				}
			}
			
			public static OrderByDescendingTransition Create(MethodCallExpression ex) {
				return new OrderByDescendingTransition() {
					_keySelector = ex.Arguments[1],
				};
			}
	  }

	  partial class OrderByDescending2Transition : QyTransitionBase 
	  { 
			Expression _keySelector;
			Expression _comparer;

			public override SeqMethod SeqMethod { get; } = SeqMethods.OrderByDescending2;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _keySelector;
					yield return _comparer;
					yield break;
				}
			}
			
			public static OrderByDescending2Transition Create(MethodCallExpression ex) {
				return new OrderByDescending2Transition() {
					_keySelector = ex.Arguments[1],
					_comparer = ex.Arguments[2],
				};
			}
	  }

	  partial class ReverseTransition : QyTransitionBase 
	  { 

			public override SeqMethod SeqMethod { get; } = SeqMethods.Reverse;

			public override IEnumerable<Expression> Args {
				get { 
					yield break;
				}
			}
			
			public static ReverseTransition Create(MethodCallExpression ex) {
				return new ReverseTransition() {
				};
			}
	  }

	  partial class SelectTransition : QyTransitionBase 
	  { 
			Expression _selector;

			public override SeqMethod SeqMethod { get; } = SeqMethods.Select;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _selector;
					yield break;
				}
			}
			
			public static SelectTransition Create(MethodCallExpression ex) {
				return new SelectTransition() {
					_selector = ex.Arguments[1],
				};
			}
	  }

	  partial class Select2Transition : QyTransitionBase 
	  { 
			Expression _selector;

			public override SeqMethod SeqMethod { get; } = SeqMethods.Select2;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _selector;
					yield break;
				}
			}
			
			public static Select2Transition Create(MethodCallExpression ex) {
				return new Select2Transition() {
					_selector = ex.Arguments[1],
				};
			}
	  }

	  partial class SelectManyTransition : QyTransitionBase 
	  { 
			Expression _selector;

			public override SeqMethod SeqMethod { get; } = SeqMethods.SelectMany;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _selector;
					yield break;
				}
			}
			
			public static SelectManyTransition Create(MethodCallExpression ex) {
				return new SelectManyTransition() {
					_selector = ex.Arguments[1],
				};
			}
	  }

	  partial class SelectMany2Transition : QyTransitionBase 
	  { 
			Expression _selector;

			public override SeqMethod SeqMethod { get; } = SeqMethods.SelectMany2;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _selector;
					yield break;
				}
			}
			
			public static SelectMany2Transition Create(MethodCallExpression ex) {
				return new SelectMany2Transition() {
					_selector = ex.Arguments[1],
				};
			}
	  }

	  partial class SelectMany3Transition : QyTransitionBase 
	  { 
			Expression _collectionSelector;
			Expression _resultSelector;

			public override SeqMethod SeqMethod { get; } = SeqMethods.SelectMany3;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _collectionSelector;
					yield return _resultSelector;
					yield break;
				}
			}
			
			public static SelectMany3Transition Create(MethodCallExpression ex) {
				return new SelectMany3Transition() {
					_collectionSelector = ex.Arguments[1],
					_resultSelector = ex.Arguments[2],
				};
			}
	  }

	  partial class SelectMany4Transition : QyTransitionBase 
	  { 
			Expression _collectionSelector;
			Expression _resultSelector;

			public override SeqMethod SeqMethod { get; } = SeqMethods.SelectMany4;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _collectionSelector;
					yield return _resultSelector;
					yield break;
				}
			}
			
			public static SelectMany4Transition Create(MethodCallExpression ex) {
				return new SelectMany4Transition() {
					_collectionSelector = ex.Arguments[1],
					_resultSelector = ex.Arguments[2],
				};
			}
	  }

	  partial class SequenceEqualTransition : QyTransitionBase 
	  { 
			Expression _source2;

			public override SeqMethod SeqMethod { get; } = SeqMethods.SequenceEqual;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _source2;
					yield break;
				}
			}
			
			public static SequenceEqualTransition Create(MethodCallExpression ex) {
				return new SequenceEqualTransition() {
					_source2 = ex.Arguments[1],
				};
			}
	  }

	  partial class SequenceEqual2Transition : QyTransitionBase 
	  { 
			Expression _source2;
			Expression _comparer;

			public override SeqMethod SeqMethod { get; } = SeqMethods.SequenceEqual2;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _source2;
					yield return _comparer;
					yield break;
				}
			}
			
			public static SequenceEqual2Transition Create(MethodCallExpression ex) {
				return new SequenceEqual2Transition() {
					_source2 = ex.Arguments[1],
					_comparer = ex.Arguments[2],
				};
			}
	  }

	  partial class SingleTransition : QyTransitionBase 
	  { 

			public override SeqMethod SeqMethod { get; } = SeqMethods.Single;

			public override IEnumerable<Expression> Args {
				get { 
					yield break;
				}
			}
			
			public static SingleTransition Create(MethodCallExpression ex) {
				return new SingleTransition() {
				};
			}
	  }

	  partial class Single2Transition : QyTransitionBase 
	  { 
			Expression _predicate;

			public override SeqMethod SeqMethod { get; } = SeqMethods.Single2;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _predicate;
					yield break;
				}
			}
			
			public static Single2Transition Create(MethodCallExpression ex) {
				return new Single2Transition() {
					_predicate = ex.Arguments[1],
				};
			}
	  }

	  partial class SingleOrDefaultTransition : QyTransitionBase 
	  { 

			public override SeqMethod SeqMethod { get; } = SeqMethods.SingleOrDefault;

			public override IEnumerable<Expression> Args {
				get { 
					yield break;
				}
			}
			
			public static SingleOrDefaultTransition Create(MethodCallExpression ex) {
				return new SingleOrDefaultTransition() {
				};
			}
	  }

	  partial class SingleOrDefault2Transition : QyTransitionBase 
	  { 
			Expression _predicate;

			public override SeqMethod SeqMethod { get; } = SeqMethods.SingleOrDefault2;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _predicate;
					yield break;
				}
			}
			
			public static SingleOrDefault2Transition Create(MethodCallExpression ex) {
				return new SingleOrDefault2Transition() {
					_predicate = ex.Arguments[1],
				};
			}
	  }

	  partial class SkipTransition : QyTransitionBase 
	  { 
			Expression _count;

			public override SeqMethod SeqMethod { get; } = SeqMethods.Skip;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _count;
					yield break;
				}
			}
			
			public static SkipTransition Create(MethodCallExpression ex) {
				return new SkipTransition() {
					_count = ex.Arguments[1],
				};
			}
	  }

	  partial class SkipWhileTransition : QyTransitionBase 
	  { 
			Expression _predicate;

			public override SeqMethod SeqMethod { get; } = SeqMethods.SkipWhile;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _predicate;
					yield break;
				}
			}
			
			public static SkipWhileTransition Create(MethodCallExpression ex) {
				return new SkipWhileTransition() {
					_predicate = ex.Arguments[1],
				};
			}
	  }

	  partial class SkipWhile2Transition : QyTransitionBase 
	  { 
			Expression _predicate;

			public override SeqMethod SeqMethod { get; } = SeqMethods.SkipWhile2;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _predicate;
					yield break;
				}
			}
			
			public static SkipWhile2Transition Create(MethodCallExpression ex) {
				return new SkipWhile2Transition() {
					_predicate = ex.Arguments[1],
				};
			}
	  }

	  partial class SumTransition : QyTransitionBase 
	  { 
			Expression _selector;

			public override SeqMethod SeqMethod { get; } = SeqMethods.Sum;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _selector;
					yield break;
				}
			}
			
			public static SumTransition Create(MethodCallExpression ex) {
				return new SumTransition() {
					_selector = ex.Arguments[1],
				};
			}
	  }

	  partial class Sum10Transition : QyTransitionBase 
	  { 

			public override SeqMethod SeqMethod { get; } = SeqMethods.Sum10;

			public override IEnumerable<Expression> Args {
				get { 
					yield break;
				}
			}
			
			public static Sum10Transition Create(MethodCallExpression ex) {
				return new Sum10Transition() {
				};
			}
	  }

	  partial class Sum11Transition : QyTransitionBase 
	  { 

			public override SeqMethod SeqMethod { get; } = SeqMethods.Sum11;

			public override IEnumerable<Expression> Args {
				get { 
					yield break;
				}
			}
			
			public static Sum11Transition Create(MethodCallExpression ex) {
				return new Sum11Transition() {
				};
			}
	  }

	  partial class Sum12Transition : QyTransitionBase 
	  { 
			Expression _selector;

			public override SeqMethod SeqMethod { get; } = SeqMethods.Sum12;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _selector;
					yield break;
				}
			}
			
			public static Sum12Transition Create(MethodCallExpression ex) {
				return new Sum12Transition() {
					_selector = ex.Arguments[1],
				};
			}
	  }

	  partial class Sum13Transition : QyTransitionBase 
	  { 
			Expression _selector;

			public override SeqMethod SeqMethod { get; } = SeqMethods.Sum13;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _selector;
					yield break;
				}
			}
			
			public static Sum13Transition Create(MethodCallExpression ex) {
				return new Sum13Transition() {
					_selector = ex.Arguments[1],
				};
			}
	  }

	  partial class Sum14Transition : QyTransitionBase 
	  { 
			Expression _selector;

			public override SeqMethod SeqMethod { get; } = SeqMethods.Sum14;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _selector;
					yield break;
				}
			}
			
			public static Sum14Transition Create(MethodCallExpression ex) {
				return new Sum14Transition() {
					_selector = ex.Arguments[1],
				};
			}
	  }

	  partial class Sum15Transition : QyTransitionBase 
	  { 
			Expression _selector;

			public override SeqMethod SeqMethod { get; } = SeqMethods.Sum15;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _selector;
					yield break;
				}
			}
			
			public static Sum15Transition Create(MethodCallExpression ex) {
				return new Sum15Transition() {
					_selector = ex.Arguments[1],
				};
			}
	  }

	  partial class Sum16Transition : QyTransitionBase 
	  { 
			Expression _selector;

			public override SeqMethod SeqMethod { get; } = SeqMethods.Sum16;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _selector;
					yield break;
				}
			}
			
			public static Sum16Transition Create(MethodCallExpression ex) {
				return new Sum16Transition() {
					_selector = ex.Arguments[1],
				};
			}
	  }

	  partial class Sum17Transition : QyTransitionBase 
	  { 
			Expression _selector;

			public override SeqMethod SeqMethod { get; } = SeqMethods.Sum17;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _selector;
					yield break;
				}
			}
			
			public static Sum17Transition Create(MethodCallExpression ex) {
				return new Sum17Transition() {
					_selector = ex.Arguments[1],
				};
			}
	  }

	  partial class Sum18Transition : QyTransitionBase 
	  { 
			Expression _selector;

			public override SeqMethod SeqMethod { get; } = SeqMethods.Sum18;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _selector;
					yield break;
				}
			}
			
			public static Sum18Transition Create(MethodCallExpression ex) {
				return new Sum18Transition() {
					_selector = ex.Arguments[1],
				};
			}
	  }

	  partial class Sum19Transition : QyTransitionBase 
	  { 
			Expression _selector;

			public override SeqMethod SeqMethod { get; } = SeqMethods.Sum19;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _selector;
					yield break;
				}
			}
			
			public static Sum19Transition Create(MethodCallExpression ex) {
				return new Sum19Transition() {
					_selector = ex.Arguments[1],
				};
			}
	  }

	  partial class Sum2Transition : QyTransitionBase 
	  { 

			public override SeqMethod SeqMethod { get; } = SeqMethods.Sum2;

			public override IEnumerable<Expression> Args {
				get { 
					yield break;
				}
			}
			
			public static Sum2Transition Create(MethodCallExpression ex) {
				return new Sum2Transition() {
				};
			}
	  }

	  partial class Sum20Transition : QyTransitionBase 
	  { 
			Expression _selector;

			public override SeqMethod SeqMethod { get; } = SeqMethods.Sum20;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _selector;
					yield break;
				}
			}
			
			public static Sum20Transition Create(MethodCallExpression ex) {
				return new Sum20Transition() {
					_selector = ex.Arguments[1],
				};
			}
	  }

	  partial class Sum3Transition : QyTransitionBase 
	  { 

			public override SeqMethod SeqMethod { get; } = SeqMethods.Sum3;

			public override IEnumerable<Expression> Args {
				get { 
					yield break;
				}
			}
			
			public static Sum3Transition Create(MethodCallExpression ex) {
				return new Sum3Transition() {
				};
			}
	  }

	  partial class Sum4Transition : QyTransitionBase 
	  { 

			public override SeqMethod SeqMethod { get; } = SeqMethods.Sum4;

			public override IEnumerable<Expression> Args {
				get { 
					yield break;
				}
			}
			
			public static Sum4Transition Create(MethodCallExpression ex) {
				return new Sum4Transition() {
				};
			}
	  }

	  partial class Sum5Transition : QyTransitionBase 
	  { 

			public override SeqMethod SeqMethod { get; } = SeqMethods.Sum5;

			public override IEnumerable<Expression> Args {
				get { 
					yield break;
				}
			}
			
			public static Sum5Transition Create(MethodCallExpression ex) {
				return new Sum5Transition() {
				};
			}
	  }

	  partial class Sum6Transition : QyTransitionBase 
	  { 

			public override SeqMethod SeqMethod { get; } = SeqMethods.Sum6;

			public override IEnumerable<Expression> Args {
				get { 
					yield break;
				}
			}
			
			public static Sum6Transition Create(MethodCallExpression ex) {
				return new Sum6Transition() {
				};
			}
	  }

	  partial class Sum7Transition : QyTransitionBase 
	  { 

			public override SeqMethod SeqMethod { get; } = SeqMethods.Sum7;

			public override IEnumerable<Expression> Args {
				get { 
					yield break;
				}
			}
			
			public static Sum7Transition Create(MethodCallExpression ex) {
				return new Sum7Transition() {
				};
			}
	  }

	  partial class Sum8Transition : QyTransitionBase 
	  { 

			public override SeqMethod SeqMethod { get; } = SeqMethods.Sum8;

			public override IEnumerable<Expression> Args {
				get { 
					yield break;
				}
			}
			
			public static Sum8Transition Create(MethodCallExpression ex) {
				return new Sum8Transition() {
				};
			}
	  }

	  partial class Sum9Transition : QyTransitionBase 
	  { 

			public override SeqMethod SeqMethod { get; } = SeqMethods.Sum9;

			public override IEnumerable<Expression> Args {
				get { 
					yield break;
				}
			}
			
			public static Sum9Transition Create(MethodCallExpression ex) {
				return new Sum9Transition() {
				};
			}
	  }

	  partial class TakeTransition : QyTransitionBase 
	  { 
			Expression _count;

			public override SeqMethod SeqMethod { get; } = SeqMethods.Take;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _count;
					yield break;
				}
			}
			
			public static TakeTransition Create(MethodCallExpression ex) {
				return new TakeTransition() {
					_count = ex.Arguments[1],
				};
			}
	  }

	  partial class TakeWhileTransition : QyTransitionBase 
	  { 
			Expression _predicate;

			public override SeqMethod SeqMethod { get; } = SeqMethods.TakeWhile;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _predicate;
					yield break;
				}
			}
			
			public static TakeWhileTransition Create(MethodCallExpression ex) {
				return new TakeWhileTransition() {
					_predicate = ex.Arguments[1],
				};
			}
	  }

	  partial class TakeWhile2Transition : QyTransitionBase 
	  { 
			Expression _predicate;

			public override SeqMethod SeqMethod { get; } = SeqMethods.TakeWhile2;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _predicate;
					yield break;
				}
			}
			
			public static TakeWhile2Transition Create(MethodCallExpression ex) {
				return new TakeWhile2Transition() {
					_predicate = ex.Arguments[1],
				};
			}
	  }

	  partial class ThenByTransition : QyTransitionBase 
	  { 
			Expression _keySelector;

			public override SeqMethod SeqMethod { get; } = SeqMethods.ThenBy;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _keySelector;
					yield break;
				}
			}
			
			public static ThenByTransition Create(MethodCallExpression ex) {
				return new ThenByTransition() {
					_keySelector = ex.Arguments[1],
				};
			}
	  }

	  partial class ThenBy2Transition : QyTransitionBase 
	  { 
			Expression _keySelector;
			Expression _comparer;

			public override SeqMethod SeqMethod { get; } = SeqMethods.ThenBy2;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _keySelector;
					yield return _comparer;
					yield break;
				}
			}
			
			public static ThenBy2Transition Create(MethodCallExpression ex) {
				return new ThenBy2Transition() {
					_keySelector = ex.Arguments[1],
					_comparer = ex.Arguments[2],
				};
			}
	  }

	  partial class ThenByDescendingTransition : QyTransitionBase 
	  { 
			Expression _keySelector;

			public override SeqMethod SeqMethod { get; } = SeqMethods.ThenByDescending;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _keySelector;
					yield break;
				}
			}
			
			public static ThenByDescendingTransition Create(MethodCallExpression ex) {
				return new ThenByDescendingTransition() {
					_keySelector = ex.Arguments[1],
				};
			}
	  }

	  partial class ThenByDescending2Transition : QyTransitionBase 
	  { 
			Expression _keySelector;
			Expression _comparer;

			public override SeqMethod SeqMethod { get; } = SeqMethods.ThenByDescending2;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _keySelector;
					yield return _comparer;
					yield break;
				}
			}
			
			public static ThenByDescending2Transition Create(MethodCallExpression ex) {
				return new ThenByDescending2Transition() {
					_keySelector = ex.Arguments[1],
					_comparer = ex.Arguments[2],
				};
			}
	  }

	  partial class UnionTransition : QyTransitionBase 
	  { 
			Expression _source2;

			public override SeqMethod SeqMethod { get; } = SeqMethods.Union;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _source2;
					yield break;
				}
			}
			
			public static UnionTransition Create(MethodCallExpression ex) {
				return new UnionTransition() {
					_source2 = ex.Arguments[1],
				};
			}
	  }

	  partial class Union2Transition : QyTransitionBase 
	  { 
			Expression _source2;
			Expression _comparer;

			public override SeqMethod SeqMethod { get; } = SeqMethods.Union2;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _source2;
					yield return _comparer;
					yield break;
				}
			}
			
			public static Union2Transition Create(MethodCallExpression ex) {
				return new Union2Transition() {
					_source2 = ex.Arguments[1],
					_comparer = ex.Arguments[2],
				};
			}
	  }

	  partial class WhereTransition : QyTransitionBase 
	  { 
			Expression _predicate;

			public override SeqMethod SeqMethod { get; } = SeqMethods.Where;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _predicate;
					yield break;
				}
			}
			
			public static WhereTransition Create(MethodCallExpression ex) {
				return new WhereTransition() {
					_predicate = ex.Arguments[1],
				};
			}
	  }

	  partial class Where2Transition : QyTransitionBase 
	  { 
			Expression _predicate;

			public override SeqMethod SeqMethod { get; } = SeqMethods.Where2;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _predicate;
					yield break;
				}
			}
			
			public static Where2Transition Create(MethodCallExpression ex) {
				return new Where2Transition() {
					_predicate = ex.Arguments[1],
				};
			}
	  }

	  partial class ZipTransition : QyTransitionBase 
	  { 
			Expression _source2;
			Expression _resultSelector;

			public override SeqMethod SeqMethod { get; } = SeqMethods.Zip;

			public override IEnumerable<Expression> Args {
				get { 
					yield return _source2;
					yield return _resultSelector;
					yield break;
				}
			}
			
			public static ZipTransition Create(MethodCallExpression ex) {
				return new ZipTransition() {
					_source2 = ex.Arguments[1],
					_resultSelector = ex.Arguments[2],
				};
			}
	  }

}