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
        depth = 0
        li1 = [root]
        li2 = []

        def inner_method():
            depth = depth + 1
            while li1:
                item = li1.pop(0)
                if  item.left or item.right:
                    pass
                else:
                    return depth
            pass

        return depth


s = Solution()
# s.minDepth()

