# Definition for a binary tree node.
class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Solution:
    def minDepth(self, root: TreeNode) -> int:
        if not root:
            return 0

        def get_height(node: TreeNode):

            if not node.left and not node.right:
                return 0
            if not node.left:
                return get_height(node.right) + 1
            if not node.right:
                return get_height(node.left) + 1

            left_len = get_height(node.left)
            right_len = get_height(node.right)
            return min(left_len, right_len) + 1

        return get_height(root)