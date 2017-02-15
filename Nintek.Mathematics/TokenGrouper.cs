using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics
{
    public class TokenGrouper
    {
        public List<TokenGroup> GroupTokens(IEnumerable<IToken> tokens)
        {
            var groups = new List<TokenGroup>();

            TokenGroup currentGroup = null;

            foreach (var token in tokens)
            {
                //if (token is SpaceToken)
                //{
                //    continue;
                //}

                var tokenType = token.GetType();

                if (currentGroup != null && tokenType != currentGroup.TokensType)
                {
                    groups.Add(currentGroup);
                    currentGroup = null;
                }

                if (currentGroup == null)
                {
                    currentGroup = new TokenGroup();
                    currentGroup.TokensType = tokenType;
                }

                currentGroup.Tokens.Add(token);
            }

            groups.Add(currentGroup);

            return groups;
        }
    }
}
