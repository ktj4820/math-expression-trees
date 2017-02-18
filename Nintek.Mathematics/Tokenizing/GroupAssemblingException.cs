using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics
{
    public class GroupAssemblingException : InvalidOperationException
    {
        public ITokenGroup AssemblingFailedFor { get; }

        public GroupAssemblingException(string message, ITokenGroup failureGroup)
            : base(message)
        {
            AssemblingFailedFor = failureGroup;
        }
    }
}
