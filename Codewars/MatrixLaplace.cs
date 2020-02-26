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
            if (matrix.Length == 3)
            {
                return matrix[0][0] * matrix[1][1] * matrix[2][2] + matrix[0][1] * matrix[1][2] * matrix[2][0] + matrix[0][2] * matrix[1][0] * matrix[2][1]
                   - matrix[2][0] * matrix[0][2] * matrix[1][1] - matrix[2][1] * matrix[1][2] * matrix[0][0] - matrix[2][2] * matrix[1][0] * matrix[0][1];
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
        static void Main2(string[] args)
        {
            Console.WriteLine(MatrixLaplace.Determinant(new int[][] { new[] { 2 ,  -3  ,  0   , 5 ,-10 ,  8 , -1 ,  9 , -7 , -8},
new[] { 5 ,  -2  , 10  , -9 , -8 , -8 ,-10 , -6 , -6 , -2},
new[] { 2  , -3 ,   2  ,  8 , -7 , -6 ,  4 , -3 ,  2 , -5},
new[] { 4  ,  0 , -10  ,  5 , -9 ,  0 ,  1 , -6 , -6 ,  4},
new[] { 0  , -4  , -7  ,  8 ,  7 , -7 ,  5 , -7 ,  4 , -2},
new[] { -7 ,   4 ,   4 ,   4,  -7,  -5,   5,   3,   1,   6},
new[] { -6  , -8 ,  -4,   9 , -2 , -5 , -3 , -6 ,-10 ,  3},
new[] { 2  ,  7 , -10 ,  1  , 9  ,-4  ,-7  , 4  , -10, -10},
new[] { 0  ,  0  ,  4 , -7  ,-9  ,-10 ,  7 , -3 ,  1 ,  7},
new[] { 5  ,  9  ,  4 , -2  , 0  ,-2  ,10  ,-5  ,-1  , 2} }));


            Console.ReadKey();
        }
    }
}
