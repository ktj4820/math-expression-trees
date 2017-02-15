using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

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
            var groups = _tokenGrouper.GroupTokens(tokens.ToArray());

            return groups.Select(g => Assemble(g)).ToList();
        }

        IToken Assemble(TokenGroup group)
        {
            if (group.TokenTypes.Length == 1 && group.TokenTypes[0] == typeof(DigitToken))
            {
                return AssembleNumber(group.Tokens.Cast<DigitToken>());
            }

            if (group.TokenTypes.Contains(typeof(LetterToken)))
            {
                return AssembleVariable(group.Tokens);
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

        VariableToken AssembleVariable(IEnumerable<IToken> tokens)
        {
            var components = tokens.ToArray();
            var tokenString = components.Aggregate("", (accumulator, component) => accumulator + component.Value.ToString());

            var number = Regex.Match(tokenString, @"\d+").Value;

            if (!tokenString.StartsWith(number))
            {
                throw new InvalidOperationException("Input tokenization error.");
            }

            VariableToken token;

            if (string.IsNullOrEmpty(number))
            {
                token = new VariableToken(tokenString, components);
            }
            else
            {
                token = new VariableToken(tokenString, double.Parse(number), components);
            }
            
            return token;
        }
    }
}
