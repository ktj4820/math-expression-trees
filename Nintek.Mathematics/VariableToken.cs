using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics
{
    public class VariableToken : Token<string>, IComplexToken<string>
    {
        public IReadOnlyCollection<IToken> Components { get; }

        public VariableToken(string value, IReadOnlyCollection<IToken> components)
            : base(value)
        {
            Components = components;
        }
    }
}
