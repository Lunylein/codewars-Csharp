using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Codewars
{
    class Alphabet
    {
        public static string AlphabetPosition(string text)
        {
            return text.ToUpper().Aggregate(new StringBuilder(), (sbAccumulator, x) => (((int)x < 91 && (int)x > 64) ? sbAccumulator.Append(((int)x - 64) + " ") : sbAccumulator.Append(""))).ToString().Trim();
        }
    }
}
