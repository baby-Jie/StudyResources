package com.smx.test;

import org.junit.Test;

public class LambdaTest {

    /**
     * 用于测试 jdk 8版本以后的 lambda
     */

    // region 直接使用lambda给 Runnable 赋值
    @Test
    public void runnableTest(){

        Runnable runnable = ()->{
            for (int i = 0; i < 5; i++){
                System.out.println("Runnable线程内执行, threadId:" + Thread.currentThread().getId() + " count:" + i);
                try {
                    Thread.sleep(500);
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
            }
        };
//        runnable.run();  // 主线程中执行
        Thread runnableThread = new Thread(runnable);
        runnableThread.start();  // 多线程执行

        Thread thread = new Thread(() ->{
            for (int i = 0; i < 5; i++){
                System.out.println("Thread线程内执行, threadId:" + Thread.currentThread().getId());
                try {
                    Thread.sleep(500);
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
            }
        });
        thread.start();

        for (int i = 0; i < 5; i++){
            System.out.println("主函数执行, threadId:" + Thread.currentThread().getId());
            try {
                Thread.sleep(500);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }
    }
    // endregion 直接使用lambda给 Runnable 赋值
}
