# Definition for a binary tree node.
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right
class Solution:
    def flatten(self, root: TreeNode) -> None:
        """
        Do not return anything, modify root in-place instead.
        """
        if not root:
            return
        temp = root
        left = root.left
        right = root.right
        if root.left:
            self.flatten(left)
            root.right = left
            root.left = None
            while temp.right:
                temp = temp.right
        if right:
            self.flatten(right)
            temp.right = right


