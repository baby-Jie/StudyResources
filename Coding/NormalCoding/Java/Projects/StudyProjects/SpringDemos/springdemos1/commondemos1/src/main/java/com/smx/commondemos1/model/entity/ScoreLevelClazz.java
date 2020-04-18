package com.smx.commondemos1.model.entity;

import lombok.Data;

@Data
public class ScoreLevelClazz {

    public static ScoreLevelClazz D = new ScoreLevelClazz("D", 0);
    public static ScoreLevelClazz C = new ScoreLevelClazz("C", 1);
    public static ScoreLevelClazz B = new ScoreLevelClazz("B", 2);
    public static ScoreLevelClazz A = new ScoreLevelClazz("A", 3);
    public static ScoreLevelClazz APlus = new ScoreLevelClazz("A+", 4);

    private static ScoreLevelClazz[] values = {D, C, B, A, APlus};

    private ScoreLevelClazz(String name, int index){
        this.index = index;
        this.name = name;
    }

    private String name;

    private int index;

    public static ScoreLevelClazz[] values(){
        return values;
    }

    public static ScoreLevelClazz getScoreLevelClazzByIndex(int index){

//        int len = values.length;
//        if (index >= len){
//            index = len - 1;
//        }
//
//        if (index < 0){
//            index = 0;
//        }

        for (ScoreLevelClazz item: values){
            if (index == item.getIndex()){
                return item;
            }
        }

        return null;
    }
}
