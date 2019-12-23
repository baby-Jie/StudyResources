package com.smx.services;

import org.springframework.cloud.netflix.feign.FeignClient;
import org.springframework.web.bind.annotation.RequestMapping;

@FeignClient(value = "microservicecloud-demo", path="/user")
public interface UserClient {

    @RequestMapping("/get")
    String test();
}
