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
            if (tokens.Count == 1)
            {
                Token = tokens.First();
                return;
            }

            var left = new List<IToken>();
            var right = new List<IToken>();
            IToken delimiter = null;
            var predicateSolved = false;

            var firstOperation = tokens
                .OfType<OperationToken>()
                .Aggregate((Operation) int.MaxValue, (accumulator, token) => accumulator > token.Value ? token.Value : accumulator);

            foreach (var token in tokens)
            {
                if (predicate(token) && !predicateSolved && IsOperation(token, firstOperation))
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
            => $"<{Token.ToString()}>";

        bool IsOperation(IToken token, Operation comparedOperation)
        {
            var operationToken = token as OperationToken;

            if (operationToken == null)
            {
                return false;
            }

            return operationToken.Value == comparedOperation;
        }
    }
}
