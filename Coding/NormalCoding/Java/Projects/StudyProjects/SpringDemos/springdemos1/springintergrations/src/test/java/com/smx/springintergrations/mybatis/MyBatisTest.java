package com.smx.springintergrations.mybatis;

import com.smx.mycommonapi.model.User;
import com.smx.springintergrations.SpringintergrationsApplication;
import com.smx.springintergrations.model.entity.mapper.UserMapper;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.test.context.junit4.SpringRunner;

import java.util.List;

@RunWith(SpringRunner.class)
@SpringBootTest(classes = SpringintergrationsApplication.class)
public class MyBatisTest {

    @Autowired
    private UserMapper userMapper;

    @Test
    public void testMybatis(){

        List<User> userList = userMapper.findAll();
        System.out.println(userList);
        System.out.println(userMapper == null);
        System.out.println(":yes");
    }
}
