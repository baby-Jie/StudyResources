# Definition for a binary tree node.
class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Solution:
    def hasPathSum(self, root: TreeNode, t: int) -> bool:
        if not root:
            return False
        retLi = []
        def innerMethod(node:TreeNode, li:list):

            li.append(node.val)
            if not node.left and not node.right:
                if sum(li) == t:
                    retLi.append([item for item in li])
            if node.left:
                innerMethod(node.left, li)
            if node.right:
                innerMethod(node.right, li)
            li.pop()
        innerMethod(root, [])
        return len(retLi) > 0