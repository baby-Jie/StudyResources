class Solution:
    def singleNumber(self, nums) -> int:
        once = 0
        twice = 0
        for item in nums:
            old_twice = twice
            current_twice = once & item # 这次升级为两次的
            current_twice = current_twice ^ old_twice
            third = current_twice
            print("num:" + str(item))
            print(once)
            print(twice)
            print("-"*10)
        return once

s = Solution()
print(s.singleNumber([2, 2, 1, 1, 3, 1, 3, 3, 4, 2]))
