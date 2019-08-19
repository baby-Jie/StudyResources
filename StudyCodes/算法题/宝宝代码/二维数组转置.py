"""
二维数组转置
"""

li=[[] for i in range(3)]
for i in range(0,3):
    line=input().split(" ")
    for j in range (0,3):
        li[i].append(int(line[j]))
# print(li)
for i in range(0,3):
    for j in range(0,i+1):
        li[i][j],li[j][i]=li[j][i],li[i][j]

for i in range(0,3):
    for j in range(0,3):
        print("%d "%(li[i][j]),end='')
    print("")
