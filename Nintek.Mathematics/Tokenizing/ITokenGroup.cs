using System;

namespace Nintek.Mathematics
{
    public interface ITokenGroup
    {
        ITokenCollection Tokens { get; }
        Type[] TokenTypes { get; }
    }
}