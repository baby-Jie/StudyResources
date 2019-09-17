# 173. 二叉搜索树迭代器

# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, x):
#         self.val = x
#         self.left = None
#         self.right = None

class BSTIterator:

    def __init__(self, root: TreeNode):
        self.li = []
        self.root = root
        self.inorder(root)
        
    def inorder(self, root:TreeNode):
        if root == None:
            return 
        self.inorder(root.left)
        self.li.append(root.val)
        self.inorder(root.right)
        

    def next(self) -> int:
        """
        @return the next smallest number
        """
        ret = self.li[0]
        self.li.pop(0)
        return ret

    def hasNext(self) -> bool:
        """
        @return whether we have a next smallest number
        """
        return len(self.li) > 0
        


# Your BSTIterator object will be instantiated and called as such:
# obj = BSTIterator(root)
# param_1 = obj.next()
# param_2 = obj.hasNext()