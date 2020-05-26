package com.smx.work;


import org.junit.jupiter.api.Test;

import java.text.MessageFormat;
import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class WorkTest {

    // region 工作中的测试

    // endregion 工作中的测试

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

    // region 3月19日作业(1)数字累加
    @Test
    public void testWork(){
        String taskTitle = "3月19日作业";
        Set<String> titleSets = new HashSet<>();
        titleSets.add("3月19日作业");
        titleSets.add("13月19日作业(1)");
        titleSets.add("13月19日作业(3)");
        titleSets.add("13月19日作业(2)");
        titleSets.add("13月19日作业(1)");
        titleSets.add("3月19日作业(1)(1)");

        int maxNum = 0;
        String patternStr = MessageFormat.format("^{0}\\(([\\d]+)\\)$", taskTitle);
        Pattern pattern = Pattern.compile(patternStr);
        List<Integer> nums = new ArrayList<>();
        for (String input: titleSets){
            Matcher matcher = pattern.matcher(input);
            if (matcher.matches() && matcher.groupCount() >= 1){
                String numVal = matcher.group(1);
                int num = Integer.valueOf(numVal);
                nums.add(num);
            }
        }
        if (!nums.isEmpty()) {
            maxNum = Collections.max(nums);
        }
        maxNum++;
        System.out.println(maxNum);
    }
    // endregion 3月19日作业(1)数字累加
}
