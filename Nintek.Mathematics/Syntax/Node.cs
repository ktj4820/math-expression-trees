using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics
{
    public class Node
    {
        public IToken Token { get; private set; }
        public Node Left { get; private set; }
        public Node Right { get; private set; }

        public Node(IToken token, Node left, Node right)
        {
            Token = token;
            Left = left;
            Right = right;
        }
    }
}
