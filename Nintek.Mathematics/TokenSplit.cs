using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics
{
    public class TokenSplit
    {
        public IToken Delimiter { get; }
        public IReadOnlyCollection<IToken> Left { get; }
        public IReadOnlyCollection<IToken> Right { get; }

        public TokenSplit(
            IToken delimiter,
            IReadOnlyCollection<IToken> left,
            IReadOnlyCollection<IToken> right)
        {
            Delimiter = delimiter;
            Left = left;
            Right = right;
        }
    }
}
