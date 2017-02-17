using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics.Syntax.Builder
{
    public class ExpressionNode : IBuilderNode
    {
        public ITokenCollection Tokens { get; }

        public ExpressionNode(ITokenCollection tokens)
        {
            Tokens = tokens;
        }

        public Node Compile()
        {
            throw new NotImplementedException();
        }
    }
}
