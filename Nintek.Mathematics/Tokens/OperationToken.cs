using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics
{
    public class OperationToken : Token<Operation>
    {
        public OperationToken(Operation operation)
            : base(operation)
        {
        }
    }
}
