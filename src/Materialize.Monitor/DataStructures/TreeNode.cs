using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Monitor.DataStructures
{
    public class TreeNode<TValue>
    {
        public static readonly TreeNode<TValue>[] EmptyArray = new TreeNode<TValue>[0];


        public TValue Value { get; private set; }

        public TreeNode<TValue>[] Children { get; private set; }


        public TreeNode(TValue value, IEnumerable<TreeNode<TValue>> children = null) {
            Value = value;
            Children = children != null
                        ? children.ToArray()
                        : EmptyArray;
        }
    }
}
