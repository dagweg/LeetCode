# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right
class Solution:
    def isBalanced(self, root: Optional[TreeNode]) -> bool:
        
        def checkBalanced(root):
            if root == None:
                return [0,True]
            
            left = checkBalanced(root.left)
            right = checkBalanced(root.right)
            height = max(left[0],right[0])

            if left[1] == False or \
               right[1] == False or \
               abs(left[0] - right[0]) > 1:
                return [height,False]

            return [height+1, True]

        return checkBalanced(root)[1]

            
