using System;
using System.Collections.Generic;
using System.Linq;

namespace Codewars
{
    class HighestScoringWord
    {
        public static string High(string s)
        {
            string[] words = s.Split(' ');
            int[] wordValue = words.Select(x => { return x.Select(y => { return char.ToUpper(y) - 64; }).Sum(); }).ToArray();
            int maxIndex = Array.IndexOf(wordValue, wordValue.Max());
            return words[maxIndex];
        }
    }
}
