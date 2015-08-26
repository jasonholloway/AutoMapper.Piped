using AutoMapper;
using FizzWare.NBuilder;
using Should;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Materialize.Tests
{
    public class BasicTests
    {        
        [Fact]
        public void Basic() {
            Mapper.Initialize(x => {
                x.CreateMap<Dog, Person>();
            });

            using(var ctx = new Context()) {
                ctx.Dogs.ShouldNotBeEmpty();

                var people = ctx.Dogs.MaterializeAs<Person>();
                people.ShouldNotBeEmpty();

                throw new NotImplementedException();
            }
        }

    }
}
