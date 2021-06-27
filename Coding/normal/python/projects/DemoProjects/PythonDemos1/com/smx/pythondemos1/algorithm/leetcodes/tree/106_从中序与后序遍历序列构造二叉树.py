class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None


class Solution:
    def buildTree(self, inorder, postorder) -> TreeNode:
        if not inorder:
            return None
        rootElement = postorder[len(postorder) - 1]
        index = inorder.index(rootElement)
        leftInorder = inorder[0:index]
        rightInorder = inorder[index + 1:]
        leftPostorder = postorder[0:index]
        rightPostorder = postorder[index:-1]

        root = TreeNode(rootElement)
        left = self.buildTree(leftInorder, leftPostorder)
        right = self.buildTree(rightInorder, rightPostorder)

        root.left = left
        root.right = right

        return root


s = Solution()

