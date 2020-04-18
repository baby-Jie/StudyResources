package com.smx.springintergrations.configuation;

import com.smx.mycommonapi.model.Account;
import com.smx.mycommonapi.model.User;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

@Configuration
public class MyConfiguration {

    @Bean(name = "user")
    public User getUser() {
        return new User(111, "smx", 100);
    }

//    @Bean(name = "user2")
//    public User getUser2() {
//        return new User(222, "smx2", 99);
//    }
//
//    @Bean(name = "account")
//    public Account getAccount(){
//        return new Account(1, "smx", 10);
//    }
//
//    @Bean(name = "account2")
//    public Account getAccount1(){
//        return new Account(2, "smx", 20);
//    }

}
