"""
链表反转2

"""

class Node:
    def __init__(self, val):
        self.val = val
        self.next = None
        return super().__init__()

def reverseNode(node:Node):
    if not node:
        return
    reverseNode(node.next)
    print(node.val)

node1 = Node(1)
node2 = Node(2)
node3 = Node(3)
node4 = Node(4)
node5 = Node(5)
node6 = Node(6)

node1.next = node2
node2.next = node3
node3.next = node4
node4.next = node5
node5.next = node6

def main():
    head = Node(-999)
    head.next = node1

    reverseNode(head.next)

    pass

if __name__ == "__main__":
    main()