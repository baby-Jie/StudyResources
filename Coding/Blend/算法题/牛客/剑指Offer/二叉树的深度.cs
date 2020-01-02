/*
二叉树的深度
输入一棵二叉树，求该树的深度。从根结点到叶结点依次经过的结点（含根、叶结点）形成树的一条路径，最长路径的长度为树的深度
 */

 /*
public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode (int x)
    {
        val = x;
    }
}*/
using System;
class Solution
{
    public int TreeDepth(TreeNode pRoot)
    {
        // write code here
          if (pRoot == null)
            {
                return 0;
            }

            int left = TreeDepth(pRoot.left);
            int right = TreeDepth(pRoot.right);
            int deep = Math.Max(left, right) + 1;

            return deep;
    }
}