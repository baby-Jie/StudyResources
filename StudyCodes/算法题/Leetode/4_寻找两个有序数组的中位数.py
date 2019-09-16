# 方法一： 执行用时：136ms 内存消耗：14.1mb  使用系统的排序方法
class Solution:
    def findMedianSortedArrays(self, nums1: List[int], nums2: List[int]) -> float:
        nums1 += nums2
        nums1.sort()
        length = len(nums1)
        if length % 2 == 0:
            index = length // 2
            return (nums1[index] + nums1[index-1]) / 2.0
        else:
            return nums1[length // 2] * 1.0
        
# 方法二：执行用时：136ms 内存消耗：14.1mb 归并两个有序序列
class Solution:
    def findMedianSortedArrays(self, nums1: List[int], nums2: List[int]) -> float:
        li = []
        len1 = len(nums1)
        len2 = len(nums2)
        i, j = 0, 0
        while i < len1 and j < len2:
            if nums1[i] <= nums2[j]:
                li.append(nums1[i])
                i += 1
            else:
                li.append(nums2[j])
                j += 1
        while i < len1:
            li.append(nums1[i])
            i += 1
        while j < len2:
            li.append(nums2[j])
            j += 1
        length = len(li)
        if length % 2 == 0:
            index = length // 2
            return (li[index] + li[index-1]) / 2.0
        else:
            return li[length // 2] * 1.0

# 方法三：执行用时：212ms 内存消耗：14.1Mb 使用系统的heapq的merge函数
import heapq
class Solution:
    def findMedianSortedArrays(self, nums1: List[int], nums2: List[int]) -> float:
        len1 = len(nums1)
        len2 = len(nums2)
        if len1 == 0:
            minVal = nums2[0]
        elif len2 == 0:
            minVal = nums1[0]
        else:
            minVal = min(nums1[0], nums2[0])
        differLen = abs(len1-len2)
        for i in range(differLen):
            if len1 < len2:
                nums1.insert(0, minVal)
            else:
                nums2.insert(0, minVal)
        li = list(heapq.merge(nums1, nums2))
        li = li[differLen::]
        length = len(li)
        if length % 2 == 0:
            index = length // 2
            return (li[index] + li[index-1]) / 2.0
        else:
            return li[length // 2] * 1.0