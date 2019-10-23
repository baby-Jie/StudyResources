# 198. 打家劫舍 动态规划 执行用时：48ms 内存消耗：13.9mb
class Solution:
    def rob(self, nums: List[int]) -> int:
        dic1 = {}
        length = len(nums)
        if length == 0:
            return 0
        def innerRob(i:int):
            if i == 0:
                return nums[0]
            elif i == 1:
                return max(nums[0], nums[1])
            else:
                if i in dic1.keys():
                    return dic1[i]
                val1 = innerRob(i-1)
                val2 = innerRob(i-2) + nums[i]
                ret = max(val1, val2)
                dic1[i] = ret
                return ret
        return innerRob(length-1)
        