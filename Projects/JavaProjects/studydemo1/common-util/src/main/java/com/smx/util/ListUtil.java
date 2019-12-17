package com.smx.util;

import java.util.List;
import java.util.function.Function;
import java.util.stream.Collectors;

public class ListUtil {

    // region 获取列表的某个field的集合
    public static <T, R> List<R> getSingleFieldList(List<T> list, Function<? super T, ? extends R> map){
        return list.stream().map(map).collect(Collectors.toList());
    }
    // endregion
}
