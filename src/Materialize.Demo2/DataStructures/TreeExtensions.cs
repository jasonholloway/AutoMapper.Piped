using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Demo2.DataStructures
{
    public static class TreeExtensions
    {
        public static void ForEach<TValue>(
                                this Tree<TValue> @this, Action<TValue> fnAction) {
            foreach(var rootNode in @this.Roots) {
                ForEach(rootNode, fnAction);
            }
        }

        public static void ForEach<TValue>(
                                this TreeNode<TValue> @this,
                                Action<TValue> fnAction) {
            fnAction(@this.Value);

            foreach(var childNode in @this.Children) {
                ForEach(childNode, fnAction);
            }
        }




        public static void ForEach<TValue>(
                                this Tree<TValue> @this,
                                Action<TreeNode<TValue>, IEnumerable<TreeNode<TValue>>> fnActionWithPath) {
            foreach(var rootNode in @this.Roots) {
                ForEach(rootNode, fnActionWithPath);
            }
        }


        public static void ForEach<TValue>(
                                this TreeNode<TValue> @this,
                                Action<TreeNode<TValue>, IEnumerable<TreeNode<TValue>>> fnActionWithPath) {
            ForEach(@this, fnActionWithPath, new Stack<TreeNode<TValue>>());
        }

        static void ForEach<TValue>(
                        this TreeNode<TValue> @this,
                        Action<TreeNode<TValue>, IEnumerable<TreeNode<TValue>>> fnAction,
                        Stack<TreeNode<TValue>> pathStack) {
            fnAction(@this, pathStack);

            pathStack.Push(@this);

            foreach(var childNode in @this.Children) {
                ForEach(childNode, fnAction, pathStack);
            }

            pathStack.Pop();
        }




        public static IEnumerable<TreeNode<TValue>> Flatten<TValue>(this Tree<TValue> @this) {
            return @this.Roots.SelectMany(r => Flatten(r));
        }

        public static IEnumerable<TreeNode<TValue>> Flatten<TValue>(this TreeNode<TValue> @this) {
            yield return @this;

            var descendents = @this.Children.SelectMany(c => Flatten(c));

            foreach(var descendent in descendents) {
                yield return descendent;
            }
        }



        public static Tree<TNewItem> Project<TItem, TNewItem>(this Tree<TItem> @this, Func<TItem, TNewItem> fnProject) {
            return new Tree<TNewItem>(
                            @this.Roots
                                    .Select(r => Project(r, fnProject))
                                    .ToArray()
                            );
        }

        public static TreeNode<TNewItem> Project<TItem, TNewItem>(this TreeNode<TItem> @this, Func<TItem, TNewItem> fnProject) {
            return new TreeNode<TNewItem>(
                            fnProject(@this.Value),
                            @this.Children
                                    .Select(c => Project(c, fnProject))
                                    .ToArray()
                            );
        }





        public static Tree<TNewItem> Project<TItem, TNewItem>(
                                                this Tree<TItem> @this,
                                                Func<TreeNode<TItem>, IEnumerable<TreeNode<TItem>>, TNewItem> fnProject) {
            return new Tree<TNewItem>(
                            @this.Roots
                                    .Select(r => r.Project(fnProject))
                                    .ToArray()
                            );
        }

        public static TreeNode<TNewItem> Project<TItem, TNewItem>(
                                                    this TreeNode<TItem> @this,
                                                    Func<TreeNode<TItem>, IEnumerable<TreeNode<TItem>>, TNewItem> fnProject) {
            return @this.Project(fnProject, new Stack<TreeNode<TItem>>());
        }


        static TreeNode<TNewItem> Project<TItem, TNewItem>(
                                            this TreeNode<TItem> @this,
                                            Func<TreeNode<TItem>, IEnumerable<TreeNode<TItem>>, TNewItem> fnProject,
                                            Stack<TreeNode<TItem>> stPath) {
            stPath.Push(@this);

            var childNodes = @this.Children
                                    .Select(c => c.Project(fnProject, stPath))
                                    .ToArray();
            stPath.Pop();

            var newItem = fnProject(@this, stPath);

            return new TreeNode<TNewItem>(newItem, childNodes);
        }



    }
}
