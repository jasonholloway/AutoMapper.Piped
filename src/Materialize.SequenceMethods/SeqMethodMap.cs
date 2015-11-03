using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Materialize.SequenceMethods
{
    
    public class SeqMethod
    {
        public readonly string Name;
        public readonly MethodInfo Qy;
        public readonly MethodInfo En;

        public SeqMethod(string name, MethodInfo mQy, MethodInfo mEn) {
            Name = name;
            Qy = mQy;
            En = mEn;
        }
    }



    public static class SeqMethodMap
    {
        public static readonly IReadOnlyDictionary<string, SeqMethod> Methods;
        
        static SeqMethodMap() {
            Methods = new ReadOnlyDictionary<string, SeqMethod>(Build());
        }
                        

        static IDictionary<string, SeqMethod> Build() 
        {
            var qyMethods = typeof(Queryable).GetMethods()
                                        .Where(m => m.DeclaringType == typeof(Queryable))
                                        .Where(m => m.GetParameters().Any() && typeof(IQueryable).IsAssignableFrom(m.GetParameters().First().ParameterType));

            var enMethods = typeof(Enumerable).GetMethods()
                                        .Where(m => m.DeclaringType == typeof(Enumerable))
                                        .Where(m => m.GetParameters().Any() && typeof(IEnumerable).IsAssignableFrom(m.GetParameters().First().ParameterType));

            var nameHash = new HashSet<string>();

            var records = qyMethods.Join(
                                enMethods, 
                                m => m, 
                                m => m, 
                                (mQy, mEn) => new SeqMethod(IndividuateName(nameHash, mQy.Name), mQy, mEn), 
                                new MethodEqualityComparer());

            var d = records.OrderBy(s => s.Name)
                            .ToDictionary(s => s.Name);

            return d;
        }

        
        class MethodEqualityComparer : IEqualityComparer<MethodInfo>
        {
            public bool Equals(MethodInfo x, MethodInfo y) {
                return x.Name == y.Name
                        && x.GetParameters().Select(p => p.ParameterType)
                                                .SequenceEqual(
                                                    y.GetParameters().Select(p => p.ParameterType), 
                                                    new TypeEqualityComparer());
            }

            public int GetHashCode(MethodInfo obj) {
                return obj.Name.GetHashCode() + obj.GetParameters().Length; //SHOULD DO SUMMAT BETTER THAN THIS!!
            }
        }

        class TypeEqualityComparer : IEqualityComparer<Type>
        {
            static ISet<Type> _seqGens = new HashSet<Type>(new[] { typeof(IQueryable<>), typeof(IEnumerable<>) });
            static ISet<Type> _seqNonGens = new HashSet<Type>(new[] { typeof(IQueryable), typeof(IEnumerable) });
            static ISet<Type> _ordGens = new HashSet<Type>(new[] { typeof(IOrderedQueryable<>), typeof(IOrderedEnumerable<>) });

            public bool Equals(Type x, Type y) 
            {
                x = UnpackExpression(x);
                y = UnpackExpression(y);

                if(_seqNonGens.Contains(x) && _seqNonGens.Contains(y)) {
                    return true;
                }
                
                if(x.IsGenericParameter && y.IsGenericParameter) {
                    return x.GenericParameterPosition == y.GenericParameterPosition;
                }
                
                if(x.IsGenericTypeDefinition && y.IsGenericTypeDefinition) 
                {
                    if(_seqGens.Contains(x) && _seqGens.Contains(y)) {
                        return true;
                    }

                    if(_ordGens.Contains(x) && _ordGens.Contains(y)) {
                        return true;
                    }

                    return x == y;
                }

                if(x.IsGenericType && y.IsGenericType) {
                    return Equals(x.GetGenericTypeDefinition(), y.GetGenericTypeDefinition())
                            && x.GetGenericArguments().SequenceEqual(y.GetGenericArguments(), this); 
                }
                
                return x == y;
            }

            public int GetHashCode(Type obj) {
                return obj.Name.GetHashCode();
            }


            static Type UnpackExpression(Type t) {
                return (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Expression<>))
                            ? t.GetGenericArguments().Single()
                            : t;
            }

        }



        static string IndividuateName(ISet<string> names, string baseName) {
            for(int i = 1; true; i++) {
                var name = baseName + (i > 1 ? i.ToString() : "");

                if(!names.Contains(name)) {
                    names.Add(name);
                    return name;
                }
            }
        }


    }
}
