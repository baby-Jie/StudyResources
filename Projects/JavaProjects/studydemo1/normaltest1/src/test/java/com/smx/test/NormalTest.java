package com.smx.test;

import org.junit.Test;

import java.util.Date;
import java.util.Random;

public class NormalTest {

    public void test(){
        char s = 'h';
        System.out.println(Character.SIZE);

    }

    // region jdk 8 版本中 使用随机数
    @Test
    public void randomTest() {

        new Random().ints().limit(10).sorted().forEach(System.out::println);
    }
    // endregion jdk 8 版本中 使用随机数

    // region Date类型转换成long 时间戳
    @Test
    public void dateTime2LongTest() {
        Date date = new Date();
        Long time = date.getTime();
        System.out.println(time);
        // 1575707500   this is mysql  SELECT UNIX_TIMESTAMP(NOW()); // 数据库中的时间戳是秒级别的
        // 1575707475610 this is date.getTime() in java // java中的时间戳是毫秒级别的
    }
    // endregion DateTime类型转换成long 时间戳

    // region 字符串格式化测试
    /**
     * 字符串格式化测试
     */
    @Test
    public void stringFormatTest() {
        String formatStr = String.format("userId:%d, userName:%s", 1, "smx");
        System.out.println(formatStr);
    }
    // endregion 字符串格式化测试

    // region long 类型转换成int类型

    /**
     * long 类型 to int 类型
     */
    @Test
    public void long2IntTest() {
        System.out.println(new Date());
        int val1 = (int) 123L;
        int val2 = new Long(123).intValue();
        int val3 = Integer.valueOf(String.valueOf(123L));
    }
    // endregion long 类型转换成int类型

    // region 测试java中的中文的长度

    /**
     * 测试java中的中文的长度
     */
    @Test
    public void JavaChineseStringLengthTest() {
        String englishStr = "abc";
        String chineseStr = "你好";
        String mixedStr = "abc你好def";
        System.out.println("englishStr:" + englishStr.length()); // 3
        System.out.println("chineseStr:" + chineseStr.length()); // 2
        System.out.println("mixedStr:" + mixedStr.length()); // 8

    }
    // endregion 测试java中的中文的长度
}
