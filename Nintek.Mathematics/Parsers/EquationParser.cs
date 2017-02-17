using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics
{
    public class EquationParser : IParser
    {
        public SyntaxTree Parse(ITokenCollection tokens)
        {
            var rootNode = new Node(
                tokens,
                token => token is OperationToken && ((Operation) token.Value) == Operation.Equals);

            return new SyntaxTree(rootNode, tokens);
        }
    }
}
