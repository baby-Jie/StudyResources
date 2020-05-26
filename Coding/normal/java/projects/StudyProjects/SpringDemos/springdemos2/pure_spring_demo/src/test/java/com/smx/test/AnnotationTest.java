package com.smx.test;

import com.smx.SpringConfiguration;
import com.smx.model.User2;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

@RunWith(SpringJUnit4ClassRunner.class)
@ContextConfiguration(classes = {SpringConfiguration.class})
public class AnnotationTest {

    @Autowired
    private User2 user2;

    @Test
    public void testAnnotation(){

        System.out.println(user2);
    }
}
