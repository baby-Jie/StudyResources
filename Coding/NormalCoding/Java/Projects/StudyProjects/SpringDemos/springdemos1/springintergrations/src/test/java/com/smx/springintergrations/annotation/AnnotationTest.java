package com.smx.springintergrations.annotation;

import com.smx.springintergrations.SpringintergrationsApplication;
import com.smx.mycommonapi.model.Account;
import com.smx.mycommonapi.model.User;
import org.junit.jupiter.api.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.test.context.junit4.SpringRunner;

import javax.annotation.Resource;

@RunWith(SpringRunner.class)
@SpringBootTest(classes = SpringintergrationsApplication.class)
public class AnnotationTest {

    // region Fields
    @Autowired
    private User user;

//    @Autowired
//    @Qualifier(value = "user2")
//    private User user22;
//
//    @Resource
//    private Account account;
//
//    @Resource(name = "account2")
//    private Account account22;
    // endregion Fields


    @Test
    public void testAutowired() {

        System.out.println(user);
//        System.out.println(user22);
//        System.out.println("yes");
    }

    @Test
    public void testResource(){

//        System.out.println("yes");
//        System.out.println(account);
//        System.out.println(account22);
    }
}
