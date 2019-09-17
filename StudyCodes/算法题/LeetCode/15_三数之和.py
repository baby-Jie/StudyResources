# 方法一：超出时间限制
class Solution:
    def threeSum(self, nums: List[int]) -> List[List[int]]:
        dics = {}
        length = len(nums)
        for i in range(length-1):
            for j in range(i+1, length):
                temp = -1 * (nums[i] + nums[j])
                tempNums = nums[j+1::]
                if temp in tempNums:
                    li = [nums[i], nums[j], temp]
                    li.sort()
                    dics[str(li)] = 1
        retLi = []
        for key in dics.keys():
            retLi.append(eval(key))
        return retLi
