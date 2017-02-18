using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics.Tokens
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

        public ITokenCollectionSplit Split(Func<IToken, bool> splitPredicate)
        {
            IToken delimiter = null;
            var left = new List<IToken>();
            var right = new List<IToken>();
            var predicateSolved = false;

            foreach (var token in _source)
            {
                if (!predicateSolved && splitPredicate(token))
                {
                    delimiter = token;
                    predicateSolved = true;
                    continue;
                }

                if (delimiter == null)
                {
                    left.Add(token);
                }
                else
                {
                    right.Add(token);
                }
            }

            return new TokenCollectionSplit(
                delimiter, 
                left.ToTokenCollection(), 
                right.ToTokenCollection());
        }
    }
}
