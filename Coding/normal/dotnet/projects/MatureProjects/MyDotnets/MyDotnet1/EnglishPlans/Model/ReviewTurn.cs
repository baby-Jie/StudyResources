using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishPlans.Model
{
    /**
     * 复习轮数枚举
     */
    public enum ReviewTurn
    {
        FIRST = 0, // 1 days
        SECOND, // 3 days
        THIRD,// 7 days
        FOURTH, // 14 days 
        FIFTH, // 21 days
        SIXTH, // 60 days
        SEVENTH, // 365 days
        OVER, // 结束
    }
}
