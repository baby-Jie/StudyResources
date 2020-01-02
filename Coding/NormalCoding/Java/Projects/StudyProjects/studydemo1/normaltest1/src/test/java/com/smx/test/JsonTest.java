package com.smx.test;

import com.alibaba.fastjson.JSON;
import com.fasterxml.jackson.core.type.TypeReference;
import com.fasterxml.jackson.databind.ObjectMapper;
import com.smx.model.domain.User;
import org.junit.Before;
import org.junit.Test;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

public class JsonTest {

    /**
     * json的操作方式一般有一下几种
     * fastJson
     * jackson
     * gson
     * json-lib
     * org.json
     * 一般只要掌握fastJson 和 jackSon即可
     */

    // region fields
    private User user = new User();
    private List<User> userList = new ArrayList<>();
    // endregion fields

    // region init
    @Before
    public void init() {
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

    // region fastJSON
    @Test
    public void fastJsonTest() {

        String objectJson = JSON.toJSONString(user);
        User user2 = JSON.parseObject(objectJson, User.class);

        String listJson = JSON.toJSONString(userList);
        List<User> list = JSON.parseArray(listJson, User.class);
        System.out.println(list);
    }

    @Test
    public void fastJsonTest2() {

        // 在fastjson中, JSONObject 继承 JSON
//        String objectJson = JSONObject.toJSONString(user);
//        User user2 = JSONObject.parseObject(objectJson, User.class);
//
//        String listJson = JSONObject.toJSONString(userList);
//        List<User> list = JSONObject.parseArray(listJson, User.class);
    }
    // endregion fastJson

    // region jackson
    @Test
    public void jackSonTest() throws IOException {

        ObjectMapper objectMapper = new ObjectMapper();

        String objectJson = objectMapper.writeValueAsString(user);
        User user2 = objectMapper.readValue(objectJson, User.class);

        String listJson = objectMapper.writeValueAsString(userList);
        List<User> list = objectMapper.readValue(listJson, new TypeReference<List<User>>(){});
    }
    // endregion jackson

    // region json-lib test
    @Test
    public void jsonLibTest(){

        // region object serialization
//        net.sf.json.JSONObject jsonObject = net.sf.json.JSONObject.fromObject(user);
//        String objectJson = jsonObject.toString();
//        System.out.println(objectJson);
        // endregion object serialization

    }
    // endregion json-lib test

    // region org.json Test
    @Test
    public void orgJsonTest(){

        org.json.JSONObject jsonObject = new org.json.JSONObject(user);
        String objectStr = jsonObject.toString();

        org.json.JSONObject jsonObject1 = new org.json.JSONObject(objectStr);
        System.out.println(objectStr);
    }
    // endregion org.json Test
}
