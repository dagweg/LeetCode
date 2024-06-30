# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right
class Solution:
    def sortedArrayToBST(self, nums: List[int]) -> Optional[TreeNode]:
        def dac(arr, l, r):
            if r < l: return None
            mid = (r + l) // 2
            new_node = TreeNode(arr[mid])
            new_node.left = dac(arr, l, mid - 1)
            new_node.right = dac(arr, mid + 1, r)
            return new_node

        return dac(nums, 0, len(nums) - 1)
        


        
