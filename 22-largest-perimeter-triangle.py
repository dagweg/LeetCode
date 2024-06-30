class Solution:
    def largestPerimeter(self, nums: List[int]) -> int:
        nums = sorted(nums,reverse=True)
        
        largest_perimeter = 0
        left, right = 0, 2

        while right < len(nums):
            if nums[left] < nums[right-1] + nums[right]:
                largest_perimeter = sum(nums[left:right+1])
                break
            left += 1
            right += 1
        return largest_perimeter
