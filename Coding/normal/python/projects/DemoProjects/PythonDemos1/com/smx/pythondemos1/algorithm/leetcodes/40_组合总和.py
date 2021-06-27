class Solution:
    def combinationSum2(self, A, K: int):
        s = []
        li = []

        def get(index):
            if index >= len(A):
                return
            item = A[index]
            # select
            li.append(item)
            if sum(li) == K:
                temp_li = [i for i in li]
                temp_li.sort()
                s.append(temp_li)
            get(index + 1)
            li.pop()

            # unselect
            get(index + 1)
        get(0)

        ret = []
        dic1 = {}
        for item in s:
            dic1[str(item)] = item
        for val in dic1.values():
            ret.append(val)

        return ret


s = Solution()


ret = s.combinationSum2([10, 1, 2, 7, 6, 1, 5], 8)

print(ret)




