import re

result = re.match("hello","hello my name")  # match 匹配开头

t = result.group()

print(t)