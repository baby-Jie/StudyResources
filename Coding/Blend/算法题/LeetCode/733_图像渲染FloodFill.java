/**
 * 733. 图像渲染
 * 方法一：
 * 执行用时：7ms
 * 内存消耗：41.9mb
 * 
 */

class Solution {
    public int[][] inputImage;
    public int newColor;
    public int oldColor;
    public  int[][] direction = new int[][]{{0, -1}, {0, 1}, {-1, 0}, {1, 0}}; // 上下左右
    
    public int[][] floodFill(int[][] image, int sr, int sc, int newColor) {
        inputImage = image;
        this.newColor = newColor;
        oldColor = image[sr][sc];
        System.out.println(oldColor);

        dfs(sr, sc);
        return inputImage;
    }
    
     public void dfs(int x, int y)
    {
        if (x < 0 || y < 0 || x >= inputImage.length || y >= inputImage[0].length)
        {
            return;
        }
        if (inputImage[x][y] != oldColor)
        {
            return;
        }
         if (inputImage[x][y] == newColor)
         {
             return;
         }
           // 修改
        inputImage[x][y] = newColor;
        int newX = x;
        int newY = y;
        // 上
        newX = x + direction[0][0];
        newY = y + direction[0][1];
        dfs(newX, newY);

        // 下
        newX = x + direction[1][0];
        newY = y + direction[1][1];
        dfs(newX, newY);

        // 左
        newX = x + direction[2][0];
        newY = y + direction[2][1];
        dfs(newX, newY);

        // 右
        newX = x + direction[3][0];
        newY = y + direction[3][1];
        dfs(newX, newY);

    }
}