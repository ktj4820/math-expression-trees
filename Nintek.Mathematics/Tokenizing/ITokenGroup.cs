using System;
using Nintek.Mathematics.Tokens;

namespace Nintek.Mathematics.Tokenizing
{
    public interface ITokenGroup
    {
        ITokenCollection Tokens { get; }
        Type[] TokenTypes { get; }
    }
}