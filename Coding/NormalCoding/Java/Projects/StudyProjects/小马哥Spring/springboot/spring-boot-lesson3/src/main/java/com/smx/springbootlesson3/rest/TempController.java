package com.smx.springbootlesson3.rest;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.ResponseBody;

@Controller()
@RequestMapping("/temp")
public class TempController {

    @GetMapping("/demo1")
    public String demo1(){
        return "hello";
    }
}
