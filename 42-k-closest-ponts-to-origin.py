import heapq

class Solution:
    def kClosest(self, points: List[List[int]], k: int) -> List[List[int]]:
        kcl = [[x**2+y**2,x,y] for x,y in points]
        heapq.heapify(kcl)
        kclp = []
        for i in range(k):
            kclp += [heapq.heappop(kcl)[1:]]
        return kclp
