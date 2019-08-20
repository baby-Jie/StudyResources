"""
逆转链表
"""

class Node(object):
    def __init__(self, val):
        self.val = val
        self.next = None

head1 = Node(-999)

node1 = Node(1)
node2 = Node(2)
node3 = Node(3)
node4 = Node(4)

head1.next = node1
node1.next = node2
node2.next = node3
node3.next = node4

# 遍历
def tranverse(head: Node):
    current = head.next
    while current:
        print(current.val)
        current = current.next

#tranverse(head1)

# 逆转方法一
def reverse(head:Node):
    current = head.next
    head.next = None
    while current:
        next = current.next
        current.next = head.next
        head.next = current
        current = next

# 逆转方法二
def reverse2(head:Node):
    head2 = Node(-999)
    current = head.next

    while current:
        next = current.next
        current.next = head2.next
        head2.next = current
        current = next
    return head2

head2 = reverse2(head1)
#reverse(head1)
tranverse(head2)


