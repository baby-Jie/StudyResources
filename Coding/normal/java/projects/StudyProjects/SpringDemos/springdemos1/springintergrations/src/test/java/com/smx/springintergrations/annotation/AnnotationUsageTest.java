package com.smx.springintergrations.annotation;

import org.junit.Test;

import java.lang.reflect.Method;
import java.util.Date;

public class AnnotationUsageTest {

    @Test
    @SuppressWarnings(value = "deprecated")
    public void testSuppressWarning(){

        Date date = new Date(2020, 1, 1);
        System.out.println(date);
    }

    @Hello("hello my annotation")
    public static void main(String[] args) throws  NoSuchMethodException{
        Class cls = AnnotationUsageTest.class;
        Method method = cls.getMethod("main", String[].class);
        Hello hello = method.getAnnotation(Hello.class);
        String val = hello.value();
        System.out.println(val);
        Method m = cls.getMethod("value");
    }
}
