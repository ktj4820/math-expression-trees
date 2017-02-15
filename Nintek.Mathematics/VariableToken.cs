using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics
{
    public class VariableToken : IComplexToken<string>
    {
        public IReadOnlyCollection<IToken> Components { get; }
        public string Value { get; }

        public VariableToken(string value, IReadOnlyCollection<IToken> components)
        {
            Value = value;
            Components = components;
        }
    }
}
