using System;

namespace TopCoder
{
    public class A0Paper
    {
        public static void Main(string[] args)
        {
            A0Paper a = new A0Paper();
            Console.WriteLine(a.canBuild(new int[] { 0, 0, 0, 0, 15 }));
        }
        public string canBuild(int[] input)
        {
            bool doWeHaveAA0SizePaper = false;
            double counter = 0;
            for (int i = input.Length - 1; i >= 0; i--)
            {
                if (i == 0)
                    doWeHaveAA0SizePaper = input[i] + Math.Floor(counter / 2) >= 1 ? true : false; 
                counter = Math.Floor(counter / 2) + input[i];
            }
            return doWeHaveAA0SizePaper ? "Possible" : "Impossible";
        }
    }
}
