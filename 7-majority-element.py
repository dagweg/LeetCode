from collections import Counter

class Solution:
    def majorityElement(self, nums: List[int]) -> int:
        return max(list(Counter(nums).items()), key=lambda x: x[1])[0]
