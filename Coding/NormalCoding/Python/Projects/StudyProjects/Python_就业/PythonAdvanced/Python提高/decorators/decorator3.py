# 带参数的 装饰器

from time import ctime, sleep

def timefun(func):
    def wrapped_func(a, b):
        print("%s called at %s" % (func.__name__, ctime()))
        print(a, b)
        a += 1 
        b += 1
        func(a, b)

    return wrapped_func

@timefun
def foo(a, b):
    print(a + b)

foo(3, 5)
sleep(2)
foo(2, 4)

""" out put 
foo called at Thu Aug 15 23:11:01 2019
3 5
10
foo called at Thu Aug 15 23:11:03 2019
2 4
8
"""