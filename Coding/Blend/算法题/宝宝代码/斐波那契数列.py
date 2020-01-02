# 递归实现斐波那契数列
def fibonaci(num:int)->int: # num:int 表示参数num是int类型的数据，->int 表示返回值是int类型的数据
    if num <= 2:
        return 1
    return fibonaci(num-1) + fibonaci(num-2)

# 递归实现斐波那契数列 但是存储了子问题的结果
def fibonaci2(num:int)->int:
    dic1 = {}
    def fibonaciInner(numInner:int)->int:
        if numInner <= 2:
            return 1
        if numInner in dic1.keys():
            return dic1[numInner]
        ret = fibonaciInner(numInner-1) + fibonaciInner(numInner-2)
        dic1[numInner] = ret
        return ret
    return fibonaciInner(num)

# 非递归实现斐波那契数列
def fibonaci3(num:int)->int:
    if num <= 2:
        return 1
    pre_pre, pre = 1, 1
    for ii in range(3, num+1):
        current = pre + pre_pre
        pre_pre = pre
        pre = current
    return current

num = 100
print(fibonaci(num))  # 速度很慢
print(fibonaci2(num)) # 速度快
print(fibonaci3(num)) # 速度快
