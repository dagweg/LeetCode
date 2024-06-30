class Solution:
    def maxScoreIndices(self, nums: List[int]) -> List[int]:
        zero_count = 0
        one_count = sum(num for num in nums if num == 1)
        N = len(nums)
        max_count = 0 
        indices = []
        for i in range(N+1):
            if max_count < zero_count + one_count:
                max_count = zero_count + one_count
                indices = [i]
            elif max_count == zero_count + one_count:
                indices += [i]
            if i == N : continue
            zero_count += 0 if nums[i] else 1
            one_count += -1 if nums[i] else 0
        return indices
