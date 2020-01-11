using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeFight
{
    class TimeDifference
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
                if (value % 10 >= 5)
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
        int leastCommonPrimeDivisor(int a, int b)
        {
            int i;
            if (a > b)
            {
                i = a;
            }
            else
                i = b;
            for (int j = 2; j <= i; j++)
            {
                if (a % j == 0 && b % j == 0)
                {
                    return j;
                }
            }
            return -1;
        }
        string whoseMove(string lastPlayer, bool win)
        {
            if (win)
                return lastPlayer;
            else
                switch (lastPlayer)
                {
                    case "white":
                        return "black";
                    case "black":
                        return "white";
                }
            return "";
        }
        bool arePrizesOK(int first, int second, int third)
        {
            if (first >= second && second >= third)
                return true;
            return false;
        }
        int[] lazyFriends(int[] houses, int maxDist)
        {
            int[] result = new int[houses.Length];
            int counter;
            for (int i = 0; i < houses.Length; i++)
            {
                counter = 0;
                for (int j = 0; j < houses.Length; j++)
                {
                    if (i != j)
                    {
                        if (Math.Abs(houses[j] - houses[i]) <= maxDist)
                        {
                            counter++;
                        }
                    }
                }
                result[i] = counter;
            }
            return result;
        }
        int calculationsWithCoins(int a, int b, int c)
        {
            return new HashSet<int>() { a, b, c, a + b, b + c, a + c, a + b + c }.Count;
        }
        int[] robotPath(string instructions, int bound)
        {
            int[] index = new int[2];
            foreach (var item in instructions)
            {
                switch (item)
                {
                    case 'U':
                        index[1]++;
                        break;
                    case 'D':
                        index[1]--;
                        break;
                    case 'L':
                        index[0]--;
                        break;
                    case 'R':
                        index[0]++;
                        break;
                }
                if (Math.Abs(index[0]) > bound)
                {
                    if (index[0] < 0)
                        index[0] = -bound;
                    else
                        index[0] = bound;
                }
                if (Math.Abs(index[1]) > bound)
                {
                    if (index[1] < 0)
                        index[1] = -bound;
                    else
                        index[1] = bound;
                }
            }
            return index;
        }
        int circleOfNumbers(int n, int firstNumber)
        {
            return firstNumber >= n / 2 ? firstNumber - n / 2 : firstNumber + n / 2;
        }
        bool isMAC48Address(string inputString)
        {
            string[] temp = inputString.Split('-');
            string regex = "^[0-9A-F]";
            if (temp.Length != 6)
            {
                return false;
            }
            foreach (var item in temp)
            {
                if (item.Length != 2)
                    return false;
                foreach (var item2 in item)
                {
                    if (!System.Text.RegularExpressions.Regex.IsMatch(item2.ToString(), regex))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        int stringsCrossover(string[] inputArray, string result)
        {
            int counter = 0;
            for (int i = 0; i < inputArray.Length; i++)
            {
                for (int j = 0; j < inputArray.Length; j++)
                {
                    if (i != j)
                    {
                        for (int k = 0; k < result.Length; k++)
                        {
                            if (inputArray[i][k] != result[k] && inputArray[j][k] != result[k])
                            {
                                break;
                            }
                            if (k == result.Length - 1)
                            {
                                counter++;
                            }
                        }
                    }
                }
            }
            return counter / 2;
        }
        int matrixTrace(int[][] matrix)
        {
            int sum = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                sum += matrix[i][i];
            }
            return sum;
        }
        int[] bfsDistancesUnweightedGraph(bool[][] matrix, int startVertex)
        {
            List<int> visited = new List<int>() { startVertex };
            int[] visitResult = new int[matrix.Length];

            int visit = 1;
            int previous = 0;
            while (visited.Count != matrix.Length)
            {
                foreach (var item in visited)
                {
                    for (int i = 0; i < matrix.Length; i++)
                    {
                        if (matrix[item][i] && !visited.Contains(i))
                        {
                            visitResult[i] = visit;
                        }
                    }
                }
                for (int i = 0; i < visitResult.Length; i++)
                {
                    if (visitResult[i] == visit)
                    {
                        visited.Add(i);
                    }
                }
                visit++;
                if (previous == visited.Count)
                    break;
                else
                    previous = visited.Count;
            }
            return visitResult;
        }
        int[] nextSecond(int[] currentTime)
        {
            if (currentTime[2] == 59)
            {
                currentTime[2] = 0;
                if (currentTime[1] + 1 == 60)
                {
                    currentTime[1] = 0;
                    if (currentTime[0] + 1 == 24)
                    {
                        currentTime[0] = 0;
                    }
                    else
                    {
                        currentTime[0]++;
                    }
                }
                else
                {
                    currentTime[1]++;
                }
            }
            else
            {
                currentTime[2]++;
            }
            return currentTime;
        }
        string htmlEndTagByStartTag(string startTag)
        {
            return (startTag.Split(' ').Count() > 1) ? "</" + startTag.Split(' ')[0].Substring(1, startTag.Split(' ')[0].Count() - 1) + ">" : "</" + startTag.Split(' ')[0].Substring(1, startTag.Split(' ')[0].Count() - 1);
        }
        int maxDigit(int n)
        {
            int current = 0;
            for (int i = 0; i < n.ToString().Length; i++)
            {
                if (current < int.Parse(n.ToString()[i].ToString()))
                {
                    current = int.Parse(n.ToString()[i].ToString());
                }
            }
            return current;
        }
        string mySubstring(string inputString, int l, int r)
        {
            return inputString.Substring(l, inputString.Length - l - r);
        }


















    }
}
