class Solution:
    def countSquares(self, matrix) -> int:

        ret_count = 0
        row_count = len(matrix)
        for i in range(0, row_count):
            column_count = len(matrix[i])
            for j in range(0, column_count):
                if not matrix[i][j]:
                    continue
                print("startX:" + str(i) + ", startY:" + str(j))
                ret_count += 1 # 本身就是一个边长为1的正方形
                start_x, start_y = i, j
                max_len = min(row_count - start_x - 1, column_count - start_y - 1) # 能够加上的最大长度
                for k in range(1, max_len + 1):
                    end_x, end_y = start_x + k, start_y + k
                    if not matrix[end_x][end_y]:
                        break
                    # 判断下册是否都为1
                    flag = True
                    for l in range(start_y, end_y):
                        if not matrix[end_x][l]:
                            flag = False
                            break
                    if not flag:
                        break
                    # 判断右侧是否都为1
                    for l in range(start_x, end_x):
                        if not matrix[l][end_y]:
                            flag = False
                            break
                    if flag:
                        ret_count += 1
                        print("startX:" + str(i) + ", startY:" + str(j) + "\tendX:" + str(end_x) + ",endY:" + str(end_y))
                    else:
                        break


        return ret_count

s = Solution()
matrix =[[0,1,1,1],
         [1,1,0,1],
         [1,1,1,1],
         [1,0,1,0]]
print(s.countSquares(matrix))