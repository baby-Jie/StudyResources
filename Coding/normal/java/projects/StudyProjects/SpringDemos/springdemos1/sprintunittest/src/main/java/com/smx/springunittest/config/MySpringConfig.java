package com.smx.springunittest.config;

import com.smx.springunittest.dao.UserDao;
import org.apache.commons.dbutils.QueryRunner;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.cglib.proxy.Enhancer;
import org.springframework.cglib.proxy.MethodInterceptor;
import org.springframework.cglib.proxy.MethodProxy;
import org.springframework.context.annotation.*;

import javax.sql.DataSource;
import java.lang.reflect.Method;
import java.text.MessageFormat;

@Configuration
@ComponentScan(value = "com.smx.springunittest")
@Import(JdbcConfig.class)
@PropertySource("classpath:jdbc.properties")
@EnableAspectJAutoProxy
public class MySpringConfig {


    @Bean(name = "proxyUserDao")
    public UserDao getProxyUserDao(@Autowired UserDao userDao){

        UserDao proxyUserDao = (UserDao) Enhancer.create(userDao.getClass(), new MethodInterceptor() {
            @Override
            public Object intercept(Object o, Method method, Object[] objects, MethodProxy methodProxy) throws Throwable {
                String methodName = method.getName();
                System.out.println(MessageFormat.format("before method:{0} invoke", methodName));
                Object ret = method.invoke(userDao, objects);
                System.out.println(MessageFormat.format("after method:{0} invoke", methodName));

                return ret;
            }
        });

        return proxyUserDao;
    }
}
