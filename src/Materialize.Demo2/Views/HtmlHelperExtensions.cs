using HtmlTags;
using HtmlTags.Extended;
using Nancy.ViewEngines.Razor;
using System;
using System.Collections.Generic;
using System.Linq;
using Materialize.Demo2.DataStructures;

namespace Materialize.Demo2.Views
{
    public static class HtmlHelperExtensions
    {
        public static HtmlTag TreeList<TModel, TNode>(
            this HtmlHelpers<TModel> html,
            Tree<TNode> tree,
            Action<TNode, HtmlTag> fnModifyTag)
        {
            return new HtmlTag("ul", t => {
                foreach(var rootNode in tree.Roots) {
                    t.Append(TreeListNode(html, rootNode, fnModifyTag));
                }
            });
        }



        static HtmlTag TreeListNode<TModel, TValue>(
            this HtmlHelpers<TModel> html,
            TreeNode<TValue> node,
            Action<TValue, HtmlTag> fnModifyTag) 
        {
            return new HtmlTag("li", tLi => {
                fnModifyTag(node.Value, tLi);

                if(node.Children.Any()) {
                    tLi.Append("ul", tUl => {
                        foreach(var childNode in node.Children) {
                            tUl.Append(TreeListNode(html, childNode, fnModifyTag));
                        }
                    });
                }
            });
        }

        

        public static IHtmlString ToNancyHtmlString(this HtmlTag @this) {
            return new NonEncodedHtmlString(@this.ToString());
        }


    }
}