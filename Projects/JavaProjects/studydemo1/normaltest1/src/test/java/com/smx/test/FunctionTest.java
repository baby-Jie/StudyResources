package com.smx.test;

import com.smx.util.functions.Function2;
import com.sun.org.apache.xpath.internal.operations.Bool;
import org.junit.Test;

public class FunctionTest {

    // region 自定义类型 Function 的使用
    @Test
    public void functionTest1() {

        Function2<String, String, Boolean> function2 = (msg1, msg2) -> {
            System.out.println("message1:" + msg1 + " message2:" + msg2);
            return false;
        };

        boolean flag = function2.invoke("test1", "test2");
    }
    // endregion 自定义类型 Function 的使用
}
