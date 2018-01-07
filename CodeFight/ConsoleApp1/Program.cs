using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        bool[][][] financialCrisis(bool[][] roadRegister)
        {
            bool[][][] result = new bool[roadRegister[0].Length][][];
            

            return result;
        }

        bool[] Slice(bool[] source, int start, int end)
        {
            // Handles negative ends.
            if (end < 0)
            {
                end = source.Length + end;
            }
            int len = end - start;

            // Return new array.
            bool[] res = new bool[len];
            for (int i = 0; i < len; i++)
            {
                res[i] = source[i + start];
            }
            return res;
        }


        static void Main(string[] args)
        {
            Program gp = new Program();
            bool[][] test = new bool[4][];
            test[0] = new bool[] { false, true, true, false };
            test[1] = new bool[] { true, false, true, false };
            test[2] = new bool[] { true, true, false, true };
            test[3] = new bool[] { false, false, true, false };

            gp.financialCrisis(test);
        }
    }
}
