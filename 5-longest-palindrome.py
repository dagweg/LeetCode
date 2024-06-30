from collections import Counter

class Solution:
    def longestPalindrome(self, s: str) -> int:

        n = len(s)

        chars_count = {} 
        odd_chars = set()

        for c in s:
            if c in chars_count:
                chars_count[c] += 1
            else:
                chars_count[c] = 1

        longest = 0

        for v in chars_count.values():
            if v % 2: 
                odd_chars.add(v)
            longest += v // 2 * 2

        if odd_chars:
            longest += 1

        return longest
