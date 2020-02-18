using System;
using System.Linq;
using System.Text;
namespace Codewars
{
    class MatrixLaplace
    {
        public static int Determinant(int[][] matrix)
        {
            MatrixLaplace.DrawMatrix(matrix);
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
               
                det += fak * matrix[0][i] * MatrixLaplace.Determinant(minor);
                fak *= -1;
            }
            return det;
        }
        public static void DrawMatrix(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                Console.Write("|");
                for (int j = 0; j < matrix.Length; j++)
                {
                    String value = matrix[i][j].ToString();
                    Console.Write("".PadLeft(5-value.Length) + value);
                }
                Console.Write("|");
                Console.Write(Environment.NewLine + Environment.NewLine);
            }

            Console.WriteLine("-------------------------------------------------");
        }

    }
}
