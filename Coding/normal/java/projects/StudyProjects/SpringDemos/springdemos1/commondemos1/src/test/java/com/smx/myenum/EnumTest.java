package com.smx.myenum;

import com.smx.commondemos1.model.entity.ScoreLevel;
import com.smx.commondemos1.model.entity.ScoreLevelClazz;
import org.junit.Test;

public class EnumTest {

    @Test
    public void testEnum(){

        ScoreLevel[] levels = ScoreLevel.values();

        for (ScoreLevel level: levels){
            System.out.println(level.getName());
        }

//        ScoreLevel scoreLevel = ScoreLevel.A;
//
//        int level = scoreLevel.ordinal();
//        System.out.println(scoreLevel);
//        System.out.println(level);
    }

    @Test
    public void testMyEnum(){

        ScoreLevelClazz[] levels = ScoreLevelClazz.values();

        for (ScoreLevelClazz level: levels){
            System.out.println(level.getName());
        }
    }

    @Test
    public void testEnum2(){

        ScoreLevel level1 = ScoreLevel.A;
        ScoreLevel level2 = ScoreLevel.B;

        System.out.println(level1.bigger(level2));
    }
}
