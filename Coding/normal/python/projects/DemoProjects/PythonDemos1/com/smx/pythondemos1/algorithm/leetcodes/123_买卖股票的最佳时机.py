class Solution:
    def maxProfit(self, prices) -> int:
        if len(prices) == 0:
            return 0

        def getSegments():
            li = []
            start = prices[0]
            end = start
            for index in range(1, len(prices)):
                price = prices[index]

                if price < end:
                    if start < end:
                        li.append((start, end))
                    start = price
                    end = price
                elif price > end:
                    end = price
                    if index == len(prices) - 1:
                        if start < end:
                            li.append((start, end))
            return li

        max_profit = 0
        li = getSegments()
        print(li)
        for index in range(len(li)):
            first = li[index]
            first_sum = first[1] - first[0]
            remained_list = []
            for item in li[index+1:]:
                remained_list.append(item[0])
                remained_list.append(item[1])
            ret = self.maxProfit1(remained_list)
            max_profit = max(max_profit, first_sum + ret)
        return max_profit

    def maxProfit1(self, prices) -> int:
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
print(s.maxProfit([3, 3, 5, 0, 0, 3, 1, 4]))
