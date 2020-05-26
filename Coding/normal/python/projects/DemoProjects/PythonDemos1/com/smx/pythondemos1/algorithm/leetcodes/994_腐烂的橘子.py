# 56ms ac通过
def orangesRotting(grid):

    minute = 0
    good_flag = 1
    bad_flag = 2
    while True:
        change_flag = False
        has_good_flag = False

        radix = len(grid)
        width = len(grid[0])
        for i in range(radix):
            for j in range(width):
                if grid[i][j] == good_flag:
                    has_good_flag = True
                if grid[i][j] == bad_flag:
                    # 上下左右都要检测
                    # 左边
                    if i-1 >= 0 and grid[i-1][j] == good_flag:
                        grid[i-1][j] = bad_flag + 1
                        change_flag = True
                    # 上边
                    if j-1 >= 0 and grid[i][j-1] == good_flag:
                        grid[i][j-1] = bad_flag + 1
                        change_flag = True
                    # 右边
                    if i + 1 < radix and grid[i+1][j] == good_flag:
                        grid[i + 1][j] = bad_flag + 1
                        change_flag = True
                    # 下边
                    if j + 1 < width and grid[i][j+1] == good_flag:
                        grid[i][j + 1] = bad_flag + 1
                        change_flag = True
        bad_flag += 1

        if not change_flag:
            if has_good_flag:
                minute = -1
            break
        minute += 1

    return minute

li = [[1],[2]]

print(li)
ret = orangesRotting(li)
print(ret)