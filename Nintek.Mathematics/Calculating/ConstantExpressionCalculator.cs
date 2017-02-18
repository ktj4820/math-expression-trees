using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nintek.Mathematics.Syntax;
using Nintek.Mathematics.Tokens;

namespace Nintek.Mathematics.Calculating
{
    public class ConstantExpressionCalculator : IConstantExpressionCalculator
    {
        public double Calculate(SyntaxTree tree)
            => Calculate(tree.Root);

        public double Calculate(Node node)
        {
            var numberToken = node.Token as NumberToken;
            if (numberToken != null)
            {
                return numberToken.Value;
            }

            var operationToken = node.Token as OperationToken;

            if (operationToken == null)
            {
                throw new InvalidOperationException($"Cannot calculate node which contains token: {node.Token}.");
            }

            Func<double, double, double> operation;

            switch (operationToken.Value)
            {
                case Operation.Add:
                    operation = (x, y) => x + y;
                    break;

                case Operation.Remove:
                    operation = (x, y) => x - y;
                    break;

                case Operation.Multiply:
                    operation = (x, y) => x * y;
                    break;

                case Operation.Divide:
                    operation = (x, y) => x / y;
                    break;

                default:
                    throw new InvalidOperationException($"Cannot calculate operation: {operationToken.Value}.");
            }

            var leftValue = Calculate(node.Left);
            var rightValue = Calculate(node.Right);

            return operation(leftValue, rightValue);
        }
    }
}
