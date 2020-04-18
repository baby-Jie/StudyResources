package com.smx.springintergrations.util.redis;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.redis.core.RedisTemplate;
import org.springframework.data.redis.core.StringRedisTemplate;
import org.springframework.data.redis.core.ValueOperations;
import org.springframework.stereotype.Service;

import javax.annotation.Resource;
import java.util.Date;
import java.util.concurrent.TimeUnit;

@Service
public class RedisServer {

    // region Fields
    @Autowired
    private StringRedisTemplate stringRedisTemplate;

    @Autowired
    private RedisTemplate<Object, Object> redisTemplate;

    @Resource(name = "stringRedisTemplate")
    private ValueOperations<String, String> valOpsStr;

    @Resource(name = "redisTemplate")
    private ValueOperations<Object, Object> valOpsObj;

//    @Value("${redis.pre}")
    String redis_key_pre = "test:";
    // endregion Fields

    private String setFullRedisKey(String key){
        if (!key.startsWith(redis_key_pre)) {
            key = redis_key_pre + key;
        }
        return key;
    }

    // region 根据字符串key获取value
    public String getStr(String key){
        key = setFullRedisKey(key);
        return valOpsStr.get(key);
    }
    // endregion 根据字符串key获取value
    
    // region 根据字符串key value expireTime 设置值
    public void setStr(String key, String value){

        key = setFullRedisKey(key);
        valOpsStr.set(key, value);
    }
    public void setStr(String key, String value, long expireTime){
        key = setFullRedisKey(key);
        valOpsStr.set(key, value, expireTime, TimeUnit.SECONDS);
    }
    // endregion 根据字符串key value expireTime 设置值

    // region 删除指定的key

    public void del(String key){
        key = setFullRedisKey(key);
        stringRedisTemplate.delete(key);
    }

    // endregion 删除指定的key

    // region 根据指定o获取Object

    public Object getObj(Object o){
        String key = setFullRedisKey(o.toString());
        return valOpsObj.get(key);
    }

    // endregion 根据指定o获取Object

    // region 设置obj缓存

    public void setObj(Object o1, Object o2){

        setObj(o1, o2, 0);
    }

    public void setObj(Object o1, Object o2, long expireSec){
        String key = setFullRedisKey(o1.toString());
        if (expireSec > 0) {
            valOpsObj.set(key, o2, expireSec, TimeUnit.SECONDS);
        } else {
            valOpsObj.set(key, o2);
        }
    }

    public void updateObj(Object o1, Object o2){

        String key = setFullRedisKey(o1.toString());
        long expireSec = getExpireSec(key);
        if (expireSec > 0) {
            valOpsObj.set(key, o2, expireSec, TimeUnit.SECONDS);
        } else {
            valOpsObj.set(key, o2);
        }
    }

    public void delObj(Object o) {
        String key = setFullRedisKey(o.toString());
        redisTemplate.delete(key);
    }

    // endregion 设置obj缓存

    // region 获取key的有效期 - 秒

    public long getExpireSec(String key) {
        key = setFullRedisKey(key);
        return redisTemplate.getExpire(key, TimeUnit.SECONDS);
    }

    // endregion 获取key的有效期 - 秒

    // region 指定key在指定的日期过期

    public void expireKeyAt(String key, Date date) {
        key = setFullRedisKey(key);
        redisTemplate.expireAt(key, date);
    }

    // endregion 指定key在指定的日期过期

    // region 设置key失效时间 （s秒）

    public void expireKey(String key, long expireSec) {
        key = setFullRedisKey(key);
        redisTemplate.expire(key, expireSec, TimeUnit.SECONDS);
    }

    // endregion 设置key失效时间 （s秒）

    // region 将key设置为永久有效
    public void persistKey(String key) {
        key = setFullRedisKey(key);
        redisTemplate.persist(key);
    }
    // endregion 将key设置为永久有效
}
