using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics
{
    public class Tokenizer : ITokenizer
    {
        readonly IAtomicTokenizer _atomicTokenizer;
        readonly ISemanticTokenizer _assembleTokenizer;
        readonly ISemanticTokenizer _parenthesesTokenizer;

        public Tokenizer(
            IAtomicTokenizer atomicTokenizer,
            ISemanticTokenizer assembleTokenizer,
            ISemanticTokenizer parenthesesTokenizer)
        {
            _atomicTokenizer = atomicTokenizer;
            _assembleTokenizer = assembleTokenizer;
            _parenthesesTokenizer = parenthesesTokenizer;
        }

        public ITokenCollection Tokenize(string expression)
        {
            var tokens = _atomicTokenizer.Tokenize(expression);
            tokens = _assembleTokenizer.Tokenize(tokens);
            tokens = _parenthesesTokenizer.Tokenize(tokens);
            return tokens;
        }
    }
}
