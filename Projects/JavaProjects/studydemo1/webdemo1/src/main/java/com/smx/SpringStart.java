package com.smx;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import tk.mybatis.spring.annotation.MapperScan;

@SpringBootApplication
@MapperScan("com.smx.model.mapper")
public class SpringStart {

    public static void main(String[] args) {

        SpringApplication.run(SpringStart.class, args);
    }
}
