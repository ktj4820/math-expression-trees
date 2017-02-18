using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics
{
    public class TokenGroup : ITokenGroup
    {
        public ITokenCollection Tokens { get; }
        public Type[] TokenTypes { get; }

        public TokenGroup(ITokenCollection tokens)
        {
            if (tokens == null) throw new ArgumentNullException(nameof(tokens));

            Tokens = tokens;
            TokenTypes = tokens.Select(t => t.GetType()).Distinct().ToArray();
        }
    }
}
