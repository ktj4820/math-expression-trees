using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Nintek.Mathematics.Tests
{
    public class AcceptanceTests
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
        [InlineData("6 / 2 * (2 + 1)", 9)]
        [InlineData("(2 + 1) * 6 / 2", 9)]
        [InlineData("6 * 2 / (2 + 1)", 4)]
        [InlineData("(2 + 1) / 6 * 2", 1)]
        public void ConstantExpressionsCalculating(string expression, double expected)
        {
            var solver = new ConstantExpressionSolver();

            var result = solver.Solve(expression);
            
            Assert.Equal(expected, result);
        }
    }
}
