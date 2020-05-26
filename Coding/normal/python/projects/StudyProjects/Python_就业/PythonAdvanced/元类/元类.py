class ObjectCreator(object):
    pass

print(ObjectCreator)  # 打印类对象

o1 = ObjectCreator #  赋值给一个变量

def echo(o):
    print(o)

echo(ObjectCreator) # 类对象作为函数参数进行传递

ObjectCreator.mylist = [1, 2, 3]

o2 = ObjectCreator()


o3 = ObjectCreator()

o2.mylist[2] = 4
print(o2.mylist)  # 1 2 4
print(o3.mylist)  # 1 2 4





