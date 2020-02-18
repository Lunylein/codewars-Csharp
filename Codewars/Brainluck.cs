using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Codewars
{
    class Brain
    {
        public static string BrainLuck(string code, string input)
        {
            int head = 0;
            int inputHead = 0;
            int skipCounter = 0;
            List<byte> output = new List<byte>();
            byte[] data = new byte[30000];
            Stack<int> loopPointer = new Stack<int>();
            bool skipLoop = false;
            if (String.IsNullOrEmpty(code))
            {
                return "";
            }
            byte[] bytes = new byte[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                bytes[i] = Convert.ToByte(input[i]);
            }
            for (int i = 0; i < code.Length; i++)
            {

                if (i < code.Length && code[i] != ']' && skipLoop)
                {
                    if (code[i] == '[')
                    {
                        skipCounter++;
                    }
                    continue;
                }
                else
                {
                    if (skipCounter > 0)
                    {
                        skipCounter--;
                        continue;
                    }
                    skipLoop = false;
                }
                switch (code[i])
                {
                    case '>': head++; break;
                    case '<': head--; break;
                    case '+': if (data[head] == Convert.ToByte(255)) data[head] = Convert.ToByte(0); else data[head]++; break;
                    case '-': if (data[head] == Convert.ToByte(0)) data[head] = Convert.ToByte(255); else data[head]--; break;
                    case '.': output.Add(data[head]); break;
                    case ',': data[head] = (inputHead < bytes.Length) ? bytes[inputHead++] : Convert.ToByte(0); break;
                    case '[':

                        loopPointer.Push(i);


                        if (data[head] == 0)
                        {
                            skipLoop = true;
                        }
                        break;
                    case ']':
                        if (!skipLoop)
                        {
                            int tmp = -1;
                             tmp = loopPointer.Pop();
                            if (data[head] != 0)
                            {
                                i = tmp - 1;
                            }
                        }
                        break;
                }
            }

            return Encoding.ASCII.GetString(output.ToArray());
        }
    }
}
