using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using AdvancedSets.Utils;

namespace AdvancedSets.Trees
{
    public class AVLTree<T> : BSTTree<T> where T : IComparable<T>
    {
        #region Constructors

        public AVLTree(T val) : base(val)
        {
        }

        public AVLTree(T val, TreeCompareType type) : base(val, type)
        {
        }

        public AVLTree(T val, BinaryTree<T> left, BinaryTree<T> right) : base(val, left, right)
        {
        }

        public AVLTree(T val, BinaryTree<T> left, BinaryTree<T> right, TreeCompareType type) : base(val, left, right, type)
        {
        }

        #endregion Constructors	

        #region Add

        public override BinaryTree<T> Add(T val)
        { 
            return Add(this, val);
        }

        public override BinaryTree<T> Add(BinaryTree<T> node, T val)
        {
            if (node == null)
            {
                return new AVLTree<T>(val, TreeCompareType);
            }

            if (MyCompare(val, node.Val) == 0)
            {
                return node;
            }

            if (MyCompare(val, node.Val) < 0)
            {
                // 插入左子树
                node.Left = Add(node.Left, val);

                var leftDeep = TreeUtil.GetBinaryTreeDeep(node.Left);
                var rightDeep = TreeUtil.GetBinaryTreeDeep(node.Right);

                // 调整树的结构
                if (leftDeep - rightDeep > 1)
                {
                    // 左左 右旋转
                    node = RightSingleRotate(node);
                }
                else if (rightDeep - leftDeep > 1)
                {
                    // 左右  左右旋转
                    node = LeftRightRotate(node);
                }
            }
            else
            {
                // 插入右子树
                node.Right = Add(node.Right, val);

                var leftDeep = TreeUtil.GetBinaryTreeDeep(node.Left);
                var rightDeep = TreeUtil.GetBinaryTreeDeep(node.Right);

                // 调整树的结构
                if (leftDeep - rightDeep > 1)
                {
                    // 右左 右左旋转
                    node = RightLeftRotate(node);
                }
                else if (rightDeep - leftDeep > 1)
                {
                    // 右右 左旋转
                    node = LeftSingleRotate(node);
                }
            }

            return node;
        }

        #endregion Add	

        #region Remove

        public override BinaryTree<T> Remove(T val)
        {
            return Remove(this, val);
        }

        public override BinaryTree<T> Remove(BinaryTree<T> node, T val)
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

        #endregion Remove	

        #region Rotation

        /// <summary>
        /// 单左旋转
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public BinaryTree<T> LeftSingleRotate(BinaryTree<T> node)
        {
            if (node == null)
            {
                return null;
            }

            var rightNode = node.Right;

            if (rightNode == null)
            {
                return node;
            }

            node.Right = rightNode.Left;
            rightNode.Left = node;

            return rightNode;
        }

        /// <summary>
        /// 单右旋转
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public BinaryTree<T> RightSingleRotate(BinaryTree<T> node)
        {
            if (node == null)
            {
                return null;
            }

            var leftNode = node.Left;

            if (leftNode == null)
            {
                return node;
            }

            node.Left = leftNode.Right;
            leftNode.Right = node;

            return leftNode;
        }

        /// <summary>
        /// 左右旋转
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public BinaryTree<T> LeftRightRotate(BinaryTree<T> node)
        {
            if (node == null)
            {
                return null;
            }

            node.Left = LeftSingleRotate(node.Left);
            return RightSingleRotate(node);
        }

        /// <summary>
        /// 右左旋转
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public BinaryTree<T> RightLeftRotate(BinaryTree<T> node)
        {
            if (node == null)
            {
                return null;
            }

            node.Right = RightSingleRotate(node.Right);
            return LeftSingleRotate(node);
        }

        #endregion Rotation	
    }
}
