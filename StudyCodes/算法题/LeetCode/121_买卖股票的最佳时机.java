/**
 * 执行用时：252ms
 * 内存消耗：38.1mb
 * 
 */
class Solution {
    public int maxProfit(int[] prices) {
        int maxPrice = 0;
        for (int i = 0; i < prices.length - 1; i++)
        {
            for (int j = i + 1; j < prices.length; j++)
            {
                maxPrice = Math.max(maxPrice, prices[j] - prices[i]);
            }
        }
        return maxPrice;
    }
}

/**
 * 方法二：
 */