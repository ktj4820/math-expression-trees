using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics
{
    public class Node
    {
        public IToken Token { get; }
        public Node Parent { get; }
        public Node Left { get; }
        public Node Right { get; }

        public Node(IToken token, Node parent, Node left, Node right)
        {
            Token = token;
            Parent = parent;
            Left = left;
            Right = right;
        }
    }
}
