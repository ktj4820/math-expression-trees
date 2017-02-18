using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nintek.Mathematics.Tokenizing;
using Nintek.Mathematics.Parsing;
using Nintek.Mathematics.Calculating;

namespace Nintek.Mathematics
{
    public class ConstantExpressionSolver
    {
        ITokenizer _tokenizer;
        IParser _parser;
        IConstantExpressionCalculator _calculator;

        public ConstantExpressionSolver()
        {
            _tokenizer = new Tokenizer();
            _parser = new ExpressionParser();
            _calculator = new ConstantExpressionCalculator();
        }

        public ConstantExpressionSolver(
            ITokenizer tokenizer,
            IParser parser,
            IConstantExpressionCalculator calculator)
        {
            _tokenizer = tokenizer;
            _parser = parser;
            _calculator = calculator;
        }

        public double Solve(string expression)
        {
            var tokens = _tokenizer.Tokenize(expression);
            var tree = _parser.Parse(tokens);
            var result = _calculator.Calculate(tree);
            return result;
        }
    }
}
