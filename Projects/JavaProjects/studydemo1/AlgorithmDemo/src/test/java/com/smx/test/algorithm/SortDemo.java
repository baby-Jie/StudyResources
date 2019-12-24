package com.smx.test.algorithm;

import org.junit.Before;
import org.junit.Test;

public class SortDemo {

    private int[] nums;

    private int len;

    @Before
    public void init() {
        nums = new int[]{4, 2, 8, 7, 1, 0, 9, 3, 5, 6};
        len = nums.length;
    }

    @Test
    public void bubbleSort() {
        for (int i = 0; i < len - 1; i++) {
            for (int j = 0; j < len - 1 - i; j++) {
                if (nums[j] > nums[j+1]){
                    nums[j] = nums[j] ^ nums[j+1];
                    nums[j+1] = nums[j] ^ nums[j+1];
                    nums[j] = nums[j] ^ nums[j+1];
                }
            }
        }

        printNums();
    }

    // region 选择排序
    @Test
    public void selectSort() {

        for (int i = 0; i < len -1; i++)
        {
            for (int j = i + 1; j < len; j++)
            {
                if (nums[i] > nums[j]){
                    nums[i] = nums[i] + nums[j];
                    nums[j] = nums[i] - nums[j];
                    nums[i] = nums[i] - nums[j];
                }
            }
        }
        printNums();
    }
    // endregion 选择排序

    private void printNums(){
        for (Integer num: nums)
        {
            System.out.print(num + " ");
        }
    }
}
