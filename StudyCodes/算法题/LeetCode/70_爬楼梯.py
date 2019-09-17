# 方法一：执行用时 40ms  内存消耗：13.7mb
class Solution:
    def __init__(self):
        self.dic1 = {1:1, 2:2}
    def climbStairs(self, n: int) -> int:
        if n == 1:
            return 1
        elif n == 2:
            return 2
        elif n in self.dic1.keys():
            return self.dic1[n]
        else:
            val = self.climbStairs(n-1) + self.climbStairs(n-2)
            self.dic1[n] = val
            return val