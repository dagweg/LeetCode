public class Solution {
    public int Rob(int[] nums) {
        int N = nums.Length;
        int[] dp = Enumerable.Repeat(-1, N).ToArray();

        int dfs(int i) {
            if (i < 0) return 0;
            if (dp[i] != -1) return dp[i];
            dp[i] = Math.Max(nums[i] + dfs(i - 2), dfs(i - 1));
            return dp[i];
        }

        return dfs(N - 1);
    }
}
