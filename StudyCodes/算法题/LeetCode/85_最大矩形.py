# 85. 最大矩形  使用定点法  执行用时：2092ms 内存消耗：14.7mb
class Solution:
    def maximalRectangle(self, matrix: List[List[str]]) -> int:
        height = len(matrix)
        if height == 0:
            return 0
        width = len(matrix[0])

        max_len = 0
        for ii in range(height):
            for jj in range(width):
                ret = self.getMatrixArea(matrix, ii, jj)
                if ret > max_len:
                    max_len = ret
        return max_len
    
    def getMatrixArea(self, matrix: List[List[str]], top:int, left:int):
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