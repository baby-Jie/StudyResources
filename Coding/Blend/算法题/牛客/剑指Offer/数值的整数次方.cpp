/*
给定一个double类型的浮点数base和int类型的整数exponent。求base的exponent次方。
*/

class Solution {
public:
    double Power(double base, int exponent) {
    double ret = 1;
        int flag = 1;
        if (exponent == 0)
        {
            return 1;
        }
        else if (exponent < 1)
        {
            flag = 0;
            exponent = -1 * exponent;
        }
        for (int i = 0; i < exponent; i++)
        {
            ret *= base;
        }
        if (!flag)
        {
            ret = 1 / ret;
        }
        return ret;
    }
};