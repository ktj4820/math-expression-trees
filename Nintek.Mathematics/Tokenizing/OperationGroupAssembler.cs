using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nintek.Mathematics.Tokens;

namespace Nintek.Mathematics.Tokenizing
{
    public class OperationGroupAssembler : ITokenGroupAssembler
    {
        public bool CanAssemble(ITokenGroup group)
            => group.Tokens.Count == 1 && group.TokenTypes[0] == typeof(OperationToken);

        public IEnumerable<IToken> Assemble(ITokenCollection tokens)
        {
            yield return tokens.First();
        }
    }
}
