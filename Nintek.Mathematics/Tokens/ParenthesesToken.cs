using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics.Tokens
{
    public class ParenthesesToken : Token<ITokenCollection>
    {
        public ParenthesesToken(ITokenCollection parenthesesContent)
            : base(parenthesesContent)
        {
        }
    }
}
