using System.Collections.Generic;
using Nintek.Mathematics.Tokens;

namespace Nintek.Mathematics.Tokenizing
{
    public interface ITokenGrouper
    {
        IEnumerable<TokenGroup> GroupTokens(ITokenCollection tokens);
    }
}