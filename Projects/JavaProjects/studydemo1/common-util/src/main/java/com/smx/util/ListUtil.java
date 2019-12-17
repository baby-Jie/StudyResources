package com.smx.util;

import java.util.List;
import java.util.Map;
import java.util.function.Function;
import java.util.function.Predicate;

public class ListUtil {

    // region Stream methods 类似于 C# 中的 linq
    // region 获取列表的某个field的集合
    public static <T, R> List<R> getFieldList(List<T> list, Function<? super T, ? extends R> map) {
        return StreamUtil.getFieldList(list, map);
    }
    // endregion

    // region 根据条件筛选列表
    public static <T> List<T> getFilterList(List<T> list, Predicate<T> predicate) {
        return StreamUtil.getFilterList(list, predicate);
    }
    // endregion 根据条件筛选列表

    // region 获取以字段为key，对象为value的map
    public static <K, T> Map<K, T> getFieldKeyMap(List<T> list, Function<T, K> mapper) {
        return StreamUtil.getFieldKeyMap(list, mapper);
    }
    // endregion 获取以字段为key，对象为value的map
    // endregion
}
