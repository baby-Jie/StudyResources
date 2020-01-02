def test1(num):
    
    def test_in(in_num):
        print("test_in num is:%d, and in_num is:%d" % (num, in_num))
    return test_in

re = test1(10)

re(11)  # test_in num is:10, and in_num is:11

# 实际例子  y = ax + b

def fun1(a, b):

    def fun(num1):
        return a*num1 + b
    return fun

re = fun1(2, 1)
val = re(4)
print(val)  # 9

# 修改外部函数中的变量

def counter(start = 0):

    def incr():
        nonlocal start
        start += 1
        return start

    return incr

c1 = counter(5)
print(c1())  # 6
print(c1())  # 7

c2 = counter(50)
print(c2())  # 51
print(c2())  # 52
