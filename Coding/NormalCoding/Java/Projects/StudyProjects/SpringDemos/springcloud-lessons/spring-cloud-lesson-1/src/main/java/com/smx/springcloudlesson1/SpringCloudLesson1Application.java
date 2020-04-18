package com.smx.springcloudlesson1;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.ApplicationEvent;
import org.springframework.context.ApplicationListener;
import org.springframework.context.annotation.AnnotationConfigApplicationContext;

@SpringBootApplication
public class SpringCloudLesson1Application {

    public static void main(String[] args) {
//        SpringApplication.run(SpringCloudLesson1Application.class, args);

        // 等价上方启动代码  完全等价
        SpringApplication springApplication = new SpringApplication(SpringCloudLesson1Application.class);
        springApplication.run(args);
    }
}
