using Materialize.SourceRegimes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Should;

namespace Materialize.Tests.Infrastructure
{
    public static class SourceRegimeExtensions
    {
        public static void AssertAccepts(this ISourceRegime regime, Expression<Action> exp) {
            regime.ServerAccepts(exp.Body).ShouldBeTrue();
        }

        public static void AssertAccepts(this ISourceRegime regime, Expression<Func<object>> exp) {
            regime.ServerAccepts(exp.Body).ShouldBeTrue();
        }

        public static void AssertDeclines(this ISourceRegime regime, Expression<Action> exp) {
            regime.ServerAccepts(exp.Body).ShouldBeFalse();
        }

        public static void AssertDeclines(this ISourceRegime regime, Expression<Func<object>> exp) {
            regime.ServerAccepts(exp.Body).ShouldBeFalse();
        }

    }
}
