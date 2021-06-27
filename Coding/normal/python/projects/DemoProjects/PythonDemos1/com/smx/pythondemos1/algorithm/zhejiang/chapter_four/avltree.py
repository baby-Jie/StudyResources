class AVL:
    def __init__(self, val):
        self.val = val
        self.left = None
        self.right = None

    def insert(self, node, val):
        """插入一个节点"""

        if not node:
            return AVL(val)

        if node.val == val:
            return node
        elif val > node.val:
            node.right = self.insert(node.right, val)

            if self.get_height(node.right) - self.get_height(node.left) > 1:
                if val > node.right.val:
                    # RR旋转 左单旋
                    node = self.left_single_rotate(node)
                elif val < node.right.val:
                    # RL旋转
                    node = self.right_left_rotate(node)
        else:
            node.left = self.insert(node.left, val)

            if self.get_height(node.left) - self.get_height(node.right) > 1:
                if val > node.left.val:
                    # LR旋转
                    node = self.left_right_rotate(node)
                elif val < node.left.val:
                    # LL旋转 右单旋
                    node = self.right_single_rotate(node)
        return node

    def right_single_rotate(self, node):
        """右旋转"""

        # if not node:
        #     return node

        left = node.left
        node.left = left.right
        left.right = node
        return left

    def left_single_rotate(self, node):
        """左旋转"""

        # if not node:
        #     return node

        right = node.right
        node.right = right.left
        right.left = node
        return right

    def left_right_rotate(self, node):
        """LR旋转"""
        node.left = self.left_single_rotate(node.left)
        return self.right_single_rotate(node)

    def right_left_rotate(self, node):
        """RL旋转"""
        node.right = self.right_single_rotate(node.right)
        return self.left_single_rotate(node)


    def get_height(self, node):
        """获取树的高度"""

        if not node:
            return 0
        left_len = self.get_height(node.left)
        right_len = self.get_height(node.right)
        return max(left_len, right_len) + 1

    def pre_order(self, node):
        if node:
            print(node.val)
            self.pre_order(node.left)
            self.pre_order(node.right)
    def mid_order(self, node):
        if node:
            self.mid_order(node.left)
            print(node.val)
            self.mid_order(node.right)

root = AVL(1)
root = root.insert(root, 15)
root = root.insert(root, 14)
root = root.insert(root, 17)
root = root.insert(root, 7)
root = root.insert(root, 2)
root = root.insert(root, 12)
root = root.insert(root, 3)
root = root.insert(root, 9)
root = root.insert(root, 11)

root.pre_order(root)
print("*" * 30)
root.mid_order(root)






