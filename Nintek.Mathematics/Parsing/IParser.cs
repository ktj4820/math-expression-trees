using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nintek.Mathematics.Tokens;
using Nintek.Mathematics.Syntax;

namespace Nintek.Mathematics.Parsing
{
    /// <summary>
    /// Object which task is to transform stream of tokens into syntax tree.
    /// </summary>
    public interface IParser
    {
        SyntaxTree Parse(ITokenCollection tokens);
    }
}
