import heapq

class MaxHeapObjectWrapper(object):
    def __init__(self, hold):
        self.hold = hold
        pass
    def __gt__(self, other):
        return other.hold > self.hold 

    def __eq__(self, value):
        return self.hold == value.hold
    
    def __str__(self):
        return str(self.hold)

li = [1, 5, 3, 9, 4]

li2 = [MaxHeapObjectWrapper(i) for i in li]

heapq.heapify(li)
heapq.heapify(li2)

print(li, end=" ")
print()
for item in li2:
    print(item, end=" ")
