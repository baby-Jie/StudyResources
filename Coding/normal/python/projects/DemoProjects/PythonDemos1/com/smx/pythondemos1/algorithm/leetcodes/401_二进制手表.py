class Solution:
    def readBinaryWatch(self, num: int):

        li = []
        one_num = 0
        s = ""

        def inner(index):
            nonlocal s
            nonlocal one_num
            if index >= 10:
                if one_num == num:
                    k = eval("0b" + s)
                    k1 = k >> 6
                    k2 = k & 0b111111
                    if k1 <= 11 and k2 <= 59:
                        li.append(k)
                return
            if one_num < num:
                # select
                one_num += 1
                s += '1'
                inner(index + 1)
                one_num -= 1
                s = s[:-1]

            # unselect
            s += '0'
            inner(index + 1)
            s = s[:-1]
        inner(0)

        ret = []
        def get(k):
            k1 = k >> 6
            k2 = k & 0b111111
            return (k1, k2)
        for item in li:
            k1, k2 = get(item)
            ret.append("{}:{:0>2d}".format(k1, k2))
        return ret


s = Solution()

s.readBinaryWatch(1)
