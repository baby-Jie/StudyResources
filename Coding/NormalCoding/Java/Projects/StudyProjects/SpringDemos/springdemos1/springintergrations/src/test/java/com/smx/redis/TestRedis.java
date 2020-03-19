package com.smx.redis;

import com.smx.SpringintergrationsApplication;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.data.redis.core.StringRedisTemplate;
import org.springframework.test.context.junit4.SpringRunner;

import java.text.MessageFormat;

@RunWith(SpringRunner.class)
@SpringBootTest(classes = SpringintergrationsApplication.class)
public class TestRedis {

    @Autowired
    private StringRedisTemplate stringRedisTemplate;

    // region 使用redis四部曲
    // 1. 在pom.xml中添加redis依赖
    // 2. 在test类上添加注解，使用spring boot test
    // 3. 定义StringRedisTemplate 依赖注入
    // 4. 使用 stringRedisTemplate.boundValueOps("name").get()
    // endregion

    @Test
    public void testRedisUse(){

        // region get string value
        String name = stringRedisTemplate.boundValueOps("name").get();

        System.out.println(MessageFormat.format("name is:{0}", name));
        // endregion

        // region set string value
        stringRedisTemplate.boundValueOps("name").set("hello");
        String name1 = stringRedisTemplate.boundValueOps("name").get();

        System.out.println(MessageFormat.format("name is:{0}", name1));
        // endregion
    }
}
