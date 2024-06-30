class Solution:
    def climbStairs(self, n: int) -> int:
        memo = {}
        def climb(m):
            if m in memo: return memo[m]
            if m == n:
                return 1
            if m > n: 
                return 0
            memo[m] = climb(m+1) + climb(m+2)
            return memo[m]
        return climb(0)
