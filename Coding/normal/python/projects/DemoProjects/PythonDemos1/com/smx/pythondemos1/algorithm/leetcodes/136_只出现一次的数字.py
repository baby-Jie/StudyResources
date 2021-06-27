class Solution:
    def singleNumber(self, nums) -> int:

        ret = 0
        for item in nums:
            ret = ret ^ item
        return ret
