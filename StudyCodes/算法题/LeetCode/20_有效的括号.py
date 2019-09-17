# 方法一 执行用时：52ms 内存消耗：14mb
class Solution:
    def isValid(self, s: str) -> bool:
        try:
            if s == "":
                return True
            strs = "()[]{}"
            strs1 = "([{"
            strs2 = ")]}"
            li = []
            for ch in s:
                if ch in strs:
                    if ch in strs1:
                        li.append(ch)
                    elif ch in strs2:
                        ch2 = li.pop()
                        if ch2+ch not in ["()", "{}", "[]"]:
                            return False
                else:
                    return False
            if len(li) > 0:
                return False
            return True
        except:
            return False
        