﻿using Materialize.Types;
using Materialize.Reify2.Transitions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Materialize.Expressions;

namespace Materialize.Tests.Inner
{
    [TestFixture]
    class SeqTransitionTests
    {


        Expression GetQuotedLambda<TIn, TOut>(Expression<Func<TIn, TOut>> ex) {
            return Expression.Quote(ex);
        }



        [Test]
        public void ArgumentsExceptSourceTakenFromCall() {
            var exProjParam = Expression.Parameter(typeof(int));

            var exCall = Expression.Call(
                                QyMethods.Select.MakeGenericMethod(typeof(int), typeof(float)),
                                Expression.Default(typeof(IQueryable<int>)),
                                Expression.Lambda(
                                    Expression.Convert(exProjParam, typeof(float)),
                                    exProjParam)
                                );

            var tran = new SelectTransition(exCall);

            Assert.That(
                tran.Source, Is.Null);

            Assert.That(
                tran.Selector.IsFormallyEquivalentTo(GetQuotedLambda<int, float>(i => (float)i)));
        }




        [Test]
        public void TypeArgsTakenFromCall() 
        {
            var exProjParam = Expression.Parameter(typeof(int));

            var exCall = Expression.Call(
                                QyMethods.Select.MakeGenericMethod(typeof(int), typeof(float)),
                                Expression.Default(typeof(IQueryable<int>)),
                                Expression.Lambda(
                                    Expression.Convert(exProjParam, typeof(float)),
                                    exProjParam)
                                );
            
            var tran = new SelectTransition(exCall);
            
            var typeArgs = tran.GetTypeArgs();
            
            Assert.That(
                    typeArgs.Select(a => a.ParamType), 
                    Is.EquivalentTo(QyMethods.Select.GetGenericArguments()));

            Assert.That(
                    typeArgs.Select(a => a.ArgType), 
                    Is.EquivalentTo(exCall.Method.GetGenericArguments()));
        }


        [Test]
        public void TypeArgsAdaptToArguments() 
        {
            var exProjParam = Expression.Parameter(typeof(int));

            var exCall = Expression.Call(
                                QyMethods.Select.MakeGenericMethod(typeof(int), typeof(float)),
                                Expression.Default(typeof(IQueryable<int>)),
                                Expression.Lambda(
                                    Expression.Convert(exProjParam, typeof(float)),
                                    exProjParam)
                                );

            var tran = new SelectTransition(exCall);


            var exProjParam2 = Expression.Parameter(typeof(int?));

            tran.Selector = Expression.Quote(
                                Expression.Lambda(
                                    Expression.Convert(exProjParam2, typeof(double)),
                                    exProjParam2)
                                );
            
            Assert.That(
                    tran.GetTypeArgs().Select(a => a.ArgType),
                    Is.EquivalentTo(new[] { typeof(int?), typeof(double) }));
        }

        


    }
}
