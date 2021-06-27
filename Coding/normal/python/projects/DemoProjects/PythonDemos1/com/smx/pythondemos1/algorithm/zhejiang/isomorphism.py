class Tree:
    def __int__(self, val):
        self.val = val
        self.left = None
        self.right = None


def isIsomorphism(node1: Tree, node2: Tree):
    """判断两棵树是否同构"""

    if not node1 and not node2:
        # 如果两棵树都为空树，那么属于同构
        return True
    if not node1 or not node2:
        # 如果其中一棵树为空，另外一棵树不为空 那么肯定不属于同构
        return False
    if node1.val != node2.val:
        return False

    if isIsomorphism(node1.left, node2.left) and isIsomorphism(node1.right, node2.right):
        return True

    if isIsomorphism(node1.left, node2.right) and isIsomorphism(node1.right, node2.left):
        return True
    return False
