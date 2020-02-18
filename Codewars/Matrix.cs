using System;
using System.Linq;
namespace Codewars
{
    class Matrix
    {
        public static int Determinant(int[][] matrix)
        {
            if (matrix.Length == 0)
            {
                return 0;
            }
            if (matrix.Length == 1)
            {
                return matrix[0][0];
            }
            if (matrix.Length == 2)
            {
                return matrix[0][0] * matrix[1][1] - matrix[1][0] * matrix[0][1];
            }

            int fak = 1;
            int det = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                int[][] minor = new int[matrix.Length-1][];
                for (int j = 1; j < matrix.Length; j++)
                {
                    minor[j-1] = matrix[j].Where((val, idx) => idx != i).ToArray();
                }
               
                det += fak * matrix[0][i] * Matrix.Determinant(minor);
                fak *= -1;
            }
            return det;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(Matrix.Determinant(new int[][] { new[] { 2, 5, 3 }, new[] { 1, -2, -1 }, new[] { 1, 3, 4 } }));
            Console.ReadKey();
        }
    }
}
