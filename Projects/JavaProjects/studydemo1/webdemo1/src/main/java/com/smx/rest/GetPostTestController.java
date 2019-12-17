package com.smx.rest;

import com.smx.model.domain.User;
import org.springframework.web.bind.annotation.*;

@RestController
public class UserController {

    @RequestMapping("/test")
    public User test(User user){

        return user;
    }

    @PostMapping("/test1")
    public User test1(User user){
        return user;
    }

    @PostMapping("/test2")
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

//    public void test5()

}
