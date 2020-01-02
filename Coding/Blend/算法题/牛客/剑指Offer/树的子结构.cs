/*
输入两棵二叉树A，B，判断B是不是A的子结构。（ps：我们约定空树不是任意一个树的子结构）
 /*
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
using System.Collections.Generic;
class Solution
{
       public bool IsSubTree(TreeNode node1, TreeNode node2)
        {
            if (node1 == null || node2 == null)
            {
                return true;
            }

            if (node1.val != node2.val)
            {
                return false;
            }

            bool flag = true;
            if (node2.left != null)
            {
                if (node1.left != null)
                {
                    flag &= IsSubTree(node1.left, node2.left);

                    if (flag == false)
                    {
                        return flag;
                    }
                }
                else
                {
                    flag = false;
                    return flag;
                }
            }

            if (node2.right != null)
            {
                if (node1.right != null)
                {
                    flag &= IsSubTree(node1.right, node2.right);

                    if (flag == false)
                    {
                        return flag;
                    }
                }
                else
                {
                    flag = false;
                    return flag;
                }
            }

            return flag;
        }
   
    public bool HasSubtree(TreeNode pRoot1, TreeNode pRoot2)
    {
        // write code here
          if (pRoot2 == null || pRoot1 == null)
            {
                return false;
            }

            bool flag = false;

            if (pRoot1.val == pRoot2.val)
            {
                // 获取层级遍历序列 判断是否包含
                flag = IsSubTree(pRoot1, pRoot2);

            }

            if (flag)
            {
                return true;
            }
            flag |= HasSubtree(pRoot1.left, pRoot2);
            flag |= HasSubtree(pRoot1.right, pRoot2);

            return flag;
    }
}