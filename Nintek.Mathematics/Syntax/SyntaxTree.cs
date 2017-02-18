using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics
{
    public class SyntaxTree : IWalkable<Node>
    {
        public Node Root { get; }
        public ITokenCollection Source { get; }

        public SyntaxTree(Node root, ITokenCollection source)
        {
            Root = root;
            Source = source;
        }

        public IEnumerable<Node> InOrderWalk()
            => Root.InOrderWalk();

        public IEnumerable<Node> PreOrderWalk()
            => Root.PreOrderWalk();

        public IEnumerable<Node> PostOrderWalk()
            => Root.PostOrderWalk();

        public void InOrder(Action<Node> action)
            => Root.InOrder(action);

        public void PreOrder(Action<Node> action)
            => Root.PreOrder(action);

        public void PostOrder(Action<Node> action)
            => Root.PostOrder(action);

        public IEnumerable<TResult> InOrderSelect<TResult>(Func<Node, TResult> selector)
            => Root.InOrderSelect(selector);

        public IEnumerable<TResult> PreOrderSelect<TResult>(Func<Node, TResult> selector)
            => Root.PreOrderSelect(selector);

        public IEnumerable<TResult> PostOrderSelect<TResult>(Func<Node, TResult> selector)
            => Root.PostOrderSelect(selector);

        public IEnumerator<Node> GetEnumerator()
            => Root.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => Root.GetEnumerator();
    }
}
