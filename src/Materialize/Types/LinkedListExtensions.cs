using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Types
{
    public static class LinkedListExtensions
    {

        public static IEnumerable<LinkedListNode<TVal>> EnumerateNodes<TVal>(this LinkedList<TVal> @this) 
        {
            var node = @this.First;

            while(node != null) {
                yield return node;
                node = node.Next;
            }
        }


    }
}
