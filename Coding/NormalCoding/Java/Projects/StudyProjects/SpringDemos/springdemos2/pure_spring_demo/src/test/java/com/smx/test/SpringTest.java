package com.smx.test;

import com.smx.SpringConfiguration;
import com.smx.model.User;
import com.smx.model.User2;
import org.junit.Test;
import org.springframework.context.ApplicationContext;
import org.springframework.context.annotation.AnnotationConfigApplicationContext;
import org.springframework.context.support.ClassPathXmlApplicationContext;

public class SpringTest {

    @Test
    public void testXml(){

        ApplicationContext ac = new ClassPathXmlApplicationContext("beans.xml");
        User user = ac.getBean("user", User.class);
        System.out.println(user);
        System.out.println("yes");
    }

    @Test
    public void testAnnotation(){

        ApplicationContext ac = new AnnotationConfigApplicationContext(SpringConfiguration.class);
        User2 user = ac.getBean("user2", User2.class);
        System.out.println(user);
    }
}
