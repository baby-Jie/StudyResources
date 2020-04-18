package com.smx.mycommonapi.util.string;

public class MyStringUtil {

    // region 检测传入的字符串是否为空
    public boolean checkNotBlank(String ... params){
        if (params == null){
            return false;
        }

        for (String item: params){
            if (item == null || item.trim().length() == 0){
                return false;
            }
        }

        return true;
    }
    // endregion 检测传入的字符串是否为空
}
