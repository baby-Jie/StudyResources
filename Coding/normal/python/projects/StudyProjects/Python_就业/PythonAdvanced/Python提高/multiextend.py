
# 使用父类名 来调用父类的初始化方法
class Parent(object):
    def __init__(self, name):
        print('parent的init开始被调用')
        self.name = name
        print('parent的init结束被调用')

class Son1(Parent):
    def __init__(self, name, age):
        print('Son1的init开始被调用')
        self.age = age
        Parent.__init__(self, name)
        print('Son1的init结束被调用')

class Son2(Parent):
    def __init__(self, name, gender):
        print('Son2的init开始被调用')
        self.gender = gender
        Parent.__init__(self, name)
        print('Son2的init结束被调用')

class GrandSon(Son1, Son2):
    def __init__(self, name, age, gender):
        print('Grandson的init开始被调用')
        Son1.__init__(self, name, age)
        Son2.__init__(self, name, gender)  # 如果在这修改了name的值， 那么最后GrandSon的name值就会被更改
        print('Grandson的init结束被调用')

gs = GrandSon("grandSon", 12, '男')

print("name:", gs.name)
print("age:", gs.age)
print("gender:", gs.gender)

"""  
运行效果：
Grandson的init开始被调用
Son1的init开始被调用
parent的init开始被调用
parent的init结束被调用
Son1的init结束被调用
Son2的init开始被调用
parent的init开始被调用
parent的init结束被调用
Son2的init结束被调用
Grandson的init结束被调用
name: name
age: 12
gender: 男

# 注意： Parent的init方法被执行了两次
"""

