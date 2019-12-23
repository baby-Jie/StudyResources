package com.smx.rest;

import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/user")
public class User2Controller {

    @RequestMapping("/get")
    public String user2Test(){

        System.out.println("this is user2Test in User2Controller");
        return "this is user2Test in User2Controller";
    }
}
