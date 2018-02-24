using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeFight
{
    class Tournament
    {
        bool isEarlier(int[] time1, int[] time2)
        {
            if (time1[0] > time2[0])
            {
                return false;
            }
            else if (time1[0] == time2[0])
            {
                if (time1[1] >= time2[1])
                {
                    return false;
                }
                return true;
            }
            return true;
        }
        string capitalizeVowelsRegExp(string input)
        {
            List<char> voc = new List<char>() { 'a', 'e', 'i', 'o', 'u', 'y' };
            string temp = "";
            foreach (var item in input)
            {
                if (voc.Contains(item))
                {
                    temp += char.ToUpper(item);
                }
                else
                    temp += item;
            }
            return temp;
        }
        int maximalEven(int[] inputArray)
        {
            int max = 0;
            foreach (var item in inputArray)
            {
                if (item % 2 == 0 && max < item)
                {
                    max = item;
                }
            }
            return max;
        }
        int[] makeArrayConsecutive(int[] sequence)
        {
            int minimum = int.MaxValue;
            int maximum = int.MinValue;
            List<int> numbers = new List<int>();

            for (int i = 0; i < sequence.Length; i++)
            {
                if (sequence[i] < minimum)
                {
                    minimum = sequence[i];
                }
                if (sequence[i] > maximum)
                {
                    maximum = sequence[i];
                }
                numbers.Add(sequence[i]);
            }

            List<int> result = new List<int>();

            for (int i = minimum; i < maximum; i++)
            {
                if (!numbers.Contains(i))
                {
                    result.Add(i);
                }
            }
            return result.ToArray();
        }
        int rounders(int value)
        {
            int carry = 0;
            string temp = "";
            while (value + carry > 9)
            {
                value += carry;
                temp += "0";
                if (value%10 >= 5)
                {
                    carry = 1;
                }
                else
                {
                    carry = 0;
                }
                value /= 10;
            }
            temp += value + carry;
            return int.Parse(new string(temp.ToCharArray().Reverse().ToArray()));
        }
        bool pepEight2(string line)
        {
            if (line.Length > 79)
                return false;
            return true;
        }
        bool isSmooth(int[] arr)
        {
            int start;
            int middle;
            int end;
            if (arr.Length == 1)
            {
                return true;
            }

            if (arr.Length % 2 == 0)
            {
                start = arr[0];
                middle = arr[(arr.Length / 2) - 1] + arr[(arr.Length / 2)];
                end = arr[arr.Length - 1];
            }
            else
            {
                start = arr[0];
                middle = arr[(arr.Length / 2)];
                end = arr[arr.Length - 1];
            }
            if (start == end && start == middle && middle == end)
            {
                return true;
            }
            return false;
        }
        int[] firstReverseTry(int[] arr)
        {
            if (arr.Length >= 2)
            {
                int temp = arr[0];
                arr[0] = arr[arr.Length - 1];
                arr[arr.Length - 1] = temp;
            }
            return arr;
        }








    }
}
