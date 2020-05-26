package com.smx.mycommonapi.util.collection;

import javax.validation.constraints.NotNull;
import java.text.MessageFormat;
import java.util.*;

/**
 * 我的List
 * 如果new MyArrayList() 那么不会分配空间，默认长度为0，一旦添加了一个元素，那么初始长度为10，以后每次以1.5倍增长。
 */
public class MyArrayList<E> extends AbstractList<E>
        implements List<E>, RandomAccess, Cloneable, java.io.Serializable {

    // region Constructors

    /**
     * 无参构造函数 使用空数组初始化
     */
    public MyArrayList() {
        this.elementData = DEFAULT_CAPACITY_EMPTY_ELEMENT_DATA;
    }

    /**
     * 传参 initialCapacity 初始容器大小
     *
     * @param initialCapacity
     */
    public MyArrayList(int initialCapacity) {

        if (initialCapacity > 0) {
            this.elementData = new Object[initialCapacity];
        } else if (initialCapacity == 0) {
            this.elementData = EMPTY_ELEMENT_DATA;
        } else {
            throw new IllegalArgumentException("Illegal Capacity:" + initialCapacity);
        }
    }

    public MyArrayList(@NotNull Collection<? extends E> c) {

        this.elementData = c.toArray();

        if ((size = elementData.length) != 0) {

            // c.toArray might (incorrectly) not return Object[]
            if (elementData.getClass() != Object[].class) {
                elementData = Arrays.copyOf(elementData, size, Object[].class);
            }
        } else {
            elementData = EMPTY_ELEMENT_DATA;
        }
    }

    // endregion Constructors

    // region Fields

    // region Constants

    /**
     * 容器默认初始容量
     */
    private static final int DEFAULT_CAPACITY = 10;

    /**
     * 公用的空数组
     */
    private static final Object[] EMPTY_ELEMENT_DATA = {};

    /**
     * 默认初始空数组 长度为0
     */
    private static final Object[] DEFAULT_CAPACITY_EMPTY_ELEMENT_DATA = {};

    /**
     * 列表数据
     */
    transient Object[] elementData;

    /**
     * 数组的最大长度 为什么要减去8 ？
     */
    private static final int MAX_ARRAY_SIZE = Integer.MAX_VALUE - 8;

    // endregion Constants

    // region Others

    /**
     * MyArrayList的长度
     * The size of the MyArrayList ( the number of elements it contains )
     */
    private int size;

    // endregion Others

    // endregion Fields

    // region Methods

    // region Private Methods

    /**
     * 确定容器的容量
     *
     * @param minCapacity
     */
    private void ensureExplicitCapacity(int minCapacity) {

        modCount++;
        if (minCapacity > elementData.length) {
            grow(minCapacity);
        }
    }

    /**
     * 增长容器容量
     *
     * @param minCapacity
     */
    private void grow(int minCapacity) {

        int oldCapacity = elementData.length; // 原来数组长度 即容器容量
        int newCapacity = oldCapacity + (oldCapacity >> 1); // 扩容会不会变小？ 因为第一位是符号位？ newCapacity 可能会变成负数。
        newCapacity = Integer.max(newCapacity, minCapacity); // 取newCapacity和minCapacity中的大值
        if (newCapacity > MAX_ARRAY_SIZE) {  // 超出数组长度最大限制
            newCapacity = hugeCapacity(minCapacity);
        }
        elementData = Arrays.copyOf(elementData, newCapacity); // 扩容
    }

    private static int hugeCapacity(int minCapacity) {

        if (minCapacity < 0) {
            throw new OutOfMemoryError();
        }
        return (minCapacity > MAX_ARRAY_SIZE) ? Integer.MAX_VALUE : MAX_ARRAY_SIZE;
    }

    @SuppressWarnings("unchecked")
    E elementDat(int index) {
        return (E) elementData[index];
    }

    private void rangeCheck(int index){
        if (index >= size)
            throw new IndexOutOfBoundsException(outOfBoundsMsg(index));
    }

    private void rangeCheckForAdd(int index){
        if (index >= size || index < 0)
            throw new IndexOutOfBoundsException(outOfBoundsMsg(index));
    }

    /**
     * 索引超出提示信息
     * @param index
     * @return
     */
    private String outOfBoundsMsg(int index){
        return MessageFormat.format("Index: {0}, Size: {1}", index, size);
    }

    // endregion Private Methods

    // region Public Methods

    /**
     * 列表是否为空
     *
     * @return
     */
    public boolean isEmpty() {
        return size == 0;
    }

    /**
     * 是否包含某个元素
     *
     * @param o
     * @return
     */
    public boolean contains(Object o) {
        return indexOf(o) >= 0;
    }

    /**
     * 获取该元素在列表中的第一个索引值
     *
     * @param o
     * @return
     */
    public int indexOf(Object o) {

        // 这里为什么要对null 进行特殊判断， 因为在else分支中 要进行 o.equals操作 如果 o为null 的话 会抛出 NullReference 异常
        if (o == null) {
            for (int i = 0; i < size; i++) {
                if (elementData[i] == null) {
                    return i;
                }
            }
        } else {
            for (int i = 0; i < size; i++) {
                if (o.equals(elementData[i])) {
                    return i;
                }
            }
        }
        return -1; // 未找到
    }

    /**
     * 获取该元素在列表中的最后一个索引值
     *
     * @param o
     * @return
     */
    public int lastIndexOf(Object o) {

        if (o == null) {
            for (int i = size - 1; i >= 0; i--) {
                if (elementData[i] == null) {
                    return i;
                }
            }
        } else {
            for (int i = size - 1; i >= 0; i--) {
                if (o.equals(elementData[i])) {
                    return i;
                }
            }
        }
        return -1;
    }

    /**
     * 返回数组
     *
     * @return
     */
    public Object[] toArray() {
        return Arrays.copyOf(elementData, size);
    }

    public <T> T[] toArray(T[] a) {

        if (a.length < size) {
            return (T[]) Arrays.copyOf(elementData, size, a.getClass());
        }
        // 将elementData中的数据拷贝到a中
        System.arraycopy(elementData, 0, a, 0, size);
        if (a.length > size) {
            a[size] = null;
        }
        return a;
    }

    /**
     * 修剪容器的容量大小
     */
    public void trimToSize() {

        modCount++;
        if (size < elementData.length) {
            elementData = (size == 0) ? EMPTY_ELEMENT_DATA : Arrays.copyOf(elementData, size);
        }
    }

    /**
     * @param minCapacity
     */
    public void ensureCapacity(int minCapacity) {

    }

    // endregion Public Methods

    // region Override Methods

    @Override
    public int size() {
        return size;
    }

    @Override
    public E get(int index) {
        return null;
    }

    /**
     * 拷贝方法
     *
     * @return
     */
    @Override
    public Object clone() {
        try {
            MyArrayList<?> v = (MyArrayList<?>) super.clone();
            v.elementData = Arrays.copyOf(elementData, size);
            v.modCount = 0;
            return v;
        } catch (Exception e) {
            throw new InternalError(e);
        }
    }

    // endregion Override Methods

    // endregion Methods
    // region Classes

    private class Itr implements Iterator<E>{
        int cursor; // index of next element to return
        int lastRet = -1; // index of last element returned; -1 if no such
        int expectModCount = modCount;

        Itr(){}

        public boolean hasNext(){return cursor != size;}

        @SuppressWarnings("unchecked")
        public E next(){
            checkForComodification();
            int i = cursor;
            if (i > size){
                throw new NoSuchElementException();
            }
            Object[] elementData = MyArrayList.this.elementData;
            if (i >= elementData.length){
                throw new ConcurrentModificationException();
            }
            cursor = i + 1;
            return (E)elementData[lastRet = i];
        }

        public void remove(){
            if (lastRet < 0)
                throw new IllegalStateException();
            checkForComodification();
        }

        final void checkForComodification(){

            if (modCount != expectModCount){
                throw new ConcurrentModificationException();
            }
        }

    }

    // endregion Classes
}
