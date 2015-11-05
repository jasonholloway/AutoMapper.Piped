using Materialize.SequenceMethods;
using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify2.Transitions 
{
	  partial class AggregateTransition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Aggregate;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _funcArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression Func {
				get { return _funcArg.Expression; }
				set { _funcArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _funcArg }.Select(a => a.Expression); }
			}
			
			public AggregateTransition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_funcArg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public AggregateTransition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_funcArg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class Aggregate2Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Aggregate2;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _seedArg;
			readonly Arg _funcArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression Seed {
				get { return _seedArg.Expression; }
				set { _seedArg.Expression = value; }
			}
			
			public Expression Func {
				get { return _funcArg.Expression; }
				set { _funcArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _seedArg, _funcArg }.Select(a => a.Expression); }
			}
			
			public Aggregate2Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_seedArg = new Arg(_paramTypes[1], _typeArgHub);
				_funcArg = new Arg(_paramTypes[2], _typeArgHub);
			}
			
			public Aggregate2Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_seedArg.Expression = ex.Arguments[1];
				_funcArg.Expression = ex.Arguments[2];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class Aggregate3Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Aggregate3;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _seedArg;
			readonly Arg _funcArg;
			readonly Arg _selectorArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression Seed {
				get { return _seedArg.Expression; }
				set { _seedArg.Expression = value; }
			}
			
			public Expression Func {
				get { return _funcArg.Expression; }
				set { _funcArg.Expression = value; }
			}
			
			public Expression Selector {
				get { return _selectorArg.Expression; }
				set { _selectorArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _seedArg, _funcArg, _selectorArg }.Select(a => a.Expression); }
			}
			
			public Aggregate3Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_seedArg = new Arg(_paramTypes[1], _typeArgHub);
				_funcArg = new Arg(_paramTypes[2], _typeArgHub);
				_selectorArg = new Arg(_paramTypes[3], _typeArgHub);
			}
			
			public Aggregate3Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_seedArg.Expression = ex.Arguments[1];
				_funcArg.Expression = ex.Arguments[2];
				_selectorArg.Expression = ex.Arguments[3];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class AllTransition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.All;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _predicateArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression Predicate {
				get { return _predicateArg.Expression; }
				set { _predicateArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _predicateArg }.Select(a => a.Expression); }
			}
			
			public AllTransition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_predicateArg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public AllTransition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_predicateArg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class AnyTransition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Any;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg }.Select(a => a.Expression); }
			}
			
			public AnyTransition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
			}
			
			public AnyTransition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class Any2Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Any2;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _predicateArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression Predicate {
				get { return _predicateArg.Expression; }
				set { _predicateArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _predicateArg }.Select(a => a.Expression); }
			}
			
			public Any2Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_predicateArg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public Any2Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_predicateArg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class AverageTransition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Average;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg }.Select(a => a.Expression); }
			}
			
			public AverageTransition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
			}
			
			public AverageTransition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class Average10Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Average10;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg }.Select(a => a.Expression); }
			}
			
			public Average10Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
			}
			
			public Average10Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class Average11Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Average11;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _selectorArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression Selector {
				get { return _selectorArg.Expression; }
				set { _selectorArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _selectorArg }.Select(a => a.Expression); }
			}
			
			public Average11Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_selectorArg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public Average11Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_selectorArg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class Average12Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Average12;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _selectorArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression Selector {
				get { return _selectorArg.Expression; }
				set { _selectorArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _selectorArg }.Select(a => a.Expression); }
			}
			
			public Average12Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_selectorArg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public Average12Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_selectorArg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class Average13Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Average13;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _selectorArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression Selector {
				get { return _selectorArg.Expression; }
				set { _selectorArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _selectorArg }.Select(a => a.Expression); }
			}
			
			public Average13Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_selectorArg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public Average13Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_selectorArg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class Average14Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Average14;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _selectorArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression Selector {
				get { return _selectorArg.Expression; }
				set { _selectorArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _selectorArg }.Select(a => a.Expression); }
			}
			
			public Average14Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_selectorArg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public Average14Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_selectorArg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class Average15Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Average15;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _selectorArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression Selector {
				get { return _selectorArg.Expression; }
				set { _selectorArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _selectorArg }.Select(a => a.Expression); }
			}
			
			public Average15Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_selectorArg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public Average15Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_selectorArg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class Average16Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Average16;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _selectorArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression Selector {
				get { return _selectorArg.Expression; }
				set { _selectorArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _selectorArg }.Select(a => a.Expression); }
			}
			
			public Average16Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_selectorArg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public Average16Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_selectorArg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class Average17Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Average17;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _selectorArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression Selector {
				get { return _selectorArg.Expression; }
				set { _selectorArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _selectorArg }.Select(a => a.Expression); }
			}
			
			public Average17Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_selectorArg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public Average17Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_selectorArg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class Average18Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Average18;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _selectorArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression Selector {
				get { return _selectorArg.Expression; }
				set { _selectorArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _selectorArg }.Select(a => a.Expression); }
			}
			
			public Average18Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_selectorArg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public Average18Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_selectorArg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class Average19Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Average19;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _selectorArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression Selector {
				get { return _selectorArg.Expression; }
				set { _selectorArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _selectorArg }.Select(a => a.Expression); }
			}
			
			public Average19Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_selectorArg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public Average19Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_selectorArg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class Average2Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Average2;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg }.Select(a => a.Expression); }
			}
			
			public Average2Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
			}
			
			public Average2Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class Average20Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Average20;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _selectorArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression Selector {
				get { return _selectorArg.Expression; }
				set { _selectorArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _selectorArg }.Select(a => a.Expression); }
			}
			
			public Average20Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_selectorArg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public Average20Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_selectorArg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class Average3Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Average3;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg }.Select(a => a.Expression); }
			}
			
			public Average3Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
			}
			
			public Average3Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class Average4Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Average4;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg }.Select(a => a.Expression); }
			}
			
			public Average4Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
			}
			
			public Average4Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class Average5Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Average5;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg }.Select(a => a.Expression); }
			}
			
			public Average5Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
			}
			
			public Average5Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class Average6Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Average6;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg }.Select(a => a.Expression); }
			}
			
			public Average6Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
			}
			
			public Average6Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class Average7Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Average7;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg }.Select(a => a.Expression); }
			}
			
			public Average7Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
			}
			
			public Average7Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class Average8Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Average8;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg }.Select(a => a.Expression); }
			}
			
			public Average8Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
			}
			
			public Average8Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class Average9Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Average9;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg }.Select(a => a.Expression); }
			}
			
			public Average9Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
			}
			
			public Average9Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class CastTransition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Cast;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg }.Select(a => a.Expression); }
			}
			
			public CastTransition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
			}
			
			public CastTransition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class ConcatTransition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Concat;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _source1Arg;
			readonly Arg _source2Arg;
			
			public Expression Source1 {
				get { return _source1Arg.Expression; }
				set { _source1Arg.Expression = value; }
			}
			
			public Expression Source2 {
				get { return _source2Arg.Expression; }
				set { _source2Arg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _source1Arg, _source2Arg }.Select(a => a.Expression); }
			}
			
			public ConcatTransition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_source1Arg = new Arg(_paramTypes[0], _typeArgHub);
				_source2Arg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public ConcatTransition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_source2Arg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _source1Arg.Expression; }
				set { _source1Arg.Expression = value; }
			}
	  }


	  partial class ContainsTransition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Contains;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _itemArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression Item {
				get { return _itemArg.Expression; }
				set { _itemArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _itemArg }.Select(a => a.Expression); }
			}
			
			public ContainsTransition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_itemArg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public ContainsTransition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_itemArg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class Contains2Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Contains2;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _itemArg;
			readonly Arg _comparerArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression Item {
				get { return _itemArg.Expression; }
				set { _itemArg.Expression = value; }
			}
			
			public Expression Comparer {
				get { return _comparerArg.Expression; }
				set { _comparerArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _itemArg, _comparerArg }.Select(a => a.Expression); }
			}
			
			public Contains2Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_itemArg = new Arg(_paramTypes[1], _typeArgHub);
				_comparerArg = new Arg(_paramTypes[2], _typeArgHub);
			}
			
			public Contains2Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_itemArg.Expression = ex.Arguments[1];
				_comparerArg.Expression = ex.Arguments[2];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class CountTransition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Count;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg }.Select(a => a.Expression); }
			}
			
			public CountTransition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
			}
			
			public CountTransition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class Count2Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Count2;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _predicateArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression Predicate {
				get { return _predicateArg.Expression; }
				set { _predicateArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _predicateArg }.Select(a => a.Expression); }
			}
			
			public Count2Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_predicateArg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public Count2Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_predicateArg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class DefaultIfEmptyTransition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.DefaultIfEmpty;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg }.Select(a => a.Expression); }
			}
			
			public DefaultIfEmptyTransition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
			}
			
			public DefaultIfEmptyTransition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class DefaultIfEmpty2Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.DefaultIfEmpty2;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _defaultValueArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression DefaultValue {
				get { return _defaultValueArg.Expression; }
				set { _defaultValueArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _defaultValueArg }.Select(a => a.Expression); }
			}
			
			public DefaultIfEmpty2Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_defaultValueArg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public DefaultIfEmpty2Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_defaultValueArg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class DistinctTransition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Distinct;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg }.Select(a => a.Expression); }
			}
			
			public DistinctTransition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
			}
			
			public DistinctTransition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class Distinct2Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Distinct2;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _comparerArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression Comparer {
				get { return _comparerArg.Expression; }
				set { _comparerArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _comparerArg }.Select(a => a.Expression); }
			}
			
			public Distinct2Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_comparerArg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public Distinct2Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_comparerArg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class ElementAtTransition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.ElementAt;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _indexArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression Index {
				get { return _indexArg.Expression; }
				set { _indexArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _indexArg }.Select(a => a.Expression); }
			}
			
			public ElementAtTransition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_indexArg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public ElementAtTransition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_indexArg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class ElementAtOrDefaultTransition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.ElementAtOrDefault;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _indexArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression Index {
				get { return _indexArg.Expression; }
				set { _indexArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _indexArg }.Select(a => a.Expression); }
			}
			
			public ElementAtOrDefaultTransition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_indexArg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public ElementAtOrDefaultTransition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_indexArg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class ExceptTransition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Except;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _source1Arg;
			readonly Arg _source2Arg;
			
			public Expression Source1 {
				get { return _source1Arg.Expression; }
				set { _source1Arg.Expression = value; }
			}
			
			public Expression Source2 {
				get { return _source2Arg.Expression; }
				set { _source2Arg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _source1Arg, _source2Arg }.Select(a => a.Expression); }
			}
			
			public ExceptTransition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_source1Arg = new Arg(_paramTypes[0], _typeArgHub);
				_source2Arg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public ExceptTransition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_source2Arg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _source1Arg.Expression; }
				set { _source1Arg.Expression = value; }
			}
	  }


	  partial class Except2Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Except2;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _source1Arg;
			readonly Arg _source2Arg;
			readonly Arg _comparerArg;
			
			public Expression Source1 {
				get { return _source1Arg.Expression; }
				set { _source1Arg.Expression = value; }
			}
			
			public Expression Source2 {
				get { return _source2Arg.Expression; }
				set { _source2Arg.Expression = value; }
			}
			
			public Expression Comparer {
				get { return _comparerArg.Expression; }
				set { _comparerArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _source1Arg, _source2Arg, _comparerArg }.Select(a => a.Expression); }
			}
			
			public Except2Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_source1Arg = new Arg(_paramTypes[0], _typeArgHub);
				_source2Arg = new Arg(_paramTypes[1], _typeArgHub);
				_comparerArg = new Arg(_paramTypes[2], _typeArgHub);
			}
			
			public Except2Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_source2Arg.Expression = ex.Arguments[1];
				_comparerArg.Expression = ex.Arguments[2];
			}

			Expression IHasSource.Source {
				get { return _source1Arg.Expression; }
				set { _source1Arg.Expression = value; }
			}
	  }


	  partial class FirstTransition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.First;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg }.Select(a => a.Expression); }
			}
			
			public FirstTransition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
			}
			
			public FirstTransition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class First2Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.First2;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _predicateArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression Predicate {
				get { return _predicateArg.Expression; }
				set { _predicateArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _predicateArg }.Select(a => a.Expression); }
			}
			
			public First2Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_predicateArg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public First2Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_predicateArg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class FirstOrDefaultTransition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.FirstOrDefault;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg }.Select(a => a.Expression); }
			}
			
			public FirstOrDefaultTransition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
			}
			
			public FirstOrDefaultTransition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class FirstOrDefault2Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.FirstOrDefault2;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _predicateArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression Predicate {
				get { return _predicateArg.Expression; }
				set { _predicateArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _predicateArg }.Select(a => a.Expression); }
			}
			
			public FirstOrDefault2Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_predicateArg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public FirstOrDefault2Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_predicateArg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class GroupByTransition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.GroupBy;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _keySelectorArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression KeySelector {
				get { return _keySelectorArg.Expression; }
				set { _keySelectorArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _keySelectorArg }.Select(a => a.Expression); }
			}
			
			public GroupByTransition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_keySelectorArg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public GroupByTransition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_keySelectorArg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class GroupBy2Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.GroupBy2;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _keySelectorArg;
			readonly Arg _elementSelectorArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression KeySelector {
				get { return _keySelectorArg.Expression; }
				set { _keySelectorArg.Expression = value; }
			}
			
			public Expression ElementSelector {
				get { return _elementSelectorArg.Expression; }
				set { _elementSelectorArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _keySelectorArg, _elementSelectorArg }.Select(a => a.Expression); }
			}
			
			public GroupBy2Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_keySelectorArg = new Arg(_paramTypes[1], _typeArgHub);
				_elementSelectorArg = new Arg(_paramTypes[2], _typeArgHub);
			}
			
			public GroupBy2Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_keySelectorArg.Expression = ex.Arguments[1];
				_elementSelectorArg.Expression = ex.Arguments[2];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class GroupBy3Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.GroupBy3;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _keySelectorArg;
			readonly Arg _comparerArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression KeySelector {
				get { return _keySelectorArg.Expression; }
				set { _keySelectorArg.Expression = value; }
			}
			
			public Expression Comparer {
				get { return _comparerArg.Expression; }
				set { _comparerArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _keySelectorArg, _comparerArg }.Select(a => a.Expression); }
			}
			
			public GroupBy3Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_keySelectorArg = new Arg(_paramTypes[1], _typeArgHub);
				_comparerArg = new Arg(_paramTypes[2], _typeArgHub);
			}
			
			public GroupBy3Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_keySelectorArg.Expression = ex.Arguments[1];
				_comparerArg.Expression = ex.Arguments[2];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class GroupBy4Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.GroupBy4;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _keySelectorArg;
			readonly Arg _elementSelectorArg;
			readonly Arg _comparerArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression KeySelector {
				get { return _keySelectorArg.Expression; }
				set { _keySelectorArg.Expression = value; }
			}
			
			public Expression ElementSelector {
				get { return _elementSelectorArg.Expression; }
				set { _elementSelectorArg.Expression = value; }
			}
			
			public Expression Comparer {
				get { return _comparerArg.Expression; }
				set { _comparerArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _keySelectorArg, _elementSelectorArg, _comparerArg }.Select(a => a.Expression); }
			}
			
			public GroupBy4Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_keySelectorArg = new Arg(_paramTypes[1], _typeArgHub);
				_elementSelectorArg = new Arg(_paramTypes[2], _typeArgHub);
				_comparerArg = new Arg(_paramTypes[3], _typeArgHub);
			}
			
			public GroupBy4Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_keySelectorArg.Expression = ex.Arguments[1];
				_elementSelectorArg.Expression = ex.Arguments[2];
				_comparerArg.Expression = ex.Arguments[3];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class GroupBy5Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.GroupBy5;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _keySelectorArg;
			readonly Arg _elementSelectorArg;
			readonly Arg _resultSelectorArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression KeySelector {
				get { return _keySelectorArg.Expression; }
				set { _keySelectorArg.Expression = value; }
			}
			
			public Expression ElementSelector {
				get { return _elementSelectorArg.Expression; }
				set { _elementSelectorArg.Expression = value; }
			}
			
			public Expression ResultSelector {
				get { return _resultSelectorArg.Expression; }
				set { _resultSelectorArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _keySelectorArg, _elementSelectorArg, _resultSelectorArg }.Select(a => a.Expression); }
			}
			
			public GroupBy5Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_keySelectorArg = new Arg(_paramTypes[1], _typeArgHub);
				_elementSelectorArg = new Arg(_paramTypes[2], _typeArgHub);
				_resultSelectorArg = new Arg(_paramTypes[3], _typeArgHub);
			}
			
			public GroupBy5Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_keySelectorArg.Expression = ex.Arguments[1];
				_elementSelectorArg.Expression = ex.Arguments[2];
				_resultSelectorArg.Expression = ex.Arguments[3];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class GroupBy6Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.GroupBy6;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _keySelectorArg;
			readonly Arg _resultSelectorArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression KeySelector {
				get { return _keySelectorArg.Expression; }
				set { _keySelectorArg.Expression = value; }
			}
			
			public Expression ResultSelector {
				get { return _resultSelectorArg.Expression; }
				set { _resultSelectorArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _keySelectorArg, _resultSelectorArg }.Select(a => a.Expression); }
			}
			
			public GroupBy6Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_keySelectorArg = new Arg(_paramTypes[1], _typeArgHub);
				_resultSelectorArg = new Arg(_paramTypes[2], _typeArgHub);
			}
			
			public GroupBy6Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_keySelectorArg.Expression = ex.Arguments[1];
				_resultSelectorArg.Expression = ex.Arguments[2];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class GroupBy7Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.GroupBy7;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _keySelectorArg;
			readonly Arg _resultSelectorArg;
			readonly Arg _comparerArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression KeySelector {
				get { return _keySelectorArg.Expression; }
				set { _keySelectorArg.Expression = value; }
			}
			
			public Expression ResultSelector {
				get { return _resultSelectorArg.Expression; }
				set { _resultSelectorArg.Expression = value; }
			}
			
			public Expression Comparer {
				get { return _comparerArg.Expression; }
				set { _comparerArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _keySelectorArg, _resultSelectorArg, _comparerArg }.Select(a => a.Expression); }
			}
			
			public GroupBy7Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_keySelectorArg = new Arg(_paramTypes[1], _typeArgHub);
				_resultSelectorArg = new Arg(_paramTypes[2], _typeArgHub);
				_comparerArg = new Arg(_paramTypes[3], _typeArgHub);
			}
			
			public GroupBy7Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_keySelectorArg.Expression = ex.Arguments[1];
				_resultSelectorArg.Expression = ex.Arguments[2];
				_comparerArg.Expression = ex.Arguments[3];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class GroupBy8Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.GroupBy8;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _keySelectorArg;
			readonly Arg _elementSelectorArg;
			readonly Arg _resultSelectorArg;
			readonly Arg _comparerArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression KeySelector {
				get { return _keySelectorArg.Expression; }
				set { _keySelectorArg.Expression = value; }
			}
			
			public Expression ElementSelector {
				get { return _elementSelectorArg.Expression; }
				set { _elementSelectorArg.Expression = value; }
			}
			
			public Expression ResultSelector {
				get { return _resultSelectorArg.Expression; }
				set { _resultSelectorArg.Expression = value; }
			}
			
			public Expression Comparer {
				get { return _comparerArg.Expression; }
				set { _comparerArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _keySelectorArg, _elementSelectorArg, _resultSelectorArg, _comparerArg }.Select(a => a.Expression); }
			}
			
			public GroupBy8Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_keySelectorArg = new Arg(_paramTypes[1], _typeArgHub);
				_elementSelectorArg = new Arg(_paramTypes[2], _typeArgHub);
				_resultSelectorArg = new Arg(_paramTypes[3], _typeArgHub);
				_comparerArg = new Arg(_paramTypes[4], _typeArgHub);
			}
			
			public GroupBy8Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_keySelectorArg.Expression = ex.Arguments[1];
				_elementSelectorArg.Expression = ex.Arguments[2];
				_resultSelectorArg.Expression = ex.Arguments[3];
				_comparerArg.Expression = ex.Arguments[4];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class GroupJoinTransition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.GroupJoin;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _outerArg;
			readonly Arg _innerArg;
			readonly Arg _outerKeySelectorArg;
			readonly Arg _innerKeySelectorArg;
			readonly Arg _resultSelectorArg;
			
			public Expression Outer {
				get { return _outerArg.Expression; }
				set { _outerArg.Expression = value; }
			}
			
			public Expression Inner {
				get { return _innerArg.Expression; }
				set { _innerArg.Expression = value; }
			}
			
			public Expression OuterKeySelector {
				get { return _outerKeySelectorArg.Expression; }
				set { _outerKeySelectorArg.Expression = value; }
			}
			
			public Expression InnerKeySelector {
				get { return _innerKeySelectorArg.Expression; }
				set { _innerKeySelectorArg.Expression = value; }
			}
			
			public Expression ResultSelector {
				get { return _resultSelectorArg.Expression; }
				set { _resultSelectorArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _outerArg, _innerArg, _outerKeySelectorArg, _innerKeySelectorArg, _resultSelectorArg }.Select(a => a.Expression); }
			}
			
			public GroupJoinTransition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_outerArg = new Arg(_paramTypes[0], _typeArgHub);
				_innerArg = new Arg(_paramTypes[1], _typeArgHub);
				_outerKeySelectorArg = new Arg(_paramTypes[2], _typeArgHub);
				_innerKeySelectorArg = new Arg(_paramTypes[3], _typeArgHub);
				_resultSelectorArg = new Arg(_paramTypes[4], _typeArgHub);
			}
			
			public GroupJoinTransition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_innerArg.Expression = ex.Arguments[1];
				_outerKeySelectorArg.Expression = ex.Arguments[2];
				_innerKeySelectorArg.Expression = ex.Arguments[3];
				_resultSelectorArg.Expression = ex.Arguments[4];
			}

			Expression IHasSource.Source {
				get { return _outerArg.Expression; }
				set { _outerArg.Expression = value; }
			}
	  }


	  partial class GroupJoin2Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.GroupJoin2;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _outerArg;
			readonly Arg _innerArg;
			readonly Arg _outerKeySelectorArg;
			readonly Arg _innerKeySelectorArg;
			readonly Arg _resultSelectorArg;
			readonly Arg _comparerArg;
			
			public Expression Outer {
				get { return _outerArg.Expression; }
				set { _outerArg.Expression = value; }
			}
			
			public Expression Inner {
				get { return _innerArg.Expression; }
				set { _innerArg.Expression = value; }
			}
			
			public Expression OuterKeySelector {
				get { return _outerKeySelectorArg.Expression; }
				set { _outerKeySelectorArg.Expression = value; }
			}
			
			public Expression InnerKeySelector {
				get { return _innerKeySelectorArg.Expression; }
				set { _innerKeySelectorArg.Expression = value; }
			}
			
			public Expression ResultSelector {
				get { return _resultSelectorArg.Expression; }
				set { _resultSelectorArg.Expression = value; }
			}
			
			public Expression Comparer {
				get { return _comparerArg.Expression; }
				set { _comparerArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _outerArg, _innerArg, _outerKeySelectorArg, _innerKeySelectorArg, _resultSelectorArg, _comparerArg }.Select(a => a.Expression); }
			}
			
			public GroupJoin2Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_outerArg = new Arg(_paramTypes[0], _typeArgHub);
				_innerArg = new Arg(_paramTypes[1], _typeArgHub);
				_outerKeySelectorArg = new Arg(_paramTypes[2], _typeArgHub);
				_innerKeySelectorArg = new Arg(_paramTypes[3], _typeArgHub);
				_resultSelectorArg = new Arg(_paramTypes[4], _typeArgHub);
				_comparerArg = new Arg(_paramTypes[5], _typeArgHub);
			}
			
			public GroupJoin2Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_innerArg.Expression = ex.Arguments[1];
				_outerKeySelectorArg.Expression = ex.Arguments[2];
				_innerKeySelectorArg.Expression = ex.Arguments[3];
				_resultSelectorArg.Expression = ex.Arguments[4];
				_comparerArg.Expression = ex.Arguments[5];
			}

			Expression IHasSource.Source {
				get { return _outerArg.Expression; }
				set { _outerArg.Expression = value; }
			}
	  }


	  partial class IntersectTransition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Intersect;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _source1Arg;
			readonly Arg _source2Arg;
			
			public Expression Source1 {
				get { return _source1Arg.Expression; }
				set { _source1Arg.Expression = value; }
			}
			
			public Expression Source2 {
				get { return _source2Arg.Expression; }
				set { _source2Arg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _source1Arg, _source2Arg }.Select(a => a.Expression); }
			}
			
			public IntersectTransition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_source1Arg = new Arg(_paramTypes[0], _typeArgHub);
				_source2Arg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public IntersectTransition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_source2Arg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _source1Arg.Expression; }
				set { _source1Arg.Expression = value; }
			}
	  }


	  partial class Intersect2Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Intersect2;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _source1Arg;
			readonly Arg _source2Arg;
			readonly Arg _comparerArg;
			
			public Expression Source1 {
				get { return _source1Arg.Expression; }
				set { _source1Arg.Expression = value; }
			}
			
			public Expression Source2 {
				get { return _source2Arg.Expression; }
				set { _source2Arg.Expression = value; }
			}
			
			public Expression Comparer {
				get { return _comparerArg.Expression; }
				set { _comparerArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _source1Arg, _source2Arg, _comparerArg }.Select(a => a.Expression); }
			}
			
			public Intersect2Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_source1Arg = new Arg(_paramTypes[0], _typeArgHub);
				_source2Arg = new Arg(_paramTypes[1], _typeArgHub);
				_comparerArg = new Arg(_paramTypes[2], _typeArgHub);
			}
			
			public Intersect2Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_source2Arg.Expression = ex.Arguments[1];
				_comparerArg.Expression = ex.Arguments[2];
			}

			Expression IHasSource.Source {
				get { return _source1Arg.Expression; }
				set { _source1Arg.Expression = value; }
			}
	  }


	  partial class JoinTransition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Join;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _outerArg;
			readonly Arg _innerArg;
			readonly Arg _outerKeySelectorArg;
			readonly Arg _innerKeySelectorArg;
			readonly Arg _resultSelectorArg;
			
			public Expression Outer {
				get { return _outerArg.Expression; }
				set { _outerArg.Expression = value; }
			}
			
			public Expression Inner {
				get { return _innerArg.Expression; }
				set { _innerArg.Expression = value; }
			}
			
			public Expression OuterKeySelector {
				get { return _outerKeySelectorArg.Expression; }
				set { _outerKeySelectorArg.Expression = value; }
			}
			
			public Expression InnerKeySelector {
				get { return _innerKeySelectorArg.Expression; }
				set { _innerKeySelectorArg.Expression = value; }
			}
			
			public Expression ResultSelector {
				get { return _resultSelectorArg.Expression; }
				set { _resultSelectorArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _outerArg, _innerArg, _outerKeySelectorArg, _innerKeySelectorArg, _resultSelectorArg }.Select(a => a.Expression); }
			}
			
			public JoinTransition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_outerArg = new Arg(_paramTypes[0], _typeArgHub);
				_innerArg = new Arg(_paramTypes[1], _typeArgHub);
				_outerKeySelectorArg = new Arg(_paramTypes[2], _typeArgHub);
				_innerKeySelectorArg = new Arg(_paramTypes[3], _typeArgHub);
				_resultSelectorArg = new Arg(_paramTypes[4], _typeArgHub);
			}
			
			public JoinTransition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_innerArg.Expression = ex.Arguments[1];
				_outerKeySelectorArg.Expression = ex.Arguments[2];
				_innerKeySelectorArg.Expression = ex.Arguments[3];
				_resultSelectorArg.Expression = ex.Arguments[4];
			}

			Expression IHasSource.Source {
				get { return _outerArg.Expression; }
				set { _outerArg.Expression = value; }
			}
	  }


	  partial class Join2Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Join2;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _outerArg;
			readonly Arg _innerArg;
			readonly Arg _outerKeySelectorArg;
			readonly Arg _innerKeySelectorArg;
			readonly Arg _resultSelectorArg;
			readonly Arg _comparerArg;
			
			public Expression Outer {
				get { return _outerArg.Expression; }
				set { _outerArg.Expression = value; }
			}
			
			public Expression Inner {
				get { return _innerArg.Expression; }
				set { _innerArg.Expression = value; }
			}
			
			public Expression OuterKeySelector {
				get { return _outerKeySelectorArg.Expression; }
				set { _outerKeySelectorArg.Expression = value; }
			}
			
			public Expression InnerKeySelector {
				get { return _innerKeySelectorArg.Expression; }
				set { _innerKeySelectorArg.Expression = value; }
			}
			
			public Expression ResultSelector {
				get { return _resultSelectorArg.Expression; }
				set { _resultSelectorArg.Expression = value; }
			}
			
			public Expression Comparer {
				get { return _comparerArg.Expression; }
				set { _comparerArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _outerArg, _innerArg, _outerKeySelectorArg, _innerKeySelectorArg, _resultSelectorArg, _comparerArg }.Select(a => a.Expression); }
			}
			
			public Join2Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_outerArg = new Arg(_paramTypes[0], _typeArgHub);
				_innerArg = new Arg(_paramTypes[1], _typeArgHub);
				_outerKeySelectorArg = new Arg(_paramTypes[2], _typeArgHub);
				_innerKeySelectorArg = new Arg(_paramTypes[3], _typeArgHub);
				_resultSelectorArg = new Arg(_paramTypes[4], _typeArgHub);
				_comparerArg = new Arg(_paramTypes[5], _typeArgHub);
			}
			
			public Join2Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_innerArg.Expression = ex.Arguments[1];
				_outerKeySelectorArg.Expression = ex.Arguments[2];
				_innerKeySelectorArg.Expression = ex.Arguments[3];
				_resultSelectorArg.Expression = ex.Arguments[4];
				_comparerArg.Expression = ex.Arguments[5];
			}

			Expression IHasSource.Source {
				get { return _outerArg.Expression; }
				set { _outerArg.Expression = value; }
			}
	  }


	  partial class LastTransition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Last;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg }.Select(a => a.Expression); }
			}
			
			public LastTransition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
			}
			
			public LastTransition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class Last2Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Last2;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _predicateArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression Predicate {
				get { return _predicateArg.Expression; }
				set { _predicateArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _predicateArg }.Select(a => a.Expression); }
			}
			
			public Last2Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_predicateArg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public Last2Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_predicateArg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class LastOrDefaultTransition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.LastOrDefault;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg }.Select(a => a.Expression); }
			}
			
			public LastOrDefaultTransition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
			}
			
			public LastOrDefaultTransition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class LastOrDefault2Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.LastOrDefault2;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _predicateArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression Predicate {
				get { return _predicateArg.Expression; }
				set { _predicateArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _predicateArg }.Select(a => a.Expression); }
			}
			
			public LastOrDefault2Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_predicateArg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public LastOrDefault2Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_predicateArg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class LongCountTransition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.LongCount;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg }.Select(a => a.Expression); }
			}
			
			public LongCountTransition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
			}
			
			public LongCountTransition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class LongCount2Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.LongCount2;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _predicateArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression Predicate {
				get { return _predicateArg.Expression; }
				set { _predicateArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _predicateArg }.Select(a => a.Expression); }
			}
			
			public LongCount2Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_predicateArg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public LongCount2Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_predicateArg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class MaxTransition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Max;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg }.Select(a => a.Expression); }
			}
			
			public MaxTransition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
			}
			
			public MaxTransition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class Max2Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Max2;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _selectorArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression Selector {
				get { return _selectorArg.Expression; }
				set { _selectorArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _selectorArg }.Select(a => a.Expression); }
			}
			
			public Max2Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_selectorArg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public Max2Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_selectorArg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class MinTransition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Min;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg }.Select(a => a.Expression); }
			}
			
			public MinTransition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
			}
			
			public MinTransition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class Min2Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Min2;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _selectorArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression Selector {
				get { return _selectorArg.Expression; }
				set { _selectorArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _selectorArg }.Select(a => a.Expression); }
			}
			
			public Min2Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_selectorArg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public Min2Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_selectorArg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class OfTypeTransition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.OfType;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg }.Select(a => a.Expression); }
			}
			
			public OfTypeTransition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
			}
			
			public OfTypeTransition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class OrderByTransition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.OrderBy;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _keySelectorArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression KeySelector {
				get { return _keySelectorArg.Expression; }
				set { _keySelectorArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _keySelectorArg }.Select(a => a.Expression); }
			}
			
			public OrderByTransition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_keySelectorArg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public OrderByTransition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_keySelectorArg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class OrderBy2Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.OrderBy2;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _keySelectorArg;
			readonly Arg _comparerArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression KeySelector {
				get { return _keySelectorArg.Expression; }
				set { _keySelectorArg.Expression = value; }
			}
			
			public Expression Comparer {
				get { return _comparerArg.Expression; }
				set { _comparerArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _keySelectorArg, _comparerArg }.Select(a => a.Expression); }
			}
			
			public OrderBy2Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_keySelectorArg = new Arg(_paramTypes[1], _typeArgHub);
				_comparerArg = new Arg(_paramTypes[2], _typeArgHub);
			}
			
			public OrderBy2Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_keySelectorArg.Expression = ex.Arguments[1];
				_comparerArg.Expression = ex.Arguments[2];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class OrderByDescendingTransition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.OrderByDescending;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _keySelectorArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression KeySelector {
				get { return _keySelectorArg.Expression; }
				set { _keySelectorArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _keySelectorArg }.Select(a => a.Expression); }
			}
			
			public OrderByDescendingTransition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_keySelectorArg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public OrderByDescendingTransition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_keySelectorArg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class OrderByDescending2Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.OrderByDescending2;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _keySelectorArg;
			readonly Arg _comparerArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression KeySelector {
				get { return _keySelectorArg.Expression; }
				set { _keySelectorArg.Expression = value; }
			}
			
			public Expression Comparer {
				get { return _comparerArg.Expression; }
				set { _comparerArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _keySelectorArg, _comparerArg }.Select(a => a.Expression); }
			}
			
			public OrderByDescending2Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_keySelectorArg = new Arg(_paramTypes[1], _typeArgHub);
				_comparerArg = new Arg(_paramTypes[2], _typeArgHub);
			}
			
			public OrderByDescending2Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_keySelectorArg.Expression = ex.Arguments[1];
				_comparerArg.Expression = ex.Arguments[2];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class ReverseTransition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Reverse;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg }.Select(a => a.Expression); }
			}
			
			public ReverseTransition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
			}
			
			public ReverseTransition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class SelectTransition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Select;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _selectorArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression Selector {
				get { return _selectorArg.Expression; }
				set { _selectorArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _selectorArg }.Select(a => a.Expression); }
			}
			
			public SelectTransition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_selectorArg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public SelectTransition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_selectorArg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class Select2Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Select2;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _selectorArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression Selector {
				get { return _selectorArg.Expression; }
				set { _selectorArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _selectorArg }.Select(a => a.Expression); }
			}
			
			public Select2Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_selectorArg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public Select2Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_selectorArg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class SelectManyTransition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.SelectMany;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _selectorArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression Selector {
				get { return _selectorArg.Expression; }
				set { _selectorArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _selectorArg }.Select(a => a.Expression); }
			}
			
			public SelectManyTransition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_selectorArg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public SelectManyTransition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_selectorArg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class SelectMany2Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.SelectMany2;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _selectorArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression Selector {
				get { return _selectorArg.Expression; }
				set { _selectorArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _selectorArg }.Select(a => a.Expression); }
			}
			
			public SelectMany2Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_selectorArg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public SelectMany2Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_selectorArg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class SelectMany3Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.SelectMany3;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _collectionSelectorArg;
			readonly Arg _resultSelectorArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression CollectionSelector {
				get { return _collectionSelectorArg.Expression; }
				set { _collectionSelectorArg.Expression = value; }
			}
			
			public Expression ResultSelector {
				get { return _resultSelectorArg.Expression; }
				set { _resultSelectorArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _collectionSelectorArg, _resultSelectorArg }.Select(a => a.Expression); }
			}
			
			public SelectMany3Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_collectionSelectorArg = new Arg(_paramTypes[1], _typeArgHub);
				_resultSelectorArg = new Arg(_paramTypes[2], _typeArgHub);
			}
			
			public SelectMany3Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_collectionSelectorArg.Expression = ex.Arguments[1];
				_resultSelectorArg.Expression = ex.Arguments[2];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class SelectMany4Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.SelectMany4;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _collectionSelectorArg;
			readonly Arg _resultSelectorArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression CollectionSelector {
				get { return _collectionSelectorArg.Expression; }
				set { _collectionSelectorArg.Expression = value; }
			}
			
			public Expression ResultSelector {
				get { return _resultSelectorArg.Expression; }
				set { _resultSelectorArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _collectionSelectorArg, _resultSelectorArg }.Select(a => a.Expression); }
			}
			
			public SelectMany4Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_collectionSelectorArg = new Arg(_paramTypes[1], _typeArgHub);
				_resultSelectorArg = new Arg(_paramTypes[2], _typeArgHub);
			}
			
			public SelectMany4Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_collectionSelectorArg.Expression = ex.Arguments[1];
				_resultSelectorArg.Expression = ex.Arguments[2];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class SequenceEqualTransition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.SequenceEqual;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _source1Arg;
			readonly Arg _source2Arg;
			
			public Expression Source1 {
				get { return _source1Arg.Expression; }
				set { _source1Arg.Expression = value; }
			}
			
			public Expression Source2 {
				get { return _source2Arg.Expression; }
				set { _source2Arg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _source1Arg, _source2Arg }.Select(a => a.Expression); }
			}
			
			public SequenceEqualTransition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_source1Arg = new Arg(_paramTypes[0], _typeArgHub);
				_source2Arg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public SequenceEqualTransition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_source2Arg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _source1Arg.Expression; }
				set { _source1Arg.Expression = value; }
			}
	  }


	  partial class SequenceEqual2Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.SequenceEqual2;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _source1Arg;
			readonly Arg _source2Arg;
			readonly Arg _comparerArg;
			
			public Expression Source1 {
				get { return _source1Arg.Expression; }
				set { _source1Arg.Expression = value; }
			}
			
			public Expression Source2 {
				get { return _source2Arg.Expression; }
				set { _source2Arg.Expression = value; }
			}
			
			public Expression Comparer {
				get { return _comparerArg.Expression; }
				set { _comparerArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _source1Arg, _source2Arg, _comparerArg }.Select(a => a.Expression); }
			}
			
			public SequenceEqual2Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_source1Arg = new Arg(_paramTypes[0], _typeArgHub);
				_source2Arg = new Arg(_paramTypes[1], _typeArgHub);
				_comparerArg = new Arg(_paramTypes[2], _typeArgHub);
			}
			
			public SequenceEqual2Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_source2Arg.Expression = ex.Arguments[1];
				_comparerArg.Expression = ex.Arguments[2];
			}

			Expression IHasSource.Source {
				get { return _source1Arg.Expression; }
				set { _source1Arg.Expression = value; }
			}
	  }


	  partial class SingleTransition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Single;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg }.Select(a => a.Expression); }
			}
			
			public SingleTransition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
			}
			
			public SingleTransition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class Single2Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Single2;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _predicateArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression Predicate {
				get { return _predicateArg.Expression; }
				set { _predicateArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _predicateArg }.Select(a => a.Expression); }
			}
			
			public Single2Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_predicateArg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public Single2Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_predicateArg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class SingleOrDefaultTransition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.SingleOrDefault;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg }.Select(a => a.Expression); }
			}
			
			public SingleOrDefaultTransition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
			}
			
			public SingleOrDefaultTransition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class SingleOrDefault2Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.SingleOrDefault2;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _predicateArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression Predicate {
				get { return _predicateArg.Expression; }
				set { _predicateArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _predicateArg }.Select(a => a.Expression); }
			}
			
			public SingleOrDefault2Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_predicateArg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public SingleOrDefault2Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_predicateArg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class SkipTransition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Skip;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _countArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression Count {
				get { return _countArg.Expression; }
				set { _countArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _countArg }.Select(a => a.Expression); }
			}
			
			public SkipTransition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_countArg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public SkipTransition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_countArg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class SkipWhileTransition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.SkipWhile;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _predicateArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression Predicate {
				get { return _predicateArg.Expression; }
				set { _predicateArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _predicateArg }.Select(a => a.Expression); }
			}
			
			public SkipWhileTransition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_predicateArg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public SkipWhileTransition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_predicateArg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class SkipWhile2Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.SkipWhile2;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _predicateArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression Predicate {
				get { return _predicateArg.Expression; }
				set { _predicateArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _predicateArg }.Select(a => a.Expression); }
			}
			
			public SkipWhile2Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_predicateArg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public SkipWhile2Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_predicateArg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class SumTransition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Sum;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _selectorArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression Selector {
				get { return _selectorArg.Expression; }
				set { _selectorArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _selectorArg }.Select(a => a.Expression); }
			}
			
			public SumTransition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_selectorArg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public SumTransition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_selectorArg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class Sum10Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Sum10;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg }.Select(a => a.Expression); }
			}
			
			public Sum10Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
			}
			
			public Sum10Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class Sum11Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Sum11;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg }.Select(a => a.Expression); }
			}
			
			public Sum11Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
			}
			
			public Sum11Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class Sum12Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Sum12;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _selectorArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression Selector {
				get { return _selectorArg.Expression; }
				set { _selectorArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _selectorArg }.Select(a => a.Expression); }
			}
			
			public Sum12Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_selectorArg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public Sum12Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_selectorArg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class Sum13Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Sum13;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _selectorArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression Selector {
				get { return _selectorArg.Expression; }
				set { _selectorArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _selectorArg }.Select(a => a.Expression); }
			}
			
			public Sum13Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_selectorArg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public Sum13Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_selectorArg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class Sum14Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Sum14;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _selectorArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression Selector {
				get { return _selectorArg.Expression; }
				set { _selectorArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _selectorArg }.Select(a => a.Expression); }
			}
			
			public Sum14Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_selectorArg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public Sum14Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_selectorArg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class Sum15Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Sum15;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _selectorArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression Selector {
				get { return _selectorArg.Expression; }
				set { _selectorArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _selectorArg }.Select(a => a.Expression); }
			}
			
			public Sum15Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_selectorArg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public Sum15Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_selectorArg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class Sum16Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Sum16;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _selectorArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression Selector {
				get { return _selectorArg.Expression; }
				set { _selectorArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _selectorArg }.Select(a => a.Expression); }
			}
			
			public Sum16Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_selectorArg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public Sum16Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_selectorArg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class Sum17Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Sum17;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _selectorArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression Selector {
				get { return _selectorArg.Expression; }
				set { _selectorArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _selectorArg }.Select(a => a.Expression); }
			}
			
			public Sum17Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_selectorArg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public Sum17Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_selectorArg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class Sum18Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Sum18;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _selectorArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression Selector {
				get { return _selectorArg.Expression; }
				set { _selectorArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _selectorArg }.Select(a => a.Expression); }
			}
			
			public Sum18Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_selectorArg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public Sum18Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_selectorArg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class Sum19Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Sum19;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _selectorArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression Selector {
				get { return _selectorArg.Expression; }
				set { _selectorArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _selectorArg }.Select(a => a.Expression); }
			}
			
			public Sum19Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_selectorArg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public Sum19Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_selectorArg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class Sum2Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Sum2;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg }.Select(a => a.Expression); }
			}
			
			public Sum2Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
			}
			
			public Sum2Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class Sum20Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Sum20;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _selectorArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression Selector {
				get { return _selectorArg.Expression; }
				set { _selectorArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _selectorArg }.Select(a => a.Expression); }
			}
			
			public Sum20Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_selectorArg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public Sum20Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_selectorArg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class Sum3Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Sum3;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg }.Select(a => a.Expression); }
			}
			
			public Sum3Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
			}
			
			public Sum3Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class Sum4Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Sum4;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg }.Select(a => a.Expression); }
			}
			
			public Sum4Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
			}
			
			public Sum4Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class Sum5Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Sum5;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg }.Select(a => a.Expression); }
			}
			
			public Sum5Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
			}
			
			public Sum5Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class Sum6Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Sum6;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg }.Select(a => a.Expression); }
			}
			
			public Sum6Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
			}
			
			public Sum6Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class Sum7Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Sum7;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg }.Select(a => a.Expression); }
			}
			
			public Sum7Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
			}
			
			public Sum7Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class Sum8Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Sum8;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg }.Select(a => a.Expression); }
			}
			
			public Sum8Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
			}
			
			public Sum8Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class Sum9Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Sum9;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg }.Select(a => a.Expression); }
			}
			
			public Sum9Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
			}
			
			public Sum9Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class TakeTransition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Take;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _countArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression Count {
				get { return _countArg.Expression; }
				set { _countArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _countArg }.Select(a => a.Expression); }
			}
			
			public TakeTransition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_countArg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public TakeTransition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_countArg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class TakeWhileTransition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.TakeWhile;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _predicateArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression Predicate {
				get { return _predicateArg.Expression; }
				set { _predicateArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _predicateArg }.Select(a => a.Expression); }
			}
			
			public TakeWhileTransition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_predicateArg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public TakeWhileTransition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_predicateArg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class TakeWhile2Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.TakeWhile2;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _predicateArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression Predicate {
				get { return _predicateArg.Expression; }
				set { _predicateArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _predicateArg }.Select(a => a.Expression); }
			}
			
			public TakeWhile2Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_predicateArg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public TakeWhile2Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_predicateArg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class ThenByTransition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.ThenBy;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _keySelectorArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression KeySelector {
				get { return _keySelectorArg.Expression; }
				set { _keySelectorArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _keySelectorArg }.Select(a => a.Expression); }
			}
			
			public ThenByTransition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_keySelectorArg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public ThenByTransition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_keySelectorArg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class ThenBy2Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.ThenBy2;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _keySelectorArg;
			readonly Arg _comparerArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression KeySelector {
				get { return _keySelectorArg.Expression; }
				set { _keySelectorArg.Expression = value; }
			}
			
			public Expression Comparer {
				get { return _comparerArg.Expression; }
				set { _comparerArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _keySelectorArg, _comparerArg }.Select(a => a.Expression); }
			}
			
			public ThenBy2Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_keySelectorArg = new Arg(_paramTypes[1], _typeArgHub);
				_comparerArg = new Arg(_paramTypes[2], _typeArgHub);
			}
			
			public ThenBy2Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_keySelectorArg.Expression = ex.Arguments[1];
				_comparerArg.Expression = ex.Arguments[2];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class ThenByDescendingTransition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.ThenByDescending;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _keySelectorArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression KeySelector {
				get { return _keySelectorArg.Expression; }
				set { _keySelectorArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _keySelectorArg }.Select(a => a.Expression); }
			}
			
			public ThenByDescendingTransition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_keySelectorArg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public ThenByDescendingTransition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_keySelectorArg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class ThenByDescending2Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.ThenByDescending2;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _keySelectorArg;
			readonly Arg _comparerArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression KeySelector {
				get { return _keySelectorArg.Expression; }
				set { _keySelectorArg.Expression = value; }
			}
			
			public Expression Comparer {
				get { return _comparerArg.Expression; }
				set { _comparerArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _keySelectorArg, _comparerArg }.Select(a => a.Expression); }
			}
			
			public ThenByDescending2Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_keySelectorArg = new Arg(_paramTypes[1], _typeArgHub);
				_comparerArg = new Arg(_paramTypes[2], _typeArgHub);
			}
			
			public ThenByDescending2Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_keySelectorArg.Expression = ex.Arguments[1];
				_comparerArg.Expression = ex.Arguments[2];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class UnionTransition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Union;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _source1Arg;
			readonly Arg _source2Arg;
			
			public Expression Source1 {
				get { return _source1Arg.Expression; }
				set { _source1Arg.Expression = value; }
			}
			
			public Expression Source2 {
				get { return _source2Arg.Expression; }
				set { _source2Arg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _source1Arg, _source2Arg }.Select(a => a.Expression); }
			}
			
			public UnionTransition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_source1Arg = new Arg(_paramTypes[0], _typeArgHub);
				_source2Arg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public UnionTransition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_source2Arg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _source1Arg.Expression; }
				set { _source1Arg.Expression = value; }
			}
	  }


	  partial class Union2Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Union2;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _source1Arg;
			readonly Arg _source2Arg;
			readonly Arg _comparerArg;
			
			public Expression Source1 {
				get { return _source1Arg.Expression; }
				set { _source1Arg.Expression = value; }
			}
			
			public Expression Source2 {
				get { return _source2Arg.Expression; }
				set { _source2Arg.Expression = value; }
			}
			
			public Expression Comparer {
				get { return _comparerArg.Expression; }
				set { _comparerArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _source1Arg, _source2Arg, _comparerArg }.Select(a => a.Expression); }
			}
			
			public Union2Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_source1Arg = new Arg(_paramTypes[0], _typeArgHub);
				_source2Arg = new Arg(_paramTypes[1], _typeArgHub);
				_comparerArg = new Arg(_paramTypes[2], _typeArgHub);
			}
			
			public Union2Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_source2Arg.Expression = ex.Arguments[1];
				_comparerArg.Expression = ex.Arguments[2];
			}

			Expression IHasSource.Source {
				get { return _source1Arg.Expression; }
				set { _source1Arg.Expression = value; }
			}
	  }


	  partial class WhereTransition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Where;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _predicateArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression Predicate {
				get { return _predicateArg.Expression; }
				set { _predicateArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _predicateArg }.Select(a => a.Expression); }
			}
			
			public WhereTransition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_predicateArg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public WhereTransition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_predicateArg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class Where2Transition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Where2;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _sourceArg;
			readonly Arg _predicateArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
			
			public Expression Predicate {
				get { return _predicateArg.Expression; }
				set { _predicateArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _sourceArg, _predicateArg }.Select(a => a.Expression); }
			}
			
			public Where2Transition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_predicateArg = new Arg(_paramTypes[1], _typeArgHub);
			}
			
			public Where2Transition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_predicateArg.Expression = ex.Arguments[1];
			}

			Expression IHasSource.Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}
	  }


	  partial class ZipTransition : SeqTransition, IHasSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Zip;
			static readonly Type[] _paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParams = _seqMethod.Qy.GetGenericArguments();
			
			readonly Arg _source1Arg;
			readonly Arg _source2Arg;
			readonly Arg _resultSelectorArg;
			
			public Expression Source1 {
				get { return _source1Arg.Expression; }
				set { _source1Arg.Expression = value; }
			}
			
			public Expression Source2 {
				get { return _source2Arg.Expression; }
				set { _source2Arg.Expression = value; }
			}
			
			public Expression ResultSelector {
				get { return _resultSelectorArg.Expression; }
				set { _resultSelectorArg.Expression = value; }
			}
		
			public override SeqMethod SeqMethod { 
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _source1Arg, _source2Arg, _resultSelectorArg }.Select(a => a.Expression); }
			}
			
			public ZipTransition()
			{
				_typeArgHub = new TypeArgHub(_typeParams);								
				_source1Arg = new Arg(_paramTypes[0], _typeArgHub);
				_source2Arg = new Arg(_paramTypes[1], _typeArgHub);
				_resultSelectorArg = new Arg(_paramTypes[2], _typeArgHub);
			}
			
			public ZipTransition(MethodCallExpression ex) : this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_source2Arg.Expression = ex.Arguments[1];
				_resultSelectorArg.Expression = ex.Arguments[2];
			}

			Expression IHasSource.Source {
				get { return _source1Arg.Expression; }
				set { _source1Arg.Expression = value; }
			}
	  }


}

