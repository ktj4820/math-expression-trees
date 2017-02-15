using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics
{
    public class Parser
    {
        public SyntaxTree Parse(IReadOnlyCollection<IToken> tokens)
        {
            var split = Split(tokens, token => token is OperationToken && ((Operation) token.Value) == Operation.Equals);

            

            throw new NotImplementedException();
        }

        TokenSplit Split(IReadOnlyCollection<IToken> tokens, Func<IToken, bool> predicate)
        {
            var left = new List<IToken>();
            var right = new List<IToken>();
            IToken delimiter = null;

            foreach (var token in tokens)
            {
                if (predicate(token))
                {
                    delimiter = token;
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

            return new TokenSplit(delimiter, left, right);
        }
    }
}
