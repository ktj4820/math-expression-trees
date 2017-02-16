using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics
{
    /// <summary>
    /// Object which task is to transform stream of tokens into syntax tree.
    /// </summary>
    public interface IParser
    {
        SyntaxTree Parse(IReadOnlyCollection<IToken> tokens);
    }
}
