package com.smx.springcloudlesson1.event;

import org.springframework.context.ApplicationEvent;
import org.springframework.context.ApplicationListener;
import org.springframework.context.annotation.AnnotationConfigApplicationContext;
import org.springframework.stereotype.Component;

public class SpringEventListenerDemo {

    public static void main(String[] args) {
        test2();
    }

    private static void test1() {
        // 定义上下文
        AnnotationConfigApplicationContext context = new AnnotationConfigApplicationContext();

        // 增加事件监听器
//        context.addApplicationListener(new MyApplicationEventListener());

        // 注册事件监听器
        context.register(MyApplicationEventListener.class);

        // 上下文启动
        context.refresh();

        // 发布事件
        context.publishEvent(new MyApplicationEvent("Hello,World"));
    }

    private static void test2(){

        // 定义上下文
        AnnotationConfigApplicationContext context = new AnnotationConfigApplicationContext(MyApplicationEventListener.class);

        context.publishEvent(new MyApplicationEvent("Hello,World"));
    }

    @Component
    private static class MyApplicationEventListener implements ApplicationListener<MyApplicationEvent> {

        @Override
        public void onApplicationEvent(MyApplicationEvent myApplicationEvent) {
            Object source = myApplicationEvent.getSource();

            System.out.println("source:" + source);
        }
    }

    private static class MyApplicationEvent extends ApplicationEvent {

        public MyApplicationEvent(Object source) {
            super(source);
        }
    }
}
