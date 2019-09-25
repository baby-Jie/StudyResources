/**
 * 11——盛最多水的容器
 * 执行用时：337ms
 * 内存消耗：39.1mb
 */

class Solution {
    public int maxArea(int[] height) {
         int maxAreas = 0;
        for (int i = 0; i < height.length - 1; i++)
        {
            for (int j = i + 1; j < height.length; j++)
            {
                int capacity = (j - i) * Math.min(height[i], height[j]);
                maxAreas = Math.max(maxAreas, capacity);
            }
        }
        return maxAreas;
    }
}

/**
 * 双指针法
 * 执行用时：4ms
 * 内存消耗：39.7mb
 * 
 */

public int maxArea2(int[] height)
{
    int maxAreas = 0;
    int left = 0;
    int right = height.length - 1;

    while (left < right)
    {
        int capacity = (right - left) * Math.min(height[left], height[right]);
        maxAreas = Math.max(maxAreas, capacity);

        if (height[left] < height[right])
        {
            left++;
        }
        else
        {
            right--;
        }
    }
    return maxAreas;
}