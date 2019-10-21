# 求两个数的最大公约数和最小公倍数

L=[int(i) for i in input().split(" ")]

if L[0]>L[1]:
    L[0],L[1]=L[1],L[0]
mul=L[0]*L[1]
for i in range(L[0],int(L[0]**0.5)-1,-1):
    if L[1]%i==0 and L[0]%i==0:
        print("最大公约数为：%d",i)
        print("最小公倍数是：%d",int(mul/i))
        break