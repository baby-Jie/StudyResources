package com.smx.collection;

import com.smx.mycommonapi.model.User;
import com.sun.javafx.collections.ImmutableObservableList;
import org.junit.Before;
import org.junit.Test;

import java.text.MessageFormat;
import java.util.*;

public class ListTest {

    // region Fields
    private List<Integer> testList;
    // endregion Fields

    @Before
    public void init() {
        testList = new ArrayList<>();
        testList.add(4);
        testList.add(1);
        testList.add(5);
        testList.add(3);
    }

    // region List test

    // endregion List test

    // region List 最大值 最小值 排序
    @Test
    public void testListSort(){
        int min = Collections.min(testList);
        int max = Collections.max(testList);
        System.out.println(MessageFormat.format("min of testList:{0}, max of testList:{1}", min, max));
        Collections.sort(testList); // 升序排序
        // 自定义排序
//        Collections.sort(testList, new Comparator<Integer>() {
//            @Override
//            public int compare(Integer o1, Integer o2) {
//                return o2 - o1;
//            }
//        });
        Collections.sort(testList, Collections.reverseOrder());
        System.out.println(testList);

        // 数组排序
        Integer myArray[] = {5, 4, 8, 1};
        Arrays.sort(myArray);
        Arrays.sort(myArray, Collections.reverseOrder());
        for (Integer i: myArray){
            System.out.print(i + " ");
        }
        System.out.println();

        List<User> users = new ArrayList<>();
        users.add(new User(1, "smx", 88));
        users.add(new User(2, "smx1", 78));
        users.add(new User(3, "smx2", 98));

        Collections.sort(users, Collections.reverseOrder());
        System.out.println(users);
    }
    // endregion List 最大值 最小值 排序

    @Test
    public void testAverage(){

        List<Integer> list = new ArrayList<>();
        list.add(3);
        list.add(5);
        list.add(1);

        double average = list.stream().mapToInt(s -> s).average().orElse(0);

        System.out.println(average);
    }
}
