using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics
{
    public class DigitToken : Token<char>
    {
        public DigitToken(char digit)
            : base(digit)
        {
        }
    }
}
