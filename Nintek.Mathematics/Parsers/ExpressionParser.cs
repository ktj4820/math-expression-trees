using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics
{
    public class ExpressionParser : IParser
    {
        public SyntaxTree Parse(ITokenCollection tokens)
        {
            var rootBuilderNode = ParseTree(tokens);
            var rootNode = rootBuilderNode.ToNode();
            return new SyntaxTree(rootNode, tokens);
        }

        BuilderNode ParseTree(ITokenCollection tokens)
        {
            Func<IToken, bool> splitPredicate = token =>
            {
                var maxWeight = tokens.OfType<OperationToken>().Any()
                    ? tokens.OfType<OperationToken>().Max(t => t.Weight)
                    : 0;

                var operationToken = token as OperationToken;
                if (operationToken != null && operationToken.Weight == maxWeight)
                {
                    return true;
                }
                return false;
            };

            var split = tokens.Split(splitPredicate);

            if (split.Delimiter == null)
            {
                var token = split.Left.First();
                return ParseNode(token);
            }

            var node = new BuilderNode
            {
                Token = split.Delimiter,
                Left = ParseTree(split.Left),
                Right = ParseTree(split.Right)
            };

            return node;
        }

        BuilderNode ParseNode(IToken token)
        {
            var parenthesesToken = token as ParenthesesToken;
            if (parenthesesToken != null)
            {
                return ParseTree(parenthesesToken.Value);
            }
            else
            {
                return new BuilderNode
                {
                    Token = token
                };
            }
        }
    }
}
