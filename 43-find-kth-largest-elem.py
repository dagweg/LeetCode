class Solution:
    def findKthLargest(self, nums: List[int], k: int) -> int:
        mh = [-n for n in nums]
        heapq.heapify(mh)
        for i in range(k-1):
            heapq.heappop(mh)
        return -heapq.heappop(mh)
