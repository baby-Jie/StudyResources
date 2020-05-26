package com.smx.mycommonapi.util.string;

public class MyStringUtil {

    // region Fields
    public static final String EMPTY = "";
    // endregion Fields

    // region 检测传入的单个字符串是否为empty

    public static boolean isEmpty(String str) {
        return str == null || str.length() == 0;
    }

    public static boolean isNotEmpty(String str) {
        return !isEmpty(str);
    }

    // endregion 检测传入的单个字符串是否为empty

    // region 检测传入的单个参数是否为blank

    /**
     * 如果传入的字符串为blank返回true，否则返回false
     *
     * @param str
     * @return
     */
    public static boolean isBlank(String str) {
        return str == null || str.trim().length() == 0;
    }

    /**
     * 如果传入的字符串不为blank返回true，否则返回false
     *
     * @param str
     * @return
     */
    public static boolean isNotBlank(String str) {
        return !isBlank(str);
    }

    // endregion 检测传入的单个参数是否为blank

    // region 检测传入的多个字符串是否为空

    /**
     * 如果传入的字符串全部为blank,返回true 否则返回false
     *
     * @param params
     * @return
     */
    public static boolean checkBlank(String... params) {
        if (params == null) {
            return true;
        }

        for (String item : params) {
            if (item != null && item.trim().length() > 0) {
                return false;
            }
        }
        return true;
    }

    /**
     * 如果参数全部不为blank，那么返回true，否则返回false
     *
     * @param params
     * @return
     */
    public static boolean checkNotBlank(String... params) {
        if (params == null) {
            return false;
        }

        for (String item : params) {
            if (item == null || item.trim().length() == 0) {
                return false;
            }
        }
        return true;
    }

    // endregion 检测传入的多个字符串是否为空

    // region trim methods

    /**
     * safe trim
     * @param str
     * @return
     */
    public static String clean(String str){
        return str == null ? EMPTY : str.trim();
    }

    public static String trim(String str){
        return str == null ? null : str.trim();
    }

    // endregion trim methods
}
