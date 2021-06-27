class Solution:
    def titleToNumber(self, s: str) -> int:

        dic1 = {}
        ch = 'A'
        for index in range(1, 27):
            chIndex = ord(ch)
            chIndex = chIndex + index - 1
            ch1 = chr(chIndex)
            dic1[ch1] = index
        ret = 0
        for item in s:
            ret = ret * 26 + dic1[item]
        return ret


s = Solution()
ret = s.titleToNumber("AB")
print(ret)