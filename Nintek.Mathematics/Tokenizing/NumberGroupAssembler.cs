using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nintek.Mathematics.Tokens;

namespace Nintek.Mathematics.Tokenizing
{
    public class NumberGroupAssembler : ITokenGroupAssembler
    {
        public bool CanAssemble(ITokenGroup group)
            => group.TokenTypes.Length == 1 && group.TokenTypes[0] == typeof(DigitToken);

        public IEnumerable<IToken> Assemble(ITokenCollection tokens)
        {
            var digitTokens = tokens.OfType<DigitToken>().ToArray();
            var numberStr = digitTokens.Aggregate("", (accumulator, token) => accumulator + token.Value);
            var number = double.Parse(numberStr);
            yield return new NumberToken(number);
        }
    }
}
