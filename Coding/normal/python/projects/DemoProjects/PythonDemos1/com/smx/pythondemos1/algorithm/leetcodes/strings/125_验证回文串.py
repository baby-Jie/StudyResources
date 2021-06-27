class Solution:
    def isPalindrome(self, s: str) -> bool:

        s = s.lower()
        temp = ""
        for item in s:
            if item.isalnum():
                temp = temp + item
        return temp == temp[::-1]

s = Solution()
print(s.isPalindrome("race a car"))