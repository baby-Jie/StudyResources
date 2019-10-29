# Definition for singly-linked list.

import heapq
class ListNode:
    def __init__(self, x):
        self.val = x
        self.next = None

class Solution:
    def mergeKLists(self, lists: List[ListNode]) -> ListNode:
        lis = []
        for listNode in lists:
            li = []
            while listNode:
                li.append(listNode.val)
                listNode = listNode.next
            lis.append(li)
        ret = heapq.merge(*lis)
        head = ListNode(-1)
        current = head
        for item in ret:
            node = ListNode(item)
            current.next = node
            current = node
        return head.next