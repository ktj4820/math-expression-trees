using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nintek.Mathematics.Tokens;

namespace Nintek.Mathematics.Tokenizing
{
    public class ParenthesisGroupAssembler : ITokenGroupAssembler
    {
        readonly ITokenGroupAssembler _numberAssembler;

        public ParenthesisGroupAssembler(ITokenGroupAssembler numberAssembler)
        {
            _numberAssembler = numberAssembler;
        }

        public bool CanAssemble(ITokenGroup group)
            => group.TokenTypes.Contains(typeof(ParenthesisToken));

        public IEnumerable<IToken> Assemble(ITokenCollection tokens)
        {
            var numberAccumulator = new List<DigitToken>();

            foreach (var token in tokens)
            {
                if (token is ParenthesisToken)
                {
                    if (numberAccumulator.Any())
                    {
                        foreach (var numberToken in _numberAssembler.Assemble(numberAccumulator.ToTokenCollection()))
                        {
                            yield return numberToken;
                        }
                        numberAccumulator.Clear();
                    }

                    yield return token;
                }
                else
                {
                    var digitToken = (DigitToken)token;
                    numberAccumulator.Add(digitToken);
                }
            }

            if (!numberAccumulator.Any())
            {
                yield break;
            }

            foreach (var numberToken in _numberAssembler.Assemble(numberAccumulator.ToTokenCollection()))
            {
                yield return numberToken;
            }
        }
    }
}
