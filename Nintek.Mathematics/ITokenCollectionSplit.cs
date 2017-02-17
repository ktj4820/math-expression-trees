namespace Nintek.Mathematics
{
    public interface ITokenCollectionSplit
    {
        IToken Delimiter { get; }
        ITokenCollection Left { get; }
        ITokenCollection Right { get; }
    }
}