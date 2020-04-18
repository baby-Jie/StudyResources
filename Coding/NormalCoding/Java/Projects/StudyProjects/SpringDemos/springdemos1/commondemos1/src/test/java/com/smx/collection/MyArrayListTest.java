package com.smx.collection;

import com.smx.mycommonapi.util.collection.MyArrayList;
import org.junit.Test;

public class MyArrayListTest {

    @Test
    public void test1(){

        MyArrayList<Integer> list = new MyArrayList<>();

        list.add(1);

        System.out.println(list.size());
    }
}
