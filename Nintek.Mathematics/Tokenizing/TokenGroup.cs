using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics
{
    public class TokenGroup
    {
        public List<IToken> Tokens { get; }
        public Type[] TokenTypes { get; }

        public TokenGroup(List<IToken> tokens)
        {
            if (tokens == null) throw new ArgumentNullException(nameof(tokens));

            Tokens = tokens;
            TokenTypes = tokens.Select(t => t.GetType()).Distinct().ToArray();
        }
    }
}
