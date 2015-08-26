using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using JH.DynaType;
using System.Linq.Expressions;
using System.Collections;

namespace Materialize
{    
    public static class QueryableExtensions
    {        
        public static IEnumerable<TDest> MaterializeAs<TDest>(this IQueryable qyOrig) 
        {
            var tOrig = qyOrig.ElementType;
            var tDest = typeof(TDest);

            var reifier = ReifierSource.Default.GetReifier(tOrig, tDest);


            //strategy ideas:
            // if typemap exists with projection
            // if typemap exists with property mapping
            // if direct
            // if simple castable


            ////////////////////////////////////////////////////////////////////
            //build up our strategy
            //  - gather memberinfos
            //  - build tempType if necessary
            //  - create strategies for members




            ////////////////////////////////////////////////////////////////////
            //find what properties we need 
            PropertyInfo[] reqProps = null;

            var typeMap = Mapper.FindTypeMapFor(tOrig, tDest);

            if(typeMap != null) {                
                if(typeMap.CustomProjection != null) {
                    //if valid for queryprovider (check for non-edm funcs etc),
                    //then can fall back on trad behaviour

                    //else                     
                }

                if(typeMap.CustomMapper != null) {

                }

                reqProps = typeMap.GetPropertyMaps()
                                        .Select(m => (PropertyInfo)m.SourceMember)
                                        .ToArray();
            }
            else {
                throw new NotImplementedException();
            }


            ////////////////////////////////////////////////////////////////////
            //create temp type to select into
            var tTemp = DynaType.Design(x => {
                                    x.Name = "TempType1";
                
                                    foreach(var reqProp in reqProps) {
                                        var field = x.Field(reqProp.Name, reqProp.PropertyType)
                                                        .MakePublic();
                                    }
                                });


            ////////////////////////////////////////////////////////////////////
            //match up datatype fields to props
            var dDataTypeProps = new Dictionary<MemberInfo, FieldInfo>();

            foreach(var reqProp in reqProps) {
                dDataTypeProps[reqProp] = tTemp.GetField(reqProp.Name);
            }


            ////////////////////////////////////////////////////////////////////
            //now alter exp to select to temp type
            var exParam = Expression.Parameter(tOrig);

            var exNew = Expression.Call(
                                    typeof(Queryable),
                                    "Select",
                                    new[] { tOrig, tTemp },
                                    qyOrig.Expression,
                                    Expression.Lambda(
                                                typeof(Func<,>).MakeGenericType(tOrig, tTemp),
                                                Expression.MemberInit(
                                                            Expression.New(tTemp),
                                                            dDataTypeProps.Select(kv => Expression.Bind(
                                                                                                    kv.Value, 
                                                                                                    Expression.MakeMemberAccess(exParam, kv.Key)
                                                                                                    )).ToArray()
                                                            ),
                                                exParam
                                                )
                                    );

            var qyNew = qyOrig.Provider.CreateQuery(exNew);


            //////////////////////////////////////////////////////////////
            //materialize customised query
            var result = ((IEnumerable)qyNew).Cast<object>().ToArray();



            //////////////////////////////////////////////////////////////
            //perform post-hoc preparation
            //should know objects to crawl from initial mapping
            
            //or, go through graph, whenever we find a tempType, operate on it

            //temptypes should always open outwards, that is we should start from root,
            //and crawl outwards, changing types as we go.





            throw new NotImplementedException();
        }

    }
}
