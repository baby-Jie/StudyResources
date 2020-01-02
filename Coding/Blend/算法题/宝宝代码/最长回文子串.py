"""
输入字符串，输出字符串里最长的回文子串的长度
"""

def is_huiwen(str1:str):
    str2 = str1[::-1]
    return str2 == str1

def max_len(str1:str):
    length = len(str1)
    max_len = 1
    for i in range(length):
        str2 = str1[0:i+1]
        if is_huiwen(str2):
            max_len = i + 1
        else:
            pass
    return max_len

str1 = input("input:")

maxlen = 1

for i in range(len(str1)):
    str2 = str1[i::]
    length = max_len(str2)
    if maxlen < length:
        maxlen = length

print(maxlen)