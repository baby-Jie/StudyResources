# 方法一： 用时：52ms 内存消耗：13.7mb
# Definition for singly-linked list.
# class ListNode:
#     def __init__(self, x):
#         self.val = x
#         self.next = None

class Solution:
    def myRemove(self, node: ListNode)->ListNode:
        if node == None:
            return None
        nextNode = self.myRemove(node.next)
        self.count += 1
        if self.count == self.k:
            return node.next
        node.next = nextNode
        return node
    def removeNthFromEnd(self, head: ListNode, n: int) -> ListNode:
        self.count = 0
        self.k = n
        head = self.myRemove(head)
        return head
        