using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics
{
    public class TokenGrouper
    {
        public IEnumerable<TokenGroup> GroupTokens(ITokenCollection tokens)
        {
            foreach (var groupTokens in SplitBySpaceTokens(tokens))
            {
                var tokenGroup = new TokenGroup(groupTokens);
                yield return tokenGroup;
            }
        }

        IEnumerable<List<IToken>> SplitBySpaceTokens(ITokenCollection tokens)
        {
            var groupTokens = new List<IToken>();

            foreach (var token in tokens)
            {
                if (token is SpaceToken)
                {
                    yield return groupTokens;
                    groupTokens = new List<IToken>();
                }
                else
                {
                    groupTokens.Add(token);
                    
                    if (token == tokens.Last())
                    {
                        yield return groupTokens;
                    }
                }
            }
        }
    }
}
