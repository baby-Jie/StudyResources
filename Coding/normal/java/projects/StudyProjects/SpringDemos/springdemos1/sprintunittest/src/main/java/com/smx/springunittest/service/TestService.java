package com.smx.springunittest.service;

import org.springframework.stereotype.Service;

@Service
public class TestService {

    public int test(){
        System.out.println("this is test method in TestService");
//        int a = 1 / 0;
        return 1;
    }
}
