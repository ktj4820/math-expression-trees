using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics
{
    public static class TokenExtensions
    {
        public static bool IsParenthesis(this IToken token)
        {
            return token as ParenthesisToken != null;
        }

        public static bool IsParenthesis(this IToken token, Parenthesis parenthesis)
        {
            var parenthesisToken = token as ParenthesisToken;
            return parenthesisToken != null && parenthesisToken.Value == parenthesis;
        }
    }
}
