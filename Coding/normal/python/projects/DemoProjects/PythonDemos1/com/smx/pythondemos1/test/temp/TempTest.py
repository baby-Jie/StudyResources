import math

t = 15

# int(num) 向下取整
# round(num) 四舍五入
# cell(num) 向上取整
# 分别取整数和小数部分 (point, int) = math.modf(num)

dp = [float("inf")] * 10

dp = [1] * 10
print(dp)

li = [10] * 5

print(li)

li = [i for i in range(10)]
li = [5 for _ in range(10)]
li = [[False] * 5 for _ in range(3)]
print(li[2][4])
print(li)

ret = 10 % 6
print(ret)