# 给你一个数组，多次给你i,j的值，要你求下标i到下标j的和，注意是多次，所以要将所有的结果保存下来，（可以先保存，也可以用的时候再计算保存）

def f1(A):
    dic1={}
    for i in range(0,len(A)):
        sum=A[i]
        for j in range(i+1,len(A)):
            sum=sum+A[j]
            dic1[(i,j)]=sum
    return dic1

A=[3,5,2,6,8,3,9,7,4]
dic2=(f1(A))
print(dic2)
print(dic2[(2,6)])