package com.smx.commondemos1.model.entity;

public enum ScoreLevel{
    D("D", 0),
    C("C", 1),
    B("B", 2),
    A("A", 3),
    APlus("A+", 4);

    private String name;
    private int index;

    ScoreLevel(String name, int index) {
        this.name = name;
        this.index = index;
    }

    public String getName() {
        return this.name;
    }

    /**
     * 根据整型索引获取评级
     *
     * @param index
     * @return
     */
    public static ScoreLevel getScoreLevelByIndex(int index) {

        int length = ScoreLevel.values().length;
        index = index < 0 ? 0 : index;
        index = index >= length ? length - 1 : index;

        return ScoreLevel.values()[index];
    }

    public boolean bigger(ScoreLevel level){
        return this.index > level.index;
    }

}
