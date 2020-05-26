
# 使用super() 来调用父类的初始化方法
class Parent(object):
    def __init__(self, name, *args, **kwargs):
        print('parent的init开始被调用')
        self.name = name
        print('parent的init结束被调用')

class Son1(Parent):
    def __init__(self, name, age, *args, **kwargs):
        print('Son1的init开始被调用')
        self.age = age
        super().__init__(name, *args, **kwargs)
        print('Son1的init结束被调用')

class Son2(Parent):
    def __init__(self, name, gender, *args, **kwargs):
        print('Son2的init开始被调用')
        self.gender = gender
        super().__init__(name, *args, **kwargs)
        print('Son2的init结束被调用')

class GrandSon(Son1, Son2):
    def __init__(self, name, age, gender):
        print('Grandson的init开始被调用')
        super().__init__(name, age, gender)  # 不懂gender是怎么传过去的
        print('Grandson的init结束被调用')

print(GrandSon.__mro__)
gs = GrandSon("grandSon", 12, '男')

print("name:", gs.name)
print("age:", gs.age)
print("gender:", gs.gender)

"""  
(<class '__main__.GrandSon'>, <class '__main__.Son1'>, <class '__main__.Son2'>, <class '__main__.Parent'>, <class 'object'>)
Grandson的init开始被调用
Son1的init开始被调用
Son2的init开始被调用
parent的init开始被调用
parent的init结束被调用
Son2的init结束被调用
Son1的init结束被调用
Grandson的init结束被调用
name: grandSon
age: 12
gender: 男

# 注意： Parent的init方法被执行了两次
"""

