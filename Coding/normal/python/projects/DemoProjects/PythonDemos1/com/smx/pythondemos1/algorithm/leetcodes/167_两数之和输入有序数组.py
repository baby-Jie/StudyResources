class Solution:
    def twoSum(self, numbers, target: int):

        if not numbers:
            return []

        dic = {}
        for index in range(len(numbers)):
            item = numbers[index]
            mod = target - item
            if mod in dic.keys():
                modIndex = dic[mod]
                return [modIndex+1, index+1]
            else:
                dic[item] = index
        return []