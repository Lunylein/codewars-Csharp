using System.Linq;
using System;
using System.Text.RegularExpressions;

namespace Codewars
{
    class Chambouliard
    {
        public static double Doubles(int maxk, int maxn)
        {
            double sum = 0;
            for (int k = 1; k <= maxk; k++)
            {
                for (int n = 1; n <= maxn; n++)
                {
                    sum += v(k, n);
                }
            }
            return sum;
        }

        public static double v(int k, int n)
        {
            return 1 / (k * Math.Pow(n + 1, 2 * k));
        }
        private static void assertFuzzyEquals(double act, double exp)
        {
            bool inrange = Math.Abs(act - exp) <= 1e-6;
            if (inrange == false)
            {
                string specifier = "#0.000000";
                Console.WriteLine(
                    "At 1e-6: Expected must be " + exp.ToString(specifier) + ", but got " + act.ToString(specifier));
            }
            Console.WriteLine(inrange);
        }
        public static void Main2()
        {
            assertFuzzyEquals(Chambouliard.Doubles(1, 10), 0.5580321939764581); // 0.5580321939764581
            assertFuzzyEquals(Chambouliard.Doubles(10, 1000), 0.6921486500921933); // 0.6921486500921933
            assertFuzzyEquals(Chambouliard.Doubles(10, 10000), 0.6930471674194457); // 0.6930471674194457
            assertFuzzyEquals(Chambouliard.Doubles(20, 10000), 0.6930471955575918); // 0.6930471955575918
            Console.ReadKey();
        }
    }
}
