using System.Linq;
using System;
using System.Text.RegularExpressions;

namespace Codewars
{
    class Stripper
    {
        public static string StripComments(string text, string[] commentSymbols)
        {
            text += "\n";
            string pattern = "";
            Regex rgx = null;
            foreach (string reg in commentSymbols)
            {
                pattern = @"[ \t]*([" + string.Join("", commentSymbols) + @"].*|$)";
                rgx = new Regex(pattern);
                text = rgx.Replace(text, "");
            }
            pattern = "[ \t]+\n";
            rgx = new Regex(pattern);
            text = rgx.Replace(text, "\n");
            return text.Remove(text.Length - 1);
        }

        public static void Mai2n()
        {
            string result = StripComments("\n\n\nCEA\n\nAA\nAEDFFAFD\n\nD\n\n!\n\nF\n\n\n\n\nEA\n\n\n\n\n\nC\n\nA\n\nB!C\n\n\nB\n\nC\n\nCB\n\nE\n\nC\n\nCFFFE\n\n!\n\nE\n\nAAE\n\nBAE\n\nA!\n\nB\n\nA\n\n!\n\nBD\n\nBFEF\n\nE\n\nE\n\n!\n\nDAE\n\nFE\n\n\n\n!\n\nFD\n\nEB\n\nD\n\nB!A\nC\n\nB\n\n\n!!\n\nA\nB\n\nB\n\nFDF\n\n!\n\nA\n\nC\n\nCFCA\nEA\n\n\nC\n\nCB\n\n\nFA\n\n\nB\n\nA!\n\nA\n\nC\n\n!\n\nD\n\nBC!\n\nAF\n\nEBE\n\nC", new string[] { "#", "$", "!", "-" });

            Console.WriteLine(Regex.Escape(result));
            Console.ReadKey();
        }
    }
}
