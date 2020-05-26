class Solution:
    def lengthOfLIS(self, nums) -> int:

        li_len = len(nums)
        if li_len == 1:
            return 1
        elif li_len == 0:
            return 0
        dic1 = {}

        def inner_method(end):
            if end < 0:
                return 0

            if end in dic1.keys():
                return dic1[end]

            max_count = 0
            for i in range(0, end):
                if nums[i] < nums[end]:
                    max_count = max(max_count, inner_method(i))
            another_count = inner_method(end-1)
            max_count = max(another_count, max_count + 1)
            dic1[end] = max_count
            return max_count

        ret = inner_method(li_len - 1)
        return ret


li = [1, 3, 6, 7, 9, 4, 10, 5, 6]
s = Solution()
print(s.lengthOfLIS(li))
