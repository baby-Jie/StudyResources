# 方法一： 执行用时：56ms 内存消耗：13.7mb
class Solution:
    def getRes(self,  i:int, tempStr:str):
        if i >= self.length:
            self.resLi.append(tempStr)
            return
        for ch in self.li[int(self.li2[i])]:
            mytempStr = tempStr
            mytempStr += ch
            self.getRes(i+1, mytempStr)
    def letterCombinations(self, digits: str) -> List[str]:
        if digits == "":
            return ""
        self.length = len(digits)
        self.li = ["", "", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz"]
        self.li2 = digits
        self.resLi = []
        self.getRes(0, "")
        return self.resLi
        