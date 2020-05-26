package com.smx.commondemos1.startup;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import javax.validation.constraints.NotNull;

public class StartUpOne {

    @Data
    @NoArgsConstructor
    @AllArgsConstructor
    static class Student{
        private int id;

        private int age;

        private String name;
    }

    public static void main(String[] args) {

        Boolean flag = false;

        testTwo(flag);
        System.out.println(flag);
//        Student stu1 = new Student(1, 18, "smx");
//        Student stu2 = new Student(2, 18, "xyj");
//        Student stu3 = new Student(3, 19, "xpp");
//        Student stu4 = new Student(4, 17, "heheda");
//
//        List<Student> stus = new ArrayList<>();
//        stus.add(stu1);
//        stus.add(stu2);
//        stus.add(stu3);
//        stus.add(stu4);
//
//        Map<Integer, List<String>> map = stus.stream().collect(Collectors.groupingBy(s -> s.age, Collectors.mapping(s -> s.name, Collectors.toList())));
//
//        for (int key: map.keySet()){
//            System.out.println(MessageFormat.format("age:{0}, names:{1}", key, map.get(key)));
//        }


        System.out.println();
    }

    private static void testTwo(Boolean flag){
        flag = true;
    }

    private void testOne(@NotNull Integer age){
        System.out.println(age);
    }
}
