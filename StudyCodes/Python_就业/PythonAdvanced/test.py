def func(num, *tu, **dic):
    print("num is:" + str(num))
    print(tu)
    print(dic)
    pass

def func2(num, *tupp, tu =(), li = [], dic={}):
    print(num)
    print(tupp)
    print(tu)
    print(li)
    print(dic)
    pass

# func(1, *(2,3),'4', name="smx", age=18)

func2(1, *(11,22), tu = (1, 2), li = [3, 4, 5], dic = {"name":"smx"})
