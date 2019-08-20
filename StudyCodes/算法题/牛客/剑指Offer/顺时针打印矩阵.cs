/*
输入一个矩阵，按照从外向里以顺时针的顺序依次打印出每一个数字，例如，如果输入如下4 X 4矩阵： 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 则依次打印出数字1,2,3,4,8,12,16,15,14,13,9,5,6,7,11,10.
 */

 private List<int> TestMethod(int[][] a)
        {
            List<int> retList = new List<int>();
            int row = a.Length;
            int column = a[0].Length;
          

            int startRow = 0;
            int startColumn = 0;
            int endRow = row - 1;
            int endColumn = column - 1;

            while (true)
            {
                if (retList.Count == row * column)
                {
                    break;
                }

                // 打印上横
                for (int i = startColumn; i <= endColumn; i++)
                {
                    retList.Add(a[startRow][i]);
                }

                if (retList.Count == row * column)
                {
                    break;
                }

                // 打印右竖

                for (int i = startRow+1; i <= endRow; i++)
                {
                    retList.Add(a[i][endColumn]);
                }

                if (retList.Count == row * column)
                {
                    break;
                }

                // 打印下横
                for (int i = endColumn - 1; i >= startColumn ; i--)
                {
                    retList.Add(a[endRow][i]);
                }

                if (retList.Count == row * column)
                {
                    break;
                }


                // 打印左竖

                for (int i = endRow - 1; i >= startRow+1; i--)
                {
                    retList.Add(a[i][startColumn]);
                }

                if (retList.Count == row * column)
                {
                    break;
                }

                startRow++;
                startColumn++;
                endRow--;
                endColumn--;
            }

            return retList;

        }