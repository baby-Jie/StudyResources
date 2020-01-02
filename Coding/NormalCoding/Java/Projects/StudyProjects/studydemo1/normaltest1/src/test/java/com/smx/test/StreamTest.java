package com.smx.test;

import com.smx.model.domain.User;
import com.smx.util.LogUtil;
import com.smx.util.StreamUtil;
import org.junit.After;
import org.junit.Before;
import org.junit.Test;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import java.util.stream.Collectors;

/**
 * 用于测试list.stream的用法
 */
public class StreamTest {

    // region fields
    List<User> userList = new ArrayList<User>();
    // endregion

    // region init and destroy method
    @Before
    public void init(){
        userList.add(new User(1L, "smx", "男", "lianyungang", null));
        userList.add(new User(2L, "smx2", "男", "shanghai", null));
        userList.add(new User(3L, "xxx", "女", "changzhou", null));
    }

    @After
    public void destroy(){

    }
    // endregion init and destroy method

    // region map method in Stream
    @Test
    public void mapTest(){

        // 获取所有用户的名字 返回列表
        List<String> userNameList = userList.stream().map(User::getUserName).collect(Collectors.toList());
         userNameList = StreamUtil.getFieldList(userList, User::getUserName); // 使用StreamUtil中的方法

        for(String userName: userNameList){
            System.out.println(userName);
        }
    }
    // endregion map method in Stream

    // region filter method in Stream
    @Test
    public void filterTest(){

        List<User> users = userList.stream().filter(s -> s.getUserName().startsWith("s")).collect(Collectors.toList());

        users = StreamUtil.getFilterList(userList, s -> s.getUserName().startsWith("smx"));

        for (User user: users){
            System.out.println(user);
        }
    }
    // endregion filter method in Stream

    // region collect method in Stream
    @Test
    public void collectTest(){

        // Collectors.toList
        List<String> names = userList.stream().map(User::getUserName).collect(Collectors.toList());

        // Collectors.joining
        String str = names.stream().collect(Collectors.joining(":"));

        LogUtil.RedInfo(str);

        // Collectors.toSet
        userList.stream().map(User::getUserName).collect(Collectors.toSet()); // 如果有重复的就会抛出异常

        // Collectors.toMap  toMap(key, value)
        Map<Long, User> userMap =  userList.stream().collect(Collectors.toMap(User::getId, s -> s));

        // Collectors.groupingBy
        Map<String, List<User>> sexMap =  userList.stream().collect(Collectors.groupingBy(User::getSex, Collectors.toList()));
        for (Map.Entry<String, List<User>> entry: sexMap.entrySet()){
            String sexStr = entry.getKey();
            List<User> users = entry.getValue();
            System.out.println("key:" + sexStr);
            for (User user: users){
                System.out.print(user + " ");
            }
            System.out.println();
        }
    }
    // endregion collect method in Stream

    // region distinct method in Stream
    @Test
    public void distinctTest(){
        List<String> sexes = userList.stream().map(User::getSex).distinct().collect(Collectors.toList());
        for (String sex: sexes){
            LogUtil.RedInfo(sex);
        }
    }
    // endregion distinct method in Stream
}
