/*
第一个只出现一次的字符
在一个字符串(0<=字符串长度<=10000，全部由字母组成)中找到第一个只出现一次的字符,并返回它的位置, 如果没有则返回 -1（需要区分大小写）.
 */

 using System.Linq;
class Solution
{
    public int FirstNotRepeatingChar(string str)
    {
        // write code here
        for (int i = 0; i < str.Length; i++)
            {
                var ch = str[i];
                int count = str.Count(c => c == ch);

                if (count == 1)
                {
                    return i;
                }
            }

            return -1;
    }
}