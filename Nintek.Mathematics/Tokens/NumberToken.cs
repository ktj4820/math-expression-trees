using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics.Tokens
{
    public class NumberToken : Token<double>
    {
        public NumberToken(double value)
            : base(value)
        {
        }
    }
}
