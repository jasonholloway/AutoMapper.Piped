using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.SourceRegimes
{ 
    //But how will this hook in to library? Via some app.config rule? 

    internal class EF6RegimeProvider : ISourceRegimeProvider
    {
        #region Static accessor creation (via hacky reflection)

        static T Exec<T>(Func<T> fn) { return fn(); }

        static Assembly _asmEF = typeof(DbQuery).Assembly;

        static Type _tDbQueryProvider = _asmEF.GetType("System.Data.Entity.Internal.Linq.DbQueryProvider");
        static Type _tInternalContext = _asmEF.GetType("System.Data.Entity.Internal.InternalContext");

        static Func<IQueryProvider, DbContext> GetDbContext
            = Exec(() => {
                var exParam = Expression.Parameter(typeof(IQueryProvider));

                var exLambda = Expression.Lambda<Func<IQueryProvider, DbContext>>(
                                    Expression.Condition(
                                        Expression.TypeIs(exParam, _tDbQueryProvider),
                                        Expression.MakeMemberAccess(
                                                Expression.MakeMemberAccess(
                                                        Expression.Convert(exParam, _tDbQueryProvider),
                                                        _tDbQueryProvider.GetField("_internalContext", BindingFlags.NonPublic | BindingFlags.Instance)
                                                        ),
                                                _tInternalContext.GetProperty("Owner")
                                                ),
                                        Expression.Default(typeof(DbContext))
                                        ),
                                    exParam
                                    );

                return exLambda.Compile();
            });

        #endregion
                

        public ISourceRegime GetRegime(IQueryable qy) 
        {   
            //NB: below can throw exceptions relating to DbContext construction - that is, related to EF config
            var dbContext = GetDbContext(qy.Provider);
            
            if(dbContext != null) {
                return new EF6Regime(dbContext);
            }

            return null;
        }

    }

}
