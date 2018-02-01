using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFight
{
    class Core
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



    }
}
