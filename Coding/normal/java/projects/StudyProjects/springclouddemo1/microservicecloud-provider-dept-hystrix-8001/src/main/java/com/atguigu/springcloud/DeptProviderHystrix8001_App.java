package com.atguigu.springcloud;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.cloud.client.circuitbreaker.EnableCircuitBreaker;
import org.springframework.cloud.client.discovery.EnableDiscoveryClient;
import org.springframework.cloud.netflix.eureka.EnableEurekaClient;

@SpringBootApplication
@EnableEurekaClient //本服务启动后会自动注册进eureka服务中
@EnableDiscoveryClient //服务发现  用于发现其他服务
@EnableCircuitBreaker//对hystrixR熔断机制的支持
public class DeptProviderHystrix8001_App
{
    public static void main(String[] args)
    {
        SpringApplication.run(DeptProviderHystrix8001_App.class, args);
    }
}

