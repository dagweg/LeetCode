class Solution:
    def minimumLength(self, s: str) -> int:
    
        left,right = 0, len(s)-1

        while left < right and s[left] == s[right]:
            chr = s[left]
            while left <= right  and (chr == s[left] or chr == s[right]):
                if chr == s[left]:
                    left += 1
                if chr == s[right]:
                    right -= 1

        return 0 if right < left else right-left+1
