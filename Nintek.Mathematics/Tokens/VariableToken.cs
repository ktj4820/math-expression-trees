using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics
{
    public class VariableToken : Token<string>
    {
        public VariableToken(string value)
            : base(value)
        {
        }
    }
}
