# 23分 满分25
N = int(input())
li = [int(i) for i in input().strip().split(' ')]
li.sort()
ret = 0
for ii in li:
    ret = ret / 2 + ii / 2
print( int(ret // 1)) 