using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics
{
    public class NumberToken : IComplexToken<double>
    {
        public IReadOnlyCollection<IToken> Components { get; }
        public double Value { get; }

        public NumberToken(double value, IReadOnlyCollection<IToken> components)
        {
            Value = value;
            Components = components;
        }
    }
}
