package com.smx.test.string;

import com.smx.mycommonapi.util.string.MyStringUtil;
import org.junit.jupiter.api.Test;

public class MyStringUtilTest {

    @Test
    public void testCheckNotBlank(){

        boolean flag = MyStringUtil.checkNotBlank("1", "2", "    ");
        System.out.println(flag);
    }

    @Test
    public void testCheckBlank(){
        boolean flag = MyStringUtil.checkBlank("", null, "  ", "");
        System.out.println(flag);
    }
}
