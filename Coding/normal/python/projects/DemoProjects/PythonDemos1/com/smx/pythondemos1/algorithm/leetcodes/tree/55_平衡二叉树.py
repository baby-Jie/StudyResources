# Definition for a binary tree node.
class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Solution:
    def isBalanced(self, root: TreeNode) -> bool:

        def get_height(node):
            if not node:
                return 0
            return max(get_height(node.left), get_height(node.right)) + 1

        if not root:
            return True
        left_len = get_height(root.left)
        right_len = get_height(root.right)

        if abs(left_len - right_len) > 1:
            return False

        flag = self.isBalanced(root.left)
        if not flag:
            return False

        return self.isBalanced(root.right)

