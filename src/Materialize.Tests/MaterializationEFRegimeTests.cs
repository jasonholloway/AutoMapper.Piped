﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Materialize.Tests
{
    class MaterializationEFRegimeTests
    {
        
        [Fact]
        public void OnlyNonParameterizedCtorsAllowed() {
            throw new NotImplementedException();
        }


        [Fact]
        public void OnlyMappedMemberAccessesAllowed() {            
            throw new NotImplementedException();
        }


        [Fact]
        public void OnlyEdmMethodsAllowedInProjections() {            
            throw new NotImplementedException();
        }


        [Fact]
        public void CantProjectToMappedEntities() {
            //this is special case: needs to be treated like custom projection behind the scenes
            //...

            throw new NotImplementedException();
        }


    }
}
