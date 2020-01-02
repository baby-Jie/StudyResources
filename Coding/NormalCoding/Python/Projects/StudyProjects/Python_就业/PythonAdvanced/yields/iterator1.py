"""自定义可迭代器"""

from collections.abc import Iterable

class MyList(object):
    def __init__(self, items:list):
        self.items = items
        pass


    def __iter__(self):
        """重写这个方法 就表明这个对象可被迭代， 但是不表明这是一个迭代器， 还要重写__next__方法才能表明这是个迭代器"""

        iter1 = MyIterator(self)

        return iter1

class MyIterator(object):
    def __init__(self, li):
        self.myList = li
        self.current = 0
    
    def __iter__(self):
        return self
    
    def __next__(self):
        if self.current < len(self.myList.items):
            val = self.myList.items[self.current]

            self.current += 1
            return val
        else:
            raise StopIteration

print("is [] iterable:" + str(isinstance([], Iterable)))

print("is () iterable:" + str(isinstance((), Iterable)))

print("is {} iterable:" + str(isinstance({}, Iterable)))

print("is str iterable:" + str(isinstance("str", Iterable)))

li = MyList([1,2,3])

print("is MyList iterable:" + str(isinstance(li, Iterable)))

for val in li:
    print(val)