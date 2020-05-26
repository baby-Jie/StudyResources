import math


class Solution:

    def __init__(self):
        self.dic1 = {}
        self.li = [1, 1, 2]

    # 自顶向下
    def numSquares(self, n: int) -> int:

        if n == 1:
            return 1

        if math.sqrt(n) == int(math.sqrt(n)):
            return 1
        if self.dic1.__contains__(n):
            return self.dic1[n]
        middle = (n + 1) // 2
        min_count = n
        for i in range(1, middle + 1):
            min_count = min(self.numSquares(i) + self.numSquares(n - i), min_count)

        self.dic1[n] = min_count
        return min_count

    # 自底向上
    def numSquares2(self, n: int) -> int:

        if n == 1:
            return 1
        elif n == 2:
            return 2
        for i in range(3, n+1):
            if math.sqrt(i) == int(math.sqrt(i)):
                self.li.append(1)
            else:
                ret = self.custom_count(i)
                self.li.append(ret)
        return self.li[n]

    # 另外一种思路
    def numSquares3(self, n:int) ->int:
        squares = [i**2 for i in range(1, int(math.sqrt(n)) + 1)]
        dic1 = {1:1, 2:2}
        def inner_method(num):
            if num in dic1.keys():
                return dic1[num]
            if num in squares:
                dic1[num] = 1
                return 1
            min_count = num
            for s in squares:
                if s > num:
                    break
                ret = inner_method(num-s) + 1
                min_count = min(min_count, ret)
            dic1[num] = min_count
            return min_count
        return inner_method(n)

    def custom_count(self,n:int):
        middle = (n+1) // 2
        min_count = n
        for i in range(1, middle + 1):
            min_count = min(min_count, self.li[i] + self.li[n-i])
        return min_count


# custom test

s = Solution()
count = s.numSquares3(7)
# print(s.li)
print(count)
