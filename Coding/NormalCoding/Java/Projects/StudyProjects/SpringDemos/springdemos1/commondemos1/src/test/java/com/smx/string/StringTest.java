package com.smx.string;

import org.junit.Test;
import org.junit.platform.commons.util.StringUtils;

import java.text.MessageFormat;

public class StringTest {

    // region 关于字符串的测试

    // endregion 关于字符串的测试

    // region 测试字符串 空白 和 空 isBlank 比 isEmpty要更严谨
    @Test
    public void testBlankAndEmpty(){

        String nullStr = null;
        System.out.println(MessageFormat.format("nullStr is blank:{0}", StringUtils.isBlank(nullStr))); //  return str == null || str.trim().isEmpty();
        System.out.println(MessageFormat.format("nullStr is empty:{0}", org.springframework.util.StringUtils.isEmpty(nullStr))); // return str == null || "".equals(str);

        String blankStr = " ";
        System.out.println(MessageFormat.format("blankStr is blank:{0}", StringUtils.isBlank(blankStr))); // true
        System.out.println(MessageFormat.format("blankStr is empty:{0}", org.springframework.util.StringUtils.isEmpty(blankStr))); // false
    }
    // endregion 测试字符串 空白 和 空
}
