package com.smx.commondemos1.model.entity;

public class StudentFilter{
    @Override
    public boolean equals(Object obj){
        if (obj == null || !(obj instanceof Integer)){
            return false;
        }

        Integer age = (Integer)obj;
        if (age != 18){
            return false;
        }
        return true;
    }
}
