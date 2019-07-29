"""斐波那契数列 迭代器"""

class FibIterator(object):

    def __init__(self, n):

        self.n = n
        self.current = 0
        self.num1 = 0
        self.num2 = 1
        pass

    def __iter__(self):
        self.current = 0
        return self

    def __next__(self):

        if self.current < self.n:
            self.num1, self.num2 = self.num2, self.num1 + self.num2
            self.current += 1
            return self.num1
        else:
            raise StopIteration

fi = FibIterator(10)

for val in fi:
    print(val, end=" ")