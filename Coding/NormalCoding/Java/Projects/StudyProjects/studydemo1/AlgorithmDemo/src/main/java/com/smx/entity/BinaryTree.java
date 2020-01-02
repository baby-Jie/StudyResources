package com.smx.entity;

import lombok.Data;

@Data
public class BinaryTree {

    private BinaryTree left;
    private BinaryTree right;

    private Integer value;

    public BinaryTree(Integer val){
        this.value = val;
    }
}
