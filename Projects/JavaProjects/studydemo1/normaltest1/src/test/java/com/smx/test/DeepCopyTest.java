package com.smx.test;

import com.alibaba.fastjson.JSONObject;
import com.esotericsoftware.kryo.Kryo;
import com.smx.model.domain.User;
import org.junit.Before;
import org.junit.Test;

import java.util.ArrayList;
import java.util.List;

public class DeepCopyTest {

    // region fields
    private User user = new User();
    private List<User> userList = new ArrayList<>();
    // endregion fields

    // region init
    @Before
    public void init(){
        user.setId(1L);
        user.setUserName("smx");
        user.setSex("male");
        user.setAddress("LianYunGang");
        List<String> cities = new ArrayList<>();
        cities.add("LianYunGang");
        cities.add("ChangZhou");
        cities.add("ShangHai");
        user.setAddressList(cities);

        userList.add(user);

        User user2 = new User();
        user2.setId(2L);
        user2.setUserName("xxx");
        user2.setAddress("YanCheng");
        List<String> cities2 = new ArrayList<>();
        cities2.add("YanCheng");
        cities2.add("ChangZhou");
        cities2.add("ShangHai");
        user2.setAddressList(cities2);

        userList.add(user2);
    }
    // endregion init

    // region json 方式 深拷贝
    @Test
    public void jsonDeepCopyTest(){

        String userJson = JSONObject.toJSONString(user);
        user.setUserName("hello");
        User user2 = JSONObject.parseObject(userJson, User.class);
        System.out.println(user2);
    }
    // endregion json 方式 深拷贝

    // region kryo 方式 深拷贝
    @Test
    public void kryoDeepCopyTest(){

        Kryo kryo = new Kryo();
        User user2 = kryo.copy(user);
        user.setUserName("hello");
        user.getAddressList().set(0, "world");
        System.out.println(user2);
    }
    // endregion kryo 方式 深拷贝
}
