/*
输入一个字符串,按字典序打印出该字符串中字符的所有排列。例如输入字符串abc,则打印出由字符a,b,c所能排列出来的所有字符串abc,acb,bac,bca,cab和cba。
输入一个字符串,长度不超过9(可能有字符重复),字符只包括大小写字母。
 */

using System.Collections.Generic;
using System.Linq;
class Solution
{
    private List<char> stacks = new List<char>();
        private string originalStr;
        List<string> res = new List<string>();
    
     public void GetStrs(List<int> list)
        {
            if (stacks.Count >= originalStr.Length)
            {
                string str = "";
                str = string.Join("", stacks);

                res.Add(str);
                return;
            }

            for (int i = 0; i < originalStr.Length; i++)
            {
                if (list[i] == 0)
                {
                    list[i] = 1;
                    stacks.Add(originalStr[i]);
                    GetStrs(list);
                    list[i] = 0;
                    stacks.RemoveAt(stacks.Count - 1);
                }
            }
        }
    public List<string> Permutation(string str)
    {
         if (string.IsNullOrWhiteSpace(str))
            {
                return new List<string>();
            }
        // write code here
        originalStr = str;
            List<int> list = new List<int>();
            for (int i = 0; i < originalStr.Length; i++)
            {
                list.Add(0);
            }

            GetStrs(list);
       res = res.Distinct().ToList();
            // write code here
            return res;
    }
} 输入一个字符串,长度不超过9(可能有字符重复),字符只包括大小写字母。