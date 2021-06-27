# Definition for a binary tree node.
class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Solution:
    def sortedArrayToBST(self, nums) -> TreeNode:
        if not nums:
            return None
        length = len(nums)
        left_len = length // 2
        root = TreeNode(nums[left_len])
        left = self.sortedArrayToBST(nums[0:left_len])
        right = self.sortedArrayToBST(nums[left_len+1:])
        root.left = left
        root.right = right
        return root
