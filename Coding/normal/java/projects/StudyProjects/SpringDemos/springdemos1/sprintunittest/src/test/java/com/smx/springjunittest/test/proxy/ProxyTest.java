package com.smx.springjunittest.test.proxy;

import com.smx.springunittest.model.ITestInterface;
import com.smx.springunittest.model.User;
import org.junit.Test;
import org.omg.CORBA.SystemException;
import org.omg.CORBA.portable.InputStream;
import org.omg.CORBA.portable.InvokeHandler;
import org.omg.CORBA.portable.OutputStream;
import org.omg.CORBA.portable.ResponseHandler;
import org.springframework.cglib.proxy.Enhancer;
import org.springframework.cglib.proxy.MethodInterceptor;
import org.springframework.cglib.proxy.MethodProxy;

import java.lang.reflect.InvocationHandler;
import java.lang.reflect.Method;
import java.lang.reflect.Proxy;
import java.text.MessageFormat;

public class ProxyTest {

    // region 测试jdk中的proxy 动态代理 要求被代理的对象必须实现了接口，代理对象只能使用接口中的方法。
    @Test
    public void testProxy() {

        User user = new User();
        user.setUser_id(123);
        user.setUser_name("smx");

        ITestInterface proxyUser = (ITestInterface) Proxy.newProxyInstance(User.class.getClassLoader(),
                                                                           User.class.getInterfaces(),
                                                                           new InvocationHandler() {
            @Override
            public Object invoke(Object proxy, Method method, Object[] args) throws Throwable {

                String methodName = method.getName();

                System.out.println(MessageFormat.format("before method:{0} invoke", methodName));
                Object ret = method.invoke(user, args);
                System.out.println(MessageFormat.format("after method:{0} invoke", methodName));
                return ret;
            }
        });

        proxyUser.test();

        System.out.println(proxyUser);

        System.out.println("yes");
    }
    // endregion 测试jdk中的proxy 动态代理

    // region 使用cglib代理对象 非接口式

    @Test
    public void testEnhancer(){

        User user = new User();
        user.setUser_name("smx");
        user.setUser_id(1);

        User proxyUser = (User) Enhancer.create(user.getClass(), new MethodInterceptor() {
            @Override
            public Object intercept(Object o, Method method, Object[] objects, MethodProxy methodProxy) throws Throwable {
                String methodName = method.getName();
                System.out.println(MessageFormat.format("before method:{0} invoke", methodName));
                Object ret = method.invoke(user, objects);
                System.out.println(MessageFormat.format("after method:{0} invoke", methodName));

                return ret;
            }
        });

        proxyUser.test();
        System.out.println(proxyUser.getUser_name());
    }

    // endregion 使用cglib代理对象 非接口式
}
