namespace Codewars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Kata
    {
        public static int[] ArrayDiff(int[] a, int[] b)
        {
            if (b.Length == 0)
            {
                return a;
            }
            for (int i = 0; i < b.Length; i++)
            {
                for (int j = a.Length - 1; j >= 0; j--)
                {
                    if (a[j] == b[i])
                    {
                        int[] temp = new int[a.Length - 1];
                        if (j > 0)
                            Array.Copy(a, 0, temp, 0, j);

                        if (j < a.Length - 1)
                            Array.Copy(a, j + 1, temp, j, a.Length - j - 1);

                        a = temp;
                    }
                }
            }
            return a;
        }
        public static IEnumerable<T> UniqueInOrder<T>(IEnumerable<T> iterable)
        {
            List<T> result = new List<T>();
            var list = iterable.ToList();
            for (int i = 0; i < list.Count() - 1; i++)
            {
                if (list[i].GetHashCode() != list[i + 1].GetHashCode())
                {
                    result.Add(list[i]);
                }
            }
            if (list.Count > 0)
            {
                result.Add(list[list.Count - 1]);
            }
            return result;
        }
        public int GetSum(int a, int b)
        {
            int sum = 0;
            if (a > b)
            {
                for (int i = b; i <= a; i++)
                {
                    sum += i;
                }
            }
            else if (b > a)
            {
                for (int i = a; i <= b; i++)
                {
                    sum += i;
                }
            }
            else
                return a;
            return sum;
        }
        public static string GetMiddle(string s)
        {
            return s.Length % 2 == 0 ? s.Substring(Convert.ToInt32(Math.Ceiling(s.Length / 2.0) - 1), 2) : s.Substring(Convert.ToInt32(Math.Ceiling(s.Length / 2.0) - 1), 1);
        }
        public static int PositiveSum(int[] arr)
        {
            return arr.Sum(x => x > 0 ? x : 0);
        }
        public static int[] DeleteNth(int[] arr, int x)
        {
            var dict = new Dictionary<int, int>();

            var input = arr.ToList();
            var result = new List<int>();

            foreach (var item in input)
            {
                if (!dict.ContainsKey(item))
                {
                    dict.Add(item, 1);
                    result.Add(item);
                }
                else if(dict[item] < x)
                {
                    dict[item]++;
                    result.Add(item);
                }
            }
            return result.ToArray();
        }
    }
}
