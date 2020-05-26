class Solution:
    def checkSubarraySum(self, nums, k: int) -> bool:
        length = len(nums)

        for i in range(0, length):
            last_sum = 0
            for j in range(i, length):
                temp_sum = last_sum + nums[j]
                if k == 0:
                    if temp_sum == 0 and j - i >= 1:
                        return True
                elif temp_sum % k == 0 and j - i >= 1:
                    return True
                last_sum = temp_sum

        return False

s = Solution()
li = [23,2]
k = 6
ret = s.checkSubarraySum(li, k)
print(ret)