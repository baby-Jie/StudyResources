using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedSets.Utils;

namespace AdvancedSets.Trees
{
    /// <summary>
    /// 二叉树数据结构
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinaryTree<T> where T:IComparable<T>
    {
        public T Val { get; set; }

        public BinaryTree<T> Left { get; set; }

        public BinaryTree<T> Right { get; set; }

        public BinaryTree(T val):this(val, null, null)
        {
        }

        public BinaryTree(T val, BinaryTree<T> left, BinaryTree<T> right)
        {
            this.Val = val;
            this.Left = left;
            this.Right = right;
        }

        #region 遍历

        public List<BinaryTree<T>> PreOrder()
        {
            return TreeUtil.GetPreOrderList(this);
        }

        public List<BinaryTree<T>> InOrder()
        {
            return TreeUtil.GetInOrderList(this);
        }

        public List<BinaryTree<T>> PostOrder()
        {
            return TreeUtil.GetPostOrderList(this);
        }

        public List<BinaryTree<T>> LevelOrder()
        {
            return TreeUtil.GetLevelOrderList(this);
        }

        #endregion 遍历	

        public virtual BinaryTree<T> Add(T val)
        {
            return this;
        }

        public virtual BinaryTree<T> Remove(T val)
        {
            return this;
        }
    }

}
