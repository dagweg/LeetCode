class Solution:

    def threeSum(self, nums: List[int]) -> List[List[int]]:
        
        nums = sorted(nums)

        N = len(nums)
        ans = []
        for i in range(N):
            if nums[i] > 0:
                break
            if i > 0 and nums[i] == nums[i-1]:
                continue
            
            left,right = i+1,N-1
             
            while left < right:
                s = nums[i] + nums[left] + nums[right]
                if left > i+1 and nums[left] == nums[left-1]:
                    left += 1
                    continue
                if right < N-1 and nums[right] == nums[right+1]:
                    right -= 1
                    continue
                    
                if s < 0:
                    left += 1
                elif s > 0:
                    right -= 1
                else:
                    ans.append([nums[i],nums[left],nums[right]])
                    left += 1
        return ans
