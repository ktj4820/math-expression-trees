using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics
{
    public interface ITokenCollection : IReadOnlyCollection<IToken>
    {
        IToken this[int index] { get; }
        int FindIndex(Predicate<IToken> predicate);
    }
}
