class Solution:
    def reverseBits(self, n: int) -> int:
        bstr = format(n,'b').zfill(32)
        ans = 0
        for i in range(len(bstr)):
            if bstr[i] == '1':
                ans += 2 ** i
        return ans
        
