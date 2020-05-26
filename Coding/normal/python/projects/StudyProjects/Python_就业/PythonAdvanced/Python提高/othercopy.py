"""其他拷贝的方式"""

import copy

# 分片表达式可以赋值一个序列

# a = [11, 22]

# b = [33, 44]

# c = [a, b]

# d = c[:]

# print("id of c:", id(c))

# print("id of d:", id(d))

# print("id of c[0]:", id(c[0]))

# print("id of d[0]:", id(d[0]))


""" 
运行结果
id of c: 2151032852296
id of d: 2151032947080
id of c[0]: 2151015855176
id of d[0]: 2151015855176
"""

# 字典的copy方法可以拷贝一个字典

# d = dict(name = "zhangsan", age = 27, li = [1, 2])

# co = d.copy()

# d["li"].append(3)

# print("id of d:", id(d))

# print("id of co:", id(co))

# print("d is:", d)

# print("co is:", co)

"""
id of c: 140195755895184
id of d: 140195755894248
d is: {'name': 'zhangsan', 'age': 27, 'li': [1, 2, 3]}
co is: {'name': 'zhangsan', 'age': 27, 'li': [1, 2, 3]}
"""

a = [1, 2, 3]
b = copy.copy(a)

print("id of a is:", id(a))
print("id of b is:", id(b))

c = (1, 2, 3)
d = copy.copy(c)

print("id of c is:", id(c))
print("id of d is:", id(d))

"""运行结果
id of a is: 140491659547336
id of b is: 140491659548936
id of c is: 140491659501216
id of d is: 140491659501216
"""


