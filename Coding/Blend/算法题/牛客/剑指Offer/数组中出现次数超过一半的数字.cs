/*
数组中有一个数字出现的次数超过数组长度的一半，请找出这个数字。例如输入一个长度为9的数组{1,2,3,2,2,2,5,4,2}。由于数字2在数组中出现了5次，超过数组长度的一半，因此输出2。如果不存在则输出0。
 */

 using System.Collections.Generic;
using System.Linq;
class Solution
{
    public int MoreThanHalfNum_Solution(int[] numbers)
    {
        // write code here
         List<int> list = numbers.ToList();

            int ret = 0;

            for (int i = 0; i < list.Count; i++)
            {
                int count = list.Where((val) => val == list[i]).Count();
                if (count > list.Count / 2)
                {
                    ret = list[i];
                }
            }

            return ret;
    }
}