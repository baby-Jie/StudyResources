
import itertools as it

N = int(input().strip())
li = input().strip().split(" ")
li = [int(i) for i in li]

li2 = list(range(1, N + 1))
test0 = it.permutations(li2, len(li2))
test0 = list(test0)
count = 0
fuhe_li = list(range(len(test0)))
bufuhe_li = []
length = len(li)

for i in range(length):
    for index in fuhe_li:
        if index in bufuhe_li:
            continue
        if li[i] == 0:
            if test0[index][i] > test0[index][i + 1]:
                bufuhe_li.append(index)
        else:
            if test0[index][i] < test0[index][i + 1]:
                bufuhe_li.append(index)

for index in fuhe_li:
    if index not in bufuhe_li:
        count += 1

print(count % (10**9 + 7))