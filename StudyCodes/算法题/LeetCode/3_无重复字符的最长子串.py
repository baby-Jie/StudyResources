# 方法一 通过：执行用时：496ms 内存消耗：14mb
class Solution:
    def getLen(self, s:str):
        length = len(s)
        temps = ""
        for i in range(length):
            if s[i] in temps:
                break
            else:
                temps += s[i]
        return len(temps)
    def lengthOfLongestSubstring(self, s: str) -> int:
        length = len(s)
        maxCount = 0
        for i in range(length):
            tmeps = s[i::]
            count = self.getLen(tmeps)
            if count > maxCount:
                maxCount = count
        return maxCount

# 方法二：执行用时 92ms 内存消耗 13.9mb
class Solution:
    def lengthOfLongestSubstring(self, s: str) -> int:
        length = len(s)
        maxCount = 0
        temps = ""
        for i in range(length):
            index = temps.find(s[i])
            if index >= 0:
                count = len(temps)
                maxCount= max(maxCount, count)
                if index+1 >= count:
                    temps = ""
                else:
                    temps = temps[index+1::]
            temps += s[i]
        return max(maxCount, len(temps))