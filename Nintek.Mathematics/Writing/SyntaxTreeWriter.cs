using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics
{
    public class SyntaxTreeWriter
    {
        public string TreeToString(SyntaxTree tree)
        {
            var friendlyTokens = tree.Source.Select(token => ParseToken(token));

            return string.Join(" ", friendlyTokens);
        }

        string ParseToken(IToken token)
        {
            if (token is VariableToken || token is NumberToken)
            {
                return token.Value.ToString();
            }

            var operationToken = token as OperationToken;
            if (operationToken != null)
            {
                return ParseOperationToken(operationToken);
            }

            var parenthesesToken = token as ParenthesesToken;
            if (parenthesesToken != null)
            {
                var parsedContent = string.Join(" ", ParseParenthesesToken(parenthesesToken));
                return $"({parsedContent})";
            }

            throw new InvalidOperationException($"Unknown token type: {token.GetType().FullName}.");
        }

        string ParseOperationToken(OperationToken token)
        {
            switch (token.Value)
            {
                case Operation.Add:
                    return "+";
                case Operation.Divide:
                    return "/";
                case Operation.Equals:
                    return "=";
                case Operation.Multiply:
                    return "*";
                case Operation.Remove:
                    return "-";
                default:
                    throw new InvalidOperationException($"Unknown {nameof(Operation)} type: {token.Value}.");
            }
        }

        string ParseParenthesisToken(ParenthesisToken token)
        {
            switch (token.Value)
            {
                case Parenthesis.Left:
                    return "(";
                case Parenthesis.Right:
                    return ")";
                default:
                    throw new InvalidOperationException($"Unknown {nameof(Parenthesis)} type: {token.Value}.");
            }
        }

        IEnumerable<string> ParseParenthesesToken(ParenthesesToken token)
            => token.Value.Select(t => ParseToken(t));
    }
}
