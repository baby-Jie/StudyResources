/*
10%

已知某序列S=<e1,e2,…,en>，序列中的元素类型为整数（en <= 2^10），序列的长度为可变长度。
现在有若干序列S1，S2,…,Sn，现在要求设计一种算法，找出这些重复的序列。输出重复序列的序号，如果有多组重复，需全部输出。

所有序列中的数字个数加起来，小于1000000，序列个数小于10000个。

例如现有3个序列
S1=<65,43,177,655>
S2=<1,2,3,4,5,6,7>
S3=<65,43,177,655,3>
这时序列无重复。又如
S1=<65,43,177,655,3>
S2=<1,2,3,4,5,6,7>
S3=<65,43,177,655,3>
这时序列有重复。
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
            Test006();
        }
 
        public static void Test006()
        {
            int N = Int32.Parse(Console.ReadLine().Trim());
 
            List<int> retList = new List<int>();
 
            List<string> saveList = new List<string>();
 
            for (int i = 1; i <= N; i++)
            {
                string str1;
                Console.ReadLine();
                str1 = Console.ReadLine().Trim();
                Regex re = new Regex("\\s");
                str1 = re.Replace(str1, ";");
                if (saveList.Contains(str1))
                {
                    int index = saveList.IndexOf(str1);
                    if (!retList.Contains(index))
                    {
                        retList.Add(index);
                    }
                }
                saveList.Add(str1);
            }
 
            foreach (var i in retList)
            {
                string res = saveList[i];
                Console.WriteLine("{0} {1}", i, res.Split(";").Length);
            }
        }
 
    }
}
