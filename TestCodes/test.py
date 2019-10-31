N, M = map(int, input().strip().split(" "))
li = []
for _ in range(N):
    d, p = map(int, input().strip().split(" "))
    li.append((d, p))
li.sort(key = lambda x: x[0])

persons = [int(i) for i in input().strip().split(" ")]
for p in persons:
    ret = 0
    for tp in li:
        if p >= tp[0]:
            ret = tp[1]
        else:
            break
    print(ret)