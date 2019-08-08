
/*
一只青蛙一次可以跳上1级台阶，也可以跳上2级。求该青蛙跳上一个n级的台阶总共有多少种跳法（先后次序不同算不同的结果）。 */

class Solution
{

      public int jumpFloor0(int number)
        {
            // write code here

            if (number == 1)
            {
                return 1;
            }

            if (number == 2)
            {
                return 2;
            }

            return jumpFloor0(number - 1)  + jumpFloor0(number - 2);
        }
    public int jumpFloor(int number)
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

            TestFun(currentN + 1, targetN);
            if (diffN > 1)
            {
                TestFun(currentN + 2, targetN);
            }
        }
}