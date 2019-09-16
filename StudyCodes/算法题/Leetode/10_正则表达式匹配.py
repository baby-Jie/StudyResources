# 方法一：执行耗时：100ms  内存耗时：13.9mb

import re
class Solution:
    def isMatch(self, s: str, p: str) -> bool:
        p += "$"
        return re.match(p, s)