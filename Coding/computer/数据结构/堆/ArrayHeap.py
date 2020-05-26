
class ArrayHeap(object):
    """基于列表（数组）实现的最大堆和最小堆数据结构"""
    def __init__(self, heapType = 0):

        """initial"""
        self.headType = heapType
        self.__sentry = -1
        self.__heap = [-1]
        self.__startIndex = 1

    def add(self, val):
        self.__heap.append(val)

        current = self.tailIndex
        parent = current // 2

        while not self.compareTo(self.__heap[parent], self.__heap[current]):
            temp = self.__heap[parent]
            self.__heap[parent] = self.__heap[current]
            self.__heap[current] = temp

            current = parent
            parent = parent // 2

    def delete(self):
        if self.isEmpty:
            raise Exception("Empty Exception")

        root = self.__heap[self.__startIndex]

        self.__heap[self.__startIndex] = self.__heap[self.tailIndex]
        self.__heap.pop()

        currentIndex = self.__startIndex

        while currentIndex <= self.tailIndex:
            leftIndex = currentIndex * 2
            rightIndex = currentIndex * 2 + 1

            if leftIndex > self.tailIndex:
                break
            left = self.__heap[leftIndex]

            if rightIndex > self.tailIndex:
                if self.compareTo(left, self.__heap[currentIndex]):
                    self.__heap[currentIndex], self.__heap[leftIndex] = self.__heap[leftIndex], self.__heap[currentIndex]
                    currentIndex = leftIndex
                else:
                    break
            else:
                right = self.__heap[rightIndex]

                extraIndex = leftIndex
                if not self.compareTo(left, right):
                    extraIndex = rightIndex

                if self.compareTo(self.__heap[extraIndex], self.__heap[currentIndex]):
                    self.__heap[currentIndex], self.__heap[extraIndex] = self.__heap[extraIndex], self.__heap[
                        currentIndex]
                    currentIndex = extraIndex
                else:
                    break

        return root

    def compareTo(self, a, b):
        if self.headType == 0:
            return a < b
        else:
            return b < a

    @property
    def tailIndex(self):
        return len(self.__heap) - 1

    @property
    def count(self):
        return len(self.__heap) - 1

    @property
    def isEmpty(self):
        return len(self.__heap) <= 1

    @property
    def sentry(self):
        return self.__sentry

    @sentry.setter
    def sentry(self, val):
        self.__sentry = val
        self.__heap[0] = val

    def __str__(self):
        return str(self.__heap[1:])


def main():
    myheap = ArrayHeap(1)
    myheap.sentry = 99
    myheap.add(3)
    myheap.add(1)
    myheap.add(8)
    myheap.add(2)
    myheap.add(6)
    myheap.add(5)
    myheap.add(7)
    myheap.add(9)
    myheap.add(0)
    myheap.add(4)
    print(myheap)

    size = myheap.count

    for i in range(size):
        ret = myheap.delete()
        print(ret)

if __name__ == "__main__":
    main()


