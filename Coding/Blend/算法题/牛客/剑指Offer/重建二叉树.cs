/*
输入某二叉树的前序遍历和中序遍历的结果，请重建出该二叉树。假设输入的前序遍历和中序遍历的结果中都不含重复的数字。例如输入前序遍历序列{1,2,4,7,3,5,6,8}和中序遍历序列{4,7,2,1,5,3,8,6}，则重建二叉树并返回。 
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
using System.Collections.Generic;
class Solution
{
    public TreeNode reConstructBinaryTree(int[] pre, int[] tin)
    {
        // write code here
        return TesTreeNode(new List<int>(pre), new List<int>(tin));
    }
    
      public TreeNode TesTreeNode(List<int> pre, List<int> tin)
        {
            if (pre == null || pre.Count < 1)
            {
                return null;
            }

            if (pre.Count == 1)
            {
                return new TreeNode(pre[0]);
            }

            int root = pre[0];
            int index = tin.IndexOf(root);

            int leftLen = index;

            int rightLen = pre.Count - 1 - leftLen;
            TreeNode node = new TreeNode(root);
            List<int> preLeft = pre.GetRange(1, leftLen);
            List<int> preRight = null;
            if (rightLen > 0)
            {
                preRight = pre.GetRange(index + 1, rightLen);
            }

            List<int> tinLeft = tin.GetRange(0, leftLen);
            List<int> tinRight = null;
            if (rightLen > 0)
            {
                tinRight = tin.GetRange(index + 1, rightLen);
            }

            node.left = TesTreeNode(preLeft, tinLeft);
            node.right = TesTreeNode(preRight, tinRight);
            return node;
        }
}