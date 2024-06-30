class Solution:
    def climbStairs(self, n: int) -> int:
        a , b = 0 , 1
        ret = 0
        for i in range(n):
            ret = a + b
            a = b
            b = ret
        return ret
