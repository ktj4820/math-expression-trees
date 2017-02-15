using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics
{
    public interface IComplexToken<TValue> : IToken<TValue>
    {
        IReadOnlyCollection<IToken> Components { get; }
    }
}
