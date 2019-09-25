/**
 * 63 不同路径2 
 * 耗时：6ms、内存消耗：39.3mb
 */

import javafx.util.Pair;
import java.util.HashMap;
import java.util.Map;

class Solution {
       public Map<Pair<Integer, Integer>, Integer> _map = new HashMap<>();
    public int uniquePathsWithObstacles(int[][] obstacleGrid) {
       if (obstacleGrid[0][0] == 1)
            return 0;
        int m = obstacleGrid.length;
        int n = obstacleGrid[0].length;

        _map.put(new Pair<>(1, 1), 1);
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j  < n; j++)
            {
                if (obstacleGrid[i][j] == 1)
                {
                    _map.put(new Pair<>(i+1, j+1), 0);
                }
            }
        }

        return getNums(m, n);
        
    }
    
    public int getNums(int m, int n)
    {
        Pair<Integer, Integer> key = new Pair<>(m, n);
        if (_map.containsKey(key))
        {
            return _map.get(key);
        }
        int ret = 0;
        if (m > 1)
        {
            ret += getNums(m-1, n);
        }
        if ( n > 1)
        {
            ret += getNums(m, n-1);
        }
        _map.put(key, ret);
        return ret;
    }
}