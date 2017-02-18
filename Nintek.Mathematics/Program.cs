using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Nintek.Mathematics
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = Stopwatch.StartNew();

            var tokenizer = new Tokenizer();
            var tokens = tokenizer.Tokenize("6 / 2 * (2 + 1)");

            var parser = new ExpressionParser();
            var tree = parser.Parse(tokens);

            var writer = new SyntaxTreeWriter();
            var expression = writer.TreeToString(tree);

            var expressionCalculator = new ConstantExpressionCalculator();
            var result = expressionCalculator.Calculate(tree);

            Console.WriteLine($"{expression} = {result}");

            Console.WriteLine();
            Console.WriteLine($"evaluation time: {stopwatch.Elapsed.TotalMilliseconds} ms");

            Console.ReadKey();
        }
    }
}
