"""自定义可迭代器2 简化代码"""

from collections.abc import Iterable

class MyList(object):
    def __init__(self, items:list):
        self.items = items
        self.current = 0
        pass


    def __iter__(self):
        """重写这个方法 就表明这个对象可被迭代， 但是不表明这是一个迭代器， 还要重写__next__方法才能表明这是个迭代器"""

        self.current = 0

        return self

    def __next__(self):

        if self.current < len(self.items):
            val = self.items[self.current]
            self.current += 1
            return val
        else:
            raise StopIteration

li = MyList([1,2,3])

print("is MyList iterable:" + str(isinstance(li, Iterable)))

for val in li:
    print(val)

for val in li:
    print(val)