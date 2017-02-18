using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics
{
    public class Token<TValue> : IToken<TValue>, IToken
    {
        public TValue Value { get; }

        object IToken.Value => Value;
        
        public Token(TValue value)
        {
            Value = value;
        }
        
        public override string ToString()
        {
            var typeName = GetType().Name;
            var tokenName = typeName.Substring(0, typeName.Length - 5);

            if (this is ParenthesesToken)
            {
                return tokenName;
            }

            return $"{tokenName}: {Value}";
        }
    }
}
