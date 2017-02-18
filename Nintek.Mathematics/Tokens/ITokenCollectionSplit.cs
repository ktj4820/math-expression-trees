namespace Nintek.Mathematics.Tokens
{
    public interface ITokenCollectionSplit
    {
        IToken Delimiter { get; }
        ITokenCollection Left { get; }
        ITokenCollection Right { get; }
    }
}