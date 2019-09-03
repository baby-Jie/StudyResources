/*
最大堆和最小堆的数组实现

 ArrayHeap<int> heap = new ArrayHeap<int>(HeapType.Max);
            heap.Sentry = Int32.MaxValue;
            heap.Add(2);
            heap.Add(1);
            heap.Add(3);
            heap.Add(9);
            heap.Add(8);
            heap.Add(5);
            heap.Add(6);
            heap.Add(4);
            heap.Add(7);

            var count = heap.Count;

            for (int i = 0; i < count; i++)
            {
                var ret = heap.Del();
                Console.WriteLine(ret);
            }
 */

using System;
using System.Collections.Generic;

namespace MyTests
{
    public class ArrayHeap<T> where T: IComparable<T>
    {
        #region Constructors

        /// <summary>
        /// 默认为最小堆
        /// </summary>
        /// <param name="heapType"></param>
        public ArrayHeap(HeapType heapType = HeapType.Min)
        {
            _heapType = heapType;
            _heaps.Add(default(T)); // sentry
        }

        #endregion Constructors

        #region  Fields

        private List<T> _heaps = new List<T>(); // 堆列表


        private int  _startIndex = 1; // 起始位置

        #endregion Fields

        #region Properties

        #region FullProperty HeapType

        private readonly HeapType _heapType;

        public HeapType HeapType
        {
            get { return _heapType; }
        }

        #endregion	FullProperty HeapType

        #region FullProperty Sentry 哨兵

        private T _sentry;

        public T Sentry
        {
            get { return _sentry; }
            set { _sentry = value; }
        }

        #endregion	FullProperty Sentry

        public int Count => _heaps.Count - 1;  // 堆的数量

        public int TailIndex => Count; // 尾巴索引

        public bool IsEmpty => _heaps.Count == 1; // 是否是空的

        #endregion Properties

        #region Methods

        /// <summary>
        /// 比较函数
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int Compare(T a, T b)
        {
            int flag = 0;
            switch (HeapType)
            {
                case HeapType.Min:
                    flag = a.CompareTo(b);
                    break;
                case HeapType.Max:
                    flag = b.CompareTo(a);
                    break;
                default:
                    break;
            }

            return flag;
        }

        /// <summary>
        /// 添加一个元素
        /// </summary>
        /// <param name="val"></param>

        public void Add(T val)
        {
            _heaps.Add(val); // 首先加到堆列表的末尾
            // 随后调整位置

            int current = TailIndex;
            int parent = current / 2;

            while (Compare(_heaps[parent], _heaps[current]) > 0)
            {
                var temp = _heaps[parent];
                _heaps[parent] = _heaps[current];
                _heaps[current] = temp;

                current = parent;
                parent /= 2;
            }
        }

        public T Del()
        {
            if (IsEmpty)
            {
                throw new Exception("堆已空");
            }

            var root = _heaps[_startIndex];

            _heaps[_startIndex] = _heaps[TailIndex];

            _heaps.RemoveAt(TailIndex); // 删除尾元素

            // 调整结构

            int currentIndex = _startIndex;

            while (currentIndex <= TailIndex)
            {
                int leftIndex = currentIndex * 2;
                int rightIndex = currentIndex * 2 + 1;

                if (leftIndex > TailIndex)
                {
                    break;
                }

                T left = _heaps[leftIndex];

                if (rightIndex > TailIndex)
                {
                    if (Compare(left, _heaps[currentIndex]) < 0)
                    {
                        var temp = _heaps[leftIndex];
                        _heaps[leftIndex] = _heaps[currentIndex];
                        _heaps[currentIndex] = temp;

                        currentIndex = leftIndex;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    T right = _heaps[rightIndex];

                    var extraIndex = leftIndex;
                    if (Compare(left, right) > 0)
                    {
                        extraIndex = rightIndex;
                    }

                    if (Compare(_heaps[extraIndex], _heaps[currentIndex]) < 0)
                    {
                        var temp = _heaps[extraIndex];
                        _heaps[extraIndex] = _heaps[currentIndex];
                        _heaps[currentIndex] = temp;

                        currentIndex = extraIndex;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return root;
        }

        private bool CheckSons(int parentIndex)
        {
            int leftSon = parentIndex * 2;
            int rightSon = parentIndex * 2 + 1;

            if (leftSon > TailIndex)
            {
                return false;
            }

            // 右儿子超出索引
            if (rightSon > TailIndex)
            {
                return Compare(_heaps[leftSon], _heaps[parentIndex]) > 0;
            }
            else
            {
                return Compare(_heaps[leftSon], _heaps[parentIndex]) > 0 &&
                       Compare(_heaps[rightSon], _heaps[parentIndex]) > 0;
            }
        }
            

        #endregion Methods
    }

    public enum HeapType
    {
        Min = 0,
        Max
    }
}
