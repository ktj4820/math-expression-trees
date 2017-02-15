using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics
{
    public class TokenGroup
    {
        public List<IToken> Tokens { get; set; }
        public Type TokensType { get; set; }

        public TokenGroup()
        {
            Tokens = new List<IToken>();
        }
    }
}
