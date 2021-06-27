class Solution:
    def maxProfit(self, prices) -> int:
        if not prices:
            return 0
        max_profit = 0
        in_price = prices[0]
        for index in range(1, len(prices)):
            if prices[index] < in_price:
                in_price = prices[index]
            elif prices[index] > in_price:
                max_profit = max(max_profit, prices[index] - in_price)
        return max_profit


s = Solution()
ret = s.maxProfit([7, 6, 4, 3, 1])
print(ret)
