/*
把数组排成最小的数
输入一个正整数数组，把数组里所有数字拼接起来排成一个数，打印能拼接出的所有数字中最小的一个。例如输入数组{3，32，321}，则打印出这三个数字能排成的最小数字为321323。

 */

 using System.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
class Solution
{
    public string PrintMinNumber(int[] numbers)
    {
        // write code here
         var strList = (from number in numbers select number.ToString()).ToList();
            strList.Sort(new MyCompare());

            return string.Join("", strList);
    }
}

 public class MyCompare : Comparer<string>
    {
        public override int Compare(string x, string y)
        {
            if (x.Length == y.Length)
            {
                return x.CompareTo(y);
            }

            int len1 = x.Length;
            int len2 = y.Length;

            if (len1 < len2)
            {
                char ch = x[len1 - 1];
                for (int i = 0; i < len2 - len1; i++)
                {
                    x += ch;
                }
            }
            else if (len1 > len2)
            {
                char ch = y[len2 - 1];
                for (int i = 0; i < len1 - len2; i++)
                {
                    y += ch;
                }
            }

            return x.CompareTo(y);

        }
    }