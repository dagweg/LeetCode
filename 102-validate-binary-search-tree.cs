/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public bool IsValidBST(TreeNode root) {
        
        bool dfs(TreeNode node, long min, long max){
            if(node == null) return true;

            if(min >= node.val || node.val >= max) 
                return false;

            return dfs(node.left, min, node.val) && 
                   dfs(node.right, node.val, max);
        }

        return dfs(root, long.MinValue, long.MaxValue);
    }
}
