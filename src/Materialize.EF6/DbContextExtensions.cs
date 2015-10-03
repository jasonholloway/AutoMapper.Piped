using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
namespace Materialize
{
    internal static class DbContextExtensions
    {
        public static ObjectContext GetObjectContext(this DbContext @this) {
            return ((IObjectContextAdapter)@this).ObjectContext;
        }

        public static MetadataWorkspace GetMetadata(this DbContext @this) {
            return @this.GetObjectContext().MetadataWorkspace;
        }

    }
}
