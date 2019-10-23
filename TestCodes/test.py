class Solution:
    def maximalRectangle(self, matrix) -> int:
        height = len(matrix)
        width = len(matrix[0])

        max_len = 0
        for ii in range(height):
            for jj in range(width):
                ret = self.getMatrixArea(matrix, ii, jj)
                max_len = max(max_len, ret)
        return max_len
    
    def getMatrixArea(self, matrix, top:int, left:int):
        height = len(matrix)
        width = len(matrix[0])
        if top >= height or left >= width:
            return 0
        max_len = 0
        right = width - 1
        for ii in range(top, height):
            for jj in range(left, right + 1):
                if matrix[ii][jj] == '0':
                    right  = jj - 1
                    ret = (ii - top + 1) * (jj - left)
                    max_len = max(max_len, ret)
                    break
                elif jj == right:
                    ret = ret = (ii - top + 1) * (jj - left + 1)
                    max_len = max(max_len, ret)
        return max_len           

matrix = [["1","0","1","0","0"],["1","0","1","1","1"],["1","1","1","1","1"],["1","0","0","1","0"]]

s = Solution()
ret = s.maximalRectangle(matrix)

print(ret)
