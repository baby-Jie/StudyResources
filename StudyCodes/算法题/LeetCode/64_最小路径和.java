/**
 * 最小路径和 
 * 执行用时：58ms
 * 内存消耗：41.4mb
 * 
 */
import javafx.util.Pair;
import java.util.HashMap;
import java.util.Map;
class Solution {
    public Map<Pair<Integer, Integer>, Integer> _map = new HashMap<>();

    public int[][] _grid;
    public int minPathSum(int[][] grid) {
        _grid = grid;

        int m = grid.length;
        int n = grid[0].length;
        
        _map.put(new Pair<>(1, 1), _grid[0][0]);

        return getMinVal(m, n);
        
    }
     public int getMinVal(int m, int n)
    {
       if (m * n == 1)
        {
            return _grid[0][0];
        }

        Pair<Integer, Integer> key = new Pair<>(m, n);

        if (_map.containsKey(key))
        {
            return _map.get(key);
        }

       int left = 2147483647;
        int top = 2147483647;
        if (m > 1)
        {
            top = getMinVal(m - 1, n);
        }

        if (n > 1)
        {
            left = getMinVal(m, n-1);
        }

        int ret = Math.min(left, top) + _grid[m-1][n-1];

        _map.put(key, ret);

        return ret;
    }
}