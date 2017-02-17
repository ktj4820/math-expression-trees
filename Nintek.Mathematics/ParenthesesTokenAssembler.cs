using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics
{
    public class ParenthesesTokenAssembler
    {
        public IEnumerable<IToken> AssembleParentheses(IEnumerable<IToken> tokens)
        {
            if (!tokens.OfType<ParenthesisToken>().Any())
            {
                return tokens;
            }

            var result = new List<IToken>();
            var parentheses = new List<IToken>();
            var isParenthesisOpened = false;
            var scopeDepth = 0;

            foreach (var token in tokens)
            {
                if (isParenthesisOpened)
                {
                    if (token.IsParenthesis(Parenthesis.Left))
                    {
                        scopeDepth++;
                    }
                    else if (token.IsParenthesis(Parenthesis.Right))
                    {
                        scopeDepth--;

                        if (scopeDepth == 0)
                        {
                            var parenthesesToken = new ParenthesesToken(new TokenCollection(parentheses));
                            result.Add(parenthesesToken);

                            AssembleParentheses(parenthesesToken.Value);

                            parentheses.Clear();
                            isParenthesisOpened = false;
                            continue;
                        }
                    }
                    parentheses.Add(token);
                }
                else
                {
                    if (token.IsParenthesis(Parenthesis.Left))
                    {
                        isParenthesisOpened = true;
                        scopeDepth++;
                    }
                    else
                    {
                        result.Add(token);
                    }
                }
            }

            return result;
        }
    }
}
