using Nintek.Mathematics.Syntax;

namespace Nintek.Mathematics.Calculating
{
    public interface IConstantExpressionCalculator
    {
        double Calculate(SyntaxTree tree);
        double Calculate(Node node);
    }
}