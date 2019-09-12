using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedSets.Trees
{
    public class BSTTree<T>:BinaryTree<T> where T : IComparable<T>
    {
        public TreeCompareType TreeCompareType = TreeCompareType.Less;

        #region Constructors

        public BSTTree(T val) : base(val)
        {
        }

        public BSTTree(T val, TreeCompareType type) : base(val)
        {
            this.TreeCompareType = type;
        }

        public BSTTree(T val, BinaryTree<T> left, BinaryTree<T> right) : base(val, left, right)
        {
        }

        public BSTTree(T val, BinaryTree<T> left, BinaryTree<T> right, TreeCompareType type) : base(val, left, right)
        {
            this.TreeCompareType = type;
        }

        #endregion Constructors	

        #region Compare

        public int MyCompare(T t1, T t2)
        {
            if (TreeCompareType == TreeCompareType.Less)
            {
                return t1.CompareTo(t2);
            }
            else
            {
                return t2.CompareTo(t1);
            }
        }

        #endregion Compare	

        #region Add

        public override BinaryTree<T> Add(T val)
        {
            Add(this, val);
            return this;
        }

        public virtual BinaryTree<T> Add(BinaryTree<T> node, T val)
        {
            if (node == null)
            {
                return new BSTTree<T>(val, TreeCompareType);
            }

            if (MyCompare(val, node.Val) == 0)
            {
                // 相等
                return node;
            }
            else if (MyCompare(val, node.Val) < 0)
            {
                node.Left = Add(node.Left, val);
            }
            else
            {
                node.Right = Add(node.Right, val);
            }

            return node;
        }

        #endregion Add	

        #region Remove

        public override BinaryTree<T> Remove(T val)
        {
            return Remove(this, val);
        }

        public virtual BinaryTree<T> Remove(BinaryTree<T> node, T val)
        {
            if (node == null)
            {
                return null;
            }

            // 如果找到的是叶子节点，那么删除
            if (MyCompare(val, node.Val) == 0 && node.Left == null && node.Right == null)
            {
                return null;
            }

            if (MyCompare(val, node.Val) == 0)
            {
                // 左子树为空 返回右子树
                if (node.Left == null)
                {
                    return node.Right;
                }

                // 右子树为空，返回左子树
                if (node.Right == null)
                {
                    return node.Left;
                }

                // 左右子树都不为空的情况下 先找到右边的最小值替换 再删除右边最小值节点

                var tempNode = node.Right;


                while (tempNode.Left != null)
                {
                    tempNode = tempNode.Left;
                }

                T minVal = tempNode.Val;

                node.Val = minVal;

                // 删除右子树中最小的节点
                node.Right = DeleteLeftNode(node.Right);
            }
            else if (MyCompare(val, node.Val) < 0)
            {
                node.Left = Remove(node.Left, val);
            }
            else
            {
                node.Right = Remove(node.Right, val);
            }

            return node;
        }

        public BinaryTree<T> DeleteLeftNode(BinaryTree<T> node)
        {
            if (node == null)
            {
                return null;
            }

            if (node.Left == null)
            {
                return node.Right;
            }

            node.Left = DeleteLeftNode(node.Left);

            return node;
        }

        #endregion Remove	
    }

    public enum TreeCompareType
    {
        Less = 0,
        More,
    }
}
