namespace Nintek.Mathematics
{
    public interface ITokenizer
    {
        ITokenCollection Tokenize(string expression);
    }
}