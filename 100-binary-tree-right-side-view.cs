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
    public IList<int> RightSideView(TreeNode root) {
        var result = new List<int>();
        if(root is null) return result;

        var deq = new LinkedList<TreeNode>();
        deq.AddLast(root);
        

        // do this until the queue is empty
        while(deq.Count > 0){
            var n = deq.Count; // store the current size of the deq (in this level)
            TreeNode lastNonNullInLevel = null;
            for(var i = 0; i < n; i++){
                TreeNode trav = deq.First.Value;
                if(trav is not null) lastNonNullInLevel = trav;
                if(trav.left is not null) deq.AddLast(trav.left);
                if(trav.right is not null) deq.AddLast(trav.right);
                deq.RemoveFirst();
            }
            if(lastNonNullInLevel is not null) result.Add(lastNonNullInLevel.val);
        }

        return result;
    }
}
