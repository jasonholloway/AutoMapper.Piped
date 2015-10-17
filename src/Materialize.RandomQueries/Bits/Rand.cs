using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.RandomQueries.Bits
{
    static class Rand
    {
        static Random _r = new Random((int)DateTime.Now.Ticks);
        
        public static TItem FromList<TItem>(params TItem[] items) 
        {
            if(!items.Any()) {
                return default(TItem);
            }

            return items[_r.Next(0, items.Length)];
        }


        public static int FromRange(int min, int max) {
            return _r.Next(min, max);
        }


        public static bool FromProbability(double dProb) {
            if(dProb > 1d) {
                throw new ArgumentOutOfRangeException("dProb");
            }

            return _r.NextDouble() < dProb;
        }


    }
}
