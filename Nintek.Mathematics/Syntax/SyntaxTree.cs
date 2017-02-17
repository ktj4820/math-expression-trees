using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics
{
    public class SyntaxTree
    {
        public Node Root { get; }
        public ITokenCollection Source { get; }

        public SyntaxTree(Node root, ITokenCollection source)
        {
            Root = root;
            Source = source;
        }

        public IEnumerable<T> InOrderSelect<T>(Func<Node, T> selector)
        {
            return InOrderSelect(Root, selector);
        }

        IEnumerable<T> InOrderSelect<T>(Node node, Func<Node, T> selector)
        {
            if (node.Left != null)
            {
                foreach (var selected in InOrderSelect(node.Left, selector))
                {
                    yield return selected;
                }
            }

            yield return selector(node);

            if (node.Right != null)
            {
                foreach (var selected in InOrderSelect(node.Right, selector))
                {
                    yield return selected;
                }
            }
        }

        public void InOrderTreeWalk(Action<Node> action)
        {
            InOrderTreeWalk(Root, action);
        }

        void InOrderTreeWalk(Node node, Action<Node> action)
        {
            if (node.Left != null) InOrderTreeWalk(node.Left, action);
            action(node);
            if (node.Right != null) InOrderTreeWalk(node.Right, action);
        }

        public void PreOrderTreeWalk(Action<Node> action)
        {
            PreOrderTreeWalk(Root, action);
        }

        void PreOrderTreeWalk(Node node, Action<Node> action)
        {
            action(node);
            if (node.Left != null) PreOrderTreeWalk(node.Left, action);
            if (node.Right != null) PreOrderTreeWalk(node.Right, action);
        }

        public void PostOrderTreeWalk(Action<Node> action)
        {
            PostOrderTreeWalk(Root, action);
        }

        void PostOrderTreeWalk(Node node, Action<Node> action)
        {
            if (node.Left != null) PostOrderTreeWalk(node.Left, action);
            if (node.Right != null) PostOrderTreeWalk(node.Right, action);
            action(node);
        }
    }
}
