package com.smx.springjunittest.test.spring;

import com.smx.springunittest.config.MySpringConfig;
import com.smx.springunittest.service.UserService;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.junit.runners.JUnit4;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.ApplicationContext;
import org.springframework.context.annotation.AnnotationConfigApplicationContext;
import org.springframework.context.support.ClassPathXmlApplicationContext;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

@RunWith(SpringJUnit4ClassRunner.class)
@ContextConfiguration(classes = MySpringConfig.class)
public class TestOne {

    @Test
    public void testXml(){

        ApplicationContext ac = new ClassPathXmlApplicationContext("beans.xml");
//        Student student = ac.getBean("student", Student.class);
//        System.out.println(student);

        UserService userService = ac.getBean("userService", UserService.class);
        System.out.println(userService.getUsers());
        System.out.println("yes");
    }

    @Test
    public void testAnnotation() {

        ApplicationContext ac = new AnnotationConfigApplicationContext(MySpringConfig.class);
        UserService userService = ac.getBean("userService", UserService.class);
        System.out.println(userService.getUsers());
        System.out.println("yes");
    }

    @Autowired
    private UserService userService;

    @Test
    public void testJunit(){
        System.out.println(userService.getUsers());
        System.out.println("yes");
    }

}
