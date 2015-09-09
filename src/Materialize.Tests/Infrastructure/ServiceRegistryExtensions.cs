using Materialize.Dependencies;
using Materialize.SourceRegimes;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Tests.Infrastructure
{
    internal static class ServiceRegistryExtensions
    {
        public static void EmplaceIntolerantSourceRegime(this IServiceRegistry x) {
            var regime = Substitute.For<ISourceRegime>();
            regime.ServerAccepts(Arg.Any<Expression>()).Returns(false);

            var detector = Substitute.For<ISourceRegimeDetector>();
            detector.DetectRegime(Arg.Any<IQueryProvider>()).Returns(regime);

            x.Register(detector);
        }


        public static void EmplaceTolerantSourceRegime(this IServiceRegistry x) {
            var regime = Substitute.For<ISourceRegime>();
            regime.ServerAccepts(Arg.Any<Expression>()).Returns(true);

            var detector = Substitute.For<ISourceRegimeDetector>();
            detector.DetectRegime(Arg.Any<IQueryProvider>()).Returns(regime);

            x.Register(detector);
        }
    }

}
