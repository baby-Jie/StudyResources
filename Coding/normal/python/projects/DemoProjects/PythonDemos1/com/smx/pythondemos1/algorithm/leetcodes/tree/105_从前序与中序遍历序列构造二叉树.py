class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Solution:
    def buildTree(self, preorder, inorder) -> TreeNode:

        if not preorder:
            return None
        rootElement = preorder[0]
        index = inorder.index(rootElement)
        leftInorder = inorder[0:index]
        rightInorder = inorder[index+1:]
        leftPreorder = preorder[1:1+index]
        rightPreorder = preorder[1+index:]

        root = TreeNode(rootElement)
        left = self.buildTree(leftPreorder, leftInorder)
        right = self.buildTree(rightPreorder, rightInorder)

        root.left = left
        root.right = right

        return root

s = Solution()

s.buildTree([3,9,20,15,7], [9,3,15,20,7])