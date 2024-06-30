class Solution:
    def sortedSquares(self, nums: List[int]) -> List[int]:
        nums = [num ** 2 for num in nums]
        mi = nums.index(min(nums))
        N = len(nums)
        l = mi - 1
        r = mi + 1
        ans = [nums[mi]]
        while l >= 0 and r < N:
            if nums[l] < nums[r]:
                ans += [nums[l]]
                l -= 1
            else:
                ans += [nums[r]]
                r += 1
        while l >= 0:
            ans += [nums[l]]
            l -= 1
        while r < N:
            ans += [nums[r]]
            r += 1
        return ans

