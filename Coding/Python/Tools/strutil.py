# python关于sring的一些工具方法

# 字符串转列表
def str2list(string:str):
    return list(string)
    # return [i for i in string]


# 对字符串进行排序
def strSort(string:str):
    li = str2list(string)
    li.sort()
    return "".join(li)


# 判断两个字符串是否字符一致
def isStrsContianEqual(str1:str, str2:str):
    if len(str1) != len(str2):
        return False
    # 排序过后的字符串是否一致
    return strSort(str1) == strSort(str2)


