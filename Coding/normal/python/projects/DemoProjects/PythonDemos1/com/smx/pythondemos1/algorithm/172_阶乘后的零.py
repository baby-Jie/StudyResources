class Solution:
    def trailingZeroes(self, n: int) -> int:
        ret = 1
        for i in range(1, n+1):
            ret = ret * i
        print(ret)
        def zero_count(x):
            zero_count = 0
            while x % 10 == 0:
                zero_count += 1
                x = x // 10
            return zero_count

        return zero_count(ret)


s = Solution()
ret = s.trailingZeroes(20)
print(ret)