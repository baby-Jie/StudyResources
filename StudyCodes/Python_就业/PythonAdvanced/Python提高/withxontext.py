# with和上下文管理器

# with open("1.txt") as f:
#     print("hello")

# class MyFile():

#     def __init__(self, filename, mode):
#         self.filename = filename
#         self.mode = mode

#     def __enter__(self):
#         print("__entering__")
#         self.f = open(self.filename, self.mode)
#         return self.f

#     def __exit__(self, *args):

#         print("__exit__")
#         self.f.close()

# with MyFile("1.txt", "r+") as file:
#     print("hello")

# 实现上下文管理器的另外方式

from contextlib import contextmanager

@contextmanager
def my_open(path, mode):
    f = open(path, mode)
    yield f
    f.close()

with my_open('out.txt', 'w') as f:
    f.write("hello , the simplest context manager")