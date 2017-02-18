using System.Collections.Generic;

namespace Nintek.Mathematics
{
    public interface ITokenGrouper
    {
        IEnumerable<TokenGroup> GroupTokens(ITokenCollection tokens);
    }
}