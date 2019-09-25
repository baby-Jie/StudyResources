/**
 * 62_不同路径 执行用时：5ms 内存消耗：34.5mb
 */

import javafx.util.Pair;
import java.util.HashMap;
import java.util.Map;
class Solution {
    public Map<Pair<Integer, Integer>, Integer> _map = new HashMap<>();
    public int uniquePaths(int m, int n) {
         if (m == 1 || n == 1)
            return 1;
        Pair<Integer, Integer> key = new Pair<>(m, n);
        if (_map.containsKey(key))
        {
            return _map.get(key);
        }
        int ret = uniquePaths(m-1, n) + uniquePaths(m, n-1);
        _map.put(key, ret);
        return ret;
    }
}