import re

# 正则表达式: match 命名分组 replace search
# re.match(pattern, inputStr, flags) -> flags: re.l(大小写不敏感) re.L(做本地化识别匹配) re.M(多行匹配，影响^ $) re.S(使.匹配包括换行符在内的所有字符) re.U(根据Unicode字符集解析字符。这个标志影响 \w, \W, \b, \B.) re.X(该标志通过给予你更灵活的格式以便你将正则表达式写得更易于理解。)

# re.match()
inputStr = "1994/10/30"

patternStr = r"(?P<year>[\d]{4})/(?P<month>[\d]{2})/(?P<day>[\d]{2})"

match = re.match(patternStr, inputStr) # 自动匹配开头和结尾

if match:
    print("匹配成功")
    yearGroup = match.group("year")
    monthGroup = match.group("month")
    dayGroup = match.group("day")
    print(yearGroup)
    print(monthGroup)
    print(dayGroup)
else:
    print("匹配失败")

# re.search()
match1 = re.search("94", "1994/10/30") # 扫描整个字符串并返回第一个成功的匹配
print(match1)

# search 和 match的区别：re.match只匹配字符串的开始，如果字符串开始不符合正则表达式，则匹配失败，函数返回None；而re.search匹配整个字符串，直到找到一个匹配。

# re.sub(pattern, repl, originalStr, count = 0, flags = 0)

# 将非数字替换成空
retStr = re.sub(r"[^\d]", "", inputStr)
print(retStr)

# 将匹配的数字进行加工
def doubleNum(matched):
    value = int(matched.group('value'))
    return str(value * 2)

inputStr = '123Hello78'
print(re.sub(r'(?P<value>[\d]+)', doubleNum, inputStr)) # output: 246Hello156

# compile: pattern = re.compile(patternStr)  pattern.match(inputStr) 和java类似 pattern = Pattern.compile(patternStr); pattern.match(inputStr)

# findall: pattern.findall(inputStr) 返回一个list



