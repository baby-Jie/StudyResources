class Solution:
    def smallestRangeII(self, A, K: int) -> int:
        li = []
        ret = []

        def get(index):
            if index >= len(A):
                ret.append(max(li) - min(li))
                return
            item = A[index]

            # +
            li.append(item + K)
            get(index + 1)
            li.pop()

            # -
            li.append(item - K)
            get(index + 1)
            li.pop()

        get(0)
        return min(ret)

    def smallest(self, A, K):

        pass

s = Solution()

print(s.smallestRangeII([0, 10], 2))