using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Nintek.Mathematics.Tests
{
    public class LogicTests
    {
        [Theory]
        [InlineData("2 + 3", 5)]
        [InlineData("2 + 3 * 4", 14)]
        [InlineData("3 * 4 + 2", 14)]
        [InlineData("1 + 3 * 4 - 4 / 2", 11)]
        [InlineData("4 * (2 + 1) + (7 + 5) * 3", 48)]
        [InlineData("4 * (8 * 2 - 10)", 24)]
        [InlineData("81 / 9 - (32 - 27)", 4)]
        [InlineData("44 / ((20 - 9) * 2)", 2)]
        public void ConstantExpressionsCalculating(string expression, double expected)
        {
            var tokenizer = new Tokenizer();
            var parser = new ExpressionParser();
            var calculator = new ConstantExpressionCalculator();
            
            var tokens = tokenizer.Tokenize(expression);
            var tree = parser.Parse(tokens);
            var result = calculator.Calculate(tree);

            Assert.Equal(expected, result);
        }
    }
}
