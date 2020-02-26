using System;
using System.Collections.Generic;
using System.Text;

namespace Codewars
{
    class Scramblies
    {

        public static bool Scramble(string str1, string str2)
        {
            foreach(char c in str2)
            {
                int idx = str1.IndexOf(c);
                if (idx != -1)
                {
                    str1 = str1.Remove(idx, 1);
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        private static void testing(bool actual, bool expected)
        {
            Console.WriteLine(expected == actual);
        }
        
        public static void Main1()
        {
            testing(Scramblies.Scramble("rkqodlw", "world"), true);
            testing(Scramblies.Scramble("cedewaraaossoqqyt", "codewars"), true);
            testing(Scramblies.Scramble("katas", "steak"), false);
            testing(Scramblies.Scramble("scriptjavx", "javascript"), false);
            testing(Scramblies.Scramble("scriptingjava", "javascript"), true);
            testing(Scramblies.Scramble("scriptsjava", "javascripts"), true);
            testing(Scramblies.Scramble("javscripts", "javascript"), false);
            testing(Scramblies.Scramble("aabbcamaomsccdd", "commas"), true);
            testing(Scramblies.Scramble("commas", "commas"), true);
            testing(Scramblies.Scramble("sammoc", "commas"), true);
            Console.ReadKey();
        }
    }
}
