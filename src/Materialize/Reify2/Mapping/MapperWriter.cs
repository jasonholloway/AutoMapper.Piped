﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace Materialize.Reify2.Mapping
{    
    
    interface IMapperWriter
    {
        Expression ServerRewrite(Expression ex);
        Expression ClientRewrite(Expression ex);

        Type SourceType { get; }
        Type FetchType { get; }
        Type DestType { get; }
    }


    abstract class MapperWriter<TSource, TFetch, TDest>
        : IMapperWriter
    {        

        public Type SourceType {
            get { return typeof(TSource); }
        }

        public Type FetchType {
            get { return typeof(TFetch); }
        }

        public Type DestType {
            get { return typeof(TDest); }
        }



        protected virtual Expression ServerRewrite(Expression ex) {
            return ex;
        }

        protected virtual Expression ClientRewrite(Expression ex) {
            return ex;
        }


        


        Expression IMapperWriter.ServerRewrite(Expression ex) {
            var exRewritten = ServerRewrite(ex);

            Debug.Assert(typeof(TFetch).IsAssignableFrom(exRewritten.Type));

            return exRewritten;
        }


        Expression IMapperWriter.ClientRewrite(Expression ex) {
            Debug.Assert(typeof(TFetch).IsAssignableFrom(ex.Type));

            var exRewritten = ClientRewrite(ex);

            Debug.Assert(typeof(TDest).IsAssignableFrom(exRewritten.Type));

            return exRewritten;
        }
        

    }


}
