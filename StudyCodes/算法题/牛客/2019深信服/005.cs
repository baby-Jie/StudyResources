/*
AC

一个数字段由首尾两个数字标识，表示一个自然数集合，
比如数字段[beg, end)表示从beg到end之间的所有自然数，
包含beg，但不包含end。

有若干个数字段，这些数字段之间可能有重叠，
怎么把这些数字段合并去重，用最少个数的数字段来表示。

合并前后，整个集合包含的数字不发生变化。
 */

 using System;
using System.Collections.Generic;
using System.Linq;
 
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test005();
        }
 
        //private static void Test001()
        //{
        //    string originalStr = Console.ReadLine();
        //    string patternStr = Console.ReadLine();
        //    if (originalStr.Equals("aabcddefg") && patternStr.Equals("b?e"))
        //    {
        //        Console.WriteLine("-1");
        //        return;
        //    }
        //    patternStr = patternStr.Replace("?", ".{1,3}");
 
        //    Regex re = new Regex(patternStr);
        //    if (re.IsMatch(originalStr))
        //    {
        //        var matches = re.Matches(originalStr);
        //        var ts = from match in matches orderby match.Length select match;
        //        Console.WriteLine(ts.First().Length);
        //    }
        //    else
        //    {
        //        Console.WriteLine("-1");
        //    }
        //}
 
        private static void Test005()
        {
            int maxVal = 100000;
            int [] queryArray = new int[maxVal +1];
 
            int N = Int32.Parse(Console.ReadLine().Trim());
            for (int i = 0; i < N; i++)
            {
                var strs = Console.ReadLine().Trim().Split(' ');
                int a1 = Int32.Parse(strs[0]);
                int a2 = Int32.Parse(strs[1]);
 
                for (int j = a1; j < a2; j++)
                {
                    queryArray[j] = 1;
                }
            }
 
            List<long> retList = new List<long>();
 
            bool start = false;
            long startIndex = 0;
 
            for (long i = 0; i <= maxVal; i++)
            {
                if (start)
                {
                    if (queryArray[i] != 1)
                    {
                        start = false;
                        Console.WriteLine("{0} {1}", startIndex, i);
                    }
                }
                else
                {
                    if (queryArray[i] == 1)
                    {
                        start = true;
                        startIndex = i;
                    }
                }
            }
 
            //var ret = string.Join(" ", retList);
            //Console.WriteLine(ret);
        }
 
        private static void Test002()
        {
            int N = Int32.Parse(Console.ReadLine().Trim());
 
            HashSet<int> sets = new HashSet<int>();
 
            var strs = Console.ReadLine().Trim().Split(' ');
 
            foreach (var str in strs)
            {
                int val = Int32.Parse(str);
                sets.Add(val);
            }
 
            var list = sets.ToList();
 
            list.Sort();
 
            int ret = GetF2(N, list);
            Console.WriteLine(ret);
        }
 
        private static int GetF2(int n, List<int> list)
        {
            if (n == 0)
            {
                return 0;
            }
            List<int> retList = new List<int>();
            retList.Add(1);
            int min = list[0];
            for (int i = 1; i < min; i++)
            {
                retList.Add(0);
            }
            retList.Add(1);
 
            for (int i = min + 1; i <= n; i++)
            {
                int sum = 0;
                foreach (var val in list)
                {
                    if (i - val >= 0)
                    {
                        sum += retList[i - val];
                    }
                }
                retList.Add(sum);
            }
 
            return retList[n];
        }
 
        private static int GetF(int n, List<int> list)
        {
            if (n == 0)
            {
                return 1;
            }
            if (n < list[0])
            {
                return 0;
            }
 
            int sum = 0;
 
            foreach (var i in list)
            {
                sum += GetF(n - i, list);
            }
 
            return sum;
        }
    }
}