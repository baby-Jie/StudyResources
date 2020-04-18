class AVLTree(object):
    def __init__(self, val):
        self.val = val
        self.left = None
        self.right = None
        pass

    def left_single_rotate(self):
        """左单旋转"""
        pass

    def right_single_rotate(self):
        """右单旋转"""
        pass

    def left_right_rotate(self):
        """左右旋转"""
        pass

    def right_left_rotate(self):
        """右左旋转"""
        pass



    def add(self, insertVal):

        """
        给avl树添加节点
        :param insertVal:添加的节点的值。
        :return:
        """

        if insertVal > self.val:
            # 大的放右边
            if self.right:
                self.right = self.right.add(insertVal)
            else:
                self.right = AVLTree(insertVal)
        elif insertVal < self.val:
            # 小的放做左边
            if self.left:
                self.left = self.left.add(insertVal)
            else:
                self.left = AVLTree(insertVal)

        leftLen = self.get_tree_height(self.left) # 左子树的高度
        rightLen = self.get_tree_height(self.right) # 右子树的高度

        # 调整二叉树以达到平衡
        if abs(leftLen - rightLen) >= 2:
            if rightLen > leftLen:
                if insertVal > self.right.val:
                    # 在右子树的右边
                    pass
                else:
                    # 在右子树的左边
                    pass
            else:
                if insertVal > self.left.val:
                    # 在左子树的右边
                    pass
                else:
                    # 在左子树的左边
                    pass

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
