/*
把只包含质因子2、3和5的数称作丑数（Ugly Number）。例如6、8都是丑数，但14不是，因为它包含质因子7。 习惯上我们把1当做是第一个丑数。求按从小到大的顺序的第N个丑数。
 */

 using System;
using System.Collections.Generic;
class Solution
{
    public int GetUglyNumber_Solution(int n)
    {
        // write code here
   

       if (n <= 0) return 0;
            List<int> list = new List<int>();
            list.Add(1);
            int i2 = 0, i3 = 0, i5 = 0;
            while (list.Count < n)//循环的条件
            {
                int m2 = list[i2] * 2;
                int m3 = list[i3] * 3;
                int m5 = list[i5] * 5;
                int min = Math.Min(m2, Math.Min(m3, m5));
                list.Add(min);
                if (min == m2) i2++;
                if (min == m3) i3++;
                if (min == m5) i5++;
            }
            return list[list.Count - 1];
    }
}