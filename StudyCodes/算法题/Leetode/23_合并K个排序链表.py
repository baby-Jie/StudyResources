# 方法一：执行用时:132ms 内存消耗：17.8mb

# Definition for singly-linked list.
# class ListNode:
#     def __init__(self, x):
#         self.val = x
#         self.next = None
class Solution:
    def getLi(self, node:ListNode):
        li=[]
        while node:
            li.append(node.val)
            node = node.next
        return li
    def mergeKLists(self, lists: List[ListNode]) -> ListNode:
        li = []
        for node in lists:
            li += self.getLi(node)
        li.sort()
        if len(li) == 0:
            return None
        head = ListNode(-1)
        node = head
        for val in li:
            node.next = ListNode(val)
            node = node.next
        return head.next