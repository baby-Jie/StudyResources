package com.smx.springintergrations.model.entity.domain;

import javax.persistence.*;
import java.text.MessageFormat;

@Table(name = "user")
public class CustomerUser {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer userId;

    @Column
    private String userName;

    @Override
    public String toString(){
        return MessageFormat.format("id:{0}, userName:{1}", userId, userName);
    }
}
