# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right
class Solution:
    def isSymmetric(self, root: Optional[TreeNode]) -> bool:
        def dfs(left,right):
            if not left and not right: return True
            if (not left and right) or (left and not right): return False
            if left.val != right.val: return False
            
            f = dfs(left.left,right.right)
            s = dfs(left.right,right.left)
            
            return f and s
        return dfs(root.left,root.right) 
                            
