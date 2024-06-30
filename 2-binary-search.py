class Solution:
    def search(self, nums: List[int], target: int) -> int:
        if not nums: return -1

        middle = len(nums)//2

        if nums[middle] > target:
            return self.search(nums[:middle],target)
        elif nums[middle] < target:
            res = self.search(nums[middle+1:],target)
            if not res == -1:
                res += middle + 1
            return res 

        # Found
        return middle
