package com.smx.service;

import com.smx.services.UserClient;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class UserClientService  implements UserClient{

    @Override
    public String test() {
        return "yes111";
    }
}
