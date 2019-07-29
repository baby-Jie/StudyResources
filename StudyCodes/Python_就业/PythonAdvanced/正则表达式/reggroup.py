"""正则表达式分组功能"""

import re

# 需求：匹配出163、126、qq邮箱

# ret = re.match("\w{4,20}@(qq|163|126).com$", "hello@163.com") 
# if ret:
#     print("检测结果:%s" % ret.group())
# else:
#     print("no match")

# 不是以4、7结尾的手机号码(11位)

# ret = re.match("1\d{9}[0-3568-9]$", "15251922529") 
# if ret:
#     print("检测结果:%s" % ret.group())
# else:
#     print("no match")

# 提取区号和电话号码

# ret = re.match("([^-]*)-(\d+)$", "010-8493796") 
# if ret:
#     print("检测结果:%s" % ret.group())
#     print("区号：%s" % ret.group(1))
#     print("号码：%s" % ret.group(2))
# else:
#     print("no match")

# 需求：匹配出<html>hh</html>  \num  取前面分组匹配的内容

# ret = re.match(r"<([a-zA-Z]+)>[\w]*</\1>$", "<html>hello</html>") 
# if ret:
#     print("检测结果:%s" % ret.group())
# else:
#     print("no match")

# 需求：匹配出<html><h1>hello</h1></html>

# ret = re.match(r"<([\w]+)><([\w]+)>[\w]*</\2></\1>$", "<html><h1>hello</h1></html>") 
# if ret:
#     print("检测结果:%s" % ret.group())
# else:
#     print("no match")

# (?P<name>) (?P=name)  需求：匹配出<html><h1>www.itcast.cn</h1></html>

# ret = re.match(r"<(?P<tag1>[\w]+)><(?P<tag2>[\w]+)>[\w]*</(?P=tag2)></(?P=tag1)>$", "<html><h1>hello</h1></html>") 
# # ret = re.match(r"<(?P<tag1>[\w]+)><(?P<tag2>[\w]+)>[\w]*</\2></\1>$", "<html><h1>hello</h1></html>") 
# if ret:
#     print("检测结果:%s" % ret.group())
# else:
#     print("no match")

