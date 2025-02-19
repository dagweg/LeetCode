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
    public int KthSmallest(TreeNode root, int k) {
        int result = 0;

        int? dfs(TreeNode node, int cnt){
            if(node == null) return cnt + 1;

            var leftCount = dfs(node.left, cnt);
            
            if(leftCount == null) return null; // sc
            
            if(leftCount == k) {
                result = node.val;
                return null; // sc
            }
            var rightCount = dfs(node.right, leftCount ?? cnt);

            if(rightCount == null) return null; // sc
            
            return rightCount;
        }

        dfs(root, 0);
        return result;
    }
}
