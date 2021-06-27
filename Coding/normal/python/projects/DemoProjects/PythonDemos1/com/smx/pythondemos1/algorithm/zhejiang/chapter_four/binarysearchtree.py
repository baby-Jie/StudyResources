class BST:
    def __init__(self, val):
        self.val = val
        self.left = None
        self.right = None

    def find(self, val):
        """查找操作 尾递归方式 尾递归方式都可以使用循环实现"""

        def find_node(node: BST):

            if not node:
                return None
            if val == node.val:
                return node
            elif val > node.val:
                return find_node(node.right)
            else:
                return find_node(node.left)

        return find_node(self)

    def find_loop(self, val):
        """查找操作 使用循环操作"""

        node = self
        while node:
            if not node:
                return None
            elif node.val == val:
                return node
            elif val > node.val:
                node = node.right
            else:
                node = node.left
        return None

    def find_max(self):
        """查找最大值"""

        node = self

        while node.right:
            node = node.right
        return node

    def find_min(self):
        """查找最小值"""

        node = self

        while node.left:
            node = node.left
        return node

    def insert(self, val):
        """插入操作 递归操作"""

        def insert_node(node: BST):
            if not node:
                return BST(val)
            if val > node.val:
                node.right = insert_node(node.right)
            elif val < node.val:
                node.left = insert_node(node.left)
            return node

        insert_node(self)

    def insert_loop(self, val):
        """插入操作 循环操作"""

        insert_node = BST(val)
        node = self
        while True:
            if val == node.val:
                break
            elif val > node.val:
                if node.right:
                    node = node.right
                else:
                    node.right = insert_node
                    break
            else:
                if node.left:
                    node = node.left
                else:
                    node.left = insert_node
                    break

    def remove(self, val):
        """删除节点"""

        def remove_node(node: BST):
            if not node:
                return node
            if val == node.val:

                # 如果此节点是叶子节点，直接返回None
                if not node.left and not node.right:
                    return None
                if not node.left:
                    return node.left
                elif not node.right:
                    return node.right
                else:
                    # 找到右子树中的最小值 替代此 节点
                    right_min_node = node.right.find_min()
                    node.right = node.right.remove(right_min_node.val)
                    node.val = right_min_node.val
            elif val > node.val:
                node.right = remove_node(node.right)
            else:
                node.left = remove_node(node.left)
            return node
        return remove_node(self)



root = BST(3)

root.insert(5)

root.insert(4)

root.insert(2)

root.insert(6)

root = root.remove(5)

print(root.val)
