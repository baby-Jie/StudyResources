# 2. 两数相加

# 方法一

# Definition for singly-linked list.
# class ListNode:
#     def __init__(self, x):
#         self.val = x
#         self.next = None

class Solution:
    def addTwoNumbers(self, l1: ListNode, l2: ListNode) -> ListNode:
        str1 = ""
        str2 = ""
        temp1 = l1
        while temp1:
            str1 += str(temp1.val)
            temp1 = temp1.next
        temp2 = l2
        while temp2:
            str2 += str(temp2.val)
            temp2 = temp2.next
        ret = str(eval(str1[::-1] + " + " + str2[::-1]))
        ret = ret[::-1]
        root = ListNode(-1)
        head = root
        for ch in ret:
            head.next = ListNode(int(ch))
            head = head.next
        return root.next