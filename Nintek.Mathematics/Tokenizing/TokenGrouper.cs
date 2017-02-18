using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nintek.Mathematics.Tokens;

namespace Nintek.Mathematics.Tokenizing
{
    public class TokenGrouper : ITokenGrouper
    {
        public IEnumerable<TokenGroup> GroupTokens(ITokenCollection tokens)
        {
            foreach (var groupTokens in SplitBySpaceTokens(tokens))
            {
                var tokenGroup = new TokenGroup(groupTokens);
                yield return tokenGroup;
            }
        }

        IEnumerable<ITokenCollection> SplitBySpaceTokens(ITokenCollection tokens)
        {
            var groupTokens = new List<IToken>();

            foreach (var token in tokens)
            {
                if (token is SpaceToken)
                {
                    yield return groupTokens.ToTokenCollection();
                    groupTokens = new List<IToken>();
                }
                else
                {
                    groupTokens.Add(token);
                    
                    if (token == tokens.Last())
                    {
                        yield return groupTokens.ToTokenCollection();
                    }
                }
            }
        }
    }
}
