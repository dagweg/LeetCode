class Solution:
    def buildArray(self, target: List[int], n: int) -> List[str]:
        i, j, N, ans = 1, 0, len(target), []
        while i <= n and j < N:
            if i != target[j]:
                ans.extend(("Push","Pop"))
            else:
                j+=1
                ans.append("Push")
            i+=1
        return ans
