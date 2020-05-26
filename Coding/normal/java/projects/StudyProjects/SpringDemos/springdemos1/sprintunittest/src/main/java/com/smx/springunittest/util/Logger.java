package com.smx.springunittest.util;

import org.aspectj.lang.ProceedingJoinPoint;
import org.aspectj.lang.annotation.*;
import org.springframework.stereotype.Component;

/**
 * 用于记录日志的工具类，它里面提供了公共的代码
 */
@Component("logger")
@Aspect
public class Logger {

    @Pointcut("execution(* com.smx.springunittest.service.TestService.*(..))")
    private void pt1(){}
    /**
     * 用于打印日志：计划让其在切入点方法执行之前执行（切入点方法就是业务层方法）
     */
    public void printLog() {
        System.out.println("Logger类中的pringLog方法开始记录日志了。。。");
    }

    @Before("pt1()")
    /**
     * 在调用前执行
     */
    public void beforeMethodInvoke() {

        System.out.println("before method invoke");
    }

    @After("pt1()")
    /***
     * 切面编程测试 调用函数后运行
     */
    public void afterMethodInvoke() {

        System.out.println("after method invoke");
    }

    @AfterReturning("pt1()")
    /**
     * 在返回后执行
     */
    public void afterReturn() {

        System.out.println("after method return, in finally");
    }

    @AfterThrowing("pt1()")
    /**
     * 在抛出异常后执行
     */
    public void afterThrow() {

        System.out.println("after throw exception");
    }

    /**
     * 切入点
     *
     * @param pjp
     * @return
     */
    public Object aroundMethodInvoke(ProceedingJoinPoint pjp) {

        Object rtnVal = null;

        try {
            Object[] args = pjp.getArgs(); // 获取方法执行的参数
            System.out.println("before method invoke");
            rtnVal = pjp.proceed(args);
            System.out.println("after method invoke");
            return rtnVal;
        } catch (Throwable throwable) {
            System.out.println("after throw exception");
            throwable.printStackTrace();
            throw new RuntimeException(throwable);
        } finally {
            System.out.println("finally");
        }
    }
}
