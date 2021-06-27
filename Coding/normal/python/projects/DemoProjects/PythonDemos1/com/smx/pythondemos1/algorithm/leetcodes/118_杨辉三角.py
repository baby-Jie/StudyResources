class Solution:
    def generate(self, numRows: int):

        numRows = numRows + 1
        ret = []
        li = [1]
        ret.append(li)
        for _ in range(1, numRows):
            temp_li = []
            for index in range(len(li)):
                if index == 0:
                    temp_li.append(li[index])
                else:
                    temp_li.append(li[index-1] + li[index])

                if index == len(li) - 1:
                    temp_li.append(li[index])
            li = temp_li
            ret.append(li)
        return ret[numRows - 1]

s = Solution()
ret = s.generate(3)
print(ret)