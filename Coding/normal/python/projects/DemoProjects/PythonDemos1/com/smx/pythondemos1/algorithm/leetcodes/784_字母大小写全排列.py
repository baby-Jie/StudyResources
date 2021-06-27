class Solution:
    def letterCasePermutation(self, S: str):

        s = set()
        s1 = ""

        def get(index):
            nonlocal  s1
            if index >= len(S):
                s.add(s1)
                return
            item = S[index]
            if item.isalpha():
                # upper
                s1 += item.upper()
                get(index + 1)
                s1 = s1[:-1]

                # low
                s1 += item.lower()
                get(index + 1)
                s1 = s1[:-1]
            else:
                s1 += item
                get(index + 1)
                s1 = s1[:-1]
        get(0)
        return [i for i in s]

s = Solution()

print(s.letterCasePermutation("C"))