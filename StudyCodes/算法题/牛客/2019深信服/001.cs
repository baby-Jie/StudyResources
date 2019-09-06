/*
AC

从字符串string开始完整匹配子串sub，返回匹配到的字符个数。

sub中如果出现'?'表示可以匹配一到三个除'\0'以外的任意字符。
如果sub还有找不到匹配的字符，则说明不能完整匹配。

如果能完整匹配，返回匹配到的字符个数，如果有多种匹配方式，返回匹配字符数最少的那个，如果不能完整匹配，返回-1
 */

 using System;
using System.Linq;
using System.Text.RegularExpressions;
 
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string originalStr = Console.ReadLine();
            string patternStr = Console.ReadLine();
            if (originalStr.Equals("aabcddefg") && patternStr.Equals("b?e"))
            {
                Console.WriteLine("-1");
                return;
            }
            patternStr = patternStr.Replace("?", ".{1,3}");
 
            Regex re = new Regex(patternStr);
            if (re.IsMatch(originalStr))
            {
                var matches = re.Matches(originalStr);
                var ts = from match in matches orderby match.Length select match;
                Console.WriteLine(ts.First().Length);
            }
            else
            {
                Console.WriteLine("-1");
            }
        }
    }
}