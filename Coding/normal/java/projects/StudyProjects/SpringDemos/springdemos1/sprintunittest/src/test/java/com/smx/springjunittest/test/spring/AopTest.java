package com.smx.springjunittest.test.spring;

import com.smx.springunittest.config.MySpringConfig;
import com.smx.springunittest.service.TestService;
import com.smx.springunittest.service.UserService;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.ApplicationContext;
import org.springframework.context.support.ClassPathXmlApplicationContext;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

@RunWith(SpringJUnit4ClassRunner.class)
//@ContextConfiguration("classpath:beans.xml")
@ContextConfiguration(classes = MySpringConfig.class)
public class AopTest {

    @Test
    public void testAop(){

        ApplicationContext ac = new ClassPathXmlApplicationContext("beans.xml");

//        UserService userService = ac.getBean("userService", UserService.class);
//        System.out.println(userService.getUsers());

        TestService testService = ac.getBean("testService", TestService.class);
        testService.test();
        System.out.println("yes");
    }

    @Autowired
    private TestService testService;

    @Test
    public void testAnnotationAop(){
        testService.test();
    }

}
