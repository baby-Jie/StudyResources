n=int(input())
def yueshunumber(n):
    count=0
    if n == 1:
        count = 1
    else:
        for i in range(1,int(n**0.5)+1):
            if n%i==0 and int(n/i) ==i:
                count+=1
            elif n%i==0 and int(n/i)!=i:
                count+=2
    print(count)

def issushu(n):
    Flag=True
    if n==2 or  n==3:
        return Flag
    else:
        for j in range(2,int(n**0.5)+1):
                if n %j==0:
                    Flag=False
                    break
        return Flag


yueshunumber(n)
count=0
for i in range(2,n+1):
    if issushu(i)==True:
        count+=1
print(count)

# 判断是否是偶数 n & 1  == 0
# 判断是否是2的整数次幂  n & (n - 1) == 0