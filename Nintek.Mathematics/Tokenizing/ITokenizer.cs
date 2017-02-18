using Nintek.Mathematics.Tokens;

namespace Nintek.Mathematics.Tokenizing
{
    public interface ITokenizer
    {
        ITokenCollection Tokenize(string expression);
    }
}