using Materialize.Types;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Materialize.Tests.Inner
{
    [TestFixture]
    class TypeMatchingTests
    {
        void M<T, T2>() { }

        Type _tParam;
        Type _tParam2;

        public TypeMatchingTests() {
            var typeParams = typeof(TypeMatchingTests)
                                .GetMethod("M", BindingFlags.NonPublic | BindingFlags.Instance)
                                .GetGenericArguments();

            _tParam = typeParams[0];
            _tParam2 = typeParams[1];
        }




        [Test]
        public void SimpleMatch() {            
            var r = TypeMatcher.Match(_tParam, typeof(int));

            Assert.That(r.Success, Is.True);
            Assert.That(r.TypeArgs.Count, Is.EqualTo(1));
            Assert.That(r.TypeArgs[0].ParamType, Is.EqualTo(_tParam));
            Assert.That(r.TypeArgs[0].ArgType, Is.EqualTo(typeof(int)));
        }


        [Test]
        public void ArrayMatch() {
            var r = TypeMatcher.Match(_tParam.MakeArrayType(), typeof(int[]));

            Assert.That(r.TypeArgs.Count, Is.EqualTo(1));
            Assert.That(r.TypeArgs[0].ParamType, Is.EqualTo(_tParam));
            Assert.That(r.TypeArgs[0].ArgType, Is.EqualTo(typeof(int)));
        }




        [Test]
        public void NestedExactMatch() {
            var r = TypeMatcher.Match(
                            typeof(IEnumerable<>).MakeGenericType(_tParam),
                            typeof(IEnumerable<int>));

            Assert.That(r.TypeArgs.Count, Is.EqualTo(1));
            Assert.That(r.TypeArgs[0].ParamType, Is.EqualTo(_tParam));
            Assert.That(r.TypeArgs[0].ArgType, Is.EqualTo(typeof(int)));
        }


        [Test]
        public void NestedExactMatchAmongMultiple() {
            var r = TypeMatcher.Match(
                            typeof(IDictionary<,>).MakeGenericType(typeof(string), _tParam),
                            typeof(IDictionary<string, int>));

            Assert.That(r.TypeArgs.Count, Is.EqualTo(1));
            Assert.That(r.TypeArgs[0].ParamType, Is.EqualTo(_tParam));
            Assert.That(r.TypeArgs[0].ArgType, Is.EqualTo(typeof(int)));
        }


        [Test]
        public void MultipleNestedMatches() {
            var r = TypeMatcher.Match(
                            typeof(IDictionary<,>).MakeGenericType(_tParam, _tParam2),
                            typeof(IDictionary<int, float>));

            Assert.That(r.TypeArgs.Count, Is.EqualTo(2));
            Assert.That(r.TypeArgs[0].ParamType, Is.EqualTo(_tParam));
            Assert.That(r.TypeArgs[0].ArgType, Is.EqualTo(typeof(int)));
            Assert.That(r.TypeArgs[1].ParamType, Is.EqualTo(_tParam2));
            Assert.That(r.TypeArgs[1].ArgType, Is.EqualTo(typeof(float)));
        }


        [Test]
        public void DeeplyNestedMatches() {
            var r = TypeMatcher.Match(
                            typeof(Expression<>).MakeGenericType(typeof(Func<,,>).MakeGenericType(typeof(string), _tParam, _tParam2)),
                            typeof(Expression<Func<string, int, float>>));

            Assert.That(r.TypeArgs.Count, Is.EqualTo(2));
            Assert.That(r.TypeArgs[0].ParamType, Is.EqualTo(_tParam));
            Assert.That(r.TypeArgs[0].ArgType, Is.EqualTo(typeof(int)));
            Assert.That(r.TypeArgs[1].ParamType, Is.EqualTo(_tParam2));
            Assert.That(r.TypeArgs[1].ArgType, Is.EqualTo(typeof(float)));
        }




        class Class : Dictionary<string, int> { }


        [Test]
        public void MatchesOnSuperClass() {
            var r = TypeMatcher.Match(
                            typeof(Dictionary<,>).MakeGenericType(_tParam, _tParam2),
                            typeof(Class));

            Assert.That(r.TypeArgs.Count, Is.EqualTo(2));
            Assert.That(r.TypeArgs[0].ParamType, Is.EqualTo(_tParam));
            Assert.That(r.TypeArgs[0].ArgType, Is.EqualTo(typeof(string)));
            Assert.That(r.TypeArgs[1].ParamType, Is.EqualTo(_tParam2));
            Assert.That(r.TypeArgs[1].ArgType, Is.EqualTo(typeof(int)));
        }





        interface Iface<T, T2> { }

        class Class2 : Iface<string, int> { }

        [Test]
        public void MatchesOnInterface() {
            var r = TypeMatcher.Match(
                            typeof(Iface<,>).MakeGenericType(_tParam, _tParam2),
                            typeof(Class2));

            Assert.That(r.TypeArgs.Count, Is.EqualTo(2));
            Assert.That(r.TypeArgs[0].ParamType, Is.EqualTo(_tParam));
            Assert.That(r.TypeArgs[0].ArgType, Is.EqualTo(typeof(string)));
            Assert.That(r.TypeArgs[1].ParamType, Is.EqualTo(_tParam2));
            Assert.That(r.TypeArgs[1].ArgType, Is.EqualTo(typeof(int)));
        }



        [Test]
        public void MatchMultipleOccurences() {
            var r = TypeMatcher.Match(
                            typeof(Func<,,>).MakeGenericType(_tParam, _tParam2, _tParam2),
                            typeof(Func<int, float, float>));

            Assert.That(r.TypeArgs.Count, Is.EqualTo(2));
            Assert.That(r.TypeArgs[0].ParamType, Is.EqualTo(_tParam));
            Assert.That(r.TypeArgs[0].ArgType, Is.EqualTo(typeof(int)));
            Assert.That(r.TypeArgs[1].ParamType, Is.EqualTo(_tParam2));
            Assert.That(r.TypeArgs[1].ArgType, Is.EqualTo(typeof(float)));
        }

        [Test]
        public void MultipleOccurencesMustBeWellFormed() {
            var r = TypeMatcher.Match(
                            typeof(Func<,,>).MakeGenericType(_tParam, _tParam2, _tParam2),
                            typeof(Func<int, float, int>));

            Assert.That(r.Success, Is.False);
        }


        [Test]
        public void UnmatchingSimpleTypesDetected() {
            var r = TypeMatcher.Match(
                            typeof(int), typeof(float));

            Assert.That(r.Success, Is.False);
        }

        [Test]
        public void UnmatchingNestedTypesDetected() {
            var r = TypeMatcher.Match(
                            typeof(IEnumerable<int>), typeof(IEnumerable<float>));

            Assert.That(r.Success, Is.False);
        }


        [Test]
        public void NonGenericAncestorsMatched() {
            var r = TypeMatcher.Match(
                            typeof(IQueryable), typeof(EnumerableQuery<float>));

            Assert.That(r.Success, Is.True);
        }

    }
}
