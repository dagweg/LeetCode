from collections import Counter
class Solution:
    def findErrorNums(self, nums: List[int]) -> List[int]:
        sum_nums = sum(nums)
        dup,n=Counter(nums).most_common(1)[0][0],len(nums) 
        miss = n * (n + 1)// 2 + dup - sum_nums
        return [dup,miss]


                
                
