﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Mathematics.Tokens
{
    public class CommaToken : Token<char>
    {
        public CommaToken()
            : base(',')
        {
        }
    }
}
