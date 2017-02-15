using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics
{
    public class Node
    {
        public Node Parent { get; }
        public Node Left { get; }
        public Node Right { get; }
        public IToken Token { get; }

        Node()
        {
            
        }
    }
}
