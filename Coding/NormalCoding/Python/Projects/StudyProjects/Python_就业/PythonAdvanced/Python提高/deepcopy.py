"""浅拷贝和深拷贝"""

import copy

# a = [1, 2, 3]

# b = a  # 浅拷贝

# c = copy.deepcopy(a)  # 深拷贝

# a[1] = 222

# print("a = %s" % str(a)) # a = [1, 222, 3]

# print("b = %s" % str(b)) # b = [1, 222, 3]

# print("c = %s" % str(c)) # c = [1, 2, 3]

a = [11, 22]

b = [33, 44]

c = [a, b]

d = copy.deepcopy(c)

e = c

print("id of a:" + str(id(a)))
print("id of b:" + str(id(b)))
print("id of c:" + str(id(c)))
print("id of d:" + str(id(d)))
print("id of e:" + str(id(e)))

print("id of c[0]:" + str(id(c[0])))
print("id of d[0]:" + str(id(d[0])))

a.append(55)

print("c is:", c)

print("d is:", d)

""" 运行结果
id of a:2273870240072
id of b:2273864532552
id of c:2273874794312
id of d:2273874823368
id of e:2273874794312
id of c[0]:2273870240072
id of d[0]:2273874908552
c is: [[11, 22, 55], [33, 44]]
d is: [[11, 22], [33, 44]]
"""

