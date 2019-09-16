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
            
        