using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics
{
    public interface IToken
    {
    }

    public interface IToken<TValue> : IToken
    {
        TValue Value { get; }
    }
}
