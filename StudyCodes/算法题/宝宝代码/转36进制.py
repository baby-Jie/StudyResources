"""
给一个整数，输出它的36进制形式的数
"""

n=int(input())
li=[]
for i in range(0,10):
    li.append(i)
for i in range(0,26):
    li.append(chr(65+i))
print(li)

li2=[]

while(n!=0):
    yushu=n%36
    n=int(n/36)
    li2.append(li[yushu])
li2.reverse()
print(li2)