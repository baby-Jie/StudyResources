def f(n):
    if (n==1):
        result =0
    elif (n==2):
        result=1
    else :
        result =f(n-1)+f(n-2)
    return result

n=int(input("请输入一个数:"))
print(f(n))
