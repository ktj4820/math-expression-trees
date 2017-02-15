using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics
{
    public struct Letter
    {
        public char Value { get; }

        public Letter(char value)
        {
            if (!char.IsLetter(value)) throw new ArgumentException($"{value} is not letter.");

            Value = value;
        }

        public static implicit operator Letter(char value)
            => new Letter(value);

        public static implicit operator char(Letter value)
            => value.Value;
    }
}
