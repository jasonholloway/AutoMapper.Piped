using AutoMapper;
using JH.DynaType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Strategies.Projection
{
    class SelectiveFetchAndProjectStrategy<TOrig, TDest>
        : ReifyStrategyBase<TOrig, TDest>
    {
        ReifyContext _ctx;
        LambdaExpression _exProject;
        DataType _dataType;
        Func<IReifier<TOrig, TDest>> _fnCreateReifier;

        public SelectiveFetchAndProjectStrategy(ReifyContext ctx, TypeMap typeMap) 
        {
            //Need to figure out exactly what source properties we need to fuel projection
            //need to analyse expression: if only accessors appear as modulators of the param, then we're on.
            //This calls for a separate rule, I think.



            _ctx = ctx;

            _exProject = typeMap.CustomProjection;

            //is projection fit for EDM constraints?
            //if so, can stitch into expression

            //otherwise, have to use data object - maybe this should be separate rule, separate factories, etc.

            //should try and figure out exactly what data is needed to feed projection
            //for now just fetch it all
            var sourceProps = typeof(TOrig).GetProperties();

            _dataType = BuildDataType(sourceProps);

                       

            var reifierType = typeof(Reifier<>).MakeGenericType(typeof(TOrig), typeof(TDest), _dataType.Type);
            
            _fnCreateReifier = Expression.Lambda<Func<IReifier<TOrig, TDest>>>( //will opt out of this for ios
                                            Expression.New(
                                                        reifierType.GetConstructors().First(),
                                                        Expression.Constant(_ctx),
                                                        Expression.Constant(_dataType))
                                            ).Compile();

        }


        public override bool UsesIntermediateType {
            get { return true; }
        }


        public override IReifier<TOrig, TDest> CreateReifier() {
            return _fnCreateReifier();
        }


        DataType BuildDataType(MemberInfo[] sourceMembers) {
            //will eventually have to use tuple here - can't emit in certain environments
            var type = DynaType.Design(x => {
                foreach(var sourceProp in sourceMembers.OfType<PropertyInfo>()) {   //obvs use fields too
                    x.Field(sourceProp.Name, sourceProp.PropertyType)
                        .MakePublic();
                }
            });

            var fieldMaps = sourceMembers
                                .Select(m => new DataFieldMap(type.GetField(m.Name), m))
                                .ToArray();

            return new DataType(type, fieldMaps);
        }





        class Reifier<TMed> : ReifierBase<TOrig, TMed, TDest>
        {
            ReifyContext _ctx;
            DataType _dataType;

            public Reifier(ReifyContext ctx, DataType dataType) {
                _ctx = ctx;
                _dataType = dataType;
            }

            protected override Expression ProjectSingle(Expression exSource) {
                return Expression.MemberInit(
                                    Expression.New(_dataType.Type),
                                    BuildBindings(exSource)
                                    );
            }

            MemberBinding[] BuildBindings(Expression exSource) {

                //inputs should be worked out by rule, before even feeding to strategy


                return _dataType.FieldMaps
                                .Select(f => Expression.Bind(
                                                        f.Field,
                                                        Expression.MakeMemberAccess(exSource, f.SourceMember)) //need to delegate to other reifiers...
                                ).ToArray();                                            



            }


            protected override TDest TransformSingle(TMed source) {

                //how do we know what our input streams are? Strategy should build up array of maps for us to
                //iterate through. Every member with a rule to be mapped.

                //yet we rely on AutoMapper's config. No enumerating PropertyInfos for us, oh no!
                
                //but for projections, propertymaps are cleared, helpfully. 

                //our projection has inputs, yes...? 







                //reform all our input streams (that is, each field of our mediate type)

                //use them to feed our projection, which will be executed here

                //This is obvs horrible implementation...

                var dest = (TDest)Activator.CreateInstance<TDest>();
                
                //now bind reformed input streams to dest object
                
                //but if projection opaquely requires entire original as parameter, then 
                //we shouldn't use mediating type. Should just return original type?
                //Nah, cos our input streams may be transformed. Basically, just fall back on
                //property mapping behaviour, where mediation is used if children dictate it,
                //but otherwise just return plain type. 

                //When projection just leaves plain type in place, however, there will be no
                //propmaps or owt. Definitely distinct strategies here.


                //Types of proj strats:
                //  > FetchWholeAndProjectStrategy
                //      - if no inputs use intermediate types, and projection needs full source entity
                //  > EdmFriendlyProjectStrategy
                //      - can be stitched in directly, mostly
                //  > MediateFetchAndProjectStrategy
                //      - if only some props needed, bind only those streams into mediate type
                //      - if input streams weird, then need mediate type anyway

                return dest;
            }
        }




    }

}
