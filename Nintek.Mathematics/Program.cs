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

            double t = (double) (2 + 1) / 6 * 2;
            Console.WriteLine(t);

            var tokenizer = new Tokenizer();
            //var tokens = tokenizer.Tokenize("2x + x + 1 = 2 - x").ToList();
            //var tokens = tokenizer.Tokenize("1 + 3 * 4 - 4 / 2").ToList();
            //var tokens = tokenizer.Tokenize("2 + 3 * 4").ToList();
            //var tokens = tokenizer.Tokenize("3 * 4 + 2").ToList();
            //var tokens = tokenizer.Tokenize("2 + 3").ToList();

            //var tokens = tokenizer.Tokenize("1 + 3 * (4 + 1)");
            //var tokens = tokenizer.Tokenize("4 * (2 + 1) + (7 + 5) * 3");
            //var tokens = tokenizer.Tokenize("4 * (2 * (2 + 1))");
            var tokens = tokenizer.Tokenize("6 / 2 * (2 + 1)");

            //var parser = new EquationParser();
            //var parser = new ExpressionParser();
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
