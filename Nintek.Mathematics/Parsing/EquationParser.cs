using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics.Parsers
{
    class EquationParser : IParser
    {
        public SyntaxTree Parse(ITokenCollection tokens)
        {
            throw new NotImplementedException("Equations are not supported in this version.");
        }
    }
}
