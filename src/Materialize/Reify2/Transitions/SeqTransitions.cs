using Materialize.SequenceMethods;
using Materialize.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify2.Transitions 
{
	  partial class AggregateTransition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Aggregate;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vFunc;

			public Expression Func {
				get { return _vFunc.Expression; }
				set { _vFunc.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vFunc.Expression }; }
			}
			
			public AggregateTransition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vFunc = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public AggregateTransition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vFunc.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class Aggregate2Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Aggregate2;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
		
        	
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
		
        	
			readonly ArgValue _vSeed;

			public Expression Seed {
				get { return _vSeed.Expression; }
				set { _vSeed.Expression = value; }
			} 
			

			readonly ArgValue _vFunc;

			public Expression Func {
				get { return _vFunc.Expression; }
				set { _vFunc.Expression = value; }
			} 
		

			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vSeed.Expression, _vFunc.Expression }; }
			}
			
			public Aggregate2Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vSeed = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
				_vFunc = new ArgValue(new[] { _modes[0].Args[2], _modes[1].Args[2] });
			}
			
			public Aggregate2Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vSeed.Expression = ex.Arguments[1];
				_vFunc.Expression = ex.Arguments[2];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class Aggregate3Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Aggregate3;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vSeed;

			public Expression Seed {
				get { return _vSeed.Expression; }
				set { _vSeed.Expression = value; }
			} 
			
			readonly ArgValue _vFunc;

			public Expression Func {
				get { return _vFunc.Expression; }
				set { _vFunc.Expression = value; }
			} 
			
			readonly ArgValue _vResultSelector;

			public Expression ResultSelector {
				get { return _vResultSelector.Expression; }
				set { _vResultSelector.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vSeed.Expression, _vFunc.Expression, _vResultSelector.Expression }; }
			}
			
			public Aggregate3Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vSeed = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
				_vFunc = new ArgValue(new[] { _modes[0].Args[2], _modes[1].Args[2] });
				_vResultSelector = new ArgValue(new[] { _modes[0].Args[3], _modes[1].Args[3] });
			}
			
			public Aggregate3Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vSeed.Expression = ex.Arguments[1];
				_vFunc.Expression = ex.Arguments[2];
				_vResultSelector.Expression = ex.Arguments[3];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class AllTransition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.All;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vPredicate;

			public Expression Predicate {
				get { return _vPredicate.Expression; }
				set { _vPredicate.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vPredicate.Expression }; }
			}
			
			public AllTransition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vPredicate = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public AllTransition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vPredicate.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class AnyTransition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Any;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression }; }
			}
			
			public AnyTransition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
			}
			
			public AnyTransition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class Any2Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Any2;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vPredicate;

			public Expression Predicate {
				get { return _vPredicate.Expression; }
				set { _vPredicate.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vPredicate.Expression }; }
			}
			
			public Any2Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vPredicate = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public Any2Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vPredicate.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class AverageTransition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Average;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression }; }
			}
			
			public AverageTransition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
			}
			
			public AverageTransition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class Average10Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Average10;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression }; }
			}
			
			public Average10Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
			}
			
			public Average10Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class Average11Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Average11;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vSelector;

			public Expression Selector {
				get { return _vSelector.Expression; }
				set { _vSelector.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vSelector.Expression }; }
			}
			
			public Average11Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vSelector = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public Average11Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vSelector.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class Average12Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Average12;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vSelector;

			public Expression Selector {
				get { return _vSelector.Expression; }
				set { _vSelector.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vSelector.Expression }; }
			}
			
			public Average12Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vSelector = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public Average12Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vSelector.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class Average13Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Average13;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vSelector;

			public Expression Selector {
				get { return _vSelector.Expression; }
				set { _vSelector.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vSelector.Expression }; }
			}
			
			public Average13Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vSelector = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public Average13Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vSelector.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class Average14Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Average14;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vSelector;

			public Expression Selector {
				get { return _vSelector.Expression; }
				set { _vSelector.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vSelector.Expression }; }
			}
			
			public Average14Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vSelector = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public Average14Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vSelector.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class Average15Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Average15;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vSelector;

			public Expression Selector {
				get { return _vSelector.Expression; }
				set { _vSelector.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vSelector.Expression }; }
			}
			
			public Average15Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vSelector = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public Average15Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vSelector.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class Average16Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Average16;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vSelector;

			public Expression Selector {
				get { return _vSelector.Expression; }
				set { _vSelector.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vSelector.Expression }; }
			}
			
			public Average16Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vSelector = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public Average16Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vSelector.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class Average17Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Average17;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vSelector;

			public Expression Selector {
				get { return _vSelector.Expression; }
				set { _vSelector.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vSelector.Expression }; }
			}
			
			public Average17Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vSelector = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public Average17Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vSelector.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class Average18Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Average18;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vSelector;

			public Expression Selector {
				get { return _vSelector.Expression; }
				set { _vSelector.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vSelector.Expression }; }
			}
			
			public Average18Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vSelector = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public Average18Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vSelector.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class Average19Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Average19;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vSelector;

			public Expression Selector {
				get { return _vSelector.Expression; }
				set { _vSelector.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vSelector.Expression }; }
			}
			
			public Average19Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vSelector = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public Average19Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vSelector.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class Average2Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Average2;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression }; }
			}
			
			public Average2Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
			}
			
			public Average2Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class Average20Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Average20;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vSelector;

			public Expression Selector {
				get { return _vSelector.Expression; }
				set { _vSelector.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vSelector.Expression }; }
			}
			
			public Average20Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vSelector = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public Average20Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vSelector.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class Average3Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Average3;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression }; }
			}
			
			public Average3Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
			}
			
			public Average3Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class Average4Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Average4;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression }; }
			}
			
			public Average4Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
			}
			
			public Average4Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class Average5Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Average5;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression }; }
			}
			
			public Average5Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
			}
			
			public Average5Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class Average6Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Average6;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression }; }
			}
			
			public Average6Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
			}
			
			public Average6Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class Average7Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Average7;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression }; }
			}
			
			public Average7Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
			}
			
			public Average7Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class Average8Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Average8;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression }; }
			}
			
			public Average8Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
			}
			
			public Average8Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class Average9Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Average9;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression }; }
			}
			
			public Average9Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
			}
			
			public Average9Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class CastTransition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Cast;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression }; }
			}
			
			public CastTransition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
			}
			
			public CastTransition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class ConcatTransition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Concat;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vFirst;

			public Expression First {
				get { return _vFirst.Expression; }
				set { _vFirst.Expression = value; }
			} 
			
			readonly ArgValue _vSecond;

			public Expression Second {
				get { return _vSecond.Expression; }
				set { _vSecond.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vFirst.Expression, _vSecond.Expression }; }
			}
			
			public ConcatTransition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vFirst = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vSecond = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public ConcatTransition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vSecond.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vFirst.Expression; }
				set { _vFirst.Expression = value; }
			}
	  } 


	  partial class ContainsTransition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Contains;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vValue;

			public Expression Value {
				get { return _vValue.Expression; }
				set { _vValue.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vValue.Expression }; }
			}
			
			public ContainsTransition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vValue = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public ContainsTransition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vValue.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class Contains2Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Contains2;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vValue;

			public Expression Value {
				get { return _vValue.Expression; }
				set { _vValue.Expression = value; }
			} 
			
			readonly ArgValue _vComparer;

			public Expression Comparer {
				get { return _vComparer.Expression; }
				set { _vComparer.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vValue.Expression, _vComparer.Expression }; }
			}
			
			public Contains2Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vValue = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
				_vComparer = new ArgValue(new[] { _modes[0].Args[2], _modes[1].Args[2] });
			}
			
			public Contains2Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vValue.Expression = ex.Arguments[1];
				_vComparer.Expression = ex.Arguments[2];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class CountTransition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Count;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression }; }
			}
			
			public CountTransition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
			}
			
			public CountTransition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class Count2Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Count2;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vPredicate;

			public Expression Predicate {
				get { return _vPredicate.Expression; }
				set { _vPredicate.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vPredicate.Expression }; }
			}
			
			public Count2Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vPredicate = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public Count2Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vPredicate.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class DefaultIfEmptyTransition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.DefaultIfEmpty;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression }; }
			}
			
			public DefaultIfEmptyTransition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
			}
			
			public DefaultIfEmptyTransition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class DefaultIfEmpty2Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.DefaultIfEmpty2;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vDefaultValue;

			public Expression DefaultValue {
				get { return _vDefaultValue.Expression; }
				set { _vDefaultValue.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vDefaultValue.Expression }; }
			}
			
			public DefaultIfEmpty2Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vDefaultValue = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public DefaultIfEmpty2Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vDefaultValue.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class DistinctTransition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Distinct;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression }; }
			}
			
			public DistinctTransition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
			}
			
			public DistinctTransition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class Distinct2Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Distinct2;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vComparer;

			public Expression Comparer {
				get { return _vComparer.Expression; }
				set { _vComparer.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vComparer.Expression }; }
			}
			
			public Distinct2Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vComparer = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public Distinct2Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vComparer.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class ElementAtTransition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.ElementAt;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vIndex;

			public Expression Index {
				get { return _vIndex.Expression; }
				set { _vIndex.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vIndex.Expression }; }
			}
			
			public ElementAtTransition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vIndex = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public ElementAtTransition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vIndex.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class ElementAtOrDefaultTransition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.ElementAtOrDefault;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vIndex;

			public Expression Index {
				get { return _vIndex.Expression; }
				set { _vIndex.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vIndex.Expression }; }
			}
			
			public ElementAtOrDefaultTransition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vIndex = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public ElementAtOrDefaultTransition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vIndex.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class ExceptTransition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Except;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vFirst;

			public Expression First {
				get { return _vFirst.Expression; }
				set { _vFirst.Expression = value; }
			} 
			
			readonly ArgValue _vSecond;

			public Expression Second {
				get { return _vSecond.Expression; }
				set { _vSecond.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vFirst.Expression, _vSecond.Expression }; }
			}
			
			public ExceptTransition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vFirst = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vSecond = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public ExceptTransition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vSecond.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vFirst.Expression; }
				set { _vFirst.Expression = value; }
			}
	  } 


	  partial class Except2Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Except2;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vFirst;

			public Expression First {
				get { return _vFirst.Expression; }
				set { _vFirst.Expression = value; }
			} 
			
			readonly ArgValue _vSecond;

			public Expression Second {
				get { return _vSecond.Expression; }
				set { _vSecond.Expression = value; }
			} 
			
			readonly ArgValue _vComparer;

			public Expression Comparer {
				get { return _vComparer.Expression; }
				set { _vComparer.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vFirst.Expression, _vSecond.Expression, _vComparer.Expression }; }
			}
			
			public Except2Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vFirst = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vSecond = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
				_vComparer = new ArgValue(new[] { _modes[0].Args[2], _modes[1].Args[2] });
			}
			
			public Except2Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vSecond.Expression = ex.Arguments[1];
				_vComparer.Expression = ex.Arguments[2];
			}

			Expression ITakesSource.Source {
				get { return _vFirst.Expression; }
				set { _vFirst.Expression = value; }
			}
	  } 


	  partial class FirstTransition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.First;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression }; }
			}
			
			public FirstTransition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
			}
			
			public FirstTransition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class First2Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.First2;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vPredicate;

			public Expression Predicate {
				get { return _vPredicate.Expression; }
				set { _vPredicate.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vPredicate.Expression }; }
			}
			
			public First2Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vPredicate = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public First2Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vPredicate.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class FirstOrDefaultTransition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.FirstOrDefault;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression }; }
			}
			
			public FirstOrDefaultTransition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
			}
			
			public FirstOrDefaultTransition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class FirstOrDefault2Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.FirstOrDefault2;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vPredicate;

			public Expression Predicate {
				get { return _vPredicate.Expression; }
				set { _vPredicate.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vPredicate.Expression }; }
			}
			
			public FirstOrDefault2Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vPredicate = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public FirstOrDefault2Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vPredicate.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class GroupByTransition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.GroupBy;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vKeySelector;

			public Expression KeySelector {
				get { return _vKeySelector.Expression; }
				set { _vKeySelector.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vKeySelector.Expression }; }
			}
			
			public GroupByTransition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vKeySelector = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public GroupByTransition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vKeySelector.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class GroupBy2Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.GroupBy2;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vKeySelector;

			public Expression KeySelector {
				get { return _vKeySelector.Expression; }
				set { _vKeySelector.Expression = value; }
			} 
			
			readonly ArgValue _vElementSelector;

			public Expression ElementSelector {
				get { return _vElementSelector.Expression; }
				set { _vElementSelector.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vKeySelector.Expression, _vElementSelector.Expression }; }
			}
			
			public GroupBy2Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vKeySelector = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
				_vElementSelector = new ArgValue(new[] { _modes[0].Args[2], _modes[1].Args[2] });
			}
			
			public GroupBy2Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vKeySelector.Expression = ex.Arguments[1];
				_vElementSelector.Expression = ex.Arguments[2];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class GroupBy3Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.GroupBy3;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vKeySelector;

			public Expression KeySelector {
				get { return _vKeySelector.Expression; }
				set { _vKeySelector.Expression = value; }
			} 
			
			readonly ArgValue _vComparer;

			public Expression Comparer {
				get { return _vComparer.Expression; }
				set { _vComparer.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vKeySelector.Expression, _vComparer.Expression }; }
			}
			
			public GroupBy3Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vKeySelector = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
				_vComparer = new ArgValue(new[] { _modes[0].Args[2], _modes[1].Args[2] });
			}
			
			public GroupBy3Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vKeySelector.Expression = ex.Arguments[1];
				_vComparer.Expression = ex.Arguments[2];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class GroupBy4Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.GroupBy4;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vKeySelector;

			public Expression KeySelector {
				get { return _vKeySelector.Expression; }
				set { _vKeySelector.Expression = value; }
			} 
			
			readonly ArgValue _vElementSelector;

			public Expression ElementSelector {
				get { return _vElementSelector.Expression; }
				set { _vElementSelector.Expression = value; }
			} 
			
			readonly ArgValue _vComparer;

			public Expression Comparer {
				get { return _vComparer.Expression; }
				set { _vComparer.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vKeySelector.Expression, _vElementSelector.Expression, _vComparer.Expression }; }
			}
			
			public GroupBy4Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vKeySelector = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
				_vElementSelector = new ArgValue(new[] { _modes[0].Args[2], _modes[1].Args[2] });
				_vComparer = new ArgValue(new[] { _modes[0].Args[3], _modes[1].Args[3] });
			}
			
			public GroupBy4Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vKeySelector.Expression = ex.Arguments[1];
				_vElementSelector.Expression = ex.Arguments[2];
				_vComparer.Expression = ex.Arguments[3];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class GroupBy5Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.GroupBy5;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vKeySelector;

			public Expression KeySelector {
				get { return _vKeySelector.Expression; }
				set { _vKeySelector.Expression = value; }
			} 
			
			readonly ArgValue _vElementSelector;

			public Expression ElementSelector {
				get { return _vElementSelector.Expression; }
				set { _vElementSelector.Expression = value; }
			} 
			
			readonly ArgValue _vResultSelector;

			public Expression ResultSelector {
				get { return _vResultSelector.Expression; }
				set { _vResultSelector.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vKeySelector.Expression, _vElementSelector.Expression, _vResultSelector.Expression }; }
			}
			
			public GroupBy5Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vKeySelector = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
				_vElementSelector = new ArgValue(new[] { _modes[0].Args[2], _modes[1].Args[2] });
				_vResultSelector = new ArgValue(new[] { _modes[0].Args[3], _modes[1].Args[3] });
			}
			
			public GroupBy5Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vKeySelector.Expression = ex.Arguments[1];
				_vElementSelector.Expression = ex.Arguments[2];
				_vResultSelector.Expression = ex.Arguments[3];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class GroupBy6Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.GroupBy6;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vKeySelector;

			public Expression KeySelector {
				get { return _vKeySelector.Expression; }
				set { _vKeySelector.Expression = value; }
			} 
			
			readonly ArgValue _vResultSelector;

			public Expression ResultSelector {
				get { return _vResultSelector.Expression; }
				set { _vResultSelector.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vKeySelector.Expression, _vResultSelector.Expression }; }
			}
			
			public GroupBy6Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vKeySelector = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
				_vResultSelector = new ArgValue(new[] { _modes[0].Args[2], _modes[1].Args[2] });
			}
			
			public GroupBy6Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vKeySelector.Expression = ex.Arguments[1];
				_vResultSelector.Expression = ex.Arguments[2];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class GroupBy7Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.GroupBy7;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vKeySelector;

			public Expression KeySelector {
				get { return _vKeySelector.Expression; }
				set { _vKeySelector.Expression = value; }
			} 
			
			readonly ArgValue _vResultSelector;

			public Expression ResultSelector {
				get { return _vResultSelector.Expression; }
				set { _vResultSelector.Expression = value; }
			} 
			
			readonly ArgValue _vComparer;

			public Expression Comparer {
				get { return _vComparer.Expression; }
				set { _vComparer.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vKeySelector.Expression, _vResultSelector.Expression, _vComparer.Expression }; }
			}
			
			public GroupBy7Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vKeySelector = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
				_vResultSelector = new ArgValue(new[] { _modes[0].Args[2], _modes[1].Args[2] });
				_vComparer = new ArgValue(new[] { _modes[0].Args[3], _modes[1].Args[3] });
			}
			
			public GroupBy7Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vKeySelector.Expression = ex.Arguments[1];
				_vResultSelector.Expression = ex.Arguments[2];
				_vComparer.Expression = ex.Arguments[3];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class GroupBy8Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.GroupBy8;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vKeySelector;

			public Expression KeySelector {
				get { return _vKeySelector.Expression; }
				set { _vKeySelector.Expression = value; }
			} 
			
			readonly ArgValue _vElementSelector;

			public Expression ElementSelector {
				get { return _vElementSelector.Expression; }
				set { _vElementSelector.Expression = value; }
			} 
			
			readonly ArgValue _vResultSelector;

			public Expression ResultSelector {
				get { return _vResultSelector.Expression; }
				set { _vResultSelector.Expression = value; }
			} 
			
			readonly ArgValue _vComparer;

			public Expression Comparer {
				get { return _vComparer.Expression; }
				set { _vComparer.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vKeySelector.Expression, _vElementSelector.Expression, _vResultSelector.Expression, _vComparer.Expression }; }
			}
			
			public GroupBy8Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vKeySelector = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
				_vElementSelector = new ArgValue(new[] { _modes[0].Args[2], _modes[1].Args[2] });
				_vResultSelector = new ArgValue(new[] { _modes[0].Args[3], _modes[1].Args[3] });
				_vComparer = new ArgValue(new[] { _modes[0].Args[4], _modes[1].Args[4] });
			}
			
			public GroupBy8Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vKeySelector.Expression = ex.Arguments[1];
				_vElementSelector.Expression = ex.Arguments[2];
				_vResultSelector.Expression = ex.Arguments[3];
				_vComparer.Expression = ex.Arguments[4];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class GroupJoinTransition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.GroupJoin;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vOuter;

			public Expression Outer {
				get { return _vOuter.Expression; }
				set { _vOuter.Expression = value; }
			} 
			
			readonly ArgValue _vInner;

			public Expression Inner {
				get { return _vInner.Expression; }
				set { _vInner.Expression = value; }
			} 
			
			readonly ArgValue _vOuterKeySelector;

			public Expression OuterKeySelector {
				get { return _vOuterKeySelector.Expression; }
				set { _vOuterKeySelector.Expression = value; }
			} 
			
			readonly ArgValue _vInnerKeySelector;

			public Expression InnerKeySelector {
				get { return _vInnerKeySelector.Expression; }
				set { _vInnerKeySelector.Expression = value; }
			} 
			
			readonly ArgValue _vResultSelector;

			public Expression ResultSelector {
				get { return _vResultSelector.Expression; }
				set { _vResultSelector.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vOuter.Expression, _vInner.Expression, _vOuterKeySelector.Expression, _vInnerKeySelector.Expression, _vResultSelector.Expression }; }
			}
			
			public GroupJoinTransition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vOuter = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vInner = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
				_vOuterKeySelector = new ArgValue(new[] { _modes[0].Args[2], _modes[1].Args[2] });
				_vInnerKeySelector = new ArgValue(new[] { _modes[0].Args[3], _modes[1].Args[3] });
				_vResultSelector = new ArgValue(new[] { _modes[0].Args[4], _modes[1].Args[4] });
			}
			
			public GroupJoinTransition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vInner.Expression = ex.Arguments[1];
				_vOuterKeySelector.Expression = ex.Arguments[2];
				_vInnerKeySelector.Expression = ex.Arguments[3];
				_vResultSelector.Expression = ex.Arguments[4];
			}

			Expression ITakesSource.Source {
				get { return _vOuter.Expression; }
				set { _vOuter.Expression = value; }
			}
	  } 


	  partial class GroupJoin2Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.GroupJoin2;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vOuter;

			public Expression Outer {
				get { return _vOuter.Expression; }
				set { _vOuter.Expression = value; }
			} 
			
			readonly ArgValue _vInner;

			public Expression Inner {
				get { return _vInner.Expression; }
				set { _vInner.Expression = value; }
			} 
			
			readonly ArgValue _vOuterKeySelector;

			public Expression OuterKeySelector {
				get { return _vOuterKeySelector.Expression; }
				set { _vOuterKeySelector.Expression = value; }
			} 
			
			readonly ArgValue _vInnerKeySelector;

			public Expression InnerKeySelector {
				get { return _vInnerKeySelector.Expression; }
				set { _vInnerKeySelector.Expression = value; }
			} 
			
			readonly ArgValue _vResultSelector;

			public Expression ResultSelector {
				get { return _vResultSelector.Expression; }
				set { _vResultSelector.Expression = value; }
			} 
			
			readonly ArgValue _vComparer;

			public Expression Comparer {
				get { return _vComparer.Expression; }
				set { _vComparer.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vOuter.Expression, _vInner.Expression, _vOuterKeySelector.Expression, _vInnerKeySelector.Expression, _vResultSelector.Expression, _vComparer.Expression }; }
			}
			
			public GroupJoin2Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vOuter = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vInner = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
				_vOuterKeySelector = new ArgValue(new[] { _modes[0].Args[2], _modes[1].Args[2] });
				_vInnerKeySelector = new ArgValue(new[] { _modes[0].Args[3], _modes[1].Args[3] });
				_vResultSelector = new ArgValue(new[] { _modes[0].Args[4], _modes[1].Args[4] });
				_vComparer = new ArgValue(new[] { _modes[0].Args[5], _modes[1].Args[5] });
			}
			
			public GroupJoin2Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vInner.Expression = ex.Arguments[1];
				_vOuterKeySelector.Expression = ex.Arguments[2];
				_vInnerKeySelector.Expression = ex.Arguments[3];
				_vResultSelector.Expression = ex.Arguments[4];
				_vComparer.Expression = ex.Arguments[5];
			}

			Expression ITakesSource.Source {
				get { return _vOuter.Expression; }
				set { _vOuter.Expression = value; }
			}
	  } 


	  partial class IntersectTransition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Intersect;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vFirst;

			public Expression First {
				get { return _vFirst.Expression; }
				set { _vFirst.Expression = value; }
			} 
			
			readonly ArgValue _vSecond;

			public Expression Second {
				get { return _vSecond.Expression; }
				set { _vSecond.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vFirst.Expression, _vSecond.Expression }; }
			}
			
			public IntersectTransition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vFirst = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vSecond = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public IntersectTransition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vSecond.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vFirst.Expression; }
				set { _vFirst.Expression = value; }
			}
	  } 


	  partial class Intersect2Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Intersect2;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vFirst;

			public Expression First {
				get { return _vFirst.Expression; }
				set { _vFirst.Expression = value; }
			} 
			
			readonly ArgValue _vSecond;

			public Expression Second {
				get { return _vSecond.Expression; }
				set { _vSecond.Expression = value; }
			} 
			
			readonly ArgValue _vComparer;

			public Expression Comparer {
				get { return _vComparer.Expression; }
				set { _vComparer.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vFirst.Expression, _vSecond.Expression, _vComparer.Expression }; }
			}
			
			public Intersect2Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vFirst = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vSecond = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
				_vComparer = new ArgValue(new[] { _modes[0].Args[2], _modes[1].Args[2] });
			}
			
			public Intersect2Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vSecond.Expression = ex.Arguments[1];
				_vComparer.Expression = ex.Arguments[2];
			}

			Expression ITakesSource.Source {
				get { return _vFirst.Expression; }
				set { _vFirst.Expression = value; }
			}
	  } 


	  partial class JoinTransition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Join;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vOuter;

			public Expression Outer {
				get { return _vOuter.Expression; }
				set { _vOuter.Expression = value; }
			} 
			
			readonly ArgValue _vInner;

			public Expression Inner {
				get { return _vInner.Expression; }
				set { _vInner.Expression = value; }
			} 
			
			readonly ArgValue _vOuterKeySelector;

			public Expression OuterKeySelector {
				get { return _vOuterKeySelector.Expression; }
				set { _vOuterKeySelector.Expression = value; }
			} 
			
			readonly ArgValue _vInnerKeySelector;

			public Expression InnerKeySelector {
				get { return _vInnerKeySelector.Expression; }
				set { _vInnerKeySelector.Expression = value; }
			} 
			
			readonly ArgValue _vResultSelector;

			public Expression ResultSelector {
				get { return _vResultSelector.Expression; }
				set { _vResultSelector.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vOuter.Expression, _vInner.Expression, _vOuterKeySelector.Expression, _vInnerKeySelector.Expression, _vResultSelector.Expression }; }
			}
			
			public JoinTransition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vOuter = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vInner = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
				_vOuterKeySelector = new ArgValue(new[] { _modes[0].Args[2], _modes[1].Args[2] });
				_vInnerKeySelector = new ArgValue(new[] { _modes[0].Args[3], _modes[1].Args[3] });
				_vResultSelector = new ArgValue(new[] { _modes[0].Args[4], _modes[1].Args[4] });
			}
			
			public JoinTransition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vInner.Expression = ex.Arguments[1];
				_vOuterKeySelector.Expression = ex.Arguments[2];
				_vInnerKeySelector.Expression = ex.Arguments[3];
				_vResultSelector.Expression = ex.Arguments[4];
			}

			Expression ITakesSource.Source {
				get { return _vOuter.Expression; }
				set { _vOuter.Expression = value; }
			}
	  } 


	  partial class Join2Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Join2;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vOuter;

			public Expression Outer {
				get { return _vOuter.Expression; }
				set { _vOuter.Expression = value; }
			} 
			
			readonly ArgValue _vInner;

			public Expression Inner {
				get { return _vInner.Expression; }
				set { _vInner.Expression = value; }
			} 
			
			readonly ArgValue _vOuterKeySelector;

			public Expression OuterKeySelector {
				get { return _vOuterKeySelector.Expression; }
				set { _vOuterKeySelector.Expression = value; }
			} 
			
			readonly ArgValue _vInnerKeySelector;

			public Expression InnerKeySelector {
				get { return _vInnerKeySelector.Expression; }
				set { _vInnerKeySelector.Expression = value; }
			} 
			
			readonly ArgValue _vResultSelector;

			public Expression ResultSelector {
				get { return _vResultSelector.Expression; }
				set { _vResultSelector.Expression = value; }
			} 
			
			readonly ArgValue _vComparer;

			public Expression Comparer {
				get { return _vComparer.Expression; }
				set { _vComparer.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vOuter.Expression, _vInner.Expression, _vOuterKeySelector.Expression, _vInnerKeySelector.Expression, _vResultSelector.Expression, _vComparer.Expression }; }
			}
			
			public Join2Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vOuter = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vInner = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
				_vOuterKeySelector = new ArgValue(new[] { _modes[0].Args[2], _modes[1].Args[2] });
				_vInnerKeySelector = new ArgValue(new[] { _modes[0].Args[3], _modes[1].Args[3] });
				_vResultSelector = new ArgValue(new[] { _modes[0].Args[4], _modes[1].Args[4] });
				_vComparer = new ArgValue(new[] { _modes[0].Args[5], _modes[1].Args[5] });
			}
			
			public Join2Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vInner.Expression = ex.Arguments[1];
				_vOuterKeySelector.Expression = ex.Arguments[2];
				_vInnerKeySelector.Expression = ex.Arguments[3];
				_vResultSelector.Expression = ex.Arguments[4];
				_vComparer.Expression = ex.Arguments[5];
			}

			Expression ITakesSource.Source {
				get { return _vOuter.Expression; }
				set { _vOuter.Expression = value; }
			}
	  } 


	  partial class LastTransition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Last;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression }; }
			}
			
			public LastTransition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
			}
			
			public LastTransition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class Last2Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Last2;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vPredicate;

			public Expression Predicate {
				get { return _vPredicate.Expression; }
				set { _vPredicate.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vPredicate.Expression }; }
			}
			
			public Last2Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vPredicate = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public Last2Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vPredicate.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class LastOrDefaultTransition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.LastOrDefault;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression }; }
			}
			
			public LastOrDefaultTransition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
			}
			
			public LastOrDefaultTransition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class LastOrDefault2Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.LastOrDefault2;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vPredicate;

			public Expression Predicate {
				get { return _vPredicate.Expression; }
				set { _vPredicate.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vPredicate.Expression }; }
			}
			
			public LastOrDefault2Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vPredicate = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public LastOrDefault2Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vPredicate.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class LongCountTransition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.LongCount;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression }; }
			}
			
			public LongCountTransition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
			}
			
			public LongCountTransition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class LongCount2Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.LongCount2;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vPredicate;

			public Expression Predicate {
				get { return _vPredicate.Expression; }
				set { _vPredicate.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vPredicate.Expression }; }
			}
			
			public LongCount2Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vPredicate = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public LongCount2Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vPredicate.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class MaxTransition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Max;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression }; }
			}
			
			public MaxTransition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
			}
			
			public MaxTransition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class Max2Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Max2;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vSelector;

			public Expression Selector {
				get { return _vSelector.Expression; }
				set { _vSelector.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vSelector.Expression }; }
			}
			
			public Max2Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vSelector = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public Max2Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vSelector.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class MinTransition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Min;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression }; }
			}
			
			public MinTransition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
			}
			
			public MinTransition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class Min2Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Min2;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vSelector;

			public Expression Selector {
				get { return _vSelector.Expression; }
				set { _vSelector.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vSelector.Expression }; }
			}
			
			public Min2Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vSelector = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public Min2Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vSelector.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class OfTypeTransition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.OfType;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression }; }
			}
			
			public OfTypeTransition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
			}
			
			public OfTypeTransition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class OrderByTransition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.OrderBy;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vKeySelector;

			public Expression KeySelector {
				get { return _vKeySelector.Expression; }
				set { _vKeySelector.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vKeySelector.Expression }; }
			}
			
			public OrderByTransition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vKeySelector = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public OrderByTransition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vKeySelector.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class OrderBy2Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.OrderBy2;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vKeySelector;

			public Expression KeySelector {
				get { return _vKeySelector.Expression; }
				set { _vKeySelector.Expression = value; }
			} 
			
			readonly ArgValue _vComparer;

			public Expression Comparer {
				get { return _vComparer.Expression; }
				set { _vComparer.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vKeySelector.Expression, _vComparer.Expression }; }
			}
			
			public OrderBy2Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vKeySelector = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
				_vComparer = new ArgValue(new[] { _modes[0].Args[2], _modes[1].Args[2] });
			}
			
			public OrderBy2Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vKeySelector.Expression = ex.Arguments[1];
				_vComparer.Expression = ex.Arguments[2];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class OrderByDescendingTransition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.OrderByDescending;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vKeySelector;

			public Expression KeySelector {
				get { return _vKeySelector.Expression; }
				set { _vKeySelector.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vKeySelector.Expression }; }
			}
			
			public OrderByDescendingTransition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vKeySelector = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public OrderByDescendingTransition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vKeySelector.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class OrderByDescending2Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.OrderByDescending2;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vKeySelector;

			public Expression KeySelector {
				get { return _vKeySelector.Expression; }
				set { _vKeySelector.Expression = value; }
			} 
			
			readonly ArgValue _vComparer;

			public Expression Comparer {
				get { return _vComparer.Expression; }
				set { _vComparer.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vKeySelector.Expression, _vComparer.Expression }; }
			}
			
			public OrderByDescending2Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vKeySelector = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
				_vComparer = new ArgValue(new[] { _modes[0].Args[2], _modes[1].Args[2] });
			}
			
			public OrderByDescending2Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vKeySelector.Expression = ex.Arguments[1];
				_vComparer.Expression = ex.Arguments[2];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class ReverseTransition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Reverse;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression }; }
			}
			
			public ReverseTransition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
			}
			
			public ReverseTransition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class SelectTransition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Select;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vSelector;

			public Expression Selector {
				get { return _vSelector.Expression; }
				set { _vSelector.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vSelector.Expression }; }
			}
			
			public SelectTransition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vSelector = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public SelectTransition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vSelector.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class Select2Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Select2;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vSelector;

			public Expression Selector {
				get { return _vSelector.Expression; }
				set { _vSelector.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vSelector.Expression }; }
			}
			
			public Select2Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vSelector = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public Select2Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vSelector.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class SelectManyTransition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.SelectMany;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vSelector;

			public Expression Selector {
				get { return _vSelector.Expression; }
				set { _vSelector.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vSelector.Expression }; }
			}
			
			public SelectManyTransition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vSelector = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public SelectManyTransition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vSelector.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class SelectMany2Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.SelectMany2;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vSelector;

			public Expression Selector {
				get { return _vSelector.Expression; }
				set { _vSelector.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vSelector.Expression }; }
			}
			
			public SelectMany2Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vSelector = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public SelectMany2Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vSelector.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class SelectMany3Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.SelectMany3;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vCollectionSelector;

			public Expression CollectionSelector {
				get { return _vCollectionSelector.Expression; }
				set { _vCollectionSelector.Expression = value; }
			} 
			
			readonly ArgValue _vResultSelector;

			public Expression ResultSelector {
				get { return _vResultSelector.Expression; }
				set { _vResultSelector.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vCollectionSelector.Expression, _vResultSelector.Expression }; }
			}
			
			public SelectMany3Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vCollectionSelector = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
				_vResultSelector = new ArgValue(new[] { _modes[0].Args[2], _modes[1].Args[2] });
			}
			
			public SelectMany3Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vCollectionSelector.Expression = ex.Arguments[1];
				_vResultSelector.Expression = ex.Arguments[2];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class SelectMany4Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.SelectMany4;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vCollectionSelector;

			public Expression CollectionSelector {
				get { return _vCollectionSelector.Expression; }
				set { _vCollectionSelector.Expression = value; }
			} 
			
			readonly ArgValue _vResultSelector;

			public Expression ResultSelector {
				get { return _vResultSelector.Expression; }
				set { _vResultSelector.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vCollectionSelector.Expression, _vResultSelector.Expression }; }
			}
			
			public SelectMany4Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vCollectionSelector = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
				_vResultSelector = new ArgValue(new[] { _modes[0].Args[2], _modes[1].Args[2] });
			}
			
			public SelectMany4Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vCollectionSelector.Expression = ex.Arguments[1];
				_vResultSelector.Expression = ex.Arguments[2];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class SequenceEqualTransition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.SequenceEqual;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vFirst;

			public Expression First {
				get { return _vFirst.Expression; }
				set { _vFirst.Expression = value; }
			} 
			
			readonly ArgValue _vSecond;

			public Expression Second {
				get { return _vSecond.Expression; }
				set { _vSecond.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vFirst.Expression, _vSecond.Expression }; }
			}
			
			public SequenceEqualTransition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vFirst = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vSecond = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public SequenceEqualTransition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vSecond.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vFirst.Expression; }
				set { _vFirst.Expression = value; }
			}
	  } 


	  partial class SequenceEqual2Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.SequenceEqual2;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vFirst;

			public Expression First {
				get { return _vFirst.Expression; }
				set { _vFirst.Expression = value; }
			} 
			
			readonly ArgValue _vSecond;

			public Expression Second {
				get { return _vSecond.Expression; }
				set { _vSecond.Expression = value; }
			} 
			
			readonly ArgValue _vComparer;

			public Expression Comparer {
				get { return _vComparer.Expression; }
				set { _vComparer.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vFirst.Expression, _vSecond.Expression, _vComparer.Expression }; }
			}
			
			public SequenceEqual2Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vFirst = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vSecond = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
				_vComparer = new ArgValue(new[] { _modes[0].Args[2], _modes[1].Args[2] });
			}
			
			public SequenceEqual2Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vSecond.Expression = ex.Arguments[1];
				_vComparer.Expression = ex.Arguments[2];
			}

			Expression ITakesSource.Source {
				get { return _vFirst.Expression; }
				set { _vFirst.Expression = value; }
			}
	  } 


	  partial class SingleTransition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Single;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression }; }
			}
			
			public SingleTransition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
			}
			
			public SingleTransition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class Single2Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Single2;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vPredicate;

			public Expression Predicate {
				get { return _vPredicate.Expression; }
				set { _vPredicate.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vPredicate.Expression }; }
			}
			
			public Single2Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vPredicate = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public Single2Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vPredicate.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class SingleOrDefaultTransition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.SingleOrDefault;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression }; }
			}
			
			public SingleOrDefaultTransition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
			}
			
			public SingleOrDefaultTransition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class SingleOrDefault2Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.SingleOrDefault2;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vPredicate;

			public Expression Predicate {
				get { return _vPredicate.Expression; }
				set { _vPredicate.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vPredicate.Expression }; }
			}
			
			public SingleOrDefault2Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vPredicate = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public SingleOrDefault2Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vPredicate.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class SkipTransition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Skip;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vCount;

			public Expression Count {
				get { return _vCount.Expression; }
				set { _vCount.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vCount.Expression }; }
			}
			
			public SkipTransition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vCount = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public SkipTransition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vCount.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class SkipWhileTransition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.SkipWhile;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vPredicate;

			public Expression Predicate {
				get { return _vPredicate.Expression; }
				set { _vPredicate.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vPredicate.Expression }; }
			}
			
			public SkipWhileTransition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vPredicate = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public SkipWhileTransition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vPredicate.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class SkipWhile2Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.SkipWhile2;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vPredicate;

			public Expression Predicate {
				get { return _vPredicate.Expression; }
				set { _vPredicate.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vPredicate.Expression }; }
			}
			
			public SkipWhile2Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vPredicate = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public SkipWhile2Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vPredicate.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class SumTransition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Sum;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vSelector;

			public Expression Selector {
				get { return _vSelector.Expression; }
				set { _vSelector.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vSelector.Expression }; }
			}
			
			public SumTransition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vSelector = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public SumTransition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vSelector.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class Sum10Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Sum10;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression }; }
			}
			
			public Sum10Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
			}
			
			public Sum10Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class Sum11Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Sum11;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression }; }
			}
			
			public Sum11Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
			}
			
			public Sum11Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class Sum12Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Sum12;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vSelector;

			public Expression Selector {
				get { return _vSelector.Expression; }
				set { _vSelector.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vSelector.Expression }; }
			}
			
			public Sum12Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vSelector = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public Sum12Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vSelector.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class Sum13Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Sum13;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vSelector;

			public Expression Selector {
				get { return _vSelector.Expression; }
				set { _vSelector.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vSelector.Expression }; }
			}
			
			public Sum13Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vSelector = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public Sum13Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vSelector.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class Sum14Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Sum14;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vSelector;

			public Expression Selector {
				get { return _vSelector.Expression; }
				set { _vSelector.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vSelector.Expression }; }
			}
			
			public Sum14Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vSelector = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public Sum14Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vSelector.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class Sum15Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Sum15;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vSelector;

			public Expression Selector {
				get { return _vSelector.Expression; }
				set { _vSelector.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vSelector.Expression }; }
			}
			
			public Sum15Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vSelector = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public Sum15Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vSelector.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class Sum16Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Sum16;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vSelector;

			public Expression Selector {
				get { return _vSelector.Expression; }
				set { _vSelector.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vSelector.Expression }; }
			}
			
			public Sum16Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vSelector = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public Sum16Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vSelector.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class Sum17Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Sum17;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vSelector;

			public Expression Selector {
				get { return _vSelector.Expression; }
				set { _vSelector.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vSelector.Expression }; }
			}
			
			public Sum17Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vSelector = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public Sum17Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vSelector.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class Sum18Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Sum18;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vSelector;

			public Expression Selector {
				get { return _vSelector.Expression; }
				set { _vSelector.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vSelector.Expression }; }
			}
			
			public Sum18Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vSelector = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public Sum18Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vSelector.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class Sum19Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Sum19;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vSelector;

			public Expression Selector {
				get { return _vSelector.Expression; }
				set { _vSelector.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vSelector.Expression }; }
			}
			
			public Sum19Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vSelector = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public Sum19Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vSelector.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class Sum2Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Sum2;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression }; }
			}
			
			public Sum2Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
			}
			
			public Sum2Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class Sum20Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Sum20;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vSelector;

			public Expression Selector {
				get { return _vSelector.Expression; }
				set { _vSelector.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vSelector.Expression }; }
			}
			
			public Sum20Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vSelector = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public Sum20Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vSelector.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class Sum3Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Sum3;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression }; }
			}
			
			public Sum3Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
			}
			
			public Sum3Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class Sum4Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Sum4;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression }; }
			}
			
			public Sum4Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
			}
			
			public Sum4Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class Sum5Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Sum5;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression }; }
			}
			
			public Sum5Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
			}
			
			public Sum5Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class Sum6Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Sum6;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression }; }
			}
			
			public Sum6Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
			}
			
			public Sum6Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class Sum7Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Sum7;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression }; }
			}
			
			public Sum7Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
			}
			
			public Sum7Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class Sum8Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Sum8;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression }; }
			}
			
			public Sum8Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
			}
			
			public Sum8Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class Sum9Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Sum9;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression }; }
			}
			
			public Sum9Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
			}
			
			public Sum9Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class TakeTransition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Take;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vCount;

			public Expression Count {
				get { return _vCount.Expression; }
				set { _vCount.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vCount.Expression }; }
			}
			
			public TakeTransition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vCount = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public TakeTransition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vCount.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class TakeWhileTransition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.TakeWhile;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vPredicate;

			public Expression Predicate {
				get { return _vPredicate.Expression; }
				set { _vPredicate.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vPredicate.Expression }; }
			}
			
			public TakeWhileTransition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vPredicate = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public TakeWhileTransition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vPredicate.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class TakeWhile2Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.TakeWhile2;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vPredicate;

			public Expression Predicate {
				get { return _vPredicate.Expression; }
				set { _vPredicate.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vPredicate.Expression }; }
			}
			
			public TakeWhile2Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vPredicate = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public TakeWhile2Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vPredicate.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class ThenByTransition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.ThenBy;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vKeySelector;

			public Expression KeySelector {
				get { return _vKeySelector.Expression; }
				set { _vKeySelector.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vKeySelector.Expression }; }
			}
			
			public ThenByTransition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vKeySelector = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public ThenByTransition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vKeySelector.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class ThenBy2Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.ThenBy2;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vKeySelector;

			public Expression KeySelector {
				get { return _vKeySelector.Expression; }
				set { _vKeySelector.Expression = value; }
			} 
			
			readonly ArgValue _vComparer;

			public Expression Comparer {
				get { return _vComparer.Expression; }
				set { _vComparer.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vKeySelector.Expression, _vComparer.Expression }; }
			}
			
			public ThenBy2Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vKeySelector = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
				_vComparer = new ArgValue(new[] { _modes[0].Args[2], _modes[1].Args[2] });
			}
			
			public ThenBy2Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vKeySelector.Expression = ex.Arguments[1];
				_vComparer.Expression = ex.Arguments[2];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class ThenByDescendingTransition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.ThenByDescending;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vKeySelector;

			public Expression KeySelector {
				get { return _vKeySelector.Expression; }
				set { _vKeySelector.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vKeySelector.Expression }; }
			}
			
			public ThenByDescendingTransition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vKeySelector = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public ThenByDescendingTransition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vKeySelector.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class ThenByDescending2Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.ThenByDescending2;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vKeySelector;

			public Expression KeySelector {
				get { return _vKeySelector.Expression; }
				set { _vKeySelector.Expression = value; }
			} 
			
			readonly ArgValue _vComparer;

			public Expression Comparer {
				get { return _vComparer.Expression; }
				set { _vComparer.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vKeySelector.Expression, _vComparer.Expression }; }
			}
			
			public ThenByDescending2Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vKeySelector = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
				_vComparer = new ArgValue(new[] { _modes[0].Args[2], _modes[1].Args[2] });
			}
			
			public ThenByDescending2Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vKeySelector.Expression = ex.Arguments[1];
				_vComparer.Expression = ex.Arguments[2];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class UnionTransition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Union;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vFirst;

			public Expression First {
				get { return _vFirst.Expression; }
				set { _vFirst.Expression = value; }
			} 
			
			readonly ArgValue _vSecond;

			public Expression Second {
				get { return _vSecond.Expression; }
				set { _vSecond.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vFirst.Expression, _vSecond.Expression }; }
			}
			
			public UnionTransition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vFirst = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vSecond = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public UnionTransition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vSecond.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vFirst.Expression; }
				set { _vFirst.Expression = value; }
			}
	  } 


	  partial class Union2Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Union2;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vFirst;

			public Expression First {
				get { return _vFirst.Expression; }
				set { _vFirst.Expression = value; }
			} 
			
			readonly ArgValue _vSecond;

			public Expression Second {
				get { return _vSecond.Expression; }
				set { _vSecond.Expression = value; }
			} 
			
			readonly ArgValue _vComparer;

			public Expression Comparer {
				get { return _vComparer.Expression; }
				set { _vComparer.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vFirst.Expression, _vSecond.Expression, _vComparer.Expression }; }
			}
			
			public Union2Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vFirst = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vSecond = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
				_vComparer = new ArgValue(new[] { _modes[0].Args[2], _modes[1].Args[2] });
			}
			
			public Union2Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vSecond.Expression = ex.Arguments[1];
				_vComparer.Expression = ex.Arguments[2];
			}

			Expression ITakesSource.Source {
				get { return _vFirst.Expression; }
				set { _vFirst.Expression = value; }
			}
	  } 


	  partial class WhereTransition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Where;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vPredicate;

			public Expression Predicate {
				get { return _vPredicate.Expression; }
				set { _vPredicate.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vPredicate.Expression }; }
			}
			
			public WhereTransition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vPredicate = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public WhereTransition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vPredicate.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class Where2Transition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Where2;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vSource;

			public Expression Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			} 
			
			readonly ArgValue _vPredicate;

			public Expression Predicate {
				get { return _vPredicate.Expression; }
				set { _vPredicate.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vSource.Expression, _vPredicate.Expression }; }
			}
			
			public Where2Transition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vSource = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vPredicate = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
			}
			
			public Where2Transition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vPredicate.Expression = ex.Arguments[1];
			}

			Expression ITakesSource.Source {
				get { return _vSource.Expression; }
				set { _vSource.Expression = value; }
			}
	  } 


	  partial class ZipTransition : SeqTransition, ITakesSource
	  { 
			static readonly SeqMethod _seqMethod = SeqMethods.Zip;
			static readonly Type[] _paramTypesQy = _seqMethod.Qy.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _paramTypesEn = _seqMethod.En.GetParameters().Select(p => p.ParameterType).ToArray();
			static readonly Type[] _typeParamsQy = _seqMethod.Qy.GetGenericArguments();
			static readonly Type[] _typeParamsEn = _seqMethod.En.GetGenericArguments();			
			
			readonly ArgValue _vFirst;

			public Expression First {
				get { return _vFirst.Expression; }
				set { _vFirst.Expression = value; }
			} 
			
			readonly ArgValue _vSecond;

			public Expression Second {
				get { return _vSecond.Expression; }
				set { _vSecond.Expression = value; }
			} 
			
			readonly ArgValue _vResultSelector;

			public Expression ResultSelector {
				get { return _vResultSelector.Expression; }
				set { _vResultSelector.Expression = value; }
			} 
		
			public override SeqMethod SeqMethod {  
				get { return _seqMethod; }
			}

			public override IEnumerable<Expression> Args {
				get { return new[] { _vFirst.Expression, _vSecond.Expression, _vResultSelector.Expression }; }
			}
			
			public ZipTransition()
			{
				_modes = new Mode[] {
					new Mode(_seqMethod.Qy, _typeParamsQy, _paramTypesQy),
					new Mode(_seqMethod.En, _typeParamsEn, _paramTypesEn)
				};
					
				_vFirst = new ArgValue(new[] { _modes[0].Args[0], _modes[1].Args[0] });
				_vSecond = new ArgValue(new[] { _modes[0].Args[1], _modes[1].Args[1] });
				_vResultSelector = new ArgValue(new[] { _modes[0].Args[2], _modes[1].Args[2] });
			}
			
			public ZipTransition(MethodCallExpression ex) : this()
			{
				var typeArgTypes = ex.Method.GetGenericArguments();

				var origTypeArgsQy = _typeParamsQy.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));															
				var origTypeArgsEn = _typeParamsEn.Zip(typeArgTypes, (p, a) => new TypeArg(p, a));

				foreach(var typeArg in origTypeArgsQy) {
					_modes[0].TypeArgHub.Register(typeArg, null);
				}
				
				foreach(var typeArg in origTypeArgsEn) {
					_modes[1].TypeArgHub.Register(typeArg, null);
				}

				_vSecond.Expression = ex.Arguments[1];
				_vResultSelector.Expression = ex.Arguments[2];
			}

			Expression ITakesSource.Source {
				get { return _vFirst.Expression; }
				set { _vFirst.Expression = value; }
			}
	  } 


}

