class Solution:
    def findPeaks(self, mountain: List[int]) -> List[int]:
        peaks = []
        N = len(mountain)
        for i in range(1,N-1):
            if mountain[i-1] < mountain[i] and mountain[i] > mountain[i+1]:
                peaks.append(i)
        return peaks
