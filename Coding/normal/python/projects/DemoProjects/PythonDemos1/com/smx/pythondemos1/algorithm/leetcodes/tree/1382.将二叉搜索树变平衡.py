class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Solution:
    def balanceBST(self, root: TreeNode) -> TreeNode:

        if not root:
            return root

        # 先平衡左

        root.left = self.balanceBST(root.left)
        root.right = self.balanceBST(root.right)

        # 再平衡root
        # root =
        return root

    def getHeight(self, root: TreeNode):

        if not root:
            return 0
        left = self.getHeight(root.left)
        right = self.getHeight(root.right)
        return max(left, right) + 1