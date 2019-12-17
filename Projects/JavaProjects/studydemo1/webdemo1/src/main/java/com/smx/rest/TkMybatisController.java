package com.smx.rest;

import com.smx.model.domain.User;
import com.smx.model.mapper.UserMapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
@RequestMapping("/user")
public class UserController {

    @Autowired
    private UserMapper userMapper;
//
//    @RequestMapping("/list")
//    public List<User> list(){
//
//        return userMapper.findAll();
//    }
}
