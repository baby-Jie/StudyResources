/*
数字在排序数组中出现的次数
统计一个数字在排序数组中出现的次数。
 */
 using System.Linq;
class Solution
{
    public int GetNumberOfK(int[] data, int k)
    {
        // write code here
        return data.Count(t => t == k);
    }
}