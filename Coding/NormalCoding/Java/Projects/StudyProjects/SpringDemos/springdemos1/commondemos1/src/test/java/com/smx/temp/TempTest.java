package com.smx.temp;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.smx.commondemos1.model.entity.ScoreLevel;
import com.smx.commondemos1.model.entity.Student;
import org.junit.Test;

import java.util.*;
import java.util.function.Consumer;
import java.util.stream.Collectors;

public class TempTest {


    @Test
    public void testJson() throws JsonProcessingException {

        int a = -10;
        int b = a >> 1;
        System.out.println(b);
    }

    @Test
    public void test2(){

        Consumer<Student> s = s1 -> {
            System.out.println(s1);
        };

        s.accept(new Student());
    }

    @Test
    public void test3(){

        int a = 0x7fffffff;
        int b = a + (a >> 1);
        System.out.println(a);
        System.out.println(b);

        Student stu1 = new Student();
        stu1.setAge(18);

        Student stu2 = new Student();
        stu2.setAge(17);

        List<Student> stus = new ArrayList<>();
        stus.add(stu1);
        stus.add(stu2);

        Collections.sort(stus,Collections.reverseOrder());

        for (Student item: stus){
            System.out.println(item.getAge());
        }
    }

    @Test
    public void test4(){
        Set<Integer> set1 = new HashSet<>();
        set1.add(1);
        List<Integer> list1 = set1.stream().collect(Collectors.toList());
        System.out.println(list1);
    }

}
