package com.smx.util;

import com.smx.model.constant.ColorConstants;

public class LogUtil {

    public static void whiteInfo(Object object){
        ColorInfo(ColorConstants.COLOR_WHITE, object);
    }

    public static void RedInfo(Object object){
        ColorInfo(ColorConstants.COLOR_RED, object);
    }

    public static void ColorInfo(String colorStr, Object obj){
        if (obj == null){
            return ;
        }
        System.out.println(colorStr + obj.toString() + ColorConstants.COLOR_CANCEL);
    }
}
