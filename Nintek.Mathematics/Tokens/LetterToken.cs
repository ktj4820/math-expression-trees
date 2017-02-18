using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics.Tokens
{
    public class LetterToken : Token<char>
    {
        public LetterToken(char letter)
            : base(letter)
        {
        }
    }
}
