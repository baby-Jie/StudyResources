# N为学校数量
N = int(input().strip())

# 学校补课学生科目详情列表
school_li = []

school_location_dic = {}

school_relation_dic = {}

ret = 0

for _ in range(N):
    s = input().strip()
    s = '[' + s + ']'
    li = eval(s)
    school_li.append(li)

# 将初中语文、数学、英语三个年级合并 统一为初中学科（初一语文、初二语文、初三语文统称为初中语文）
for li in school_li:
    x = li[0]
    y = li[1]
    chinese = li[2] + li[5] + li[8]
    math = li[3] + li[6] + li[9]
    english = li[4] + li[7] + li[10]

    ret += (chinese // 6) * 2
    chinese = chinese % 6

    ret += (math // 6) * 2
    math = math % 6

    ret += (english // 6) * 2
    english = english % 6

    li.clear()
    li.append(chinese)
    li.append(math)
    li.append(english)
    school_location_dic[(x, y)] = li

# 计算每所学校相邻的学校
for school_key in school_location_dic.keys():
    x, y = school_key
    school = school_location_dic[school_key]
    
    pass

print(school_li)

# 输出所需最少老师人数
