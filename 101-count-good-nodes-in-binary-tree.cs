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
    public int GoodNodes(TreeNode root) {
        int count = 0;

        void dfs(TreeNode node, int maxP){
            if(node == null) return;

            int maxC = maxP;
            if(maxP <= node.val) {
                maxC = Math.Max(maxP, node.val);
                count += 1;
            }            
            dfs(node.left, maxC);
            dfs(node.right, maxC);
        }

        dfs(root, root.val);

        return count;
    }
}
