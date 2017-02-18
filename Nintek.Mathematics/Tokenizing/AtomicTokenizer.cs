using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics
{
    public class AtomicTokenizer : IAtomicTokenizer
    {
        public ITokenCollection Tokenize(string expression)
            => expression.Select(c => TokenizeChar(c)).ToTokenCollection();
        
        public IToken TokenizeChar(char character)
        {
            if (char.IsLetter(character))
            {
                return new LetterToken(character);
            }

            if (char.IsDigit(character))
            {
                return new DigitToken(character);
            }

            switch (character)
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

            throw new InvalidOperationException($"Unrecognized token: {character}.");
        }
    }
}
