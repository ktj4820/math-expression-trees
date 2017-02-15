using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics
{
    public class Node
    {
        public IToken Token { get; private set; }
        public Node Left { get; private set; }
        public Node Right { get; private set; }

        public Node(IReadOnlyCollection<IToken> tokens, Func<IToken, bool> rootPredicate)
        {
            Split(tokens, rootPredicate);
        }

        void Split(IReadOnlyCollection<IToken> tokens, Func<IToken, bool> predicate)
        {
            var left = new List<IToken>();
            var right = new List<IToken>();
            IToken delimiter = null;
            var predicateSolved = false;

            foreach (var token in tokens)
            {
                if (predicate(token) && !predicateSolved)
                {
                    delimiter = token;
                    predicateSolved = true;
                    continue;
                }

                if (delimiter == null)
                {
                    left.Add(token);
                }
                else
                {
                    right.Add(token);
                }
            }

            if (delimiter == null)
            {
                Token = tokens.First();
                return;
            }
            else
            {
                Token = delimiter;
            }

            Left = new Node(left, token => token is OperationToken);
            Right = new Node(right, token => token is OperationToken);
        }

        public override string ToString()
        {
            return $"node: {Token.ToString()}";
        }
    }
}
