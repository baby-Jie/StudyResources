/*
一只青蛙一次可以跳上1级台阶，也可以跳上2级……它也可以跳上n级。求该青蛙跳上一个n级的台阶总共有多少种跳法。

易知 f(n)=f(n-1)+f(n-2)+……f(1)
f(n-1)=f(n-2)+……f(1)
两式相减得f(n)=2f(n-1)

链接：https://www.nowcoder.com/questionTerminal/22243d016f6b47f2a6928b4313c85387?answerType=1&f=discussion
来源：牛客网

# -*- coding:utf-8 -*-
class Solution:
    def jumpFloorII(self, number):
        # write code here
        n=1 
        for i in range(2,number+1):
            n=2*n
        return n
 */

class Solution
{

    public int jumpFloorII(int number)
    {
        // write code here
        if (number == 0)
        {
            return 1;
        }
        if (number == 1)
        {
            return 1;
        }
        if (number == 2)
        {
            return 2;
        }

        int sum = 0;
        for (int i = 0; i < number; i++)
        {
            sum += jumpFloorII(i);
        }

        return sum;
    }
    public int jumpFloorII(int number)
    {
        // write code here
        TestFun(0, number);

        return num;
    }

    private int num = 0;

    public void TestFun(int currentN, int targetN)
    {
        if (currentN == targetN)
        {
            num++;
            return;
        }

        int diffN = targetN - currentN;

        for (int i = 1; i <= diffN; i++)
        {
            TestFun(currentN + i, targetN);
        }
    }
}