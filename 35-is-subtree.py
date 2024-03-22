# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right
class Solution:
    def isSubtree(self, root: Optional[TreeNode], subRoot: Optional[TreeNode]) -> bool:
        
        def ist(root,subRoot):
            if not root and not subRoot: return True
            if not root or not subRoot or root.val != subRoot.val: return False
            
            return ist(root.left,subRoot.left) and ist(root.right,subRoot.right)

        def dfs(root,subRoot):
            if not root: return False
            return ist(root,subRoot) or dfs(root.left,subRoot) or dfs(root.right,subRoot)
        
        return dfs(root,subRoot)
