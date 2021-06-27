class Solution:
    def maxProfit(self, prices) -> int:
        if len(prices) == 0:
            return 0
        max_profit = 0
        in_price = prices[0]
        out_price = prices[0]
        ret = []
        for price in prices[1:]:
            if price > out_price:
                out_price = price
                max_profit = max(out_price - in_price, max_profit)
            elif price < out_price:
                ret.append(max_profit)
                in_price = price
                out_price = price
                max_profit = 0
        ret.append(max_profit)
        return sum(ret)

s = Solution()
print(s.maxProfit([1, 2, 3, 4, 5]))
