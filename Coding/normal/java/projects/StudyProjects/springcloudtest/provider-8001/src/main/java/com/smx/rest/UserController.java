package com.smx.rest;

import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class UserController {

    @RequestMapping("/test")
    public String test(){
        String message = "this is test method in UserController";
        System.out.println(message);
        return message;
    }
}
