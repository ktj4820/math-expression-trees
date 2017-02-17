using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics
{
    public static class UtilExtensions
    {
        public static bool As<TActual, TTarget>(this TActual target, Func<TTarget, bool> predicate)
            where TTarget : class
        {
            var cast = target as TTarget;
            return cast != null && predicate(cast);
        }
    }
}
