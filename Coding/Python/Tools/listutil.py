# python关于list的一些工具方法

# 列表转字符串
def list2str(li:list, splitStr:str):
    li = [str(x) for x in li] # 先将列表转成字符串列表
    return splitStr.join(li)


def sortByLen(x):
    return len(x)

# 根据内容长度排序列表
def listSortByLen(li:list):
    list.sort(sortByLen)