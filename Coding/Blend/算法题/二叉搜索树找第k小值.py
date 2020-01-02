"""
二叉搜索树找第K小值的节点
分析：中序遍历顺序就是从小到大的顺序

"""

class Node:
    def __init__(self, val):
        self.val = val
        self.left = None
        self.right = None
        return super().__init__()

node1 = Node(1)
node2 = Node(2)
node3 = Node(3)
node4 = Node(4)
node5 = Node(5)
node6 = Node(6)
node7 = Node(7)
node8 = Node(8)
node9 = Node(9)
node10 = Node(10)
node11 = Node(11)
node12 = Node(12)

node2.left = node1
node2.right = node3

node4.left = node2
node4.right = node6

node6.left = node5

node7.left = node4
node7.right = node10

node10.left = node8
node10.right = node11

node8.right = node9

node11.right = node12

nodeRoot = node7

def beforeTraverse(rootNode:Node):
    if not rootNode:
        return

    print(rootNode.val)
    beforeTraverse(rootNode.left)
    beforeTraverse(rootNode.right)
    pass

def middleTraverse(rootNode:Node):
    if not rootNode:
        return

    middleTraverse(rootNode.left)
    print(rootNode.val)
    middleTraverse(rootNode.right)
    pass

def afterTraverse(rootNode:Node):
    if not rootNode:
        return

    afterTraverse(rootNode.left)
    afterTraverse(rootNode.right)
    print(rootNode.val)
    pass

k_count = 0
k_val = 1

def findKMinNode(rootNode:Node):
    if not rootNode:
        return
    findKMinNode(rootNode.left)
    global k_count
    k_count += 1
    if k_count == k_val:
        print(rootNode.val)
    findKMinNode(rootNode.right)

    pass

def main():
    # beforeTraverse(nodeRoot)
    # middleTraverse(nodeRoot)
    # afterTraverse(nodeRoot)
    findKMinNode(nodeRoot)

    pass

if __name__ == "__main__":
    main()