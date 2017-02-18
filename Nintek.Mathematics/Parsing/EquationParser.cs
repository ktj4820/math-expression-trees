using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nintek.Mathematics.Syntax;
using Nintek.Mathematics.Tokens;

namespace Nintek.Mathematics.Parsing
{
    class EquationParser : IParser
    {
        public SyntaxTree Parse(ITokenCollection tokens)
        {
            throw new NotImplementedException("Equations are not supported in this version.");
        }
    }
}
