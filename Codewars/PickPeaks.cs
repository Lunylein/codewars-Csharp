
using System;
using System.Collections.Generic;
using System.Linq;

namespace Codewars
{
    class PickPeaks
    {
        public static Dictionary<string, List<int>> GetPeaks(int[] arr)
        {

            List<int> pos = new List<int>();
            List<int> peaks = new List<int>();
            if (arr.Length > 2)
            {
            int possiblePeak = -1;

                for (int i = 0; i< arr.Length-1; i++)
                {

                    if (arr[i] < arr[i+1])
                    {
                        possiblePeak = i+1;
                    }
                    if (possiblePeak != -1 && arr[i + 1] < arr[i])
                    {
                        pos.Add(possiblePeak);
                        peaks.Add(arr[possiblePeak]);
                        possiblePeak = -1;
                    }
                }
            }
            return new Dictionary<string, List<int>>()
                {
                    ["pos"] = pos,
                    ["peaks"] = peaks
                };
        }

        private static string[] msg =
    {
        "should support finding peaks",
        "should support finding peaks, but should ignore peaks on the edge of the array",
        "should support finding peaks; if the peak is a plateau, it should only return the position of the first element of the plateau",
        "should support finding peaks; if the peak is a plateau, it should only return the position of the first element of the plateau",
        "should support finding peaks, but should ignore peaks on the edge of the array"
    };

        private static int[][] array =
        {
        new int[]{1,2,3,6,4,1,2,3,2,1},
        new int[]{3,2,3,6,4,1,2,3,2,1,2,3},
        new int[]{3,2,3,6,4,1,2,3,2,1,2,2,2,1},
        new int[]{2,1,3,1,2,2,2,2,1},
        new int[]{2,1,3,1,2,2,2,2}
    };

        private static int[][] posS =
        {
        new int[]{3,7},
        new int[]{3,7},
        new int[]{3,7,10},
        new int[]{2,4},
        new int[]{2}
    };

        private static int[][] peaksS =
        {
        new int[]{6,3},
        new int[]{6,3},
        new int[]{6,3,2},
        new int[]{3,2},
        new int[]{3}
    };
        
        public static void Main2()
        {
            for (int n = 0; n < msg.Length; n++)
            {
                int[] p1 = posS[n], p2 = peaksS[n];
                var expected = new Dictionary<string, List<int>>()
                {
                    ["pos"] = p1.ToList(),
                    ["peaks"] = p2.ToList()
                };
                var actual = PickPeaks.GetPeaks(array[n]);
            }
            Console.ReadKey();
        }
    }
}
