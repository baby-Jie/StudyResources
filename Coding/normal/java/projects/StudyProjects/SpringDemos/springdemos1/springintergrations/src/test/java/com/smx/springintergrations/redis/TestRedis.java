package com.smx.springintergrations.redis;

import com.smx.springintergrations.SpringintergrationsApplication;
import com.smx.springintergrations.model.entity.domain.Account;
import com.smx.springintergrations.util.redis.RedisServer;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.data.redis.core.StringRedisTemplate;
import org.springframework.data.redis.core.ValueOperations;
import org.springframework.test.context.junit4.SpringRunner;

import javax.annotation.Resource;
import java.text.MessageFormat;
import java.util.concurrent.TimeUnit;

@RunWith(SpringRunner.class)
@SpringBootTest(classes = SpringintergrationsApplication.class)
public class TestRedis {

    @Resource
    private StringRedisTemplate stringRedisTemplate;

    @Autowired
    private RedisServer redisServer;

    // region 使用redis四部曲
    // 1. 在pom.xml中添加redis依赖
    // 2. 在test类上添加注解，使用spring boot test
    // 3. 定义StringRedisTemplate 依赖注入
    // 4. 使用 stringRedisTemplate.boundValueOps("name").get()
    // endregion

    @Test
    public void testRedisUse() {

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

    @Test
    public void testRedisServer() {

//        String name = redisServer.getStr("name");
//        System.out.println(name);
//        redisServer.setStr("name", "30s", 30);

//        Account account = new Account();
//        account.setAccountId(1);
//        account.setAccountName("smx");
//        account.setAccountMoney(10);
//
//        redisServer.setObj("account", account);
        Object obj = redisServer.getObj("account");
        if (obj instanceof Account) {
            Account account = (Account)obj;
            String name = account.getAccountName();
            System.out.println(name);
        }
        System.out.println(obj);
    }
}
