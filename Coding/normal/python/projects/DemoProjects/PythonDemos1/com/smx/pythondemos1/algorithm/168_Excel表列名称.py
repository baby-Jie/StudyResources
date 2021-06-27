class Solution:
    def convertToTitle(self, n: int) -> str:
        if n == 26:
            return "Z"
        li = ["Z"]
        temp = "A"
        for _ in range(25):
            li.append(temp)
            i = ord(temp)
            i = i + 1
            temp = chr(i)
        ret = []
        mod = n % 26
        n = n // 26
        ret.append(li[mod])
        if mod == 0:
            n = n - 1
        while n > 0:
            mod = n % 26
            n = n // 26
            ret.append(li[mod])
            if mod == 0:
                n = n - 1
        return "".join(ret)[::-1]


s = Solution()
ret = s.convertToTitle(701)
print("yes")
print(ret)