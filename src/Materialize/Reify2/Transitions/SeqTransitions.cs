using Materialize.SequenceMethods;
using Materialize.Types;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify2.Transitions 
{
	  partial class AggregateTransition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static AggregateTransition() {
				_seqMethod = SeqMethods.Aggregate;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public AggregateTransition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_funcArg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _sourceArg, _funcArg }.Select(a => a.Expression);
			}
			
			public AggregateTransition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_funcArg.Expression = ex.Arguments[1];
			}
	  }


	  partial class Aggregate2Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static Aggregate2Transition() {
				_seqMethod = SeqMethods.Aggregate2;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public Aggregate2Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_seedArg = new Arg(_paramTypes[1], _typeArgHub);
				_funcArg = new Arg(_paramTypes[2], _typeArgHub);

				Args = new[] { _sourceArg, _seedArg, _funcArg }.Select(a => a.Expression);
			}
			
			public Aggregate2Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_seedArg.Expression = ex.Arguments[1];
				_funcArg.Expression = ex.Arguments[2];
			}
	  }


	  partial class Aggregate3Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static Aggregate3Transition() {
				_seqMethod = SeqMethods.Aggregate3;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public Aggregate3Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_seedArg = new Arg(_paramTypes[1], _typeArgHub);
				_funcArg = new Arg(_paramTypes[2], _typeArgHub);
				_selectorArg = new Arg(_paramTypes[3], _typeArgHub);

				Args = new[] { _sourceArg, _seedArg, _funcArg, _selectorArg }.Select(a => a.Expression);
			}
			
			public Aggregate3Transition(MethodCallExpression ex) 
				: this()
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
	  }


	  partial class AllTransition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static AllTransition() {
				_seqMethod = SeqMethods.All;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public AllTransition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_predicateArg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _sourceArg, _predicateArg }.Select(a => a.Expression);
			}
			
			public AllTransition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_predicateArg.Expression = ex.Arguments[1];
			}
	  }


	  partial class AnyTransition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}

		
			static AnyTransition() {
				_seqMethod = SeqMethods.Any;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public AnyTransition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);

				Args = new[] { _sourceArg }.Select(a => a.Expression);
			}
			
			public AnyTransition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}
	  }


	  partial class Any2Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static Any2Transition() {
				_seqMethod = SeqMethods.Any2;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public Any2Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_predicateArg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _sourceArg, _predicateArg }.Select(a => a.Expression);
			}
			
			public Any2Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_predicateArg.Expression = ex.Arguments[1];
			}
	  }


	  partial class AverageTransition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}

		
			static AverageTransition() {
				_seqMethod = SeqMethods.Average;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public AverageTransition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);

				Args = new[] { _sourceArg }.Select(a => a.Expression);
			}
			
			public AverageTransition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}
	  }


	  partial class Average10Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}

		
			static Average10Transition() {
				_seqMethod = SeqMethods.Average10;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public Average10Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);

				Args = new[] { _sourceArg }.Select(a => a.Expression);
			}
			
			public Average10Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}
	  }


	  partial class Average11Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static Average11Transition() {
				_seqMethod = SeqMethods.Average11;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public Average11Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_selectorArg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _sourceArg, _selectorArg }.Select(a => a.Expression);
			}
			
			public Average11Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_selectorArg.Expression = ex.Arguments[1];
			}
	  }


	  partial class Average12Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static Average12Transition() {
				_seqMethod = SeqMethods.Average12;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public Average12Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_selectorArg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _sourceArg, _selectorArg }.Select(a => a.Expression);
			}
			
			public Average12Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_selectorArg.Expression = ex.Arguments[1];
			}
	  }


	  partial class Average13Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static Average13Transition() {
				_seqMethod = SeqMethods.Average13;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public Average13Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_selectorArg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _sourceArg, _selectorArg }.Select(a => a.Expression);
			}
			
			public Average13Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_selectorArg.Expression = ex.Arguments[1];
			}
	  }


	  partial class Average14Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static Average14Transition() {
				_seqMethod = SeqMethods.Average14;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public Average14Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_selectorArg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _sourceArg, _selectorArg }.Select(a => a.Expression);
			}
			
			public Average14Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_selectorArg.Expression = ex.Arguments[1];
			}
	  }


	  partial class Average15Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static Average15Transition() {
				_seqMethod = SeqMethods.Average15;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public Average15Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_selectorArg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _sourceArg, _selectorArg }.Select(a => a.Expression);
			}
			
			public Average15Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_selectorArg.Expression = ex.Arguments[1];
			}
	  }


	  partial class Average16Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static Average16Transition() {
				_seqMethod = SeqMethods.Average16;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public Average16Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_selectorArg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _sourceArg, _selectorArg }.Select(a => a.Expression);
			}
			
			public Average16Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_selectorArg.Expression = ex.Arguments[1];
			}
	  }


	  partial class Average17Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static Average17Transition() {
				_seqMethod = SeqMethods.Average17;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public Average17Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_selectorArg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _sourceArg, _selectorArg }.Select(a => a.Expression);
			}
			
			public Average17Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_selectorArg.Expression = ex.Arguments[1];
			}
	  }


	  partial class Average18Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static Average18Transition() {
				_seqMethod = SeqMethods.Average18;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public Average18Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_selectorArg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _sourceArg, _selectorArg }.Select(a => a.Expression);
			}
			
			public Average18Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_selectorArg.Expression = ex.Arguments[1];
			}
	  }


	  partial class Average19Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static Average19Transition() {
				_seqMethod = SeqMethods.Average19;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public Average19Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_selectorArg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _sourceArg, _selectorArg }.Select(a => a.Expression);
			}
			
			public Average19Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_selectorArg.Expression = ex.Arguments[1];
			}
	  }


	  partial class Average2Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}

		
			static Average2Transition() {
				_seqMethod = SeqMethods.Average2;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public Average2Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);

				Args = new[] { _sourceArg }.Select(a => a.Expression);
			}
			
			public Average2Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}
	  }


	  partial class Average20Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static Average20Transition() {
				_seqMethod = SeqMethods.Average20;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public Average20Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_selectorArg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _sourceArg, _selectorArg }.Select(a => a.Expression);
			}
			
			public Average20Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_selectorArg.Expression = ex.Arguments[1];
			}
	  }


	  partial class Average3Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}

		
			static Average3Transition() {
				_seqMethod = SeqMethods.Average3;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public Average3Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);

				Args = new[] { _sourceArg }.Select(a => a.Expression);
			}
			
			public Average3Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}
	  }


	  partial class Average4Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}

		
			static Average4Transition() {
				_seqMethod = SeqMethods.Average4;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public Average4Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);

				Args = new[] { _sourceArg }.Select(a => a.Expression);
			}
			
			public Average4Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}
	  }


	  partial class Average5Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}

		
			static Average5Transition() {
				_seqMethod = SeqMethods.Average5;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public Average5Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);

				Args = new[] { _sourceArg }.Select(a => a.Expression);
			}
			
			public Average5Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}
	  }


	  partial class Average6Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}

		
			static Average6Transition() {
				_seqMethod = SeqMethods.Average6;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public Average6Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);

				Args = new[] { _sourceArg }.Select(a => a.Expression);
			}
			
			public Average6Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}
	  }


	  partial class Average7Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}

		
			static Average7Transition() {
				_seqMethod = SeqMethods.Average7;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public Average7Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);

				Args = new[] { _sourceArg }.Select(a => a.Expression);
			}
			
			public Average7Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}
	  }


	  partial class Average8Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}

		
			static Average8Transition() {
				_seqMethod = SeqMethods.Average8;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public Average8Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);

				Args = new[] { _sourceArg }.Select(a => a.Expression);
			}
			
			public Average8Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}
	  }


	  partial class Average9Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}

		
			static Average9Transition() {
				_seqMethod = SeqMethods.Average9;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public Average9Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);

				Args = new[] { _sourceArg }.Select(a => a.Expression);
			}
			
			public Average9Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}
	  }


	  partial class CastTransition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}

		
			static CastTransition() {
				_seqMethod = SeqMethods.Cast;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public CastTransition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);

				Args = new[] { _sourceArg }.Select(a => a.Expression);
			}
			
			public CastTransition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}
	  }


	  partial class ConcatTransition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static ConcatTransition() {
				_seqMethod = SeqMethods.Concat;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public ConcatTransition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_source1Arg = new Arg(_paramTypes[0], _typeArgHub);
				_source2Arg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _source1Arg, _source2Arg }.Select(a => a.Expression);
			}
			
			public ConcatTransition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_source2Arg.Expression = ex.Arguments[1];
			}
	  }


	  partial class ContainsTransition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static ContainsTransition() {
				_seqMethod = SeqMethods.Contains;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public ContainsTransition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_itemArg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _sourceArg, _itemArg }.Select(a => a.Expression);
			}
			
			public ContainsTransition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_itemArg.Expression = ex.Arguments[1];
			}
	  }


	  partial class Contains2Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static Contains2Transition() {
				_seqMethod = SeqMethods.Contains2;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public Contains2Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_itemArg = new Arg(_paramTypes[1], _typeArgHub);
				_comparerArg = new Arg(_paramTypes[2], _typeArgHub);

				Args = new[] { _sourceArg, _itemArg, _comparerArg }.Select(a => a.Expression);
			}
			
			public Contains2Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_itemArg.Expression = ex.Arguments[1];
				_comparerArg.Expression = ex.Arguments[2];
			}
	  }


	  partial class CountTransition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}

		
			static CountTransition() {
				_seqMethod = SeqMethods.Count;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public CountTransition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);

				Args = new[] { _sourceArg }.Select(a => a.Expression);
			}
			
			public CountTransition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}
	  }


	  partial class Count2Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static Count2Transition() {
				_seqMethod = SeqMethods.Count2;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public Count2Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_predicateArg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _sourceArg, _predicateArg }.Select(a => a.Expression);
			}
			
			public Count2Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_predicateArg.Expression = ex.Arguments[1];
			}
	  }


	  partial class DefaultIfEmptyTransition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}

		
			static DefaultIfEmptyTransition() {
				_seqMethod = SeqMethods.DefaultIfEmpty;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public DefaultIfEmptyTransition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);

				Args = new[] { _sourceArg }.Select(a => a.Expression);
			}
			
			public DefaultIfEmptyTransition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}
	  }


	  partial class DefaultIfEmpty2Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static DefaultIfEmpty2Transition() {
				_seqMethod = SeqMethods.DefaultIfEmpty2;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public DefaultIfEmpty2Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_defaultValueArg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _sourceArg, _defaultValueArg }.Select(a => a.Expression);
			}
			
			public DefaultIfEmpty2Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_defaultValueArg.Expression = ex.Arguments[1];
			}
	  }


	  partial class DistinctTransition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}

		
			static DistinctTransition() {
				_seqMethod = SeqMethods.Distinct;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public DistinctTransition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);

				Args = new[] { _sourceArg }.Select(a => a.Expression);
			}
			
			public DistinctTransition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}
	  }


	  partial class Distinct2Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static Distinct2Transition() {
				_seqMethod = SeqMethods.Distinct2;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public Distinct2Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_comparerArg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _sourceArg, _comparerArg }.Select(a => a.Expression);
			}
			
			public Distinct2Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_comparerArg.Expression = ex.Arguments[1];
			}
	  }


	  partial class ElementAtTransition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static ElementAtTransition() {
				_seqMethod = SeqMethods.ElementAt;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public ElementAtTransition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_indexArg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _sourceArg, _indexArg }.Select(a => a.Expression);
			}
			
			public ElementAtTransition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_indexArg.Expression = ex.Arguments[1];
			}
	  }


	  partial class ElementAtOrDefaultTransition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static ElementAtOrDefaultTransition() {
				_seqMethod = SeqMethods.ElementAtOrDefault;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public ElementAtOrDefaultTransition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_indexArg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _sourceArg, _indexArg }.Select(a => a.Expression);
			}
			
			public ElementAtOrDefaultTransition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_indexArg.Expression = ex.Arguments[1];
			}
	  }


	  partial class ExceptTransition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static ExceptTransition() {
				_seqMethod = SeqMethods.Except;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public ExceptTransition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_source1Arg = new Arg(_paramTypes[0], _typeArgHub);
				_source2Arg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _source1Arg, _source2Arg }.Select(a => a.Expression);
			}
			
			public ExceptTransition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_source2Arg.Expression = ex.Arguments[1];
			}
	  }


	  partial class Except2Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static Except2Transition() {
				_seqMethod = SeqMethods.Except2;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public Except2Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_source1Arg = new Arg(_paramTypes[0], _typeArgHub);
				_source2Arg = new Arg(_paramTypes[1], _typeArgHub);
				_comparerArg = new Arg(_paramTypes[2], _typeArgHub);

				Args = new[] { _source1Arg, _source2Arg, _comparerArg }.Select(a => a.Expression);
			}
			
			public Except2Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_source2Arg.Expression = ex.Arguments[1];
				_comparerArg.Expression = ex.Arguments[2];
			}
	  }


	  partial class FirstTransition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}

		
			static FirstTransition() {
				_seqMethod = SeqMethods.First;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public FirstTransition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);

				Args = new[] { _sourceArg }.Select(a => a.Expression);
			}
			
			public FirstTransition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}
	  }


	  partial class First2Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static First2Transition() {
				_seqMethod = SeqMethods.First2;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public First2Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_predicateArg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _sourceArg, _predicateArg }.Select(a => a.Expression);
			}
			
			public First2Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_predicateArg.Expression = ex.Arguments[1];
			}
	  }


	  partial class FirstOrDefaultTransition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}

		
			static FirstOrDefaultTransition() {
				_seqMethod = SeqMethods.FirstOrDefault;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public FirstOrDefaultTransition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);

				Args = new[] { _sourceArg }.Select(a => a.Expression);
			}
			
			public FirstOrDefaultTransition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}
	  }


	  partial class FirstOrDefault2Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static FirstOrDefault2Transition() {
				_seqMethod = SeqMethods.FirstOrDefault2;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public FirstOrDefault2Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_predicateArg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _sourceArg, _predicateArg }.Select(a => a.Expression);
			}
			
			public FirstOrDefault2Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_predicateArg.Expression = ex.Arguments[1];
			}
	  }


	  partial class GroupByTransition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static GroupByTransition() {
				_seqMethod = SeqMethods.GroupBy;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public GroupByTransition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_keySelectorArg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _sourceArg, _keySelectorArg }.Select(a => a.Expression);
			}
			
			public GroupByTransition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_keySelectorArg.Expression = ex.Arguments[1];
			}
	  }


	  partial class GroupBy2Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static GroupBy2Transition() {
				_seqMethod = SeqMethods.GroupBy2;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public GroupBy2Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_keySelectorArg = new Arg(_paramTypes[1], _typeArgHub);
				_elementSelectorArg = new Arg(_paramTypes[2], _typeArgHub);

				Args = new[] { _sourceArg, _keySelectorArg, _elementSelectorArg }.Select(a => a.Expression);
			}
			
			public GroupBy2Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_keySelectorArg.Expression = ex.Arguments[1];
				_elementSelectorArg.Expression = ex.Arguments[2];
			}
	  }


	  partial class GroupBy3Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static GroupBy3Transition() {
				_seqMethod = SeqMethods.GroupBy3;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public GroupBy3Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_keySelectorArg = new Arg(_paramTypes[1], _typeArgHub);
				_comparerArg = new Arg(_paramTypes[2], _typeArgHub);

				Args = new[] { _sourceArg, _keySelectorArg, _comparerArg }.Select(a => a.Expression);
			}
			
			public GroupBy3Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_keySelectorArg.Expression = ex.Arguments[1];
				_comparerArg.Expression = ex.Arguments[2];
			}
	  }


	  partial class GroupBy4Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static GroupBy4Transition() {
				_seqMethod = SeqMethods.GroupBy4;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public GroupBy4Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_keySelectorArg = new Arg(_paramTypes[1], _typeArgHub);
				_elementSelectorArg = new Arg(_paramTypes[2], _typeArgHub);
				_comparerArg = new Arg(_paramTypes[3], _typeArgHub);

				Args = new[] { _sourceArg, _keySelectorArg, _elementSelectorArg, _comparerArg }.Select(a => a.Expression);
			}
			
			public GroupBy4Transition(MethodCallExpression ex) 
				: this()
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
	  }


	  partial class GroupBy5Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static GroupBy5Transition() {
				_seqMethod = SeqMethods.GroupBy5;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public GroupBy5Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_keySelectorArg = new Arg(_paramTypes[1], _typeArgHub);
				_elementSelectorArg = new Arg(_paramTypes[2], _typeArgHub);
				_resultSelectorArg = new Arg(_paramTypes[3], _typeArgHub);

				Args = new[] { _sourceArg, _keySelectorArg, _elementSelectorArg, _resultSelectorArg }.Select(a => a.Expression);
			}
			
			public GroupBy5Transition(MethodCallExpression ex) 
				: this()
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
	  }


	  partial class GroupBy6Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static GroupBy6Transition() {
				_seqMethod = SeqMethods.GroupBy6;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public GroupBy6Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_keySelectorArg = new Arg(_paramTypes[1], _typeArgHub);
				_resultSelectorArg = new Arg(_paramTypes[2], _typeArgHub);

				Args = new[] { _sourceArg, _keySelectorArg, _resultSelectorArg }.Select(a => a.Expression);
			}
			
			public GroupBy6Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_keySelectorArg.Expression = ex.Arguments[1];
				_resultSelectorArg.Expression = ex.Arguments[2];
			}
	  }


	  partial class GroupBy7Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static GroupBy7Transition() {
				_seqMethod = SeqMethods.GroupBy7;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public GroupBy7Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_keySelectorArg = new Arg(_paramTypes[1], _typeArgHub);
				_resultSelectorArg = new Arg(_paramTypes[2], _typeArgHub);
				_comparerArg = new Arg(_paramTypes[3], _typeArgHub);

				Args = new[] { _sourceArg, _keySelectorArg, _resultSelectorArg, _comparerArg }.Select(a => a.Expression);
			}
			
			public GroupBy7Transition(MethodCallExpression ex) 
				: this()
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
	  }


	  partial class GroupBy8Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static GroupBy8Transition() {
				_seqMethod = SeqMethods.GroupBy8;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public GroupBy8Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_keySelectorArg = new Arg(_paramTypes[1], _typeArgHub);
				_elementSelectorArg = new Arg(_paramTypes[2], _typeArgHub);
				_resultSelectorArg = new Arg(_paramTypes[3], _typeArgHub);
				_comparerArg = new Arg(_paramTypes[4], _typeArgHub);

				Args = new[] { _sourceArg, _keySelectorArg, _elementSelectorArg, _resultSelectorArg, _comparerArg }.Select(a => a.Expression);
			}
			
			public GroupBy8Transition(MethodCallExpression ex) 
				: this()
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
	  }


	  partial class GroupJoinTransition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static GroupJoinTransition() {
				_seqMethod = SeqMethods.GroupJoin;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public GroupJoinTransition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_outerArg = new Arg(_paramTypes[0], _typeArgHub);
				_innerArg = new Arg(_paramTypes[1], _typeArgHub);
				_outerKeySelectorArg = new Arg(_paramTypes[2], _typeArgHub);
				_innerKeySelectorArg = new Arg(_paramTypes[3], _typeArgHub);
				_resultSelectorArg = new Arg(_paramTypes[4], _typeArgHub);

				Args = new[] { _outerArg, _innerArg, _outerKeySelectorArg, _innerKeySelectorArg, _resultSelectorArg }.Select(a => a.Expression);
			}
			
			public GroupJoinTransition(MethodCallExpression ex) 
				: this()
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
	  }


	  partial class GroupJoin2Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static GroupJoin2Transition() {
				_seqMethod = SeqMethods.GroupJoin2;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public GroupJoin2Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_outerArg = new Arg(_paramTypes[0], _typeArgHub);
				_innerArg = new Arg(_paramTypes[1], _typeArgHub);
				_outerKeySelectorArg = new Arg(_paramTypes[2], _typeArgHub);
				_innerKeySelectorArg = new Arg(_paramTypes[3], _typeArgHub);
				_resultSelectorArg = new Arg(_paramTypes[4], _typeArgHub);
				_comparerArg = new Arg(_paramTypes[5], _typeArgHub);

				Args = new[] { _outerArg, _innerArg, _outerKeySelectorArg, _innerKeySelectorArg, _resultSelectorArg, _comparerArg }.Select(a => a.Expression);
			}
			
			public GroupJoin2Transition(MethodCallExpression ex) 
				: this()
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
	  }


	  partial class IntersectTransition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static IntersectTransition() {
				_seqMethod = SeqMethods.Intersect;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public IntersectTransition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_source1Arg = new Arg(_paramTypes[0], _typeArgHub);
				_source2Arg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _source1Arg, _source2Arg }.Select(a => a.Expression);
			}
			
			public IntersectTransition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_source2Arg.Expression = ex.Arguments[1];
			}
	  }


	  partial class Intersect2Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static Intersect2Transition() {
				_seqMethod = SeqMethods.Intersect2;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public Intersect2Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_source1Arg = new Arg(_paramTypes[0], _typeArgHub);
				_source2Arg = new Arg(_paramTypes[1], _typeArgHub);
				_comparerArg = new Arg(_paramTypes[2], _typeArgHub);

				Args = new[] { _source1Arg, _source2Arg, _comparerArg }.Select(a => a.Expression);
			}
			
			public Intersect2Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_source2Arg.Expression = ex.Arguments[1];
				_comparerArg.Expression = ex.Arguments[2];
			}
	  }


	  partial class JoinTransition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static JoinTransition() {
				_seqMethod = SeqMethods.Join;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public JoinTransition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_outerArg = new Arg(_paramTypes[0], _typeArgHub);
				_innerArg = new Arg(_paramTypes[1], _typeArgHub);
				_outerKeySelectorArg = new Arg(_paramTypes[2], _typeArgHub);
				_innerKeySelectorArg = new Arg(_paramTypes[3], _typeArgHub);
				_resultSelectorArg = new Arg(_paramTypes[4], _typeArgHub);

				Args = new[] { _outerArg, _innerArg, _outerKeySelectorArg, _innerKeySelectorArg, _resultSelectorArg }.Select(a => a.Expression);
			}
			
			public JoinTransition(MethodCallExpression ex) 
				: this()
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
	  }


	  partial class Join2Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static Join2Transition() {
				_seqMethod = SeqMethods.Join2;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public Join2Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_outerArg = new Arg(_paramTypes[0], _typeArgHub);
				_innerArg = new Arg(_paramTypes[1], _typeArgHub);
				_outerKeySelectorArg = new Arg(_paramTypes[2], _typeArgHub);
				_innerKeySelectorArg = new Arg(_paramTypes[3], _typeArgHub);
				_resultSelectorArg = new Arg(_paramTypes[4], _typeArgHub);
				_comparerArg = new Arg(_paramTypes[5], _typeArgHub);

				Args = new[] { _outerArg, _innerArg, _outerKeySelectorArg, _innerKeySelectorArg, _resultSelectorArg, _comparerArg }.Select(a => a.Expression);
			}
			
			public Join2Transition(MethodCallExpression ex) 
				: this()
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
	  }


	  partial class LastTransition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}

		
			static LastTransition() {
				_seqMethod = SeqMethods.Last;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public LastTransition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);

				Args = new[] { _sourceArg }.Select(a => a.Expression);
			}
			
			public LastTransition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}
	  }


	  partial class Last2Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static Last2Transition() {
				_seqMethod = SeqMethods.Last2;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public Last2Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_predicateArg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _sourceArg, _predicateArg }.Select(a => a.Expression);
			}
			
			public Last2Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_predicateArg.Expression = ex.Arguments[1];
			}
	  }


	  partial class LastOrDefaultTransition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}

		
			static LastOrDefaultTransition() {
				_seqMethod = SeqMethods.LastOrDefault;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public LastOrDefaultTransition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);

				Args = new[] { _sourceArg }.Select(a => a.Expression);
			}
			
			public LastOrDefaultTransition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}
	  }


	  partial class LastOrDefault2Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static LastOrDefault2Transition() {
				_seqMethod = SeqMethods.LastOrDefault2;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public LastOrDefault2Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_predicateArg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _sourceArg, _predicateArg }.Select(a => a.Expression);
			}
			
			public LastOrDefault2Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_predicateArg.Expression = ex.Arguments[1];
			}
	  }


	  partial class LongCountTransition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}

		
			static LongCountTransition() {
				_seqMethod = SeqMethods.LongCount;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public LongCountTransition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);

				Args = new[] { _sourceArg }.Select(a => a.Expression);
			}
			
			public LongCountTransition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}
	  }


	  partial class LongCount2Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static LongCount2Transition() {
				_seqMethod = SeqMethods.LongCount2;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public LongCount2Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_predicateArg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _sourceArg, _predicateArg }.Select(a => a.Expression);
			}
			
			public LongCount2Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_predicateArg.Expression = ex.Arguments[1];
			}
	  }


	  partial class MaxTransition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}

		
			static MaxTransition() {
				_seqMethod = SeqMethods.Max;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public MaxTransition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);

				Args = new[] { _sourceArg }.Select(a => a.Expression);
			}
			
			public MaxTransition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}
	  }


	  partial class Max2Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static Max2Transition() {
				_seqMethod = SeqMethods.Max2;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public Max2Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_selectorArg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _sourceArg, _selectorArg }.Select(a => a.Expression);
			}
			
			public Max2Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_selectorArg.Expression = ex.Arguments[1];
			}
	  }


	  partial class MinTransition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}

		
			static MinTransition() {
				_seqMethod = SeqMethods.Min;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public MinTransition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);

				Args = new[] { _sourceArg }.Select(a => a.Expression);
			}
			
			public MinTransition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}
	  }


	  partial class Min2Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static Min2Transition() {
				_seqMethod = SeqMethods.Min2;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public Min2Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_selectorArg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _sourceArg, _selectorArg }.Select(a => a.Expression);
			}
			
			public Min2Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_selectorArg.Expression = ex.Arguments[1];
			}
	  }


	  partial class OfTypeTransition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}

		
			static OfTypeTransition() {
				_seqMethod = SeqMethods.OfType;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public OfTypeTransition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);

				Args = new[] { _sourceArg }.Select(a => a.Expression);
			}
			
			public OfTypeTransition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}
	  }


	  partial class OrderByTransition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static OrderByTransition() {
				_seqMethod = SeqMethods.OrderBy;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public OrderByTransition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_keySelectorArg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _sourceArg, _keySelectorArg }.Select(a => a.Expression);
			}
			
			public OrderByTransition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_keySelectorArg.Expression = ex.Arguments[1];
			}
	  }


	  partial class OrderBy2Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static OrderBy2Transition() {
				_seqMethod = SeqMethods.OrderBy2;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public OrderBy2Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_keySelectorArg = new Arg(_paramTypes[1], _typeArgHub);
				_comparerArg = new Arg(_paramTypes[2], _typeArgHub);

				Args = new[] { _sourceArg, _keySelectorArg, _comparerArg }.Select(a => a.Expression);
			}
			
			public OrderBy2Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_keySelectorArg.Expression = ex.Arguments[1];
				_comparerArg.Expression = ex.Arguments[2];
			}
	  }


	  partial class OrderByDescendingTransition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static OrderByDescendingTransition() {
				_seqMethod = SeqMethods.OrderByDescending;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public OrderByDescendingTransition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_keySelectorArg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _sourceArg, _keySelectorArg }.Select(a => a.Expression);
			}
			
			public OrderByDescendingTransition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_keySelectorArg.Expression = ex.Arguments[1];
			}
	  }


	  partial class OrderByDescending2Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static OrderByDescending2Transition() {
				_seqMethod = SeqMethods.OrderByDescending2;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public OrderByDescending2Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_keySelectorArg = new Arg(_paramTypes[1], _typeArgHub);
				_comparerArg = new Arg(_paramTypes[2], _typeArgHub);

				Args = new[] { _sourceArg, _keySelectorArg, _comparerArg }.Select(a => a.Expression);
			}
			
			public OrderByDescending2Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_keySelectorArg.Expression = ex.Arguments[1];
				_comparerArg.Expression = ex.Arguments[2];
			}
	  }


	  partial class ReverseTransition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}

		
			static ReverseTransition() {
				_seqMethod = SeqMethods.Reverse;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public ReverseTransition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);

				Args = new[] { _sourceArg }.Select(a => a.Expression);
			}
			
			public ReverseTransition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}
	  }


	  partial class SelectTransition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static SelectTransition() {
				_seqMethod = SeqMethods.Select;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public SelectTransition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_selectorArg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _sourceArg, _selectorArg }.Select(a => a.Expression);
			}
			
			public SelectTransition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_selectorArg.Expression = ex.Arguments[1];
			}
	  }


	  partial class Select2Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static Select2Transition() {
				_seqMethod = SeqMethods.Select2;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public Select2Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_selectorArg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _sourceArg, _selectorArg }.Select(a => a.Expression);
			}
			
			public Select2Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_selectorArg.Expression = ex.Arguments[1];
			}
	  }


	  partial class SelectManyTransition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static SelectManyTransition() {
				_seqMethod = SeqMethods.SelectMany;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public SelectManyTransition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_selectorArg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _sourceArg, _selectorArg }.Select(a => a.Expression);
			}
			
			public SelectManyTransition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_selectorArg.Expression = ex.Arguments[1];
			}
	  }


	  partial class SelectMany2Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static SelectMany2Transition() {
				_seqMethod = SeqMethods.SelectMany2;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public SelectMany2Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_selectorArg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _sourceArg, _selectorArg }.Select(a => a.Expression);
			}
			
			public SelectMany2Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_selectorArg.Expression = ex.Arguments[1];
			}
	  }


	  partial class SelectMany3Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static SelectMany3Transition() {
				_seqMethod = SeqMethods.SelectMany3;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public SelectMany3Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_collectionSelectorArg = new Arg(_paramTypes[1], _typeArgHub);
				_resultSelectorArg = new Arg(_paramTypes[2], _typeArgHub);

				Args = new[] { _sourceArg, _collectionSelectorArg, _resultSelectorArg }.Select(a => a.Expression);
			}
			
			public SelectMany3Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_collectionSelectorArg.Expression = ex.Arguments[1];
				_resultSelectorArg.Expression = ex.Arguments[2];
			}
	  }


	  partial class SelectMany4Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static SelectMany4Transition() {
				_seqMethod = SeqMethods.SelectMany4;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public SelectMany4Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_collectionSelectorArg = new Arg(_paramTypes[1], _typeArgHub);
				_resultSelectorArg = new Arg(_paramTypes[2], _typeArgHub);

				Args = new[] { _sourceArg, _collectionSelectorArg, _resultSelectorArg }.Select(a => a.Expression);
			}
			
			public SelectMany4Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_collectionSelectorArg.Expression = ex.Arguments[1];
				_resultSelectorArg.Expression = ex.Arguments[2];
			}
	  }


	  partial class SequenceEqualTransition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static SequenceEqualTransition() {
				_seqMethod = SeqMethods.SequenceEqual;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public SequenceEqualTransition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_source1Arg = new Arg(_paramTypes[0], _typeArgHub);
				_source2Arg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _source1Arg, _source2Arg }.Select(a => a.Expression);
			}
			
			public SequenceEqualTransition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_source2Arg.Expression = ex.Arguments[1];
			}
	  }


	  partial class SequenceEqual2Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static SequenceEqual2Transition() {
				_seqMethod = SeqMethods.SequenceEqual2;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public SequenceEqual2Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_source1Arg = new Arg(_paramTypes[0], _typeArgHub);
				_source2Arg = new Arg(_paramTypes[1], _typeArgHub);
				_comparerArg = new Arg(_paramTypes[2], _typeArgHub);

				Args = new[] { _source1Arg, _source2Arg, _comparerArg }.Select(a => a.Expression);
			}
			
			public SequenceEqual2Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_source2Arg.Expression = ex.Arguments[1];
				_comparerArg.Expression = ex.Arguments[2];
			}
	  }


	  partial class SingleTransition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}

		
			static SingleTransition() {
				_seqMethod = SeqMethods.Single;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public SingleTransition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);

				Args = new[] { _sourceArg }.Select(a => a.Expression);
			}
			
			public SingleTransition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}
	  }


	  partial class Single2Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static Single2Transition() {
				_seqMethod = SeqMethods.Single2;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public Single2Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_predicateArg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _sourceArg, _predicateArg }.Select(a => a.Expression);
			}
			
			public Single2Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_predicateArg.Expression = ex.Arguments[1];
			}
	  }


	  partial class SingleOrDefaultTransition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}

		
			static SingleOrDefaultTransition() {
				_seqMethod = SeqMethods.SingleOrDefault;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public SingleOrDefaultTransition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);

				Args = new[] { _sourceArg }.Select(a => a.Expression);
			}
			
			public SingleOrDefaultTransition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}
	  }


	  partial class SingleOrDefault2Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static SingleOrDefault2Transition() {
				_seqMethod = SeqMethods.SingleOrDefault2;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public SingleOrDefault2Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_predicateArg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _sourceArg, _predicateArg }.Select(a => a.Expression);
			}
			
			public SingleOrDefault2Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_predicateArg.Expression = ex.Arguments[1];
			}
	  }


	  partial class SkipTransition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static SkipTransition() {
				_seqMethod = SeqMethods.Skip;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public SkipTransition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_countArg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _sourceArg, _countArg }.Select(a => a.Expression);
			}
			
			public SkipTransition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_countArg.Expression = ex.Arguments[1];
			}
	  }


	  partial class SkipWhileTransition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static SkipWhileTransition() {
				_seqMethod = SeqMethods.SkipWhile;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public SkipWhileTransition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_predicateArg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _sourceArg, _predicateArg }.Select(a => a.Expression);
			}
			
			public SkipWhileTransition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_predicateArg.Expression = ex.Arguments[1];
			}
	  }


	  partial class SkipWhile2Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static SkipWhile2Transition() {
				_seqMethod = SeqMethods.SkipWhile2;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public SkipWhile2Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_predicateArg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _sourceArg, _predicateArg }.Select(a => a.Expression);
			}
			
			public SkipWhile2Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_predicateArg.Expression = ex.Arguments[1];
			}
	  }


	  partial class SumTransition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static SumTransition() {
				_seqMethod = SeqMethods.Sum;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public SumTransition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_selectorArg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _sourceArg, _selectorArg }.Select(a => a.Expression);
			}
			
			public SumTransition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_selectorArg.Expression = ex.Arguments[1];
			}
	  }


	  partial class Sum10Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}

		
			static Sum10Transition() {
				_seqMethod = SeqMethods.Sum10;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public Sum10Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);

				Args = new[] { _sourceArg }.Select(a => a.Expression);
			}
			
			public Sum10Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}
	  }


	  partial class Sum11Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}

		
			static Sum11Transition() {
				_seqMethod = SeqMethods.Sum11;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public Sum11Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);

				Args = new[] { _sourceArg }.Select(a => a.Expression);
			}
			
			public Sum11Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}
	  }


	  partial class Sum12Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static Sum12Transition() {
				_seqMethod = SeqMethods.Sum12;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public Sum12Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_selectorArg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _sourceArg, _selectorArg }.Select(a => a.Expression);
			}
			
			public Sum12Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_selectorArg.Expression = ex.Arguments[1];
			}
	  }


	  partial class Sum13Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static Sum13Transition() {
				_seqMethod = SeqMethods.Sum13;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public Sum13Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_selectorArg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _sourceArg, _selectorArg }.Select(a => a.Expression);
			}
			
			public Sum13Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_selectorArg.Expression = ex.Arguments[1];
			}
	  }


	  partial class Sum14Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static Sum14Transition() {
				_seqMethod = SeqMethods.Sum14;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public Sum14Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_selectorArg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _sourceArg, _selectorArg }.Select(a => a.Expression);
			}
			
			public Sum14Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_selectorArg.Expression = ex.Arguments[1];
			}
	  }


	  partial class Sum15Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static Sum15Transition() {
				_seqMethod = SeqMethods.Sum15;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public Sum15Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_selectorArg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _sourceArg, _selectorArg }.Select(a => a.Expression);
			}
			
			public Sum15Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_selectorArg.Expression = ex.Arguments[1];
			}
	  }


	  partial class Sum16Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static Sum16Transition() {
				_seqMethod = SeqMethods.Sum16;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public Sum16Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_selectorArg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _sourceArg, _selectorArg }.Select(a => a.Expression);
			}
			
			public Sum16Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_selectorArg.Expression = ex.Arguments[1];
			}
	  }


	  partial class Sum17Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static Sum17Transition() {
				_seqMethod = SeqMethods.Sum17;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public Sum17Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_selectorArg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _sourceArg, _selectorArg }.Select(a => a.Expression);
			}
			
			public Sum17Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_selectorArg.Expression = ex.Arguments[1];
			}
	  }


	  partial class Sum18Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static Sum18Transition() {
				_seqMethod = SeqMethods.Sum18;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public Sum18Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_selectorArg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _sourceArg, _selectorArg }.Select(a => a.Expression);
			}
			
			public Sum18Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_selectorArg.Expression = ex.Arguments[1];
			}
	  }


	  partial class Sum19Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static Sum19Transition() {
				_seqMethod = SeqMethods.Sum19;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public Sum19Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_selectorArg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _sourceArg, _selectorArg }.Select(a => a.Expression);
			}
			
			public Sum19Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_selectorArg.Expression = ex.Arguments[1];
			}
	  }


	  partial class Sum2Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}

		
			static Sum2Transition() {
				_seqMethod = SeqMethods.Sum2;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public Sum2Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);

				Args = new[] { _sourceArg }.Select(a => a.Expression);
			}
			
			public Sum2Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}
	  }


	  partial class Sum20Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static Sum20Transition() {
				_seqMethod = SeqMethods.Sum20;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public Sum20Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_selectorArg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _sourceArg, _selectorArg }.Select(a => a.Expression);
			}
			
			public Sum20Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_selectorArg.Expression = ex.Arguments[1];
			}
	  }


	  partial class Sum3Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}

		
			static Sum3Transition() {
				_seqMethod = SeqMethods.Sum3;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public Sum3Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);

				Args = new[] { _sourceArg }.Select(a => a.Expression);
			}
			
			public Sum3Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}
	  }


	  partial class Sum4Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}

		
			static Sum4Transition() {
				_seqMethod = SeqMethods.Sum4;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public Sum4Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);

				Args = new[] { _sourceArg }.Select(a => a.Expression);
			}
			
			public Sum4Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}
	  }


	  partial class Sum5Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}

		
			static Sum5Transition() {
				_seqMethod = SeqMethods.Sum5;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public Sum5Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);

				Args = new[] { _sourceArg }.Select(a => a.Expression);
			}
			
			public Sum5Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}
	  }


	  partial class Sum6Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}

		
			static Sum6Transition() {
				_seqMethod = SeqMethods.Sum6;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public Sum6Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);

				Args = new[] { _sourceArg }.Select(a => a.Expression);
			}
			
			public Sum6Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}
	  }


	  partial class Sum7Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}

		
			static Sum7Transition() {
				_seqMethod = SeqMethods.Sum7;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public Sum7Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);

				Args = new[] { _sourceArg }.Select(a => a.Expression);
			}
			
			public Sum7Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}
	  }


	  partial class Sum8Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}

		
			static Sum8Transition() {
				_seqMethod = SeqMethods.Sum8;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public Sum8Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);

				Args = new[] { _sourceArg }.Select(a => a.Expression);
			}
			
			public Sum8Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}
	  }


	  partial class Sum9Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

			readonly Arg _sourceArg;
			
			public Expression Source {
				get { return _sourceArg.Expression; }
				set { _sourceArg.Expression = value; }
			}

		
			static Sum9Transition() {
				_seqMethod = SeqMethods.Sum9;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public Sum9Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);

				Args = new[] { _sourceArg }.Select(a => a.Expression);
			}
			
			public Sum9Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

			}
	  }


	  partial class TakeTransition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static TakeTransition() {
				_seqMethod = SeqMethods.Take;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public TakeTransition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_countArg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _sourceArg, _countArg }.Select(a => a.Expression);
			}
			
			public TakeTransition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_countArg.Expression = ex.Arguments[1];
			}
	  }


	  partial class TakeWhileTransition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static TakeWhileTransition() {
				_seqMethod = SeqMethods.TakeWhile;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public TakeWhileTransition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_predicateArg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _sourceArg, _predicateArg }.Select(a => a.Expression);
			}
			
			public TakeWhileTransition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_predicateArg.Expression = ex.Arguments[1];
			}
	  }


	  partial class TakeWhile2Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static TakeWhile2Transition() {
				_seqMethod = SeqMethods.TakeWhile2;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public TakeWhile2Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_predicateArg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _sourceArg, _predicateArg }.Select(a => a.Expression);
			}
			
			public TakeWhile2Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_predicateArg.Expression = ex.Arguments[1];
			}
	  }


	  partial class ThenByTransition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static ThenByTransition() {
				_seqMethod = SeqMethods.ThenBy;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public ThenByTransition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_keySelectorArg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _sourceArg, _keySelectorArg }.Select(a => a.Expression);
			}
			
			public ThenByTransition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_keySelectorArg.Expression = ex.Arguments[1];
			}
	  }


	  partial class ThenBy2Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static ThenBy2Transition() {
				_seqMethod = SeqMethods.ThenBy2;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public ThenBy2Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_keySelectorArg = new Arg(_paramTypes[1], _typeArgHub);
				_comparerArg = new Arg(_paramTypes[2], _typeArgHub);

				Args = new[] { _sourceArg, _keySelectorArg, _comparerArg }.Select(a => a.Expression);
			}
			
			public ThenBy2Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_keySelectorArg.Expression = ex.Arguments[1];
				_comparerArg.Expression = ex.Arguments[2];
			}
	  }


	  partial class ThenByDescendingTransition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static ThenByDescendingTransition() {
				_seqMethod = SeqMethods.ThenByDescending;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public ThenByDescendingTransition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_keySelectorArg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _sourceArg, _keySelectorArg }.Select(a => a.Expression);
			}
			
			public ThenByDescendingTransition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_keySelectorArg.Expression = ex.Arguments[1];
			}
	  }


	  partial class ThenByDescending2Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static ThenByDescending2Transition() {
				_seqMethod = SeqMethods.ThenByDescending2;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public ThenByDescending2Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_keySelectorArg = new Arg(_paramTypes[1], _typeArgHub);
				_comparerArg = new Arg(_paramTypes[2], _typeArgHub);

				Args = new[] { _sourceArg, _keySelectorArg, _comparerArg }.Select(a => a.Expression);
			}
			
			public ThenByDescending2Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_keySelectorArg.Expression = ex.Arguments[1];
				_comparerArg.Expression = ex.Arguments[2];
			}
	  }


	  partial class UnionTransition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static UnionTransition() {
				_seqMethod = SeqMethods.Union;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public UnionTransition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_source1Arg = new Arg(_paramTypes[0], _typeArgHub);
				_source2Arg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _source1Arg, _source2Arg }.Select(a => a.Expression);
			}
			
			public UnionTransition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_source2Arg.Expression = ex.Arguments[1];
			}
	  }


	  partial class Union2Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static Union2Transition() {
				_seqMethod = SeqMethods.Union2;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public Union2Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_source1Arg = new Arg(_paramTypes[0], _typeArgHub);
				_source2Arg = new Arg(_paramTypes[1], _typeArgHub);
				_comparerArg = new Arg(_paramTypes[2], _typeArgHub);

				Args = new[] { _source1Arg, _source2Arg, _comparerArg }.Select(a => a.Expression);
			}
			
			public Union2Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_source2Arg.Expression = ex.Arguments[1];
				_comparerArg.Expression = ex.Arguments[2];
			}
	  }


	  partial class WhereTransition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static WhereTransition() {
				_seqMethod = SeqMethods.Where;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public WhereTransition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_predicateArg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _sourceArg, _predicateArg }.Select(a => a.Expression);
			}
			
			public WhereTransition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_predicateArg.Expression = ex.Arguments[1];
			}
	  }


	  partial class Where2Transition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static Where2Transition() {
				_seqMethod = SeqMethods.Where2;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public Where2Transition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_sourceArg = new Arg(_paramTypes[0], _typeArgHub);
				_predicateArg = new Arg(_paramTypes[1], _typeArgHub);

				Args = new[] { _sourceArg, _predicateArg }.Select(a => a.Expression);
			}
			
			public Where2Transition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_predicateArg.Expression = ex.Arguments[1];
			}
	  }


	  partial class ZipTransition : SeqTransition 
	  { 
			static readonly SeqMethod _seqMethod;
			static readonly Type[] _paramTypes;
			static readonly Type[] _typeParams;

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

		
			static ZipTransition() {
				_seqMethod = SeqMethods.Zip;
				_paramTypes = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
				_typeParams = _seqMethod.Qy.GetGenericArguments();
			}


			public ZipTransition()
			{
				SeqMethod = _seqMethod;

				_typeArgHub = new TypeArgHub(_typeParams);
								
				_source1Arg = new Arg(_paramTypes[0], _typeArgHub);
				_source2Arg = new Arg(_paramTypes[1], _typeArgHub);
				_resultSelectorArg = new Arg(_paramTypes[2], _typeArgHub);

				Args = new[] { _source1Arg, _source2Arg, _resultSelectorArg }.Select(a => a.Expression);
			}
			
			public ZipTransition(MethodCallExpression ex) 
				: this()
			{
				var origTypeArgs = _typeParams.Zip(ex.Method.GetGenericArguments(), 
															(p, a) => new TypeArg(p, a));
				foreach(var typeArg in origTypeArgs) {
					_typeArgHub.Register(typeArg, null);
				}

				_source2Arg.Expression = ex.Arguments[1];
				_resultSelectorArg.Expression = ex.Arguments[2];
			}
	  }


}

