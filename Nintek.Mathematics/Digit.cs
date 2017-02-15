using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics
{
    public struct Digit
    {
        public char Value { get; }

        public Digit(char value)
        {
            if (!char.IsDigit(value)) throw new ArgumentException($"{value} is not digit.", nameof(value));

            Value = value;
        }

        public static implicit operator Digit(char value)
            => new Digit(value);

        public static implicit operator int(Digit value)
            => value.Value;
    }
}
