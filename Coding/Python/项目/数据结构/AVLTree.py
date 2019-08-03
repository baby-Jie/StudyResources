
def getHeight(tree):
    if tree == None:
        return 0

    return max(getHeight(tree.left), getHeight(tree.right)) + 1

class AVLTree(object):
    def __init__(self, val, left, right):
        self.val = val
        self.left = left
        self.right = right

    def __init__(self, val):
        self.val = val
        self.left = None
        self.right = None

    def rightSingleRotate(self, root):
        temp = root.left
        root.left = temp.right
        temp.right = root

        return temp

    def leftSingleRotate(self, root):

        temp = root.right
        root.right = temp.left
        temp.left = root

        return temp

    def leftRightRotate(self, root):
        root.left = self.leftSingleRotate(root.left)
        root = self.rightSingleRotate(root)
        return root

    def rightLeftRotate(self, root):
        root.right = self.rightSingleRotate(root.right)
        root = self.leftSingleRotate(root)
        return root

    def insertNode(self, root, val):
        if root == None:
            root = AVLTree(val)

        if val < root.val:
            # 插入左子树
            root.left = self.insertNode(root.left, val)

            if getHeight(root.left) - getHeight(root.right) == 2:
                # 调整树的结构
                if val < root.left.val:
                    # 右单旋
                    root = self.rightSingleRotate(root)

                elif val > root.left.val:
                    # 左右旋转
                    root = self.leftRightRotate(root)

            pass
        elif val > root.val:
            # 插入右子树
            root.right = self.insertNode(root.right, val)

            if getHeight(root.right) - getHeight(root.left) == 2:
                if val < root.right.val:
                    # 右左旋转
                    root = self.rightLeftRotate(root)
                elif val > root.right.val:
                    # 左单旋
                    root = self.leftSingleRotate(root)

        return root

    def inorderTranverse(self, root):
        if root == None:
            return

        self.inorderTranverse(root.left)
        print(root.val)
        self.inorderTranverse(root.right)



def main():
    root = AVLTree(1)
    root = root.insertNode(root, 2)
    root = root.insertNode(root, 3)
    root = root.insertNode(root, 4)
    root = root.insertNode(root, 5)
    root = root.insertNode(root, 6)
    root = root.insertNode(root, 7)
    root = root.insertNode(root, 8)
    root = root.insertNode(root, 9)
    root = root.insertNode(root, 10)
    root = root.insertNode(root, 11)
    root = root.insertNode(root, 12)
    root = root.insertNode(root, 13)
    root = root.insertNode(root, 14)
    root = root.insertNode(root, 15)

    root.inorderTranverse(root)


if __name__ == "__main__":
    main()
