using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics
{
    public class Tokenizer
    {
        readonly CharTokenizer _charTokenizer;
        readonly TokenAssembler _tokenAssembler;

        public Tokenizer()
        {
            _charTokenizer = new CharTokenizer();
            _tokenAssembler = new TokenAssembler();
        }

        public IEnumerable<IToken> Tokenize(string expression)
        {
            var tokens = expression.Select(c => _charTokenizer.Tokenize(c));
            tokens = _tokenAssembler.AssembleComplexTokens(tokens);
            return tokens;
        }
    }
}
