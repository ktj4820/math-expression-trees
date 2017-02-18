using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nintek.Mathematics.Tokens;

namespace Nintek.Mathematics.Tokenizing
{
    public interface ISemanticTokenizer
    {
        ITokenCollection Tokenize(ITokenCollection tokens);
    }
}
