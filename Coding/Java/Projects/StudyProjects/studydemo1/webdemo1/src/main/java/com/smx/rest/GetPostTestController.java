package com.smx.rest;

import com.smx.model.domain.User;
import org.springframework.web.bind.annotation.*;

@RestController
public class GetPostTestController {

    /**
     * + get和post的请求参数总结：
     *     + get请求：如果拼接的参数名和方法的参数名一致，那么是否使用@RequestParam是一样的，如果方法参数列表中使用了User,
     *     且又给了userName，user中的userName和字符串userName会同时赋值。
     *         ``` java
     *         @RequestMapping("/test1")
     *         public User test1(User user, String userName, @RequestParam("address") String address, String testStr){
     *             System.out.println("userName:" + userName + " address:" + address + " testStr:" + testStr);
     *             return user;
     *         }
     *         // http://localhost:9000/test1?userName=smx&address=address&testStr=this is testStr
     *
     *         // output:userName:smx address:address testStr:this is testStr
     *         // return: {"id":null,"userName":"smx","sex":null,"address":address,"addressList":null}
     *         ```
     *     + post请求如果不加body，用法和get一致，如果带上了body，那么就得使用RequestBody去接收，
     *     get方法不能使用@RequestBody注解，否则报错（在postman中，get也可以带上body数据，不会报错）
     * @param user
     * @return
     */

    @RequestMapping("/test")
    public User test(User user){

        return user;
    }

    @RequestMapping("/test1")
    public User test1(User user, String userName, @RequestParam("address") String address, String testStr){
        System.out.println("userName:" + userName + " address:" + address + " testStr:" + testStr);
        return user;
    }

    @GetMapping("/test2")
    public User test2(@RequestBody User user){
        return user;
    }

    @RequestMapping("/test3")
    public void test3(String userName, String address){

        System.out.println("userName:" + userName + "address:" + address);
    }

    @RequestMapping("/test4")
    public void test4(@RequestParam String userName, @RequestParam("address") String address){

        System.out.println("userName:" + userName + "address:" + address);
    }

    @RequestMapping("/test5")
    public User test5(@RequestBody User user, String userName, @RequestParam("address") String userAddress){
        System.out.println("userName:" + userName + "address:" + userAddress);
        return user;
    }

}
