﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace CodeFight
{
    class Core<T>
    {
        /// <summary>
        /// Solutions to Intro Gates
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        int addTwoDigits(int n)
        {
            int temp = 0;
            foreach (var item in n.ToString())
            {
                temp += int.Parse(item.ToString());
            }
            return temp;
        }
        int largestNumber(int n)
        {
            string temp = "";
            for (int i = 0; i < n; i++)
            {
                temp += 9;
            }
            return int.Parse(temp);
        }
        int candies(int n, int m)
        {
            return (m / n) * n;
        }
        int seatsInTheater(int nCols, int nRows, int col, int row)
        {
            return (nCols - col + 1) * (nRows - row);
        }
        int maxMultiple(int divisor, int bound)
        {
            return bound - (bound % divisor);
        }
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
        int lateRide(int n)
        {
            int hours = n / 60;
            if (hours > 9)
            {
                hours = int.Parse(hours.ToString()[0].ToString()) + int.Parse(hours.ToString()[1].ToString());
            }
            int minutes = n % 60;
            if (minutes > 9)
            {
                minutes = int.Parse(minutes.ToString()[0].ToString()) + int.Parse(minutes.ToString()[1].ToString());
            }
            return hours + minutes;
        }
        int phoneCall(int min1, int min2_10, int min11, int s)
        {
            int minutes = 0;
            while (s > 0)
            {
                if (minutes == 0)
                {
                    if (min1 <= s)
                    {
                        minutes++;
                        s -= min1;
                    }
                    else
                        break;
                }
                else if (minutes < 10)
                {
                    if (min2_10 <= s)
                    {
                        minutes++;
                        s -= min2_10;
                    }
                    else
                        break;
                }
                else
                {
                    if (min11 <= s)
                    {
                        minutes++;
                        s -= min11;
                    }
                    else
                        break;
                }
            }
            return minutes;
        }
        /// <summary>
        /// Solutions to At the Crossroad
        /// </summary>
        /// <param name="experience"></param>
        /// <param name="threshold"></param>
        /// <param name="reward"></param>
        /// <returns></returns>
        bool reachNextLevel(int experience, int threshold, int reward)
        {
            if (reward + experience >= threshold)
            {
                return true;
            }
            return false;
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
        int extraNumber(int a, int b, int c)
        {
            if (a == b)
                return c;
            if (b == c)
                return a;
            return b;
        }
        bool isInfiniteProcess(int a, int b)
        {
            if (b % 2 == 0 && a % 2 == 0 && b >= a)
            {
                return false;
            }
            if (b % 2 != 0 && a % 2 != 0 && b >= a)
                return false;
            return true;
        }
        bool arithmeticExpression(int a, int b, int c)
        {
            if (a + b == c)
                return true;
            if (a - b == c)
                return true;
            if (a * b == c)
                return true;
            if ((double)a / b == (double)c)
                return true;
            return false;
        }
        bool tennisSet(int score1, int score2)
        {
            if (score1 == 7 && 4 < score2 && score2 <= 6)
            {
                return true;
            }
            if (score2 == 7 && 4 < score1 && score1 <= 6)
            {
                return true;
            }
            if (score1 == 6 && score2 <= 4)
            {
                return true;
            }
            if (score2 == 6 && score1 <= 4)
            {
                return true;
            }
            if (score1 == 5 && score2 <= 3)
            {
                return true;
            }
            if (score2 == 5 && score1 <= 3)
            {
                return true;
            }
            return false;
        }
        bool willYou(bool young, bool beautiful, bool loved)
        {
            if (young && beautiful && !loved)
                return true;
            if ((!young || !beautiful) && loved)
                return true;
            return false;
        }
        int[] metroCard(int lastNumberOfDays)
        {
            if (lastNumberOfDays == 31)
                return new int[] { 28, 30, 31 };
            if (lastNumberOfDays == 30)
                return new int[] { 31 };
            if (lastNumberOfDays == 28)
                return new int[] { 31 };
            return new int[0];
        }
        /// <summary>
        /// Solutions to Corner of 0s and 1s
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        int arrayPacking(int[] a)
        {
            string current = "";
            for (int i = a.Length-1; i >= 0; i--)
            {
                string temp = Convert.ToString(a[i], 2);
                int need = 8 - temp.Length;
                for (int j = 0; j < need; j++)
                {
                    temp = "0" + temp;
                }
                current += temp;
            }
            return Convert.ToInt32(current, 2);
        }
        int rangeBitCount(int a, int b)
        {
            int current = 0;
            for (int i = a; i <= b; i++)
            {
                string temp = Convert.ToString(i, 2);
                foreach (var item in temp)
                {
                    current += int.Parse(item.ToString());
                }
            }
            return current;
        }
        int mirrorBits(int a)
        {
            string current = "";
            foreach (var item in Convert.ToString(a, 2).Reverse())
            {
                current += item;
            }
            return Convert.ToInt32(current, 2);
        }
        int secondRightmostZeroBit(int n)
        {
            return (int)Math.Pow(2, (new String(Convert.ToString(n, 2).Reverse().ToArray()).IndexOf("0", (new String(Convert.ToString(n, 2).Reverse().ToArray()).IndexOf("0")) + 1)));
        }
        int swapAdjacentBits(int n)
        {
            return (n <= 0) ? n : ((Convert.ToInt32(Convert.ToString(n,2),2) & 0b10101010) >> 1) | (Convert.ToInt32(Convert.ToString(n, 2), 2) & 0b01010101) << 1;
        }


    }











}

