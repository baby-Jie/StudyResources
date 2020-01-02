/*
操作给定的二叉树，将其变换为源二叉树的镜像
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
class Solution
{
    public TreeNode Mirror(TreeNode root)
    {
        // write code here
        if (root == null)
            {
                return null;
            }

            var left = root.left;
            var right = root.right;
            root.left = right;
            root.right = left;
            Mirror(root.left);
            Mirror(root.right);

            return root;
    }
}