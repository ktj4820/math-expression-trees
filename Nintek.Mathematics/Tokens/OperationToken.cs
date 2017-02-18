using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics
{
    public class OperationToken : Token<Operation>
    {
        public int Weight { get; }

        public OperationToken(Operation operation)
            : base(operation)
        {
            switch (operation)
            {
                case Operation.Add:
                case Operation.Remove:
                    Weight = 3;
                    break;

                case Operation.Multiply:
                    Weight = 2;
                    break;

                case Operation.Divide:
                    Weight = 1;
                    break;

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
