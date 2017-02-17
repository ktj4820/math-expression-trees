using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics
{
    public class BuilderNode
    {
        public IToken Token { get; set; }
        public BuilderNode Left { get; set; }
        public BuilderNode Right { get; set; }

        public override string ToString()
        {
            return $"<{Token.ToString()}>";
        }

        public Node ToNode()
        {
            return new Node(Token, Left?.ToNode(), Right?.ToNode());
        }
    }
}
