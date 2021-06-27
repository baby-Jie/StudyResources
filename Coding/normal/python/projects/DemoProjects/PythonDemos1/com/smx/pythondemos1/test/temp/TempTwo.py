
def fun1():
    a = 1
    def inner():
        nonlocal a
        a = 10 + a
    inner()
    print(a)

fun1()