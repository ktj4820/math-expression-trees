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
            var tokens = tokenizer.Tokenize("2x + x + 1 = 2 - x").ToList();

            var parser = new Parser();
            var tree = parser.Parse(tokens);
        }
    }
}
