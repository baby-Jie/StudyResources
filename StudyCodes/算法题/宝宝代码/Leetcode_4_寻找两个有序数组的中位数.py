class Solution:
    def findMedianSortedArrays(self, nums1: List[int], nums2: List[int]) -> float:
        import heapq as n
        n.heapify(nums1)
        n.heapify(nums2)
        res=[]
        for c in n.merge(nums1,nums2):
            res.append(c)

        if len(res)%2==0:
            mid1=res[int(len(res)/2)-1]
            mid2 = res[int(len(res)/2)]
            result=(mid1+mid2)/2
        else:
            result=float(res[len(res)//2])
        return result