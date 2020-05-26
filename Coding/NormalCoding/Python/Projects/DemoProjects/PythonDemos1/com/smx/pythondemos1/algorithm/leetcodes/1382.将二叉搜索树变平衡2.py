class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Solution:
    def balanceBST(self, root: TreeNode) -> TreeNode:

        li = []
        self.inOrder(li, root)
        return self.buildTree(li)

    def inOrder(self, li:list, root:TreeNode):
        if root:
            self.inOrder(li, root.left)
            li.append(root.val)
            self.inOrder(li, root.right)

    def buildTree(self, li:list):

        root = TreeNode(li[0])

        pass

    def get_height(self, root:TreeNode):
        if TreeNode:
            left_height = self.getHeight(root.left)
            right_height = self.getHeight(root.right)
            return max(left_height, right_height) + 1
        else:
            return 0

    def add_node(self, root:TreeNode, val):

        if not root:
            return TreeNode(val)

        temp = root
        if val > root.val:
            pass
        elif val < root.val:
            pass

        return temp

    def left_sin_rotate(self, root:TreeNode):
        temp = root.right
        root.right = temp.left
        temp.left = root
        return temp

    def right_sin_rotate(self, root:TreeNode):
        temp = root.left
        root.left = temp.right
        temp.right = root
        return temp

    def left_right_rotate(self, root:TreeNode):
        root.left = self.left_sin_rotate(root.left)
        return self.right_sin_rotate(root)

    def right_left_rotate(self, root:TreeNode):
        root.right = self.right_sin_rotate(root.right)
        return self.left_sin_rotate(root)
