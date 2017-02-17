using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics.Syntax.Builder
{
    public class LiteralNode : IBuilderNode
    {
        public IToken Token { get; }

        public LiteralNode(IToken token)
        {
            Token = token;
        }

        public Node Compile()
        {
            throw new NotImplementedException();
        }
    }
}
