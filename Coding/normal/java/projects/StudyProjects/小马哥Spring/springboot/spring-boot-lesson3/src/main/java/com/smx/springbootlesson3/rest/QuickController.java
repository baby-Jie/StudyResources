package com.smx.springbootlesson3.rest;

import com.smx.springbootlesson3.model.User;
import lombok.Value;
import org.springframework.http.MediaType;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;
import sun.awt.SunHints;

import javax.servlet.http.HttpServletRequest;
import java.text.MessageFormat;
import java.util.Map;

@Controller
@ResponseBody
public class QuickController {

    @GetMapping("/quick")
    public Map quick(HttpServletRequest request, @RequestHeader(value = "Accept")String acceptHeader){
        Map<String, String[]> parameterMap = request.getParameterMap();
        System.out.println(acceptHeader);

        return parameterMap;
    }

    @GetMapping("/quick2")
    public String quick2(@CookieValue(required = false) String cookieName){
        return cookieName;
    }

    @GetMapping("/quick3")
    public String quick3(Integer age){

        return MessageFormat.format("age is:{0}", age);
    }

    /**
     * consumers 限定消费方(调用接口者)的accept类型
     * produces 限定返回接口的content-type类型
     * @return
     */
    @GetMapping(path = "/jsonUser", consumes = {MediaType.APPLICATION_JSON_VALUE, "text/html"}, produces = MediaType.APPLICATION_JSON_VALUE)
    public User getJsonUser(){

        User user = new User();
        user.setName("smx");
        user.setAge(18);

        return user;

    }
}
