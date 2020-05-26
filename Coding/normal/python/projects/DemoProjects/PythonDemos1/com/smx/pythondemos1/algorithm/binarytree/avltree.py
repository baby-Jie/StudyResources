class AVLTree(object):
    def __init__(self, val):
        self.val = val
        self.left = None
        self.right = None
        pass

    def left_single_rotate(self, treeNode):
        """左单旋转"""
        rightNode = treeNode.right
        treeNode.right = rightNode.left
        rightNode.left = treeNode
        return rightNode

    def right_single_rotate(self, treeNode):
        """右单旋转"""

        leftNode = treeNode.left
        treeNode.left = leftNode.right
        leftNode.right = treeNode

        return leftNode

    def left_right_rotate(self, treeNode):
        """左右旋转"""
        treeNode.left  = self.left_single_rotate(treeNode.left)
        return self.right_single_rotate(treeNode)

    def right_left_rotate(self, treeNode):
        """右左旋转"""
        treeNode.right = self.right_single_rotate(treeNode.right)
        return self.left_single_rotate(treeNode)



    def add(self, root, insertVal):

        """
        给avl树添加节点
        :param insertVal:添加的节点的值。
        :return:
        """
        if root == None:
            root = AVLTree(insertVal)

        if insertVal > root.val:
            # 大的放右边
            root.right = self.add(root.right, insertVal)
            if self.get_tree_height(root.right) - self.get_tree_height(root.left) == 2:
                if insertVal > root.right.val:
                    # 右子树的右边 左单旋转
                    root = self.left_single_rotate(root)
                else:
                    root = self.right_left_rotate(root)
        elif insertVal < self.val:
            # 小的放做左边
            root.left = self.add(root.left, insertVal)
            if self.get_tree_height(root.left) - self.get_tree_height(root.right) == 2:
                if insertVal < root.left.val:
                    # 左子树的左边 右单旋转
                    root = self.right_single_rotate(root)
                else:
                    root = self.right_left_rotate(root)
        return root

    def remove(self, delVal):

        """
        删除某个元素
        :param delVal:被删除的元素的值
        :return:
        """


        pass

    def get_tree_height(self, tree):

        if not tree:
            return 0
        leftLen = self.get_tree_height(tree.left)
        rightLen = self.get_tree_height(tree.right)
        treeLen = max(leftLen, rightLen) + 1
        return treeLen
