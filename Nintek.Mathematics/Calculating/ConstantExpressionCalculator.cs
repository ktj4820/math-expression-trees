using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics
{
    public class ConstantExpressionCalculator
    {
        public double Calculate(SyntaxTree tree)
        {
            return CalculateNode(tree.Root);
        }

        double CalculateNode(Node node)
        {
            var numberToken = node.Token as NumberToken;
            if (numberToken != null)
            {
                return numberToken.Value;
            }

            var operationToken = node.Token as OperationToken;

            if (operationToken == null)
            {
                throw new InvalidOperationException();
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
                    throw new InvalidOperationException();
            }

            var leftValue = CalculateNode(node.Left);
            var rightValue = CalculateNode(node.Right);

            return operation(leftValue, rightValue);
        }
    }
}
