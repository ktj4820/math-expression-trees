using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics
{
    public class Token<TValue> : IToken<TValue>
    {
        public TValue Value { get; }

        public Token(TValue value)
        {
            Value = value;
        }

        public override string ToString()
        {
            var typeName = GetType().Name;
            var tokenName = typeName.Substring(0, typeName.Length - 5);

            return $"{tokenName}: {Value}";
        }
    }
}
