class Solution:
    def majorityElement(self, nums) -> int:

        dic1 = {}
        for item in nums:
            if item in dic1.keys():
                dic1[item] = dic1[item] + 1
            else:
                dic1[item] = 1
        for key in dic1.keys():
            num = dic1[key]
            if num > len(nums) / 2:
                return key
        return 0
