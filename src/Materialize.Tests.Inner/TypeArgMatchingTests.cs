using Materialize.Types;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Tests.Inner
{
    [TestFixture]
    class TypeArgMatchingTests
    {
        void M<T, T2>() { }

        Type _tParam;
        Type _tParam2;

        public TypeArgMatchingTests() {
            var typeParams = typeof(TypeArgMatchingTests)
                                .GetMethod("M", BindingFlags.NonPublic | BindingFlags.Instance)
                                .GetGenericArguments();

            _tParam = typeParams[0];
            _tParam2 = typeParams[1];
        }




        [Test]
        public void SimpleMatch() {            
            var matches = TypeArgMatcher.Match(_tParam, typeof(int)).ToArray();

            Assert.That(matches.Length, Is.EqualTo(1));
            Assert.That(matches[0].ParamType, Is.EqualTo(_tParam));
            Assert.That(matches[0].ArgType, Is.EqualTo(typeof(int)));
        }


        [Test]
        public void ArrayMatch() {
            var matches = TypeArgMatcher.Match(_tParam.MakeArrayType(), typeof(int[])).ToArray();

            Assert.That(matches.Length, Is.EqualTo(1));
            Assert.That(matches[0].ParamType, Is.EqualTo(_tParam));
            Assert.That(matches[0].ArgType, Is.EqualTo(typeof(int)));
        }




        [Test]
        public void NestedExactMatch() {
            var matches = TypeArgMatcher.Match(
                                    typeof(IEnumerable<>).MakeGenericType(_tParam),
                                    typeof(IEnumerable<int>))
                                    .ToArray();

            Assert.That(matches.Length, Is.EqualTo(1));
            Assert.That(matches[0].ParamType, Is.EqualTo(_tParam));
            Assert.That(matches[0].ArgType, Is.EqualTo(typeof(int)));
        }


        [Test]
        public void NestedExactMatchAmongMultiple() {
            var matches = TypeArgMatcher.Match(
                                    typeof(IDictionary<,>).MakeGenericType(typeof(string), _tParam),
                                    typeof(IDictionary<string, int>))
                                    .ToArray();

            Assert.That(matches.Length, Is.EqualTo(1));
            Assert.That(matches[0].ParamType, Is.EqualTo(_tParam));
            Assert.That(matches[0].ArgType, Is.EqualTo(typeof(int)));
        }


        [Test]
        public void MultipleNestedMatches() {
            var matches = TypeArgMatcher.Match(
                                    typeof(IDictionary<,>).MakeGenericType(_tParam, _tParam2),
                                    typeof(IDictionary<int, float>))
                                    .ToArray();

            Assert.That(matches.Length, Is.EqualTo(2));
            Assert.That(matches[0].ParamType, Is.EqualTo(_tParam));
            Assert.That(matches[0].ArgType, Is.EqualTo(typeof(int)));
            Assert.That(matches[1].ParamType, Is.EqualTo(_tParam2));
            Assert.That(matches[1].ArgType, Is.EqualTo(typeof(float)));
        }


        [Test]
        public void DeeplyNestedMatches() {
            var matches = TypeArgMatcher.Match(
                                    typeof(Expression<>).MakeGenericType(typeof(Func<,,>).MakeGenericType(typeof(string), _tParam, _tParam2)),
                                    typeof(Expression<Func<string, int, float>>))
                                    .ToArray();

            Assert.That(matches.Length, Is.EqualTo(2));
            Assert.That(matches[0].ParamType, Is.EqualTo(_tParam));
            Assert.That(matches[0].ArgType, Is.EqualTo(typeof(int)));
            Assert.That(matches[1].ParamType, Is.EqualTo(_tParam2));
            Assert.That(matches[1].ArgType, Is.EqualTo(typeof(float)));
        }




        class Class : Dictionary<string, int> { }


        [Test]
        public void MatchesOnSuperClass() {
            var matches = TypeArgMatcher.Match(
                                    typeof(Dictionary<,>).MakeGenericType(_tParam, _tParam2),
                                    typeof(Class))
                                    .ToArray();

            Assert.That(matches.Length, Is.EqualTo(2));
            Assert.That(matches[0].ParamType, Is.EqualTo(_tParam));
            Assert.That(matches[0].ArgType, Is.EqualTo(typeof(string)));
            Assert.That(matches[1].ParamType, Is.EqualTo(_tParam2));
            Assert.That(matches[1].ArgType, Is.EqualTo(typeof(int)));
        }





        interface Iface<T, T2> { }

        class Class2 : Iface<string, int> { }

        [Test]
        public void MatchesOnInterface() {
            var matches = TypeArgMatcher.Match(
                                    typeof(Iface<,>).MakeGenericType(_tParam, _tParam2),
                                    typeof(Class2))
                                    .ToArray();

            Assert.That(matches.Length, Is.EqualTo(2));
            Assert.That(matches[0].ParamType, Is.EqualTo(_tParam));
            Assert.That(matches[0].ArgType, Is.EqualTo(typeof(string)));
            Assert.That(matches[1].ParamType, Is.EqualTo(_tParam2));
            Assert.That(matches[1].ArgType, Is.EqualTo(typeof(int)));
        }



        [Test]
        public void MatchMultipleOccurences() {
            var matches = TypeArgMatcher.Match(
                                    typeof(Func<,,>).MakeGenericType(_tParam, _tParam2, _tParam2),
                                    typeof(Func<int, float, float>))
                                    .ToArray();

            Assert.That(matches.Length, Is.EqualTo(2));
            Assert.That(matches[0].ParamType, Is.EqualTo(_tParam));
            Assert.That(matches[0].ArgType, Is.EqualTo(typeof(int)));
            Assert.That(matches[1].ParamType, Is.EqualTo(_tParam2));
            Assert.That(matches[1].ArgType, Is.EqualTo(typeof(float)));
        }

        [Test]
        public void MultipleOccurencesMustBeWellFormed() {
            Assert.Throws<InvalidOperationException>(() => {
                var matches = TypeArgMatcher.Match(
                                        typeof(Func<,,>).MakeGenericType(_tParam, _tParam2, _tParam2),
                                        typeof(Func<int, float, int>))
                                        .ToArray();
            });            
        }


    }
}
