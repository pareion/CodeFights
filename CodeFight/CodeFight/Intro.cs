using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeFight
{
    class Intro
    {
        /// <summary>
        /// https://codefights.com/arcade/intro/level-10
        /// This is the solution to the Arcade challenges from 1 to 60
        /// 
        /// 
        /// Solutions to Edge of the Ocean (Intro)
        /// </summary>
        int adjacentElementsProduct(int[] inputArray)
        {
            int highest = -1000;
            for (int i = 0; i < inputArray.Length - 1; i++)
            {
                if (inputArray[i] * inputArray[i + 1] > highest)
                {
                    highest = inputArray[i] * inputArray[i + 1];
                }
            }
            return highest;
        }
        int shapeArea(int n)
        {
            int result = 1;
            int counter = 4;
            for (int i = 1; i < n; i++)
            {
                result = result + counter;
                counter += 4;
            }
            return result;
        }
        int makeArrayConsecutive2(int[] statues)
        {
            int minimum = int.MaxValue;
            int maximum = int.MinValue;
            for (int i = 0; i < statues.Length; i++)
            {
                if (statues[i] < minimum)
                {
                    minimum = statues[i];
                }
                if (statues[i] > maximum)
                {
                    maximum = statues[i];
                }
            }
            return ((maximum - 1) - minimum) - (statues.Length - 2);
        }
        bool almostIncreasingSequence(int[] sequence)
        {
            int counter = 0;
            int minimum = int.MinValue;
            for (int i = 0; i < sequence.Length - 1; i++)
            {
                if (sequence[i] < sequence[i + 1] && sequence[i] > minimum)
                {
                    minimum = sequence[i];
                    counter++;
                }
                else if (i < sequence.Length - 2)
                {
                    if (sequence[i] < sequence[i + 2] && sequence[i] > minimum)
                    {
                        minimum = sequence[i];
                        counter++;
                        i++;
                    }
                }
            }
            if (counter == sequence.Length - 2)
            {
                return true;
            }
            return false;
        }
        int matrixElementsSum(int[][] matrix)
        {
            bool[] haunted = new bool[matrix[0].Length];
            int x = 0;
            int y = 0;
            int price = 0;
            for (int i = 0; i < matrix[0].Length * matrix.Length; i++)
            {
                if (x == matrix[0].Length)
                {
                    y++;
                    x = 0;
                }
                int current = matrix[y][x];
                if (current == 0)
                {
                    haunted[x] = true;
                }
                else if (haunted[x] != true)
                {
                    price += current;
                }
                x++;
            }
            return price;
        }
        /// <summary>
        /// Solutions to Smooth Sailing (Intro)
        /// </summary>
        string[] allLongestStrings(string[] inputArray)
        {
            Dictionary<int, List<string>> strings = new Dictionary<int, List<string>>();
            int biggest = 0;
            foreach (var item in inputArray)
            {
                int size = item.Length;
                if (strings.ContainsKey(size))
                {
                    strings[size].Add(item);
                }
                else
                {
                    strings.Add(size, new List<string>() { item });
                }
                if (size > biggest)
                {
                    biggest = size;
                }
            }
            return strings[biggest].ToArray();
        }
        int commonCharacterCount(string s1, string s2)
        {
            Dictionary<char, int> lookUp1 = new Dictionary<char, int>();
            Dictionary<char, int> lookUp2 = new Dictionary<char, int>();

            for (int i = 0; i < s1.Length; i++)
            {
                if (!lookUp1.ContainsKey(s1[i]))
                {
                    lookUp1.Add(s1[i], 1);
                }
                else
                {
                    lookUp1[s1[i]]++;
                }
            }

            for (int i = 0; i < s2.Length; i++)
            {
                if (!lookUp2.ContainsKey(s2[i]))
                {
                    lookUp2.Add(s2[i], 1);
                }
                else
                {
                    lookUp2[s2[i]]++;
                }
            }
            int count = 0;
            foreach (var item in lookUp1)
            {
                if (lookUp2.ContainsKey(item.Key))
                {
                    if (item.Value > lookUp2[item.Key])
                    {
                        count += lookUp2[item.Key];
                    }
                    else
                    {
                        count += item.Value;
                    }
                }
            }
            return count;
        }
        bool isLucky(int n)
        {
            string nS = n.ToString();
            string n1 = nS.Substring(0, nS.Length / 2);
            string n2 = nS.Substring(nS.Length / 2, nS.Length / 2);

            int count1 = 0;
            int count2 = 0;

            foreach (var item in n1)
            {
                count1 += int.Parse(item.ToString());
            }

            foreach (var item in n2)
            {
                count2 += int.Parse(item.ToString());
            }

            if (count1 == count2)
            {
                return true;
            }
            return false;
        }
        int[] sortByHeight(int[] a)
        {
            List<int> indexesUse = new List<int>();
            List<int> numbers = new List<int>();
            int[] result = new int[a.Length];

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != -1)
                {
                    numbers.Add(a[i]);
                    indexesUse.Add(i);
                }
                else
                {
                    result[i] = -1;
                }
            }
            numbers.Sort();
            for (int i = 0; i < indexesUse.Count; i++)
            {
                result[indexesUse[i]] = numbers[i];
            }
            return result;
        }
        string reverseParentheses(string s)

        {
            string result = "";
            List<string> remember = new List<string>();
            int counter = -1;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    counter++;
                    remember.Add("");
                }
                else if (s[i] == ')')
                {
                    for (int j = remember[counter].Length - 1; j >= 0; j--)
                    {
                        if (counter >= 1)
                        {
                            remember[counter - 1] += remember[counter][j];
                        }
                        else
                            result += remember[counter][j];
                    }
                    remember.RemoveAt(counter);
                    counter--;
                }
                else if (counter > -1)
                {
                    remember[counter] += s[i];
                }
                else
                {
                    result += s[i];
                }
            }
            return result;
        }
        /// <summary>
        /// Solutions to Exploring the Waters (Intro)
        /// </summary>
        int[] alternatingSums(int[] a)
        {
            int team1 = 0;
            int team2 = 0;
            for (int i = 1; i < a.Length + 1; i++)
            {
                if (i % 2 == 0)
                {
                    team1 += a[i - 1];
                }
                else
                {
                    team2 += a[i - 1];
                }
            }
            return new int[2] { team2, team1 };
        }
        string[] addBorder(string[] picture)
        {
            string[] result = new string[picture.Length + 2];
            int counter = 0;
            for (int i = 0; i < picture.Length; i++)
            {
                counter = picture[i].Length;
                result[i + 1] = "*" + picture[i] + "*";
            }
            string temp = "";
            for (int i = 0; i < counter + 2; i++)
            {
                temp += "*";
            }
            result[0] = temp;
            result[picture.Length + 1] = temp;
            return result;
        }
        bool areSimilar(int[] a, int[] b)
        {
            int badCounter = 0;
            int badUniqueCounter = 0;
            Dictionary<int, int> aD = new Dictionary<int, int>();
            Dictionary<int, int> bD = new Dictionary<int, int>();

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    badCounter++;
                }
                if (aD.ContainsKey(a[i]))
                {
                    aD[a[i]] += 1;
                }
                else
                {
                    aD.Add(a[i], 1);
                }
                if (bD.ContainsKey(b[i]))
                {
                    bD[b[i]] += 1;
                }
                else
                {
                    bD.Add(b[i], 1);
                }
            }
            foreach (var item in aD)
            {
                if (bD.ContainsKey(item.Key))
                {
                    badUniqueCounter += Math.Abs(bD[item.Key] - item.Value);
                }
                else
                {
                    return false;
                }
            }
            if (badUniqueCounter >= 2)
            {
                return false;
            }
            if (badCounter > 2)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        int arrayChange(int[] inputArray)
        {
            int counter = 0;
            for (int i = 1; i < inputArray.Length; i++)
            {
                while (inputArray[i] <= inputArray[i - 1])
                {
                    inputArray[i]++;
                    counter++;
                }
            }
            return counter;
        }
        bool palindromeRearranging(string inputString)
        {
            Dictionary<char, int> chars = new Dictionary<char, int>();
            for (int i = 0; i < inputString.Length; i++)
            {
                if (chars.ContainsKey(inputString[i]))
                {
                    chars[inputString[i]] += 1;
                }
                else
                {
                    chars.Add(inputString[i], 1);
                }
            }
            int counter = 0;
            foreach (var item in chars)
            {
                if (item.Value % 2 != 0)
                {
                    counter++;
                }
            }
            if (counter > 1)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Solutions to Island of Knowledge (Intro)
        /// </summary>
        bool areEquallyStrong(int yourLeft, int yourRight, int friendsLeft, int friendsRight)
        {
            int yourBest;
            int yourWorst;
            if (yourLeft > yourRight)
            {
                yourBest = yourLeft;
                yourWorst = yourRight;
            }
            else
            {
                yourBest = yourRight;
                yourWorst = yourLeft;
            }

            int friendsBest;
            int friendsWorst;
            if (friendsLeft > friendsRight)
            {
                friendsBest = friendsLeft;
                friendsWorst = friendsRight;
            }
            else
            {
                friendsBest = friendsRight;
                friendsWorst = friendsLeft;
            }

            if (yourBest == friendsBest && yourWorst == friendsWorst)
            {
                return true;
            }
            return false;
        }
        int arrayMaximalAdjacentDifference(int[] inputArray)
        {
            int biggestDifference = int.MinValue;
            for (int i = 0; i < inputArray.Length - 1; i++)
            {
                int current = Math.Abs(inputArray[i] - inputArray[i + 1]);
                if (current > biggestDifference)
                {
                    biggestDifference = current;
                }
            }
            return biggestDifference;
        }
        bool isIPv4Address(string inputString)
        {
            string[] addresses = inputString.Split('.');
            if (addresses.Length != 4)
            {
                return false;
            }
            foreach (var item in addresses)
            {
                try
                {
                    if (0 > int.Parse(item) || int.Parse(item) > 255)
                    {
                        return false;
                    }
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            return true;
        }
        int avoidObstacles(int[] inputArray)
        {
            int counter = 2;
            int biggestNumber = 0;
            for (int i = 0; i < inputArray.Length; i++)
            {
                if (inputArray[i] > biggestNumber)
                {
                    biggestNumber = inputArray[i];
                }
            }
            int count = 0;
            while (counter <= biggestNumber + 1)
            {
                count = 0;
                for (int j = 0; j < inputArray.Length; j++)
                {
                    if (inputArray[j] % counter != 0)
                    {
                        count++;
                    }
                    else
                        break;
                    if (count == inputArray.Length)
                    {
                        return counter;
                    }
                }
                counter++;
            }
            return 0;
        }
        int[][] boxBlur(int[][] image)
        {
            int yPosition = 0;
            int xPosition = 0;
            int[][] result = new int[image.Length - 2][];
            for (int i = 0; i < image.Length - 2; i++)
            {

                for (int j = 0; j < image[0].Length - 2; j++)
                {
                    //Take the next 3 squares
                    int current = 0;
                    for (int x = 0; x < 3; x++)
                    {
                        for (int y = 0; y < 3; y++)
                        {
                            current += image[i + x][j + y];
                        }
                    }
                    current = current / 9;
                    if (result[yPosition] == null)
                    {
                        result[yPosition] = new int[image[0].Length - 2];
                    }
                    result[yPosition][xPosition] = current;
                    xPosition++;
                    if (xPosition == image[0].Length - 2)
                    {
                        xPosition = 0;
                        yPosition++;
                    }
                }
            }
            return result;
        }
        int[][] minesweeper(bool[][] matrix)
        {
            int[][] result = new int[matrix.Length][];

            for (int y = 0; y < matrix.Length; y++)
            {
                result[y] = new int[matrix[0].Length];
                for (int x = 0; x < matrix[0].Length; x++)
                {
                    int counter = 0;
                    for (int x2 = -1; x2 <= 1; x2++)
                    {
                        try
                        {
                            if (matrix[y - 1][x2 + x])
                            {
                                counter++;
                            }
                        }
                        catch (Exception e)
                        { }
                        try
                        {
                            if (x2 != 0)
                                if (matrix[y][x2 + x])
                                {
                                    counter++;
                                }
                        }
                        catch (Exception)
                        {

                        }
                        try
                        {
                            if (matrix[y + 1][x2 + x])
                            {
                                counter++;
                            }
                        }
                        catch (Exception)
                        {
                        }
                    }
                    result[y][x] = counter;
                }
            }
            return result;
        }
        /// <summary>
        /// Solutions to Rain of Reason (Intro)
        /// </summary>
        int[] arrayReplace(int[] inputArray, int elemToReplace, int substitutionElem)
        {
            for (int i = 0; i < inputArray.Length; i++)
            {
                if (inputArray[i] == elemToReplace)
                {
                    inputArray[i] = substitutionElem;
                }
            }
            return inputArray;
        }
        bool evenDigitsOnly(int n)
        {
            string current = n.ToString();
            foreach (char item in current)
            {
                if (item % 2 != 0)
                {
                    return false;
                }
            }
            return true;
        }
        bool variableName(string name)
        {
            int a = 0;
            if (int.TryParse(name[0].ToString(), out a))
            {
                return false;
            }
            foreach (var item in name)
            {
                if (!char.IsLetterOrDigit(item) && '_' != item)
                {
                    return false;
                }
            }
            return true;
        }
        string alphabeticShift(string inputString)
        {
            string result = "";
            for (int i = 0; i < inputString.Length; i++)
            {
                if (inputString[i] == 'z')
                {
                    result += 'a';
                }
                else
                {
                    char temp = inputString[i];
                    temp++;
                    result += temp;
                }
            }
            return result;
        }
        bool chessBoardCellColor(string cell1, string cell2)
        {
            int a = cell1[0];
            int a2 = (int)char.GetNumericValue(cell1[1]);

            int b = cell2[0];
            int b2 = (int)char.GetNumericValue(cell2[1]);

            if ((Math.Abs(a - b) + Math.Abs(a2 - b2)) % 2 == 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Solutions to Through the Fog (Intro)
        /// </summary>
        int circleOfNumbers(int n, int firstNumber)
        {
            for (int i = 0; i < (n / 2); i++)
            {
                firstNumber++;
                if (firstNumber > n - 1)
                {
                    firstNumber = 0;
                }
            }
            return firstNumber;
        }
        int depositProfit(int deposit, int rate, int threshold)
        {
            int counter = 0;
            decimal current = decimal.Parse(deposit.ToString());
            while (current < threshold)
            {
                current += current * decimal.Divide(rate, 100);
                counter++;
            }
            return counter;
        }
        int absoluteValuesSumMinimization(int[] a)
        {
            int lowest = int.MaxValue;
            int index = 0;
            for (int i = 0; i < a.Length; i++)
            {
                int current = 0;
                for (int j = 0; j < a.Length; j++)
                {
                    current += Math.Abs(a[j] - a[i]);
                }
                if (current < lowest)
                {
                    lowest = current;
                    index = i;
                }
            }
            return a[index];
        }
        bool stringsRearrangement(string[] inputArray)
        {
            return TryNewElement(inputArray, new string[inputArray.Length], -1);
        }
        public bool TryNewElement(string[] input, string[] result, int counter)
        {

            bool result2 = false;
            int c = 0;
            foreach (var item in result)
            {
                if (item != null)
                {
                    c++;
                }
            }
            if (c == result.Length)
            {
                return true;
            }
            for (int i = 0; i < input.Count(); i++)
            {
                while (input[i] == null)
                {
                    i++;
                    if (i >= input.Count())
                    {
                        break;
                    }
                }
                if (i >= input.Count())
                {
                    break;
                }
                if (result.Count() > 0)
                {
                    string temp = input[i];
                    int letterDifferenceCount = 0;
                    if (result[0] != null)
                    {
                        for (int j = 0; j < temp.Length; j++)
                        {
                            if (temp[j] != result[counter][j])
                            {
                                letterDifferenceCount++;
                            }
                        }
                    }

                    if (letterDifferenceCount == 1 || result[0] == null)
                    {
                        input[i] = null;
                        counter++;
                        result[counter] = temp;
                        result2 = TryNewElement(input, result, counter);
                        if (result2)
                        {
                            return true;
                        }
                        result[counter] = null;
                        input[i] = temp;
                        counter--;
                    }
                }
                else
                {
                    string temp = input[i];
                    counter++;
                    result[counter] = temp;
                    input[i] = null;
                    result2 = TryNewElement(input, result, counter);
                    if (result2)
                    {
                        return true;
                    }
                    input[i] = temp;
                    result[counter] = null;
                    counter--;
                }

            }
            return result2;
        }
        /// <summary>
        /// Solutions to Diving Deeper (Intro)
        /// </summary>
        int[] extractEachKth(int[] inputArray, int k)
        {
            List<int> result = new List<int>();
            int temp = k;
            for (int i = 0; i < inputArray.Length; i++)
            {
                if (i != temp - 1)
                {
                    result.Add(inputArray[i]);
                }
                else
                    temp += k;
            }
            return result.ToArray();
        }
        char firstDigit(string inputString)
        {
            foreach (var item in inputString)
            {
                int a = 0;
                if (int.TryParse(item.ToString(), out a))
                {
                    return item;
                }
            }
            return 'a';
        }
        int differentSymbolsNaive(string s)
        {
            Dictionary<char, int> dictionary = new Dictionary<char, int>();
            foreach (var item in s)
            {
                if (!dictionary.ContainsKey(item))
                {
                    dictionary.Add(item, 1);
                }
            }
            return dictionary.Count;
        }
        int arrayMaxConsecutiveSum(int[] inputArray, int k)
        {
            int best = int.MinValue;
            for (int i = 0; i <= inputArray.Length - k; i++)
            {
                int temp = inputArray[i];
                for (int j = 1; j < k; j++)
                {
                    temp += inputArray[i + j];
                }
                if (best < temp)
                {
                    best = temp;
                }
            }
            return best;
        }
        /// <summary>
        /// Solutions to Dark Wilderness (Intro)
        /// </summary>
        int growingPlant(int upSpeed, int downSpeed, int desiredHeight)
        {
            int count = 0;
            int current = 0;
            while (current <= desiredHeight)
            {
                current += upSpeed;
                count++;
                if (current >= desiredHeight)
                {
                    break;
                }
                current -= downSpeed;
            }
            return count;
        }
        int knapsackLight(int value1, int weight1, int value2, int weight2, int maxW)
        {
            if (weight1 + weight2 <= maxW)
            {
                return value1 + value2;
            }
            else
            {
                if (weight1 > maxW && weight2 <= maxW)
                {
                    return value2;
                }
                else if (weight2 > maxW && weight1 <= maxW)
                {
                    return value1;
                }
                if (value1 >= value2 && weight1 <= maxW)
                {
                    return value1;
                }
                else if (value2 > value1 && weight2 <= maxW)
                {
                    return value2;
                }
            }
            return 0;
        }
        string longestDigitsPrefix(string inputString)
        {
            string result = "";
            string temp = "";
            for (int i = 0; i < inputString.Length; i++)
            {
                if (!char.IsDigit(inputString[0]))
                {
                    return "";
                }
                if (char.IsDigit(inputString[i]))
                {
                    temp += inputString[i];
                }
                else
                {
                    if (temp.Length > result.Length)
                        result = temp;
                    temp = "";
                }
            }
            if (temp.Length > result.Length)
                result = temp;
            temp = "";
            return result;
        }
        int digitDegree(int n)
        {
            int count = 0;
            int previous = 0;
            int current = n;
            while (current != 0 || current != 1)
            {
                int temp = 0;
                previous = current;
                foreach (var item in current.ToString())
                {
                    temp += int.Parse(item.ToString());
                }
                current = temp;
                if (current != previous)
                    count++;
                if (previous == current)
                    return count;

            }
            return count;
        }
        bool bishopAndPawn(string bishop, string pawn)
        {
            int a = bishop[0];
            int a2 = (int)char.GetNumericValue(bishop[1]);

            int b = pawn[0];
            int b2 = (int)char.GetNumericValue(pawn[1]);

            if ((Math.Abs(a - b) + Math.Abs(a2 - b2)) % 2 == 0 && a != b && b != b2)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Solutions to Eruption of Light (Intro)
        /// </summary>
        bool isBeautifulString(string inputString)
        {
            Dictionary<char, int> dictionary = new Dictionary<char, int>();
            string temp = "abcdefghijklmnopqrstuvwxyz";
            foreach (var item in temp)
            {
                dictionary.Add(item, 0);
            }
            foreach (var item in inputString)
            {
                dictionary[item]++;
            }
            int previous = 0;
            dictionary.TryGetValue('a', out previous);
            foreach (var item in dictionary)
            {
                if (item.Key != 'a')
                {
                    if (previous >= item.Value)
                    {
                        previous = item.Value;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        string findEmailDomain(string address)
        {
            if (!address.Contains('@'))
            {
                return "";
            }
            else
            {
                return address.Substring(address.LastIndexOf('@') + 1, address.Length - address.LastIndexOf('@') - 1);
            }
        }
        string buildPalindrome(string st)
        {
            int count = 0;
            for (int i = 0; i < st.Length / 2; i++)
            {
                if (st[i] == st[st.Length - i - 1])
                {
                    count++;
                }
            }
            if (count == st.Length / 2)
            {
                return st;
            }

            string current = st;
            for (int i = 0; i < st.Length; i++)
            {
                string temp = current;
                for (int j = 0; j < i; j++)
                {
                    temp += st[i - j - 1];
                }
                count = 0;
                for (int k = 0; k < temp.Length / 2; k++)
                {
                    if (temp[k] == temp[temp.Length - k - 1])
                    {
                        count++;
                    }
                }
                if (count == temp.Length / 2)
                {
                    return temp;
                }
            }
            return "";
        }
        int electionsWinners(int[] votes, int k)
        {
            int biggest = votes.Max();
            int counter = 0;
            int biggestNumbers = 0;
            foreach (var item in votes)
            {
                if (item == biggest)
                {
                    biggestNumbers++;
                }
                if (biggest < item + k)
                {
                    counter++;
                }
            }
            if (biggestNumbers == 1 && counter == 0)
            {
                return 1;
            }
            return counter;
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
        /// <summary>
        /// Solutions to Rainbow of Clarity (Intro)
        /// </summary>
        bool isDigit(char symbol)
        {
            return char.IsDigit(symbol);
        }
        string lineEncoding(string s)
        {
            string result = "";
            int count = 1;
            char previous = s[0];

            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == previous)
                {
                    count++;
                }
                else
                {
                    if (count > 1)
                        result += count + "" + previous;
                    else
                        result += previous;
                    previous = s[i];
                    count = 1;
                }
            }
            if (count > 1)
                result += count + "" + previous;
            else
                result += previous;

            return result;
        }
        int chessKnight(string cell)
        {
            
        }





    }
}
