using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics
{
    public class SyntaxTreeBuilder
    {
        public SyntaxTree Build(ITokenCollection tokens)
        {
            var rootBuilderNode = BuildTree(tokens);
            var rootNode = rootBuilderNode.ToNode();
            return new SyntaxTree(rootNode, tokens);
        }

        BuilderNode BuildTree(ITokenCollection tokens)
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
                var atomicToken = split.Left.First();
                return BuildNode(atomicToken);
            }

            var node = new BuilderNode
            {
                Token = split.Delimiter,
                Left = BuildTree(split.Left),
                Right = BuildTree(split.Right)
            };

            return node;
        }

        BuilderNode BuildNode(IToken token)
        {
            var parenthesesToken = token as ParenthesesToken;
            if (parenthesesToken != null)
            {
                return BuildTree(parenthesesToken.Value);
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
