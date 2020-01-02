/*
斐波那契数列的两种解法
 */

 public int Fibonaqi(int num)
        {
            if (num <= 2)
            {
                return 1;
            }

            int pre_pre = 1, pre = 1, current = 2;

            for (int i = 3; i <= num; i++)
            {
                current = pre_pre + pre;
                pre_pre = pre;
                pre = current;
            }

            return current;
        }

        public int Fibonaqi2(int num)
        {
            if (num <= 2)
            {
                return 1;
            }

            return Fibonaqi2(num - 2) + Fibonaqi2(num - 1);
        }