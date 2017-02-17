using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics
{
    public class TokenCollectionSplit : ITokenCollectionSplit
    {
        public IToken Delimiter { get; }
        public ITokenCollection Left { get; }
        public ITokenCollection Right { get; }

        public TokenCollectionSplit(
            IToken delimiter,
            ITokenCollection left,
            ITokenCollection right)
        {
            Delimiter = delimiter;
            Left = left;
            Right = right;  
        }
    }
}
