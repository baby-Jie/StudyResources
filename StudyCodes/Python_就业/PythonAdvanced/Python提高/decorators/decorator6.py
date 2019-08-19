# 装饰器带参数， 在原有装饰器的基础上，设置外部变量

from time import ctime, sleep

def timefun_arg(pre = "hello"):
    def timefun(func):
        def wrapped_func():
            print("%s called at %s %s" % (func.__name__, ctime(), pre))
            return func()

        return wrapped_func
    return timefun

# 下面的装饰过程
# 1. 调用timefun_arg("itcast")
# 2. 将步骤1得到的返回值，即time_fun返回， 然后time_fun(foo)
# 3. 将time_fun(foo)的结果返回，即wrapped_func
# 4. 让foo = wrapped_fun，即foo现在指向wrapped_func
@timefun_arg("itcast")
def foo():
    print("i am foo")

foo()  # 可以理解为： foo()==timefun_arg("itcast")(foo)()


