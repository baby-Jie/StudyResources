"""
创建生成器方法：
    方法一：表达式 (i*2 for i in range(5))
    方法二：函数
    在使用生成器实现的方式中，我们将原本在迭代器__next__方法中实现的基本逻辑放到一个函数中来实现，但是将每次迭代返回数值的return换成了yield，此时新定义的函数便不再是函数，而是一个生成器了。简单来说：只要在def中有yield关键字的 就称为 生成器
"""

def fib(n):
    current = 0
    num1, num2 = 0, 1

    while current < n:
        num1, num2 = num2, num1 + num2
        current += 1
        yield num1
    return "done"

g = fib(5)

# for val in g:
#     print(val, end=" ")
# 此时按照调用函数的方式( 案例中为F = fib(5) )使用生成器就不再是执行函数体了，而是会返回一个生成器对象（ 案例中为F ），然后就可以按照使用迭代器的方式来使用生成器了。

while True:
    try:
        x = next(g)
        print("value:%d" % x)
    except StopIteration as e:
        print("生成器返回值：%s" %e.value)
        break
# 但是用for循环调用generator时，发现拿不到generator的return语句的返回值。如果想要拿到返回值，必须捕获StopIteration错误，返回值包含在StopIteration的value中