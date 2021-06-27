package com.smx.temp;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.smx.commondemos1.model.entity.Student;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NonNull;
import lombok.extern.slf4j.Slf4j;
import org.junit.Test;

import java.math.BigDecimal;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.time.LocalDate;
import java.time.LocalDateTime;
import java.time.LocalTime;
import java.time.format.DateTimeFormatter;
import java.util.*;
import java.util.function.Consumer;
import java.util.stream.Collectors;

@Slf4j
public class TempTest {

    @Test
    public void testDouble(){

        double x = 0d;
        int a = 0;
        x += a;
        if (x == 0D){
            System.out.println("yes");
        } else {
            System.out.println("no");
        }

//        double d = 12.55;
//        System.out.println(d);
//        String val1 = new BigDecimal(d).setScale(1).toString();
//        System.out.println(val1); // 12.0
//
//        String val2 = new BigDecimal(d).setScale(1, BigDecimal.ROUND_HALF_UP).stripTrailingZeros().toPlainString();
//        System.out.println(val2); // 12
//
//        String val3 = String.valueOf(Math.round(d * 10) / 10.0);
//        System.out.println(val3); // 12.0
    }

    @Test
    public void test(){

        System.out.println("1".equals(null));
    }


    /**
     * LocalTime的使用
     * LocalDate的使用
     */
    @Test
    public void testLocalTime(){

        String date = LocalDate.now().format(DateTimeFormatter.ISO_LOCAL_DATE);
        System.out.println(date); // 2020-05-25
        String time = LocalTime.now().format(DateTimeFormatter.ISO_LOCAL_TIME);
        System.out.println(time); // 10:37:52.919
        String dateTime = LocalDateTime.now().format(DateTimeFormatter.ISO_LOCAL_DATE_TIME);
        System.out.println(dateTime); // 2020-05-25T10:38:51.595

        LocalDate.now().minusDays(1); // 前一天
    }


    @Data
    @AllArgsConstructor
    private class Tuple<T1, T2> {

        private T1 item1;

        private T2 item2;
    }

    @Test
    public void logTest() {
        log.info("hello");
        try {
            int a = 10 / 0;
        } catch (Exception e) {
            log.error(e.getMessage());
        } finally {
        }

    }

    @Test
    public void testNonNull() {

        List<String> students = new ArrayList<>();
        students.stream().collect(Collectors.joining(""));
        System.out.println("start---");
        test1(null);
        System.out.println("end-----");
    }

    private void test1(@NonNull String str) {
        System.out.println("yes");
    }

    @Test
    public void testInteger() {
        Integer i1 = null;
        Integer i2 = i1 + 3;
        System.out.println(i2);
    }

    @Test
    public void testDateFormat() {
        Date now = new Date();
        DateFormat dateFormat = new SimpleDateFormat("yyyy.MM.dd HH:mm");
        String nowStr = dateFormat.format(now);
        System.out.println(nowStr);


    }

    public void testObjectInitial() {
    }

    @Test
    public void testBigDecimal() {
        BigDecimal b = new BigDecimal(12.3456);
        b = b.setScale(3, BigDecimal.ROUND_HALF_UP);
        System.out.println(b.doubleValue());
        System.out.println("yes");
    }

    @Test
    public void testTuple() {

        Integer i = 1;
        String str = "smx";
        Tuple<Integer, String> tuple = new Tuple<>(i, str);

        System.out.println(tuple.item1);
        System.out.println(tuple.item2);
    }


    @Test
    public void testJson() throws JsonProcessingException {

        int a = -10;
        int b = a >> 1;
        System.out.println(b);
    }

    @Test
    public void test2() {

        Consumer<Student> s = s1 -> {
            System.out.println(s1);
        };

        s.accept(new Student());
    }

    @Test
    public void test3() {

        Map<Integer, String> map = new HashMap<>();
        boolean flag = map == null || map.keySet().isEmpty();

        int a = 0x7fffffff;
        int b = a + (a >> 1);
        System.out.println(a);
        System.out.println(b);

        Student stu1 = new Student();
        stu1.setAge(18);

        Student stu2 = new Student();
        stu2.setAge(17);

        List<Student> stus = new ArrayList<>();
        stus.add(stu1);
        stus.add(stu2);
        String strs = stus.stream().map(s -> s.getName()).collect(Collectors.joining());

        Collections.sort(stus, Collections.reverseOrder());

        for (Student item : stus) {
            System.out.println(item.getAge());
        }
    }

    @Test
    public void test4() {

        Set<Integer> set = new HashSet<>();
        List<Integer> list = set.stream().collect(Collectors.toList());
        System.out.println(list);

        int a = 1;
        byte b = 2;

//        byte b = 1;
//        System.out.println(b == 127);
//        int i = 1;
//        b = (byte)i; // Byte is not right
//        Map<Integer, String> map = new HashMap<>();
//        map.put(1, "1");


//        String str = map.get(2);
//        System.out.println(str);
    }

}
