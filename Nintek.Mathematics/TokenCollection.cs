using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics
{
    public class TokenCollection : ITokenCollection
    {
        List<IToken> _source;

        public TokenCollection(IEnumerable<IToken> tokens)
        {
            _source = tokens.ToList();
        }

        public IToken this[int index] => _source[index];

        public int Count => _source.Count;

        public int FindIndex(Predicate<IToken> predicate)
            => _source.FindIndex(predicate);

        public IEnumerator<IToken> GetEnumerator()
            => _source.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => _source.GetEnumerator();
    }
}
