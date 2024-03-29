package com.smx.test;

import com.smx.util.actions.Action2;
import org.junit.Test;

public class ActionTest {

    // region 自定义 类型 Action 的使用
    @Test
    public void actionTest1(){

        Action2<String, String> action2 = (str1, str2) ->{
            System.out.println(String.format("message1:%s, message2:%s", str1, str2));
        };

        action2.invoke("message1", "message2");
    }
    // endregion 自定义 类型 Action 的使用
}
