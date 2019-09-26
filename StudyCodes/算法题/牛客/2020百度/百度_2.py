# 两个数(a, b 其中 a < b), a可以+1可以*2  求a到b的最短路径
a=1
dic1={}
def f1(n):
    if n<=a:
        return 0
    else:
        if n in dic1.keys():
            return dic1[n]
        x=f1(n-1)
        min_number=x
        if n%2==0:
            y=f1(n/2)
            if y<min_number:
                min_number=y
        min_number=min_number+1
        dic1[n]=min_number

    return min_number

num=f1(12)
print(num)