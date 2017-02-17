using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics
{
    public static class TokenCollectionExtensions
    {
        public static ITokenCollection ToTokenCollection(this IEnumerable<IToken> tokens)
            => new TokenCollection(tokens);
    }
}
