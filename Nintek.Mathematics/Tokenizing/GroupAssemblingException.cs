using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics
{
    public class GroupAssemblingException : InvalidOperationException
    {
        public TokenGroup AssemblingFailedFor { get; }

        public GroupAssemblingException(string message, TokenGroup failureGroup)
            : base(message)
        {
            AssemblingFailedFor = failureGroup;
        }
    }
}
