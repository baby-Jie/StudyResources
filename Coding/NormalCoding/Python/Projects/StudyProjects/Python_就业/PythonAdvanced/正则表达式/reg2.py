"""
题目1：匹配出163的邮箱地址，且@符号之前有4到20位，例如hello@163.com
"""

import re

ret = re.match("[\S]{4,20}@163.com", "hello@163.com12334") # 匹配得到
ret = re.match("[\S]{4,20}@163.com", " hello@163.com12334") # 不能匹配的到 前面有一个空格 只匹配了开头
ret = re.match("[\S]{4,20}@163.com$", "hello@163.com111") # 不能匹配的到 有结尾约束
ret = re.match("[\S]{4,20}@163.com$", "hello@163.com") # 能匹配的到 有结尾约束

if ret:
    print(ret.group())
else:
    print("no match")