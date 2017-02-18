using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics
{
    public class Node : IWalkable<Node>
    {
        public IToken Token { get; }
        public Node Left { get; }
        public Node Right { get; }

        public Node(IToken token, Node left, Node right)
        {
            Token = token;
            Left = left;
            Right = right;
        }

        public IEnumerable<Node> InOrderWalk()
        {
            foreach (var node in InOrderWalk(this))
            {
                yield return node;
            }
        }

        IEnumerable<Node> InOrderWalk(Node node)
        {
            if (node.Left != null)
            {
                foreach (var child in InOrderWalk(node.Left))
                {
                    yield return child;
                }
            }

            yield return node;

            if (node.Right != null)
            {
                foreach (var child in InOrderWalk(node.Right))
                {
                    yield return child;
                }
            }
        }

        public IEnumerable<Node> PreOrderWalk()
        {
            foreach (var node in PreOrderWalk(this))
            {
                yield return node;
            }
        }

        IEnumerable<Node> PreOrderWalk(Node node)
        {
            yield return node;

            if (node.Left != null)
            {
                foreach (var child in PreOrderWalk(node.Left))
                {
                    yield return child;
                }
            }

            if (node.Right != null)
            {
                foreach (var child in PreOrderWalk(node.Right))
                {
                    yield return child;
                }
            }
        }

        public IEnumerable<Node> PostOrderWalk()
        {
            foreach (var node in PostOrderWalk(this))
            {
                yield return node;
            }
        }

        IEnumerable<Node> PostOrderWalk(Node node)
        {
            if (node.Left != null)
            {
                foreach (var child in PostOrderWalk(node.Left))
                {
                    yield return child;
                }
            }

            if (node.Right != null)
            {
                foreach (var child in PostOrderWalk(node.Right))
                {
                    yield return child;
                }
            }

            yield return node;
        }

        public void InOrder(Action<Node> action)
            => InOrder(this, action);

        void InOrder(Node node, Action<Node> action)
        {
            if (node.Left != null) InOrder(node.Left, action);
            action(node);
            if (node.Right != null) InOrder(node.Right, action);
        }

        public void PreOrder(Action<Node> action)
            => PreOrder(this, action);

        void PreOrder(Node node, Action<Node> action)
        {
            action(node);
            if (node.Left != null) PreOrder(node.Left, action);
            if (node.Right != null) PreOrder(node.Right, action);
        }

        public void PostOrder(Action<Node> action)
            => PostOrder(this, action);

        void PostOrder(Node node, Action<Node> action)
        {
            if (node.Left != null) PostOrder(node.Left, action);
            if (node.Right != null) PostOrder(node.Right, action);
            action(node);
        }

        public IEnumerable<TResult> InOrderSelect<TResult>(Func<Node, TResult> selector)
        {
            foreach (var selected in InOrderSelect(this, selector))
            {
                yield return selected;
            }
        }

        IEnumerable<TResult> InOrderSelect<TResult>(Node node, Func<Node, TResult> selector)
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

        public IEnumerable<TResult> PreOrderSelect<TResult>(Func<Node, TResult> selector)
        {
            foreach (var selected in PreOrderSelect(this, selector))
            {
                yield return selected;
            }
        }

        IEnumerable<TResult> PreOrderSelect<TResult>(Node node, Func<Node, TResult> selector)
        {
            yield return selector(node);

            if (node.Left != null)
            {
                foreach (var selected in PreOrderSelect(node.Left, selector))
                {
                    yield return selected;
                }
            }

            if (node.Right != null)
            {
                foreach (var selected in PreOrderSelect(node.Right, selector))
                {
                    yield return selected;
                }
            }
        }

        public IEnumerable<TResult> PostOrderSelect<TResult>(Func<Node, TResult> selector)
        {
            foreach (var selected in PostOrderSelect(this, selector))
            {
                yield return selected;
            }
        }

        IEnumerable<TResult> PostOrderSelect<TResult>(Node node, Func<Node, TResult> selector)
        {
            if (node.Left != null)
            {
                foreach (var selected in PostOrderSelect(node.Left, selector))
                {
                    yield return selected;
                }
            }

            if (node.Right != null)
            {
                foreach (var selected in PostOrderSelect(node.Right, selector))
                {
                    yield return selected;
                }
            }

            yield return selector(node);
        }

        public IEnumerator<Node> GetEnumerator()
            => InOrderWalk().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => InOrderWalk().GetEnumerator();
    }
}
