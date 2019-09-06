/*
AC

一个长方体，长宽高分别为x,y,z，都为自然数。

现在要把若干个相同的长方体摆成高为N的一根柱形体。

每层摆1个，如果两种摆法的高度是一样的，则认为这两种摆法等价，所以每层只有三种摆法。

求一共有多少种摆法。
 */

 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
 
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test002();
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
