package com.smx.commondemos1.model.entity;

import com.fasterxml.jackson.annotation.*;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.io.Serializable;

@Data
@AllArgsConstructor
@NoArgsConstructor
//@JsonInclude(JsonInclude.Include.NON_NULL)
//@JsonIgnoreProperties(value = {"name","score"})
public class Student implements  Comparable<Student>{
    @JsonInclude(value = JsonInclude.Include.CUSTOM, contentFilter = StudentFilter.class)
    private String name;

    private Integer age;

    private float score;

    public boolean isSuccess(){return true;}

    public void test(){}

    public int testInt;

    @Override
    public int compareTo(Student o) {
        return this.getAge() - o.getAge();
    }
}
