"""其他拷贝的方式"""

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

d = dict(name = "zhangsan", age = 27)

co = d.copy()

print("id of c:", id(c))

print("id of d:", id(d))