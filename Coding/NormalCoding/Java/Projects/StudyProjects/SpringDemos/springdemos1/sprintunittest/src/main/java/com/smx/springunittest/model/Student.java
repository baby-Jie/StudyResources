package com.smx.springunittest.model;

import lombok.Data;

@Data
public class Student {

    private int id;

    private String name;

    public Student(){
        System.out.println("student...");
    }

}

