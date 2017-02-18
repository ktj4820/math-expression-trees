using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics.Tokens
{
    public interface IToken
    {
        object Value { get; }
    }

    public interface IToken<TValue>
    {
        TValue Value { get; }
    }
}
