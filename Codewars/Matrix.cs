using System;
using System.Linq;
using System.Text;
namespace Codewars
{
    class Matrix
    {
        public static int Determinant(int[][] matrix)
        {
            Matrix.DrawMatrix(matrix);
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
            double det = 1;
            double[][] matrixD = new double[matrix.Length][];
            for (int i = 0; i < matrix.Length; i++)
            {

                    matrixD[i] = matrix[i].Select(Convert.ToDouble).ToArray(); 
                
            }
                for (int i = 0; i< matrixD.Length; i++)
            {
                if (matrixD[i][i] == 0)
                {
                    for (int row = i; row < matrixD.Length; row++)
                    {
                        if (matrixD[i][row] != 0)
                        { //zeile tauschen
                            for (int k = 0; k < matrix.Length; k++)
                            {
                                double tmp = matrixD[k][i];
                                matrixD[k][i] = matrixD[k][row];
                                matrixD[k][row] = tmp;
                            }
                        }
                    }
                }
                if (matrixD[i][ i] == 0) continue;
                for (int j = i + 1; j < matrix.Length; j++)
                {
                    //0er erzeugen durch Addition
                    double faktor = -matrixD[j][i] / matrixD[i][i];
                    for (int k = 0; k < matrixD.Length; k++)
                    {
                        matrixD[j][k] += faktor * matrixD[i][k];
                    }
                }
                det *= matrixD[i][i];
            }
          

            return (int)det;
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
        static void Main(string[] args)
        {
            Console.WriteLine(Matrix.Determinant(new int[][] { new[] { 2 ,  -3  ,  0   , 5 ,-10 ,  8 , -1 ,  9 , -7 , -8},
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
