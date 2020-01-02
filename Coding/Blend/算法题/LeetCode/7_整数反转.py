# 方法一： 执行耗时：48ms 内存消耗：13.8mb
class Solution:
    def reverse(self, x: int) -> int:
        flag = x < 0
        str1 = str(x)
        if flag:
            str1 = str1[1::]
        str1 = str1[::-1]
        print(str1)
        ret = int(str1)
        if flag:
            ret = ret * -1
        if ret < -2**31 or ret>= 2**31:
            ret = 0
        return ret
        