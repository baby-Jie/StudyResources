package myjava.smx.sets;

import com.sun.istack.internal.NotNull;

import java.util.Arrays;
import java.util.Collection;

public class MyArrayList<E>
{
    private static final int DEFAULT_CAPACITY = 10;

    private static final Object[] EMPTY_ELEMENTDATA = {};

    private static final int MAX_ARRAY_SIZE = Integer.MAX_VALUE - 8;

    private transient Object[] elementData;

    private int size;

    public int size()
    {
        return size;
    }

    public boolean isEmpty()
    {
        return size == 0;
    }

    protected transient int modCount = 0;

    /*
     * 构造方法
     * */
    public MyArrayList(int initialCapacity)
    {
        if (initialCapacity < 0)
        {
            throw new IllegalArgumentException("Illegal Capacity: " + initialCapacity);
        }

        this.elementData = new Object[initialCapacity];
    }

    /*
     * 无参构造函数
     * */
    public MyArrayList()
    {
        this.elementData = EMPTY_ELEMENTDATA;
    }

    public MyArrayList(@NotNull Collection<? extends E> c)
    {
        elementData = c.toArray();
        size = elementData.length;
        if (elementData.getClass() != Object[].class)
        {
            elementData = Arrays.copyOf(elementData, size, Object[].class);
        }
    }

    public void trimToSize()
    {
        modCount++;
        if (size < elementData.length)
        {
            elementData = Arrays.copyOf(elementData, size);
        }
    }

    /*
    * Returns the index of the first occurrence of the specified element
    * */
    public int indexOf(Object o)
    {
        if (o == null)
        {
            for (int i = 0; i < size; i++)
            {
                if (elementData[i] == null)
                {
                    return i;
                }
            }
        }
        else
        {
            for (int i = 0; i < size; i++)
            {
                if (o.equals(elementData[i]))
                {
                    return i;
                }
            }
        }
        return -1;
    }

    public int lastIndexof(Object o)
    {
        if (o == null)
        {
            for (int i = size - 1; i >= 0; i--)
            {
                if (elementData[i] == null)
                {
                    return i;
                }
            }
        }
        else
        {
            for (int i = size - 1; i >= 0; i--)
            {
                if (o.equals(elementData[i]))
                {
                    return i;
                }
            }
        }
        return -1;
    }

    public void Clone()
    {

    }

    public Object[] toArray(){return Arrays.copyOf(elementData, size);}

    @SuppressWarnings("unchecked")
    public <T> T[] toArray(T[] a)
    {
        if (a.length < size)
        {
            return (T[])Arrays.copyOf(elementData, size, a.getClass());
        }
        System.arraycopy(elementData, 0, a, 0, size);
        if (a.length > size)
        {
            a[size] = null;
        }
        return a;
    }

    @SuppressWarnings("unchecked")
    E elementData(int index){return (E)elementData[index];}

    public E get(int index)
    {

        return elementData(index);
    }

    private void rangeCheck(int index)
    {
        if (index >= size)
        {
            throw new IndexOutOfBoundsException(outOfBoundsMsg(index));
        }
    }

    private String outOfBoundsMsg(int index) {
        return "Index: "+index+", Size: "+size;
    }
}
