using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics
{
    class Program
    {
        static void Main(string[] args)
        {
            var tokenizer = new Tokenizer();
            //var tokens = tokenizer.Tokenize("2x + x + 1 = 2 - x").ToList();
            //var tokens = tokenizer.Tokenize("1 + 3 * 4 + 1 = 0").ToList();
            var tokens = tokenizer.Tokenize("2 + 3 * 4").ToList();
            //var tokens = tokenizer.Tokenize("2 + 3").ToList();

            //var parser = new EquationParser();
            var parser = new ExpressionParser();
            var tree = parser.Parse(tokens);

            var writer = new SyntaxTreeWriter();
            var expression = writer.TreeToString(tree);

            var expressionCalculator = new ConstantExpressionCalculator();
            var result = expressionCalculator.Calculate(tree);

            Console.WriteLine($"{expression} = {result}");

            Console.ReadKey();
        }
    }
}
