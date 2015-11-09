using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Monitor.DataStructures
{
    public class Tree<TValue>
    {
        public TreeNode<TValue>[] Roots { get; private set; }

        public Tree(IEnumerable<TreeNode<TValue>> roots = null) {
            Roots = roots != null
                    ? roots.ToArray()
                    : TreeNode<TValue>.EmptyArray;
        }
    }




    public static class Tree
    {

        public static Tree<TItem> BuildFromCrawl<TItem>(
            IEnumerable<TItem> rootItems,
            Func<TItem, IEnumerable<TItem>> fnGetChildren) 
        {
            return new Tree<TItem>(rootItems
                                    .Select(i => BuildNodeFromCrawl(i, fnGetChildren)));

        }

        public static Tree<TItem> BuildFromCrawl<TItem>(
            TItem rootItem,
            Func<TItem, IEnumerable<TItem>> fnGetChildren) 
        {
            return BuildFromCrawl(new[] { rootItem }, fnGetChildren);
        }



        static TreeNode<TItem> BuildNodeFromCrawl<TItem>(
            TItem item,
            Func<TItem, IEnumerable<TItem>> fnGetChildren) 
        {
            return new TreeNode<TItem>(
                            item,
                            fnGetChildren(item)
                                    .Select(ci => BuildNodeFromCrawl(ci, fnGetChildren))
                            );
        }







        public static Tree<TItem> BuildFromIndexedItems<TItem, TIndex>(
            IEnumerable<TItem> items,
            Func<TItem, TIndex> fnGetIndex,
            Func<TItem, TIndex> fnGetParentIndex) 
        {
            var rItems = items.ToArray();

            var dTempNodes = rItems
                                .Select(i => new TempNode<TItem>(i))
                                .ToDictionary(n => fnGetIndex(n.Item));


            foreach(var t in dTempNodes.Values
                                    .Select(n => new { ParentID = fnGetParentIndex(n.Item), Node = n })) {
                if(object.Equals(t.ParentID, default(TIndex))) {
                    continue;
                }

                TempNode<TItem> parent = null;

                if(!dTempNodes.TryGetValue(t.ParentID, out parent)) {
                    throw new InvalidOperationException("Category with bad parent id encountered!");
                }

                t.Node.Parent = parent;
                parent.Children.Add(t.Node);
            }

            //now recursively pass into SimpleTree structure

            var rootTempNodes = dTempNodes.Values
                                    .Where(n => n.Parent == null);

            var rootTreeNodes = rootTempNodes
                                    .Select(n => n.Convert2TreeNode());

            return new Tree<TItem>(rootTreeNodes.ToArray());
        }


        class TempNode<TItem>
        {
            public TItem Item { get; private set; }
            public TempNode<TItem> Parent { get; set; }
            public List<TempNode<TItem>> Children { get; private set; }

            public TempNode(TItem item) {
                Item = item;
                Children = new List<TempNode<TItem>>();
            }

            public TreeNode<TItem> Convert2TreeNode() {
                return new TreeNode<TItem>(
                                Item,
                                Children.Select(n => n.Convert2TreeNode())
                                            .ToArray()
                                );
            }
        }
    }



}
