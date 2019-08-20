# 闭包

def test_close_package(number):

    def test(number_in):

        print("this is in test of test_close_package and number is:", number_in)

        return number_in + number

    return test

def main():
    t = test_close_package(20)  # 这里的20传给了number  返回值是test函数
    ret = t(10) # 这里的10传给了number_in

    print("ret is:", ret)

# 修改外部函数中的局部变量

def counter(start=0):
        def incr():
            nonlocal start
            start += 1
            return start
        return incr

def main1():
    inc1 = counter(1)
    print(inc1())
    print(inc1())

    inc1 = counter(100)
    print(inc1())
    print(inc1())

def foo():
    print("hello i am foo")

def main2():
    foo = lambda x: x + 1
    print(foo(10))
   


if __name__ == "__main__":
    main2()