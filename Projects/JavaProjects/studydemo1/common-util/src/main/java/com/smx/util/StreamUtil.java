package com.smx.util;

import java.util.List;
import java.util.Map;
import java.util.function.Function;
import java.util.function.Predicate;
import java.util.stream.Collectors;

public class StreamUtil {

    // region 根据某个对象列表 获取 该对象某个字段的列表
    /**
     * 根据某个对象列表 获取 该对象某个字段的列表
     * @param list
     * @param mapper
     * @param <T>
     * @param <R>
     * @return
     */
    public static <T, R> List<R> getFieldList(List<T> list, Function<? super T, ? extends R> mapper){
        if (list != null){
            return list.stream().map(mapper).collect(Collectors.toList());
        }
        return null;
    }
    // endregion 根据某个对象列表 获取 该对象某个字段的列表

    // region 根据条件筛选列表
    /**
     *  根据条件筛选列表
     * @param list
     * @param predicate
     * @param <T>
     * @return
     */
    public static <T> List<T> getFilterList(List<T> list, Predicate<T> predicate){
        if (list != null){
            return list.stream().filter(predicate).collect(Collectors.toList());
        }
        return null;
    }
    // endregion 根据条件筛选列表

    // region 获取以字段为key，对象为value的map
    /**
     * 获取以字段为key，对象为value的map
     * @param list
     * @param mapper
     * @param <K>
     * @param <T>
     * @return
     */
    public static <K, T> Map<K, T> getFieldKeyMap(List<T> list, Function<T, K> mapper){
        if (list != null){
            return list.stream().collect(Collectors.toMap(mapper, o -> o));
        }
        return null;
    }
    // endregion 获取以字段为key，对象为value的map
}
