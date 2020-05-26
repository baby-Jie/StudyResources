package com.smx.date;

import org.junit.jupiter.api.Test;

import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.concurrent.TimeUnit;

public class DateTimeTest {

    @Test
    public void test1(){


        System.currentTimeMillis();

    }

    /**
     * 将日期时间格式化成字符串
     */
    @Test
    public void testFormatStr(){

        Date date = new Date();
        System.out.println(date); // Mon May 25 14:53:07 CST 2020
        DateFormat simpleDateFormat = new SimpleDateFormat("yyyy-MM-dd hh:mm:ss");
        String dateStr = simpleDateFormat.format(date); // 2020-05-25 02:55:25
        System.out.println(dateStr);
    }

    /**
     * sleep测试
     */
    @Test
    public void testSleep() throws InterruptedException {

        long startTime = System.currentTimeMillis();
        System.out.println("start---");
        TimeUnit.SECONDS.sleep(2);
        long endTime = System.currentTimeMillis();
        System.out.println("end---");
        System.out.printf("time spent:%dms\n", (endTime - startTime));
    }
}
