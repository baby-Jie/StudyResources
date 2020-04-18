package com.smx.mycommonapi.model;

import lombok.AllArgsConstructor;
import lombok.Data;

@AllArgsConstructor
@Data
public class Account {

    private int id;

    private String name;

    private float money;
}
