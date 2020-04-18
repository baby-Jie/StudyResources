package com.smx.springintergrations;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import tk.mybatis.spring.annotation.MapperScan;

@SpringBootApplication
@MapperScan("com.smx.springintergrations.model.entity.mapper")
public class SpringintergrationsApplication {

    public static void main(String[] args) {
        SpringApplication.run(SpringintergrationsApplication.class, args);
    }

}
