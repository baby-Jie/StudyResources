# 方法一： 执行用时：9184ms，内存消耗：13.8MB
class Solution:
    def getMax(self, s:str):
        temps = ""
        length = len(s)
        for i in range(length):
            temps2 = s[:i+1]
            if temps2 == temps2[::-1]:
                temps = temps2
        return temps
    
    def longestPalindrome(self, s: str) -> str:
        length = len(s)
        maxCount = 0
        huiwenStr = ""
        for i in range(length):
            temps = s[i::]
            
            temps = self.getMax(temps)
            if len(temps) > maxCount:
                maxCount = len(temps)
                huiwenStr = temps
        return huiwenStr

class Solution:
    def longestPalindrome(self, s: str) -> str:
        size = len(s)
        max_len = 0
        ret = ""
        for left in range(size):
            tempS = s[left::]
            for right in range(len(tempS)):
                tempS2 = tempS[:right+1]
                if tempS2 == tempS2[::-1]:
                    if len(tempS2) > max_len:
                        max_len =len(tempS2)
                        ret = tempS2
        return ret

# 方法二：
class Solution:
    def longestPalindrome(self, s1: str) -> str:
        size = len(s1)
        dp = [[False for t in range(size)] for _ in range(size)]
        if size <= 1:
            return s1
        max_len = 0
        ret = s1[0]
        for right in range(1, size):
            for left in range(right):
                if s1[left] == s1[right] and (right - left <= 2 or dp[left + 1][right - 1]):
                    dp[left][right] = True
                    current_len = right - left + 1
                    if current_len >= max_len:
                        max_len = current_len
                        ret = s1[left:right+1]
        return ret
