using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics
{
    public class NumberToken : Token<double>, IComplexToken<double>
    {
        public IReadOnlyCollection<IToken> Components { get; }

        public NumberToken(double value, IReadOnlyCollection<IToken> components)
            : base(value)
        {
            Components = components;
        }
    }
}
