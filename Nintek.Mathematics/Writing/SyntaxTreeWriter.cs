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
            var friendlyTokens = tree
                .InOrderSelect(node => node.Token)
                .Select(token => ParseToken(token));

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
    }
}
