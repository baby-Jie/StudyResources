package com.smx.springcloud.rest;

import com.smx.services.UserClient;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.client.RestTemplate;

@RestController
public class UserController {

    @Autowired
    private RestTemplate restTemplate;

    @Autowired
    private UserClient userClient;

    private String providerHost = "http://localhost:8001";

    @RequestMapping("/test")
    public String test(){

        String message = restTemplate.getForObject(providerHost + "/test", String.class);

        message += " this is consumer 80";

        return message;
    }

    @RequestMapping("/test1")
    public String test1(){

        if (userClient == null){
            System.out.println("userclient is null");
        }else{
            System.out.println(userClient.test());
        }

        String message = "hello";
        return message;
    }
}
