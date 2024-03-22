class Solution:
    def pancakeSort(self, arr: List[int]) -> List[int]:    
        def findMaxIndex(start,end):
            maxe,maxi = arr[start],start
            for i in range(start+1,end+1):
                if arr[i] > maxe:
                    maxe = arr[i]
                    maxi = i
            return maxi

        answer,sarr = [], sorted(arr)
        N = len(arr)
        si = N - 1

        for i in range(N):
            while sarr[si] == arr[si]:
                si -= 1
                if si < 0: return answer
            mxIndex = findMaxIndex(0,N-i-1)
            if arr[mxIndex] == mxIndex + 1: continue
            answer += [mxIndex+1,N-i]
            arr = arr[:mxIndex+1][::-1] + arr[mxIndex+1:]
            arr = arr[:N-i][::-1] + arr[N-i:]  
        return answer
