package com.smx.test.algorithm;

import org.junit.Test;

public class RecursionDemo {

    /**
     * 有20层台阶 一次只能跳一层或者两层 有多少种跳法
     */
    @Test
    public void jumpSteTest(){

        int num = jumpStepFunc2(50);
        System.out.println("\033[31;4m" + num);
    }

    private Integer jumpStepFunc1(Integer stepTotalNum){

        if (stepTotalNum <= 1)  return 1;
        if (stepTotalNum == 2)  return 2;

        return jumpStepFunc1(stepTotalNum - 1) + jumpStepFunc1(stepTotalNum - 2);
    }

    private Integer jumpStepFunc2(Integer stepTotalNum){
        if (stepTotalNum <= 1)  return 1;
        if (stepTotalNum == 2)  return 2;
        int [] resNums = new int[stepTotalNum+1];
        resNums[1] = 1;
        resNums[2] = 2;
        for (int i = 3; i <= stepTotalNum; i++){
            resNums[i] = resNums[i-1] + resNums[i-2];
        }
        return resNums[stepTotalNum];
    }
}
