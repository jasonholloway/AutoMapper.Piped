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

            var prov = Substitute.For<ISourceRegimeProvider>();
            prov.GetRegime(Arg.Any<IQueryable>()).Returns(regime);

            x.Register(prov);
        }


        public static void EmplaceTolerantSourceRegime(this IServiceRegistry x) {
            var regime = Substitute.For<ISourceRegime>();
            regime.ServerAccepts(Arg.Any<Expression>()).Returns(true);

            var prov = Substitute.For<ISourceRegimeProvider>();
            prov.GetRegime(Arg.Any<IQueryable>()).Returns(regime);

            x.Register(prov);
        }


        public static void EmplaceCustomSourceRegime(this IServiceRegistry x, Predicate<Expression> fnTest) {
            var regime = Substitute.For<ISourceRegime>();
            regime.ServerAccepts(Arg.Any<Expression>()).Returns(c => fnTest(c.Arg<Expression>()));

            var prov = Substitute.For<ISourceRegimeProvider>();
            prov.GetRegime(Arg.Any<IQueryable>()).Returns(regime);

            x.Register(prov);
        }



        public static void AllowClientSideFiltering(this IServiceRegistry x) {
            x.Resolve<Config>().AllowClientSideFiltering = true;
        }

        public static void ForbidClientSideFiltering(this IServiceRegistry x) {
            x.Resolve<Config>().AllowClientSideFiltering = false;
        }
               

    }

}
