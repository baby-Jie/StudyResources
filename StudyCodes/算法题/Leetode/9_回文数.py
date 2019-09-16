class Solution:
    def isPalindrome(self, x: int) -> bool:
        str1 = str(x)
        return str1 == str1[::-1]
        