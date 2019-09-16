# 通过率未知
dic1 = {}
dic2 = {}
N = int(input().strip())
li = {}
def getVal(index:int):
    if str(index) in li:
        return li[index]
    # 获取子节点
    if str(index) in dic1.keys():
        nodes = dic1[str(index)]
        vals = []
        for node in nodes:
            keyStr = str(index) + "-" + str(node)
            val = dic2[keyStr]
            subVal = getVal(node)
            vals.append(val + subVal)
        maxVal = max(vals)
        li[index] = maxVal
        return maxVal
    else:
        li[index] = 0
        return 0
for ii in range(N-1):
    nums = input().strip().split(" ")
    nums = [int(i) for i in nums]
    node1 = nums[0]
    node2 = nums[1]
    val = nums[2]
    if str(node1) in dic1.keys():
        # 子节点增加
        dic1[str(node1)].append(node2)
    else:
        dic1[str(node1)] = [node2]
    dic2[str(node1) + "-" + str(node2)] = val
for ii in range(1, N+1):
    val = getVal(ii)
    print(val, end=" ")



