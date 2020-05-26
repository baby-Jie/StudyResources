package com.smx.springunittest.model;

import lombok.Data;

@Data
public class User implements ITestInterface {

    private int user_id;

    private String user_name;

    @Override
    public void test() {
        System.out.println("this is test method in User class");
    }
}
