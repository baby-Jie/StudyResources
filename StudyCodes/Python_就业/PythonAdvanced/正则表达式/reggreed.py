"""正则表达式贪婪与非贪婪模式"""


import re

s = 'this is a number 234-235-22-423'

# ret = re.match(r".+(\d+-\d+-\d+-\d+)", s)

# print(ret.group())  # this is a number 234-235-22-423

# print(ret.group(1)) # 4-235-22-423

# ret = re.match(r".+?(\d+-\d+-\d+-\d+)", s)  # 终止贪婪模式

# print(ret.group(1)) #  234-235-22-423

# print(re.match(r"aa(\d+)","aa2343ddd").group(1))  # 2243

# print(re.match(r"aa(\d+?)","aa2343ddd").group(1)) # 2

# print(re.match(r"aa(\d+)ddd","aa2343ddd").group(1)) # 2243

# print(re.match(r"aa(\d+?)ddd","aa2343ddd").group(1)) # 2243

str = r'<img data-original="https://rpic.douyucdn.cn/appCovers/2016/11/13/1213973_201611131917_small.jpg" src="https://rpic.douyucdn.cn/appCovers/2016/11/13/1213973_201611131917_small.jpg" style="display: inline;">'

# ret = re.search(r'(https://.*\.jpg)', str) # https://rpic.douyucdn.cn/appCovers/2016/11/13/1213973_201611131917_small.jpg" src="https://rpic.douyucdn.cn/appCovers/2016/11/13/1213973_201611131917_small.jpg" 

ret = re.search(r'(https://.*?\.jpg)', str) # https://rpic.douyucdn.cn/appCovers/2016/11/13/1213973_201611131917_small.jpg

print(ret.group(1))
