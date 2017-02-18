using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics
{
    public interface IWalkable<TSource> : IEnumerable<TSource>
    {
        IEnumerable<TSource> InOrderWalk();
        IEnumerable<TSource> PreOrderWalk();
        IEnumerable<TSource> PostOrderWalk();

        void InOrder(Action<TSource> action);
        void PreOrder(Action<TSource> action);
        void PostOrder(Action<TSource> action);

        IEnumerable<TResult> InOrderSelect<TResult>(Func<TSource, TResult> selector);
        IEnumerable<TResult> PreOrderSelect<TResult>(Func<TSource, TResult> selector);
        IEnumerable<TResult> PostOrderSelect<TResult>(Func<TSource, TResult> selector);
    }
}
