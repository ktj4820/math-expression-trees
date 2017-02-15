using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics
{
    public class TokenAssembler
    {
        readonly TokenGrouper _tokenGrouper;

        public TokenAssembler()
        {
            _tokenGrouper = new TokenGrouper();
        }

        public IEnumerable<IToken> AssembleComplexTokens(IEnumerable<IToken> tokens)
        {
            var groups = _tokenGrouper.GroupTokens(tokens);

            return groups.Select(g => Assemble(g)).ToList();
        }

        IToken Assemble(TokenGroup group)
        {
            if (group.TokensType == typeof(DigitToken))
            {
                return AssembleNumber(group.Tokens.Cast<DigitToken>());
            }

            if (group.TokensType == typeof(LetterToken))
            {
                return AssembleVariable(group.Tokens.Cast<LetterToken>());
            }

            if (group.Tokens.Count == 1)
            {
                return group.Tokens.First();
            }

            throw new InvalidOperationException("Unknown rule for assembling tokens.");
        }

        NumberToken AssembleNumber(IEnumerable<DigitToken> digitTokens)
        {
            var numberStr = digitTokens.Aggregate("", (accumulator, token) => accumulator + token.Value);
            var number = double.Parse(numberStr);
            var result = new NumberToken(number, digitTokens.ToList());
            return result;
        }

        VariableToken AssembleVariable(IEnumerable<LetterToken> letterTokens)
        {
            var variableName = letterTokens.Aggregate("", (accumulator, token) => accumulator + token.Value);
            var result = new VariableToken(variableName, letterTokens.ToList());
            return result;
        }
    }
}
