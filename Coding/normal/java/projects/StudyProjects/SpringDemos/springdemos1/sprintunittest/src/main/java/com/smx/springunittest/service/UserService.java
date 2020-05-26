package com.smx.springunittest.service;

import com.smx.springunittest.dao.UserDao;
import com.smx.springunittest.model.User;
import lombok.Data;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
@Data
public class UserService {

    @Autowired
    @Qualifier("proxyUserDao")
    private UserDao userDao;

    public List<User> getUsers(){
        return userDao.findAll();
    }
}
