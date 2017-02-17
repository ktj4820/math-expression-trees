using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics
{
    public class ParenthesesToken : Token<ITokenCollection>
    {
        public ParenthesesToken(ITokenCollection parenthesesContent)
            : base(parenthesesContent)
        {
        }

        public Node Compile()
            => new Node(Value, token => token is OperationToken);
    }
}
