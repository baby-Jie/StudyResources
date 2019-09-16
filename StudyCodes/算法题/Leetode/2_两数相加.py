# 2. 两数相加

# 方法一

# Definition for singly-linked list.
class ListNode:
    def __init__(self, x):
        self.val = x
        self.next = None

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

# 方法二：

class Solution:
    def getList(self, node:ListNode):
        li = []
        while node:
            li.append(node.val)
            node = node.next
        return li
    
    def getSum(self, li1:ListNode, li2:ListNode):
        li = []
        flag = 0
        len1 = len(li1)
        len2 = len(li2)
        for i in range(max(len1, len2)):
           
            a1 = 0
            a2 = 0
            if i < len1:
                a1 = li1[i]
            if i < len2:
                a2 = li2[i]
            ret = a1 + a2 + flag
            if ret >= 10:
                flag = 1
                ret = ret % 10
            else:
                flag = 0
            li.append(ret)
        if flag == 1:
            li.append(1)
        return li
    
    def addTwoNumbers(self, l1: ListNode, l2: ListNode) -> ListNode:
        li1 = self.getList(l1)
        li2 = self.getList(l2)
        print(li1)
        print(li2)
        retLi = self.getSum(li1, li2)
        print(retLi)
        #retLi = retLi[::-1]
        head = ListNode(-1)
        temp = head
        for i in retLi:
            temp.next = ListNode(i)
            temp = temp.next
        return head.next