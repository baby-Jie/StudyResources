
# 第 0001 题： 做为 Apple Store App 独立开发者，你要搞限时促销，为你的应用生成激活码（或者优惠券），使用 Python 如何生成 200 个激活码（或者优惠券）？
# 主要知识点： str.join  random.sample(str, len)

import random

def genCode(length):
    s = "abcdefghijklmnopqrstuvwxyz01234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ!@#$%^&*()?"
    return "".join(random.sample(s,length))

if __name__ == "__main__":
    l = input("Enter the length of the random code:")
    print(genCode(int(l)))