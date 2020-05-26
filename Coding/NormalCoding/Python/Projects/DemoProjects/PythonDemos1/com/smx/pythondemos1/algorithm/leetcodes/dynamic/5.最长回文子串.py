class Solution:
    def longestPalindrome(self, s: str) -> str:

        return self.violence(s)

    def violence(self, s:str):
        """暴力法求解"""

        max_str = ""
        length = len(s)
        for i in range(length):
            start = i
            for j in range(start, length):
                sub_str = s[start: j + 1]
                if self.is_palindrome(sub_str):
                    if len(sub_str) > len(max_str):
                        max_str = sub_str
        return max_str

    def dp_method(self, s:str):
        """
        使用动态规划求解
        f(i, j)表示 从 索引i 到 索引 j 的字符串是否是回文字符串 true代表是回文字符串 false代表不是回文字符串

        """

        max_str = ""
        length = len(s)
        dp = [[False] * length for _ in range(length)]
        for i in range(length):
            for j in range(length):
                if i == j:
                    dp[i][j] = True
                    max_str = s[i]
        for gap in range(1, length):
            for i in range(0, length - gap):
                start = i
                end = i + gap
                sub_str = s[start: end + 1]
                if start == end:
                    dp[start][end] = True
                elif start + 1 > end - 1:
                    dp[start][end] = s[start] == s[end]
                else:
                    dp[start][end] = dp[start+1][end-1] and (s[start] == s[end])

                if dp[start][end]:
                    if len(sub_str) > len(max_str):
                        max_str = sub_str
        return max_str


    def is_palindrome(self, s:str):
        if not s:
            return False
        return s == s[::-1]

s = Solution()
print(s.dp_method("babad"))


# print("yes")