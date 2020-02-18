using System;
using System.Collections.Generic;
using System.Text;

namespace Codewars
{
    class TicTacToe
    {
        public int IsSolved(int[,] b)
        {
            List<int[]> combs = new List<int[]>();
            combs.Add(new int[] { b[0, 0], b[0, 1], b[0, 2] });
            combs.Add(new int[] { b[0, 0], b[1, 0], b[2, 0] });
            combs.Add(new int[] { b[0, 0], b[1, 1], b[2, 2] });
            combs.Add(new int[] { b[0, 2], b[1, 2], b[2, 2] });
            combs.Add(new int[] { b[0, 2], b[1, 1], b[2, 0] });
            combs.Add(new int[] { b[1, 0], b[1, 1], b[1, 2] });
            combs.Add(new int[] { b[2, 0], b[2, 1], b[2, 2] });
            foreach (int[] comb in combs)
            {
                if (comb[0] != 0 && comb[0] == comb[1] && comb[2] == comb[1]) return comb[0];
            }
            foreach (int field in b)
            {
                if (field == 0)
                {
                    return -1;
                }
            }
            return 0;
        }
    }
}
