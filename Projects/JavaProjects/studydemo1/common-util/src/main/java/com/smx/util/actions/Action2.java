package com.smx.util.actions;

@FunctionalInterface
public interface Action2<T1, T2> {

    void invoke(T1 t1, T2 t2);
}
