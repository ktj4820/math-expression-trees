using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics
{
    public class CharTokenizer
    {
        public IToken Tokenize(char c)
        {
            if (char.IsLetter(c))
            {
                return new LetterToken(c);
            }

            if (char.IsDigit(c))
            {
                return new DigitToken(c);
            }

            switch (c)
            {
                case '+':
                    return new OperationToken(Operation.Add);
                case '-':
                    return new OperationToken(Operation.Remove);
                case '*':
                    return new OperationToken(Operation.Multiply);
                case '/':
                    return new OperationToken(Operation.Divide);
                case '=':
                    return new OperationToken(Operation.Equals);
                case ',':
                    return new CommaToken();
                case ' ':
                    return new SpaceToken();
                case '(':
                    return new ParenthesisToken(Parenthesis.Left);
                case ')':
                    return new ParenthesisToken(Parenthesis.Right);
            }

            throw new InvalidOperationException($"Unrecognized token: {c}.");
        }
    }
}
