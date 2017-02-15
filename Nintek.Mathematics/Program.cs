using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics
{
    class Program
    {
        static void Main(string[] args)
        {
            var tokenizer = new Tokenizer();

            var tokens = tokenizer.Tokenize("x + y + ab * 10 = 20").ToList();
        }
    }
}
