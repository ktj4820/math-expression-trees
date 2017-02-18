namespace Nintek.Mathematics
{
    public interface IConstantExpressionCalculator
    {
        double Calculate(SyntaxTree tree);
        double Calculate(Node node);
    }
}