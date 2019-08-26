/*
输入n个整数，找出其中最小的K个数。例如输入4,5,1,6,2,7,3,8这8个数字，则最小的4个数字是1,2,3,4,。
 */

 using System.Linq;
using System.Collections.Generic;
class Solution
{
    public List<int> GetLeastNumbers_Solution(int[] input, int k)
    {
         if (k > input.Length)
            {
                return new List<int>();
            }
        // write code here
         List<int> list = input.ToList();
            list.Sort();
            var ret = list.GetRange(0, k);

            return ret;
    }
}