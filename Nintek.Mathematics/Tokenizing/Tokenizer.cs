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

        public ITokenCollection Tokenize(string expression)
        {
            var tokens = expression.Select(c => _charTokenizer.Tokenize(c)).ToTokenCollection();
            tokens = _tokenAssembler.AssembleComplexTokens(tokens);
            return new TokenCollection(tokens);
        }
    }
}
