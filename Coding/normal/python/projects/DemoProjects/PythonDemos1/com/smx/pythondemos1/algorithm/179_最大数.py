from functools import cmp_to_key
class Solution:
    def largestNumber(self, nums) -> str:
        if not nums:
            return 0

        def foo(s1:str, s2:str):
            len1 = len(s1)
            len2 = len(s2)
            if len1 > len2:
                dif = len1 - len2
                ch = s2[-1]
                ch = ch * dif
                s2 += ch
            elif len2 > len1:
                dif = len2 - len1
                ch = s1[-1]
                ch = ch * dif
                s1 += ch
            if s1 == s2:
                return 0
            elif s1 > s2:
                return 1
            else:
                return -1
        li = [str(item) for item in nums]

        li.sort(key=cmp_to_key(foo))

        li = li[::-1]

        s = "".join(li)

        return s


s = Solution()
ret = s.largestNumber([3, 30, 34, 5, 9])
print(ret)
