class Solution:
    
    def longestPalindrome(self, s: str) -> str:
        n = len(s)
        ll = 1 # Longest Length
        ls = s[0] # Longest string
        def expand(s,left,right):
            nonlocal ls,ll,n
            while 0 <= left < right < n and s[left] == s[right]:
                if right - left + 1 > ll:
                    ls = s[left:right+1]
                    ll = right - left + 1
                left -= 1
                right += 1        
        for i in range(n):
            expand(s,i-1,i+1)
            expand(s,i,i+1)
        return ls
