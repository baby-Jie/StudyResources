package com.smx.mycommonapi.util.redis;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.redis.core.StringRedisTemplate;
import org.springframework.stereotype.Service;

//@Service
public class RedisServer {

    @Autowired
    private StringRedisTemplate stringRedisTemplate;
}
