package com.smx.springcloud;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.cloud.netflix.eureka.EnableEurekaClient;
import org.springframework.cloud.netflix.feign.EnableFeignClients;

@SpringBootApplication
@EnableEurekaClient
@EnableFeignClients(basePackages = "com.smx.services")
public class Consumer80Start {
    public static void main(String[] args)
    {
        SpringApplication.run(Consumer80Start.class, args);
    }
}
