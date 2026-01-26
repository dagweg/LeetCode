class Solution:
    def smallerNumbersThanCurrent(self, nums: List[int]) -> List[int]:
        pairs = sorted([[x,i] for i,x in enumerate(nums)])
        N = len(pairs)
        ans,ret=[0] * N,[0] * N
        for i in range(1, N):            
            if pairs[i-1][0] == pairs[i][0]:
                ans[i] = ans[i-1]
            else:
                ans[i] = i
            ret[pairs[i][1]]=ans[i]
        ret[pairs[0][1]]=ans[0]
        return ret
