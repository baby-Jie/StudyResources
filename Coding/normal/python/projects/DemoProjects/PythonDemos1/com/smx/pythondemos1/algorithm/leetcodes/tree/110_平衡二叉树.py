# Definition for a binary tree node.
class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Solution:
    def isBalanced(self, root: TreeNode) -> bool:

        if not root:
            return True
        left_len = self.getHeight(root.left)
        right_len = self.getHeight(root.right)
        if abs(left_len - right_len) >= 2:
            return False
        if not self.isBalanced(root.left):
            return False
        if not self.isBalanced(root.right):
            return False
        return True

    def getHeight(self, root:TreeNode)->int:
        if not root:
            return 0
        left_len = self.getHeight(root.left)
        right_len = self.getHeight(root.right)
        return max(left_len, right_len) + 1