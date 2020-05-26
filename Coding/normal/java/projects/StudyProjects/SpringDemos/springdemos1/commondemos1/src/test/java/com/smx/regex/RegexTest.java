package com.smx.regex;


import org.junit.Test;

import java.text.MessageFormat;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class RegexTest {

    // region 关于正则的一些测试

    // endregion 关于正则的一些测试

    /**
     * 只替换单斜杠
     */
    @Test
    public void replaceSlash2(){

        String inputStr = "h\\hello\\\\haha";
        String patternStr = "[^\\\\](?<name>\\\\)[^\\\\]";
        String ret = inputStr.replaceAll(patternStr, "T");
        System.out.println(ret);
    }

    // region 单斜杠替换成双斜杠
    @Test
    public void replaceSlash(){

        /**
         * 在java中，代码中写的字符串的\ 要转义 所以 两个\\ 代表一个\ 然而在正则中也要转义，所以四个\ 代表一个\
         */
        String stem = "hello$\\underline{smx}";
        String pattern = "\\$\\\\";
        String ret = stem.replaceAll(pattern, "\\$\\\\\\\\");
        System.out.println(ret);
    }
    // endregion 单斜杠替换成双斜杠

    private void testWork(){
        String taskTitle = "3月19日作业";
        String patternStr = MessageFormat.format("{0}\\([\\d]+\\)", taskTitle);
        Pattern pattern = Pattern.compile(patternStr);
        Matcher matcher = pattern.matcher("3月19日作业(1)");
        if (matcher.matches()){
            System.out.println("yes");
        }
    }

    /**
     * 使用命名组
     * 注意 命名不能重复，也不能以数字开头。\k
     */
    @Test
    public void testNamedGroup(){

        String inputStr = "hello1111";
        boolean isMatch = inputStr.matches("pattern");
        String patternStr = ".*?(?<name1>[0-9])\\k<name1>{3}"; // \k 表示反向引用命名分组中的内容。
        Pattern pattern = Pattern.compile(patternStr);
        Matcher matcher = pattern.matcher(inputStr);

        if (matcher.matches()){
            String val = matcher.group("name1"); // 1
            System.out.println(val);
        }
    }

    @Test
    public void testDateReplace(){

        // ${name} 引用匹配的命名分组内容
        String inputStr = "1994/10/30";
        String pattern = "(?<year>[\\d]{4})/(?<month>[\\d]{2})/(?<day>[\\d]{2})";
        String ret = inputStr.replaceAll(pattern, "${year}-${month}-${day}");
        System.out.println(ret);
    }
}
