from itertools import permutations

def getPermutations(li:list):
    retLists = []
    for i in range(1, len(li) + 1):
        retLists += permutations(li, i)
    return retLists

print(getPermutations([1, 2 ,3]))