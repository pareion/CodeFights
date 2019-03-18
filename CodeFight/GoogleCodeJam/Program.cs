using System;
using System.Collections.Generic;
using System.IO;

namespace GoogleCodeJam
{
    class Program
    {
        static void Main(string[] args)
        {
            var cases = Console.ReadLine();

            for (int i = 0; i < int.Parse(cases); i++)
            {
                var length = int.Parse(Console.ReadLine());

                List<int> numList = new List<int>();
                var numInput = Console.ReadLine().Split(' ');
                foreach (var number in numInput)
                {
                    numList.Add(int.Parse(number));
                }
                
                bool passed = false;
                for (int y = 0; y < numList.Count-1; y++)
                {
                    if (numList[y] > numList[y + 1])
                    {
                        passed = false;
                        Console.WriteLine("Case #{0}: {1}", i, y);
                    }
                }
                if (passed)
                {
                    Console.WriteLine("Case #{0} OK", i);
                }
            }
        }

        public void SaveTheUniverseAgain()
        {
            var cases = Console.ReadLine();

            for (int i = 0; i < int.Parse(cases); i++)
            {
                var input = Console.ReadLine().Split(' ');
                var preventLowerThan = int.Parse(input[0]);
                var robotInstructions = input[1];
                bool impossible = true;
                string previous = robotInstructions;
                int count = 0;
                while (impossible)
                {
                    int damage = calcDamage(robotInstructions, preventLowerThan);
                    if (preventLowerThan >= damage)
                    {
                        Console.WriteLine("Case #{0}: {1}", i + 1, count);
                        impossible = false;
                        break;
                    }
                    robotInstructions = hackInstructions(robotInstructions);
                    Console.WriteLine(robotInstructions);

                    if (robotInstructions == previous)
                    {
                        break;
                    }
                    else
                    {
                        count++;
                        previous = robotInstructions;
                    }
                }
                if (impossible)
                    Console.WriteLine("Case #{0}: IMPOSSIBLE", i + 1);
            }
        }

        private static string hackInstructions(string robotInstructions)
        {
            int indexShoot = 0;
            bool found = false;
            // Find last C and change it with an S 
            for (int i = robotInstructions.Length-1; i > 0; i--)
            {
                if (robotInstructions[i] == 'S')
                    if (robotInstructions[i - 1] != 'S')
                    {
                        indexShoot = i;
                        found = true;
                        break;
                    }
            }
            if (found)
            {
                robotInstructions = RemoveAndReplaceIndex(robotInstructions, indexShoot, 'C');
                robotInstructions = RemoveAndReplaceIndex(robotInstructions, indexShoot - 1, 'S');
            }
           
           
            return robotInstructions;
        }

        private static string RemoveAndReplaceIndex(string input, int index, char replace)
        {
            var chars = input.ToCharArray();
            chars[index] = replace;
            return new string(chars);
        }

        private static int calcDamage(string robotInstructions, int preventLowerThan)
        {
            var damage = 1;
            var outputDamage = 0;
            foreach (var instruction in robotInstructions)
            {
                if (instruction == 'S')
                    outputDamage += damage;
                else
                    damage *= 2;
            }
            if (damage == 0)
            {
                return int.MaxValue;
            }
            return outputDamage;
        }
    }
}
