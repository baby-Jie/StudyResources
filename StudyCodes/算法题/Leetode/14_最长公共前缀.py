class Solution:
    def longestCommonPrefix(self, strs: List[str]) -> str:
        length = len(strs)
        if length == 0:
            return ""
        tempStr = strs[0]
        res = ""
        for i in tempStr:
            res += i
            for j in range(1, length):
                if not strs[j].startswith(res):
                    return res[:-1:]
        return res