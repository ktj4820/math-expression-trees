using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Nintek.Mathematics.Extensions;

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

            return groups.SelectMany(g => Assemble(g)).ToList();
        }

        IEnumerable<IToken> Assemble(TokenGroup group)
        {
            if (group.TokenTypes.Length == 1 && group.TokenTypes[0] == typeof(DigitToken))
            {
                return AssembleNumber(group.Tokens.Cast<DigitToken>()).AsEnumerable();
            }

            if (group.TokenTypes.Contains(typeof(LetterToken)))
            {
                if (group.Tokens.Count == 1)
                {
                    return new VariableToken(group.Tokens.First().Value.ToString()).AsEnumerable();
                }

                return AssembleComplexGroup(group.Tokens);
            }

            if (group.Tokens.Count == 1)
            {
                return group.Tokens.First().AsEnumerable();
            }

            throw new InvalidOperationException("Unknown rule for assembling tokens.");
        }

        NumberToken AssembleNumber(IEnumerable<DigitToken> digitTokens)
        {
            var numberStr = digitTokens.Aggregate("", (accumulator, token) => accumulator + token.Value);
            var number = double.Parse(numberStr);
            var result = new NumberToken(number);
            return result;
        }
        
        // e.g. valid complex groups: 'xy' or '2xy'
        IEnumerable<IToken> AssembleComplexGroup(IEnumerable<IToken> tokens)
        {
            var components = tokens.ToArray();
            var digits = components.OfType<DigitToken>();
            var number = AssembleNumber(digits);

            yield return number;

            foreach (var component in components.OfType<LetterToken>())
            {
                yield return new OperationToken(Operation.Multiply);
                yield return new VariableToken(component.Value.ToString());
            }
        }
    }
}
