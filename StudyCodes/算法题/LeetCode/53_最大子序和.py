# 方法一： 执行用时：96ms 内存消耗：14.7mb
class Solution:
    def maxSubArray(self, nums: List[int]) -> int:
        length = len(nums)
        maxSum = nums[0]
        sumtemp = 0
        for i in range(0, length):
            sumtemp += nums[i]
            maxSum = max(maxSum, sumtemp)
            if sumtemp < 0:
                sumtemp = 0
        return maxSum