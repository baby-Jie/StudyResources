
class Foo:
    """Foo描述信息"""

    def __init__(self):
        print("__init__")
        pass

    def __init__(self, name):
        print("__init__")
        self.name = name
        pass

    def __call__(self, *args, **kwargs):
        print("__call__")

    def __del__(self):
        print("__del__")

    def __str__(self):
        return "hello __str__"

    def __getitem__(self, key):
        print("__getitem__:", key)

    def __setitem__(self, key, value):
        print("__setitem__: key:", key, " value ", value)

    def __delitem__(self, key):
        print("__delitem__", key)

    def __getslice__(self, i, j):
        print("__getslice__", i, j)

    def __setslice__(self, i, j, sequence):
        print("__setslice__", i, j)

    def __delslice__(self, i, j):
        print("__delslice__", i, j)


print(Foo.__doc__)  # Foo描述信息
fo = Foo("name") # 执行 __init__

print(fo.__module__) # __main__
print(fo.__class__) # <class '__main__.Foo'>
print(fo.__dict__)  # {'name': 'name'}

print(fo) # hello __str__

fo()  #  执行__call__

fo["key1"] = "value1" # __setitem__: key: key1  value  value1
val = fo["key1"] # __getitem__: key1
del fo["key1"] # __delitem__ key1

fo[-1:1]  # 自动触发执行 __getslice__
fo[0:1] = [11, 22, 33, 44] # 自动触发执行 __setslice_
del fo[0:2]  # 自动触发执行 __delslice__