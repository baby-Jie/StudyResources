li = [3, 7, 6, 5, 1, 9, 8, 0, 2, 4]

def mergeSort(li1:[]):
    if len(li1) <= 1:
        return li1
    middleIndex = len(li1) // 2
    leftLi = mergeSort(li1[0:middleIndex])
    rightLi = mergeSort(li1[middleIndex:])
    return merge(leftLi, rightLi)

def merge(li1:[], li2:[]):
    retLi = []
    len1 = len(li1)
    len2 = len(li2)
    i, j = 0, 0
    while i < len1 and j < len2:
        if li1[i] <= li2[j]:
            retLi.append(li1[i])
            i += 1
        else:
            retLi.append(li2[j])
            j += 1
    while i < len1:
        retLi.append(li1[i])
        i += 1
    while j < len2:
        retLi.append(li2[j])
        j += 1
    return retLi
li = mergeSort(li)
print(li)